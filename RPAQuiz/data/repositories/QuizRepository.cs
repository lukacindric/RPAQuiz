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
    public sealed class QuizRepository
    {
        private static readonly Lazy<QuizRepository> lazyInstance = new Lazy<QuizRepository>(() => new QuizRepository());

        private SqlConnection Connection = new SqlConnection
        {
            ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\data\\database\\RPADatabase.mdf;Integrated Security=True"
        };

        public static QuizRepository Instance { get { return lazyInstance.Value; } }

        private QuizRepository() { }

        public  List<Quiz> GetQuizes()
        {
            var quizes = new List<Quiz>();
            Connection.Open();
            SqlCommand command = new SqlCommand(SQLQueries.GetQuizesQuery, Connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int DbId = reader.GetInt32(reader.GetOrdinal("Id"));
                        String DbName = reader.GetString(reader.GetOrdinal("Name"));
                        quizes.Add(new Quiz(DbId, DbName));

                    }
                }
            }
            Connection.Close();
            return quizes;
        }
    }
}
