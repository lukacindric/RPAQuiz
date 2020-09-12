using RPAQuiz.data.models;
using RPAQuiz.data.repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPAQuiz.features.student_quizes_overview.views
{
    public partial class StudentQuizesOverviewScreen : Form
    {
        public StudentQuizesOverviewScreen()
        {
            InitializeComponent();
            string[] columnHeaders = new string[] { "Naziv kviza" };
            var dt = SetColumnsHeaderName(columnHeaders);
            var quizes = QuizRepository.Instance.GetQuizes();
            quizes.ForEach (quiz =>
                dt.Rows.Add(new object[] {quiz.Name})
            );
            QuizesDataGridView.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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
