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
            SetupUI();
            controller.OnCreate();
        }

        public void UpdateDataGridViewSource(DataTable dataTable)
        {
            QuizesDataGridView.DataSource = null;
            QuizesDataGridView.DataSource = dataTable;
            QuizesDataGridView.Columns[2].Visible = false;
        }
        

        public override void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        //UI
        private void SetupUI()
        {
            SetupQuizesDataGridView();
        }

        private void SetupQuizesDataGridView()
        {
            QuizesDataGridView.MultiSelect = false;
        }

        //user actions
        private void BtnViewResults_Click(object sender, EventArgs e)
        {
            controller.OnUserClickedViewQuizResultsButton(GetSelectedQuizId());
        }

        private void BtnTakeQuiz_Click(object sender, EventArgs e)
        {
            controller.onUserClickedTakeQUizButton(GetSelectedQuizId());
        }

        //util
        private int GetSelectedQuizId()
        {
            var selectedRow = QuizesDataGridView.SelectedCells[0].OwningRow;
            string quizId = (string)selectedRow.Cells[2].Value;
            return Int32.Parse(quizId);
        }
    }
}
