using RPAQuiz.common;
using RPAQuiz.common.constants;
using RPAQuiz.common.delegates;
using RPAQuiz.data.models;
using RPAQuiz.data.repositories;
using RPAQuiz.features.teacher_create_quiz.views;
using RPAQuiz.features.teacher_edit_quiz.views;
using RPAQuiz.features.teacher_quiz_result.views;
using RPAQuiz.features.teacher_quizes_overview.views;
using System.Collections.Generic;
using System.Data;
using System.Resources;

namespace RPAQuiz.features.teacher_quizes_overview.controllers
{
    public class TeacherQuizesOverviewController : BaseController, QuizCreatedDelegate, QuizUpdatedDelegate
    {
        private readonly TeacherQuizesOverviewScreen View;

        private List<Quiz> viewModels = new List<Quiz>();

        private readonly ResourceManager resourceManager = new ResourceManager(typeof(TeacherQuizesOverviewScreen));

        public TeacherQuizesOverviewController(TeacherQuizesOverviewScreen view) : base(view)
        {
            this.View = view;
        }

        public void OnCreate()
        {
            string[] columnHeaders = new string[] {resourceManager.GetString(StringKeys.TeacherQuizesOverviewTableHeaderName),"Quiz_Id"};
            var dataTable = SetColumnsHeaderName(columnHeaders);
            var quizes = QuizRepository.Instance.GetQuizes();
            foreach (Quiz quiz in quizes)
            { 
                dataTable.Rows.Add(new object[] { quiz.Name, quiz.Id });
            };
            View.UpdateDataGridViewSource(dataTable);

        }

        public void OnUserClickedViewQuizResultsButton(int quizId, string quizName)
        {
            var form = new TeacherQuizResultScreen(quizId, quizName);
            form.Show();
        }

        public void OnUserClickedCreateQuizButton()
        {
            var form = new TeacherCreateQuizScreen(this);
            form.Show();
        }

        public void OnUserClickedEditQuizButton(int quizId, string quizName)
        {
            var form = new TeacherEditQuizScreen(quizId, quizName, this);
            form.Show();
        }

        public void OnUserClickedDeleteQuizButton()
        {
            View.ShowConfirmQuizDeleteDialog();
        }

        public void OnUserConfirmedDeleteQuiz(int quizId)
        {
            var successfulDelete = QuizRepository.Instance.DeleteQuiz(quizId);
            if (successfulDelete)
            {
                OnCreate();
                View.ShowMessage(resourceManager.GetString(StringKeys.TeacherQuizesOverviewDeleteQuizSuccessMessage));
            } else
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.TeacherQuizesOverviewDeleteQuizErrorMessage));
            }
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

        //delegate
        public void OnQuizCreated()
        {
            OnCreate();
        }

        public void OnQuizUpdated()
        {
            OnCreate();
        }
    }
}
