using RPAQuiz.common;
using RPAQuiz.common.constants;
using RPAQuiz.data.models;
using RPAQuiz.data.repositories;
using RPAQuiz.features.teacher_quizes_overview.views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.features.teacher_quizes_overview.controllers
{
    public class TeacherQuizesOverviewController : BaseController
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
          
        }

        public void OnUserClickedCreateQuizButton()
        {
           
        }

        public void OnUserClickedEditQuizButton(int quizId, string quizName)
        {

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

    }
}
