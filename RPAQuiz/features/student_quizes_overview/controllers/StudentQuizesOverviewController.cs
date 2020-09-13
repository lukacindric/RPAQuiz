using RPAQuiz.common;
using RPAQuiz.common.constants;
using RPAQuiz.data.repositories;
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

        private readonly ResourceManager resourceManager = new ResourceManager(typeof(StudentQuizesOverviewScreen));

        public StudentQuizesOverviewController(StudentQuizesOverviewScreen view) : base(view)
        {
            this.View = view;
        }

        public void OnCreate()
        {
            string[] columnHeaders = new string[] { resourceManager.GetString(StringKeys.StudentQuizesOverviewTableHeaderQuizName),
            resourceManager.GetString(StringKeys.StudentQUizesOverviewTableHeaderMyResult)};
            var dataTable = SetColumnsHeaderName(columnHeaders);
            var quizes = QuizRepository.Instance.GetQuizes();
            quizes.ForEach(quiz =>
               dataTable.Rows.Add(new object[] { quiz.Name, "Bla" })
            );

            View.UpdateDataGridViewSource(dataTable);

            QuizRepository.Instance.GetBla();
        }


        public DataTable SetColumnsHeaderName(string[] ColumnNames)
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
