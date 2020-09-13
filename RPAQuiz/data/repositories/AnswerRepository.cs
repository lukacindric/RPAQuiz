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
    public sealed class AnswerRepository
    {
        private static readonly Lazy<AnswerRepository> lazyInstance = new Lazy<AnswerRepository>(() => new AnswerRepository());

        private SqlConnection Connection = new SqlConnection
        {
            ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\data\\database\\RPADatabase.mdf;Integrated Security=True"
        };

        public static AnswerRepository Instance { get { return lazyInstance.Value; } }

        private AnswerRepository() { }

        public List<Answer> GetAnswersInQuiz(List<Question> questions)
        {
            var answers = new List<Answer>();
            Connection.Open();
            SqlCommand command = new SqlCommand(SQLQueries.GetAnswersForQuiz, Connection);
            command.CommandText = command.CommandText.Replace(SQLParameters.MultipleQuestionIds, string.Join(",", questions.Select(q => q.Id.ToString())));
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                         int DbId = reader.GetInt32(reader.GetOrdinal(SQLColumns.Id));
                        string DbText = reader.GetString(reader.GetOrdinal(SQLColumns.Text));
                        int DbQuestionId = reader.GetInt32(reader.GetOrdinal(SQLColumns.QuestionId));
                        bool DbIsCorrectAnswer = reader.GetBoolean(reader.GetOrdinal(SQLColumns.IsCorrectAnswer));
                        answers.Add(new Answer(DbId, DbText, DbQuestionId, DbIsCorrectAnswer));
                    }
                }
            }
            Connection.Close();
            return answers;
        }

        public List<UserAnswer> GetUserAnswersInQuiz (int userId, int quizId)
        {
            var answers = new List<UserAnswer>();
            Connection.Open();
            SqlCommand command = new SqlCommand(SQLQueries.GetUserAnswersInQuiz, Connection);
            command.Parameters.Add(SQLParameters.QuizId, System.Data.SqlDbType.Int);
            command.Parameters[SQLParameters.QuizId].Value = quizId;
            command.Parameters.Add(SQLParameters.UserId, System.Data.SqlDbType.Int);
            command.Parameters[SQLParameters.UserId].Value = userId;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int DbId = reader.GetInt32(reader.GetOrdinal(SQLColumns.Id));
                        int DbQuestionId = reader.GetInt32(reader.GetOrdinal(SQLColumns.QuestionId));
                        int DbAnswerId = reader.GetInt32(reader.GetOrdinal(SQLColumns.AnswerId));

                        answers.Add(new UserAnswer(DbId, userId, DbQuestionId, DbAnswerId, quizId));
                    }
                }
            }
            Connection.Close();
            return answers;
        }
    }
}
