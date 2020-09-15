using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.common.constants
{
    class StringKeys
    {
        // SignIn screen
        public const string SignInScreenEmptyFieldsKey = "EmptyFieldsMessage";
        public const string SignInScreenNoUsernameKey = "NoUserWIthThisUsernameMessage";
        public const string SignInScreenWrongPasswordKey = "WrongPasswordMessage";

        //StudentQuizesOverview screen
        public const string StudentQuizesOverviewTableHeaderQuizNameKey = "TableQuizNameColumnHeader";
        public const string StudentQUizesOverviewTableHeaderMyResultKey = "TableMyResultColumnHeader";
        public const string StudentQuizesOverviewTableNoResultKey = "TableUserDidNotTakeTheQuiz";
        public const string StudentQuizesOverviewNoResultsMessageKey = "UserDidNotTakeTheQuizMessage";
        public const string StudentQuizesOverviewQuizTakenMessageKey = "UserAlreadyTookQuizMessage";

        //StudentTakeQuiz screen
        public const string StudentTakeQuizInsertAnswersErrorMessage = "InsertUserAnswersErrorMessage";
        public const string StudentTakeQuizInsertAnswersSuccessMessage = "InsertUserAnswersSuccessMessage";

    }
}
