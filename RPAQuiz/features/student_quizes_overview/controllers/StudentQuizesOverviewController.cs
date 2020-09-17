using RPAQuiz.common;
using RPAQuiz.common.constants;
using RPAQuiz.common.delegates;
using RPAQuiz.data.models;
using RPAQuiz.data.repositories;
using RPAQuiz.features.student_quiz_result.views;
using RPAQuiz.features.student_quizes_overview.view_models;
using RPAQuiz.features.student_quizes_overview.views;
using RPAQuiz.features.student_take_quiz.views;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;

namespace RPAQuiz.features.student_quizes_overview.controllers
{
   public class StudentQuizesOverviewController : BaseController, QuizTakenDelegate
    {
        private readonly StudentQuizesOverviewScreen View;

        private List<StudentQuizesOverviewTableViewModel> viewModels = new List<StudentQuizesOverviewTableViewModel>();

        private readonly ResourceManager resourceManager = new ResourceManager(typeof(StudentQuizesOverviewScreen));

        private int userId;

        public StudentQuizesOverviewController(StudentQuizesOverviewScreen view, int userId) : base(view)
        {
            this.userId = userId;
            this.View = view;
        }

        public void OnCreate()
        {
            string[] columnHeaders = new string[] { resourceManager.GetString(StringKeys.StudentQuizesOverviewTableHeaderQuizNameKey),
            resourceManager.GetString(StringKeys.StudentQUizesOverviewTableHeaderMyResultKey),"Quiz_Id"};
            var dataTable = SetColumnsHeaderName(columnHeaders);
            var quizes = QuizRepository.Instance.GetQuizes();
            viewModels = QuizRepository.Instance.GetQuizesViewModelsForQuizesOverview(userId);
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

        public void OnUserClickedViewQuizResultsButton(int quizId, string quizName)
        {
           if (viewModels.Any(vM=> vM.QuizId == quizId)){
                var form = new StudentQuizResultScreen(userId,quizId, viewModels.Where(vM => vM.QuizId == quizId).ToList()[0].QuizName);
                form.Show();
            } else
            {
                view.ShowMessage(resourceManager.GetString(StringKeys.StudentQuizesOverviewNoResultsMessageKey));
            }
        }

        public void OnUserClickedTakeQuizButton(int quizId, string quizName)
        {
            if (viewModels.Any(vM => vM.QuizId == quizId))
            {
                view.ShowMessage(resourceManager.GetString(StringKeys.StudentQuizesOverviewQuizTakenMessageKey));
            }
            else
            {
                View.Hide();
                var form = new StudentTakeQuizScreen(userId, quizId, quizName, this);
                form.Show();
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

        //delegates
        public void OnQuizTaken()
        {
            OnCreate();
            View.Show();
        }
    }
}
