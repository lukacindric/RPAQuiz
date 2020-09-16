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

        // StudentQuizesOverview screen
        public const string StudentQuizesOverviewTableHeaderQuizNameKey = "TableQuizNameColumnHeader";
        public const string StudentQUizesOverviewTableHeaderMyResultKey = "TableMyResultColumnHeader";
        public const string StudentQuizesOverviewTableNoResultKey = "TableUserDidNotTakeTheQuiz";
        public const string StudentQuizesOverviewNoResultsMessageKey = "UserDidNotTakeTheQuizMessage";
        public const string StudentQuizesOverviewQuizTakenMessageKey = "UserAlreadyTookQuizMessage";

        // StudentTakeQuiz screen
        public const string StudentTakeQuizInsertAnswersErrorMessage = "InsertUserAnswersErrorMessage";
        public const string StudentTakeQuizInsertAnswersSuccessMessage = "InsertUserAnswersSuccessMessage";

        // TeacherQuizesOverview screen
        public const string TeacherQuizesOverviewTableHeaderName = "TableQuizNameColumnHeader";
        public const string TeacherQuizesOverviewDialogYesButton = "DialogYesButton";
        public const string TeacherQuizesOverviewDialogNoButton = "DialogNoButton";
        public const string TeacherQuizesOverviewDialogTitle = "DialogTitle";
        public const string TeacherQuizesOverviewDialogMessage = "DialogMessage";
        public const string TeacherQuizesOverviewDeleteQuizSuccessMessage = "DeleteQuizSuccessMessage";
        public const string TeacherQuizesOverviewDeleteQuizErrorMessage = "DeleteQuizErrorMessage";

        // TeacherQuizResult screen
        public const string TeacherQuizResultTableHeaderUsernameKey = "TableHeaderUsernameKey";
        public const string TeacherQuizResultTableHeaderResultKey = "TableHeaderResultKey";

        // TeacherCreateQuiz screen
        public const string TeacherCreateQuizInputFieldsWarning = "InputFieldsWarning";
        public const string TeacherCreateQuizSuccessMessage = "SuccessMessage";
        public const string TeacherCreateQuizErrorMessage = "ErrorMessage";

        // TeacherEditQuiz screen
        public const string TeacherEditQuizInputFieldsWarning = "InputFieldsWarning";
        public const string TeacherEditQuizSuccessMessage = "SuccessMessage";
        public const string TeacherEditQuizErrorMessage = "ErrorMessage";


    }
}
