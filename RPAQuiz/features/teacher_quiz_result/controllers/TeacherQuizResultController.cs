using RPAQuiz.common;
using RPAQuiz.common.constants;
using RPAQuiz.data.repositories;
using RPAQuiz.features.student_quiz_result.views;
using RPAQuiz.features.teacher_quiz_result.views;
using System.Data;
using System.Resources;

namespace RPAQuiz.features.teacher_quiz_result.controllers
{
    public class TeacherQuizResultController : BaseController
    {
        private readonly TeacherQuizResultScreen View;

        private readonly ResourceManager resourceManager = new ResourceManager(typeof(TeacherQuizResultScreen));

        private int quizId;

        public TeacherQuizResultController(TeacherQuizResultScreen view, int quizId) : base(view)
        {
            this.View = view;
            this.quizId = quizId;
        }

        public void OnCreate()
        {
            string[] columnHeaders = new string[] { resourceManager.GetString(StringKeys.TeacherQuizResultTableHeaderUsernameKey),
            resourceManager.GetString(StringKeys.TeacherQuizResultTableHeaderResultKey),"User_Id"};
            var dataTable = SetColumnsHeaderName(columnHeaders);
            var viewmodels = QuizRepository.Instance.GetQuizResult(quizId);
            viewmodels.ForEach(vM =>
                 dataTable.Rows.Add(new object[] { vM.Username, vM.Result, vM.UserId })
            );
            View.UpdateDataGridViewSource(dataTable);

        }

        public void OnUserClickedViewQuizResultsButton(int userId, string userName)
        {
                var form = new StudentQuizResultScreen(userId,quizId,userName);
                form.Show();
            
        }

        private DataTable SetColumnsHeaderName(string[] ColumnNames)
        {
            DataTable dt = new DataTable();
            foreach (var item in ColumnNames)
            {
                dt.Columns.Add(item);
            }
            return dt;
        }

    }
}
