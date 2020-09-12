using RPAQuiz.common;
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
            string[] columnHeaders = new string[] { "Naziv kviza" };
            var dataTable = SetColumnsHeaderName(columnHeaders);
            var quizes = QuizRepository.Instance.GetQuizes();
            quizes.ForEach(quiz =>
               dataTable.Rows.Add(new object[] { quiz.Name })
            );

            View.UpdateDataGridViewSource(dataTable);
        }


        public DataTable SetColumnsHeaderName(string[] TagName)
        {
            DataTable dt = new DataTable();
            foreach (var item in TagName)
            {
                dt.Columns.Add(item);
            }
            return dt;
        }
    }
}
