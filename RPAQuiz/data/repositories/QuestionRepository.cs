using RPAQuiz.common.constants;
using RPAQuiz.data.models;
using RPAQuiz.features.teacher_create_quiz.viewmodels;
using RPAQuiz.features.teacher_edit_quiz.viewmodels;
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

        //get
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

        //insert
        public bool InsertQuestionAndAnswers(int quizId, TeacherCreateQuizViewmodel model)
        {
            Connection.Open();
            var questionId = InsertQuestion(model.Question);
            if (questionId == -1 || !LinkQuestionAndQuiz(quizId,questionId) || !AnswerRepository.Instance.InsertAnswersForQuestion(questionId, model))
            {
                Connection.Close();
                return false;
            }

            Connection.Close();
            return true;

        }

        public bool InsertQuestionAndAnswers(int quizId, TeacherEditQuizViewmodel model)
        {
            Connection.Open();
            var questionId = InsertQuestion(model.Question.Text);
            if (questionId == -1 || !LinkQuestionAndQuiz(quizId, questionId) || !AnswerRepository.Instance.InsertAnswersForQuestion(questionId, model))
            {
                Connection.Close();
                return false;
            }

            Connection.Close();
            return true;

        }

        private bool LinkQuestionAndQuiz(int quizId, int questionId)
        {
            SqlCommand command = new SqlCommand(SQLQueries.InsertQuizQuestion, Connection);
            command.Parameters.Add(SQLParameters.QuizId, System.Data.SqlDbType.Int);
            command.Parameters[SQLParameters.QuizId].Value = quizId;
            command.Parameters.Add(SQLParameters.QuestionId, System.Data.SqlDbType.Int);
            command.Parameters[SQLParameters.QuestionId].Value = questionId;

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int InsertQuestion(string questionText)
        {
            SqlCommand command = new SqlCommand(SQLQueries.InsertQuestion, Connection);
            command.Parameters.Add(SQLParameters.QuestionText, System.Data.SqlDbType.NVarChar);
            command.Parameters[SQLParameters.QuestionText].Value = questionText;

            try
            {
                var id = (int)command.ExecuteScalar();
                return id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //delete
        public bool DeleteQuestionsFromQuizIfNeeded(int quizId, List<TeacherEditQuizViewmodel> viewModels)
        {
            var questions = GetQuestionsForQuiz(quizId);
            foreach(Question question in questions)
            {
                if (viewModels.FirstOrDefault(vm => vm.Question.Id == question.Id) == null)
                {
                   if(!DeleteQuestion(question.Id)) return false;
                }
            }
            return true;
        }

        private bool DeleteQuestion(int questionId)
        {
            Connection.Open();
            SqlCommand command = new SqlCommand(SQLQueries.DeleteQuestion, Connection);
            command.Parameters.Add(SQLParameters.QuestionId, System.Data.SqlDbType.Int);
            command.Parameters[SQLParameters.QuestionId].Value = questionId;

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Connection.Close();
                return false;
            }
            Connection.Close();
            return true;
        }

        //update

        public bool UpdateQuestionAndAnswer(TeacherEditQuizViewmodel viewmodel)
        {
            if (!UpdateQuestionText(viewmodel.Question.Id, viewmodel.Question.Text)) return false;
            foreach (Answer answer in viewmodel.Answers)
            {
                if (!AnswerRepository.Instance.UpdateAnswer(answer.Id, answer.Text, answer.IsCorrectAnswer)) return false;
            }
            return true;
        }
        private bool UpdateQuestionText(int questionId, string questionText)
        {
            Connection.Open();
            SqlCommand command = new SqlCommand(SQLQueries.UpdateQuestionText, Connection);
            command.Parameters.Add(SQLParameters.QuestionId, System.Data.SqlDbType.Int);
            command.Parameters[SQLParameters.QuestionId].Value = questionId;
            command.Parameters.Add(SQLParameters.QuestionText, System.Data.SqlDbType.NVarChar);
            command.Parameters[SQLParameters.QuestionText].Value = questionText;

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Connection.Close();
                return false;
            }
            Connection.Close();
            return true;
        }

    }
}
