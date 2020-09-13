using RPAQuiz.common;
using RPAQuiz.data.models;
using RPAQuiz.data.repositories;
using RPAQuiz.features.student_quizes_overview.controllers;
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
    public partial class StudentQuizesOverviewScreen : BaseForm
    {

        public override BaseController Controller
        {
            get { return new StudentQuizesOverviewController(this); }
        }

        private readonly StudentQuizesOverviewController controller;

        public StudentQuizesOverviewScreen(): base()
        {
            InitializeComponent();
            this.controller = Controller as StudentQuizesOverviewController;
            controller.OnCreate();
        }

        public void UpdateDataGridViewSource(DataTable dataTable)
        {
            QuizesDataGridView.DataSource = null;
            QuizesDataGridView.DataSource = dataTable;
        }
        

        public override void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
