using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.common.constants
{
    class SQLQueries
    {
        //get
        public const string GetUserWithUsernameQuery = "SELECT * FROM USERS WHERE Username =" + SQLParameters.Username +";";

        public const string GetQuizesQuery = "SELECT * FROM QUIZES ORDER BY Id DESC;";

        public const string GetUserAnswers = "SELECT Answers.IsCorrectAnswer, Quizes.Name, Quizes.Id FROM UserAnswers "+
            " JOIN Answers ON UserAnswers.Answer_Id = Answers.Id JOIN Quizes ON UserAnswers.Quiz_Id = Quizes.id"+" WHERE UserAnswers.User_Id =" + SQLParameters.UserId;

        public const string GetAnswersForQuiz = "SELECT * FROM Answers WHERE Answers.Question_Id IN (" + SQLParameters.MultipleQuestionIds +");";

        public const string GetQuestionsForQuiz = "SELECT Questions.Id, Questions.Text FROM QuizQuestions JOIN Questions ON QuizQuestions.Question_Id = Questions.Id WHERE " +
            "QuizQuestions.Quiz_Id = "+ SQLParameters.QuizId;

        public const string GetUserAnswersInQuiz = "SELECT UserAnswers.Id, UserAnswers.Question_Id, UserAnswers.Answer_Id FROM UserAnswers " +
            "WHERE User_Id=" + SQLParameters.UserId + " AND Quiz_Id =" + SQLParameters.QuizId;

        public const string GetResultsForQuiz = "SELECT Users.Id, Users.Username, Answers.IsCorrectAnswer FROM UserAnswers " +
            "JOIN Answers ON UserAnswers.Answer_Id = Answers.Id JOIN Users ON UserAnswers.User_Id = Users.Id " + "WHERE UserAnswers.Quiz_Id=" + SQLParameters.QuizId;

        //insert
        public const string InsertUserAnswersForQuiz = "INSERT INTO  UserAnswers(User_Id, Question_Id, Answer_Id, Quiz_Id) VALUES " + SQLParameters.MultipleUserAnswers;

        //delete
        public const string DeleteQuiz = "DELETE FROM Quizes WHERE Id =" + SQLParameters.QuizId;
    }
}
