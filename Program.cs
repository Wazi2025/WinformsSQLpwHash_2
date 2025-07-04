﻿using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinformsSQLpwHash_2
{
    public static class Program
    {
        static private readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=true";
        public static string LoggedInUser { get; set; }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm login = new LoginForm();            

            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Mainform());
            }
            
        }

        static private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12); // Work factor defines cost
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }

        public static bool UserPrivileges(string username)
        {
            //Set Mainform controls visibility based on user
            string checkUserQuery = "SELECT username FROM users WHERE username = @user";
            using SqlConnection conn = GetFreshConnection();
            using SqlCommand commandCheck = conn.CreateCommand();
            commandCheck.CommandText = checkUserQuery;
            commandCheck.Parameters.AddWithValue("@user", username);
            object uniqueUser = commandCheck.ExecuteScalar();

            //Check for hardcoded username for now
            if ((uniqueUser is not null) && username.Equals("Wazi"))
                return true;
            else
                return false;
        }

        static public void LogUserLogin(string username, string password, string messageBoxLoginText)
        {
            //log user login attempts in file
            string fileDataDir = "Data";
            string fileName = "log.txt";

            //Set the application path
            string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.FullName;

            string dirPath = Path.Combine(projectRoot, fileDataDir);

            //Combine application path with where the csv file is (\Data\scrubbed.csv)
            //Should eliminate hardcoding of file path as long as it's in the \Data dir with the compiled .exe a level above
            string filePath = Path.Combine(projectRoot, fileDataDir, fileName);
            DateTime dateTime = DateTime.Now;
            string logString = $"{dateTime.ToString()}:  Username:'{username}'  Message:'{messageBoxLoginText}'";

            //Create file and dir if it doesn't exist
            if (!File.Exists(filePath) || !Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                using StreamWriter streamWriter = File.CreateText(filePath);
                streamWriter.WriteLine(logString);
            }
            else //Append to already existing file
            {
                using StreamWriter streamWriter = File.AppendText(filePath);
                streamWriter.WriteLine(logString);                
            }

        }

        static public bool TryLogin(string username, string password)
        {
            using SqlConnection conn = GetFreshConnection();

            string query = "SELECT password_hash FROM users WHERE username = @user";
            using SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@user", username);

            // Get the stored hash        
            object result = command.ExecuteScalar();
            if (result == null || result == DBNull.Value)
                return false;

            string storedHash = result.ToString();

            // Use bcrypt to verify
            return VerifyPassword(password, storedHash);
        }

        static public bool SQLAddUser(string username, string password)
        {
            //Duplicate username check
            string checkDuplicateUserQuery = "SELECT username FROM users WHERE username = @user";
            using SqlConnection conn = GetFreshConnection();

            //Add the 'using' statement to SqlCommand object since it is not guaranteed to be automatically disposed when the SqlConnection it was created from is disposed
            using SqlCommand commandCheck = conn.CreateCommand();
            commandCheck.CommandText = checkDuplicateUserQuery;
            commandCheck.Parameters.AddWithValue("@user", username);
            object uniqueUser = commandCheck.ExecuteScalar();

            //If uniqueUser is null we know there are no duplicate usernames
            if (uniqueUser is null)
            {
                //Apparently using the the same SqlCommand for different parameterized query's can cause things to go pear-shaped
                //To be safe we'll create a new one for the add new user query
                //
                //Again, we add the 'using' statement to SqlCommand object since it is not guaranteed to be automatically disposed when the SqlConnection it was created from is disposed
                using SqlCommand commandInsert = conn.CreateCommand();
                //Hash user's password
                string hashedPassword = HashPassword(password);

                string query = "INSERT INTO users (username, password_hash) VALUES (@newUser, @newUserPw)";

                commandInsert.CommandText = query;
                commandInsert.Parameters.AddWithValue("@newUser", username);
                commandInsert.Parameters.AddWithValue("@newUserPw", hashedPassword);

                //Execute query
                commandInsert.ExecuteNonQuery();
            }

            else if (uniqueUser.ToString().Equals(username))
            {
                return true;
            }
            return false;
        }

        static public void SQLInsert(List<string> data)
        {
            using SqlConnection conn = GetFreshConnection();

            string insertQuery = "INSERT INTO person (first_name, last_name, phone, email, street, city, zip_code, country) VALUES (@f_name, @l_name, @phone, @email, @street, @city, @zip, @country)";

            using SqlCommand command = conn.CreateCommand();
            command.CommandText = insertQuery;

            //Note: Prolly add some sort of validation here
            command.Parameters.AddWithValue("@f_name", data[0]);
            command.Parameters.AddWithValue("@l_name", data[1]);
            command.Parameters.AddWithValue("@phone", data[2]);
            command.Parameters.AddWithValue("@email", data[3]);
            command.Parameters.AddWithValue("@street", data[4]);
            command.Parameters.AddWithValue("@city", data[5]);
            command.Parameters.AddWithValue("@zip", data[6]);
            command.Parameters.AddWithValue("@country", data[7]);

            //Execute query
            command.ExecuteNonQuery();
        }

        static public SqlConnection GetFreshConnection()
        {
            //Set connection string and open DB connection
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        static public DataTable SQLSelect(string whereText)
        {
            //By using the 'using' statement we make sure the DB connection is closed down after each use
            using SqlConnection conn = GetFreshConnection();

            string query;

            //Note: Make sure we’re not building queries with user input directly(e.g., string concatenation), and instead always use parameterized queries like:
            //command.CommandText = "SELECT * FROM person WHERE first_name = @firstName";
            //command.Parameters.AddWithValue("@firstName", userInput);
            //If not, we risk SQL injection
            if (whereText.IsNullOrEmpty())
                query = "SELECT * FROM person";
            else
                query = "SELECT * FROM person WHERE first_name = @firstName";

            using SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@firstName", whereText);

            using SqlDataAdapter da = new SqlDataAdapter(command);
            using DataTable dataTable = new DataTable();
            
                        
            da.Fill(dataTable);

            return dataTable;
        }

    }
}
