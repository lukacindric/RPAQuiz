using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.common.constants
{
    class SQLQueries
    {
        public const string GetUserWithUsernameQuery = "SELECT * FROM USERS WHERE Username =" + SQLParameters.Username +";";
        public const string GetQuizesQuery = "SELECT * FROM QUIZES;";
        public const string GetUserAnswers = "SELECT Answers.IsCorrectAnswer, Quizes.Name FROM UserAnswers "+
            " JOIN Answers ON UserAnswers.Answer_Id = Answers.Id JOIN Quizes ON UserAnswers.Quiz_Id = Quizes.id"+" WHERE UserAnswers.User_Id =" + SQLParameters.UserId;
    }
}
