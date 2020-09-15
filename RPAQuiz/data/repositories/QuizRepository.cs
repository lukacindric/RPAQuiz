using RPAQuiz.common.constants;
using RPAQuiz.data.models;
using RPAQuiz.features.student_quizes_overview.view_models;
using RPAQuiz.features.student_take_quiz.viewmodels;
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
            ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\data\\database\\RPADatabase.mdf;Integrated Security=False"
        };

        public static QuizRepository Instance { get { return lazyInstance.Value; } }

        private QuizRepository() { }

        //get
        public List<Quiz> GetQuizes()
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
                        int DbId = reader.GetInt32(reader.GetOrdinal(SQLColumns.Id));
                        String DbName = reader.GetString(reader.GetOrdinal(SQLColumns.Name));
                        quizes.Add(new Quiz(DbId, DbName));

                    }
                }
            }
            Connection.Close();
            return quizes;
        }

        public List<StudentTakeQuizViewmodel> GetQuizQuestions(int quizId)
        {
            var viewModels = new List<StudentTakeQuizViewmodel>();
            var questionsInQuiz = QuestionRepository.Instance.GetQuestionsForQuiz(quizId);
            var answersInQuiz = AnswerRepository.Instance.GetAnswersInQuiz(questionsInQuiz);
            foreach (Question question in questionsInQuiz)
            {
                var answers = answersInQuiz.Where(a => a.QuestionId == question.Id).ToList();
                viewModels.Add(new StudentTakeQuizViewmodel(question, answers, answers[0]));
            }
            return viewModels;
        }

        public List<StudentQuizesOverviewTableViewModel> GetQuizesViewModelsForQuizesOverview(int userId)
        {
            Connection.Open();
            SqlCommand command = new SqlCommand(SQLQueries.GetUserAnswers, Connection);
            command.Parameters.Add(SQLParameters.UserId, System.Data.SqlDbType.Int);
            command.Parameters[SQLParameters.UserId].Value = userId;
            var quizDictionary = new Dictionary<int, string>();
            var correctAnswersDictionary = new Dictionary<int, int>();
            var wrongAnswersDictionary = new Dictionary<int, int>();
            var studentQuizesOverviewTableViewModels = new List<StudentQuizesOverviewTableViewModel>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bool DbIsCorrectAnswer = reader.GetBoolean(reader.GetOrdinal(SQLColumns.IsCorrectAnswer));
                        string DbQuizName = reader.GetString(reader.GetOrdinal(SQLColumns.Name));
                        int DbQuizId = reader.GetInt32(reader.GetOrdinal(SQLColumns.Id));
                        quizDictionary[DbQuizId] = DbQuizName;
                        if (DbIsCorrectAnswer)
                        {
                            if (correctAnswersDictionary.ContainsKey(DbQuizId))
                                correctAnswersDictionary[DbQuizId] += 1;
                            else
                                correctAnswersDictionary[DbQuizId] = 1;
                        }
                        else
                        {
                            if (wrongAnswersDictionary.ContainsKey(DbQuizId))
                                wrongAnswersDictionary[DbQuizId] += 1;
                            else
                                wrongAnswersDictionary[DbQuizId] = 1;
                        }
                    }
                }
            }
            Connection.Close();
            foreach (KeyValuePair<int, string> quizesPair in quizDictionary)
            {
                var correctAnswers = 0;
                if (correctAnswersDictionary.ContainsKey(quizesPair.Key))
                    correctAnswers = correctAnswersDictionary[quizesPair.Key];
                var wrongAnswers = 0;
                if (wrongAnswersDictionary.ContainsKey(quizesPair.Key))
                    wrongAnswers = wrongAnswersDictionary[quizesPair.Key];
                var viewModel = new StudentQuizesOverviewTableViewModel(quizesPair.Key, quizesPair.Value, correctAnswers + "/" + (correctAnswers + wrongAnswers));
                studentQuizesOverviewTableViewModels.Add(viewModel);
            }
            return studentQuizesOverviewTableViewModels;
        }

        //insert

        public bool InsertUserAnswersForQuiz(List<StudentTakeQuizViewmodel> viewmodels, int userId, int quizId)
        {
            var valuesStringToInsert = "";
            viewmodels.ForEach(vM => valuesStringToInsert = valuesStringToInsert + vM.getStringRepresentationForInsertInDatabase(userId,quizId)+",");
            valuesStringToInsert = valuesStringToInsert.Remove(valuesStringToInsert.Length - 1);
            Connection.Open();
            SqlCommand command = new SqlCommand(SQLQueries.InsertUserAnswersForQuiz, Connection);
            command.CommandText = command.CommandText.Replace(SQLParameters.MultipleUserAnswers, valuesStringToInsert);
            
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Connection.Close();
                    return false;
                }
            Connection.Close();
            return true;
        }
    }
}
