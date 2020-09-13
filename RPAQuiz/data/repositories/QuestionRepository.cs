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
    public sealed class QuestionRepository
    {
        private static readonly Lazy<QuestionRepository> lazyInstance = new Lazy<QuestionRepository>(() => new QuestionRepository());

        private SqlConnection Connection = new SqlConnection
        {
            ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\data\\database\\RPADatabase.mdf;Integrated Security=True"
        };

        public static QuestionRepository Instance { get { return lazyInstance.Value; } }

        private QuestionRepository() { }

        public List<Question> GetQuestionsForQuiz(int quizId)
        {
            var questionsInQuiz = new List<Question>();
            Connection.Open();
            SqlCommand command = new SqlCommand(SQLQueries.GetQuestionsForQuiz, Connection);
            command.Parameters.Add(SQLParameters.QuizId, System.Data.SqlDbType.Int);
            command.Parameters[SQLParameters.QuizId].Value = quizId;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int DbId = reader.GetInt32(reader.GetOrdinal(SQLColumns.Id));
                        String DbText = reader.GetString(reader.GetOrdinal(SQLColumns.Text));
                        questionsInQuiz.Add(new Question(DbId, DbText));
                    }
                }
            }
            Connection.Close();
            return questionsInQuiz;
        }

    }
}
