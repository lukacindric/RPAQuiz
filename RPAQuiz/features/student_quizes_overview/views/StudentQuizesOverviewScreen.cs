using RPAQuiz.common;
using RPAQuiz.features.student_quizes_overview.controllers;
using System;
using System.Data;
using System.Windows.Forms;

namespace RPAQuiz.features.student_quizes_overview.views
{
    public partial class StudentQuizesOverviewScreen : BaseForm
    {

        public override BaseController Controller
        {
            get { return new StudentQuizesOverviewController(this,userId); }
        }

        private readonly StudentQuizesOverviewController controller;
        private int userId;

        public StudentQuizesOverviewScreen(int userId): base()
        {
            InitializeComponent();
            this.userId = userId;
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
            this.Icon = Properties.Resources.efzg_logo;
        }

        private void SetupQuizesDataGridView()
        {
            QuizesDataGridView.MultiSelect = false;
        }

        //user actions
        private void BtnViewResults_Click(object sender, EventArgs e)
        {
            controller.OnUserClickedViewQuizResultsButton(GetSelectedQuizId(), GetSelectedQuizName());
        }

        private void BtnTakeQuiz_Click(object sender, EventArgs e)
        {
            controller.OnUserClickedTakeQuizButton(GetSelectedQuizId(), GetSelectedQuizName());
        }

        //util
        private int GetSelectedQuizId()
        {
            var selectedRow = QuizesDataGridView.SelectedCells[0].OwningRow;
            string quizId = (string)selectedRow.Cells[2].Value;
            return Int32.Parse(quizId);
        }

        private string GetSelectedQuizName()
        {
            var selectedRow = QuizesDataGridView.SelectedCells[0].OwningRow;
            string quizName = (string)selectedRow.Cells[0].Value;
            return quizName;
        }

        private void StudentQuizesOverviewScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
