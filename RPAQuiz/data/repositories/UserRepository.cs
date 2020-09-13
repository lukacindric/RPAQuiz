using RPAQuiz.common.constants;
using RPAQuiz.data.models;
using RPAQuiz.features.student_quiz_result.viewmodels;
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
                        int DbId = reader.GetInt32(reader.GetOrdinal(SQLColumns.Id));
                        String DbUsername = reader.GetString(reader.GetOrdinal(SQLColumns.Username));
                        String DbPassword= reader.GetString(reader.GetOrdinal(SQLColumns.Password));
                        bool DbIsStudent = reader.GetBoolean(reader.GetOrdinal(SQLColumns.IsStudent));
                        Connection.Close();
                        return new User(DbId, DbUsername, DbPassword, DbIsStudent);

                    }
                }
            }
            Connection.Close();
            return null;
        }

        public List<StudentQuizResultViewmodel> GetQuizResultForUser(int userId, int quizId)
        {
            var viewModels = new List<StudentQuizResultViewmodel>();
            var questionsInQuiz = QuestionRepository.Instance.GetQuestionsForQuiz(quizId);
            var answersInQuiz = AnswerRepository.Instance.GetAnswersInQuiz(questionsInQuiz);
            var userAnswers = AnswerRepository.Instance.GetUserAnswersInQuiz(userId, quizId);
            foreach(Question question in questionsInQuiz)
            {
                var answers = answersInQuiz.Where(a => a.QuestionId == question.Id).ToList();
                var userAnswer = userAnswers.Where(a => a.QuestionId == question.Id).ToList()[0];
                var userAnswerInQuiz = answers.Where(a => a.Id == userAnswer.AnswerId).ToList()[0];
                viewModels.Add(new StudentQuizResultViewmodel(question, answers, userAnswerInQuiz));
            }
            return viewModels;
        }
    }
}
