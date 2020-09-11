using RPAQuiz.common.constants;
using RPAQuiz.data.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.data.repositories
{
    public sealed class UserRepository
    {
        private static readonly Lazy<UserRepository> lazyInstance = new Lazy<UserRepository> (() => new UserRepository() );

        private SqlConnection Connection = new SqlConnection
        {
            ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\data\\database\\RPADatabase.mdf;Integrated Security=True"
        };

        public static UserRepository Instance { get { return lazyInstance.Value; } }

        private UserRepository() { }

        public User GetUserWithUserName(String username)
        {
            Connection.Open();
            SqlCommand command = new SqlCommand(SQLQueries.GetUserWithUsernameQuery, Connection);
            command.Parameters.Add(SQLParameters.Username, System.Data.SqlDbType.NVarChar);
            command.Parameters[SQLParameters.Username].Value = username;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String DbUsername = reader.GetString(reader.GetOrdinal("Username"));
                        String DbPassword= reader.GetString(reader.GetOrdinal("Password"));
                        bool DbIsStudent = reader.GetBoolean(reader.GetOrdinal("IsStudent"));
                        Connection.Close();
                        return new User(DbUsername, DbPassword, DbIsStudent);

                    }
                }
            }
            Connection.Close();
            return null;
        }
    }
}
