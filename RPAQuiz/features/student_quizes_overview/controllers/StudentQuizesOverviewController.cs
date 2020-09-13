using RPAQuiz.common;
using RPAQuiz.common.constants;
using RPAQuiz.data.models;
using RPAQuiz.data.repositories;
using RPAQuiz.features.student_quizes_overview.view_models;
using RPAQuiz.features.student_quizes_overview.views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.features.student_quizes_overview.controllers
{
   public class StudentQuizesOverviewController : BaseController
    {
        private readonly StudentQuizesOverviewScreen View;

        private List<StudentQuizesOverviewTableViewModel> viewModels = new List<StudentQuizesOverviewTableViewModel>();

        private readonly ResourceManager resourceManager = new ResourceManager(typeof(StudentQuizesOverviewScreen));

        public StudentQuizesOverviewController(StudentQuizesOverviewScreen view) : base(view)
        {
            this.View = view;
        }

        public void OnCreate()
        {
            string[] columnHeaders = new string[] { resourceManager.GetString(StringKeys.StudentQuizesOverviewTableHeaderQuizNameKey),
            resourceManager.GetString(StringKeys.StudentQUizesOverviewTableHeaderMyResultKey),"Quiz_Id"};
            var dataTable = SetColumnsHeaderName(columnHeaders);
            var quizes = QuizRepository.Instance.GetQuizes();
            viewModels = QuizRepository.Instance.GetQuizesViewModels(1);
            foreach (Quiz quiz in quizes)
            {
                var result = resourceManager.GetString(StringKeys.StudentQuizesOverviewTableNoResultKey);
                foreach (StudentQuizesOverviewTableViewModel viewModel in viewModels)
                {
                    if (viewModel.QuizId == quiz.Id) result = viewModel.UserResult;
                }
                dataTable.Rows.Add(new object[] { quiz.Name, result, quiz.Id });
            };
            View.UpdateDataGridViewSource(dataTable);

        }

        public void OnUserClickedViewQuizResultsButton(int quizId)
        {
           if (viewModels.Any(vM=> vM.QuizId == quizId )){

            } else
            {
                view.ShowMessage(resourceManager.GetString(StringKeys.StudentQuizesOverviewNoResultsMessageKey));
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
