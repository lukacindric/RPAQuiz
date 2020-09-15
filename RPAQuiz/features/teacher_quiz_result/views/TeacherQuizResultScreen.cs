using RPAQuiz.common;
using RPAQuiz.data.models;
using RPAQuiz.data.repositories;
using RPAQuiz.features.teacher_quiz_result.controllers;
using RPAQuiz.features.teacher_quizes_overview.controllers;
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

namespace RPAQuiz.features.teacher_quiz_result.views
{
    public partial class TeacherQuizResultScreen : BaseForm
    {

        public override BaseController Controller
        {
            get { return new TeacherQuizResultController(this,quizId); }
        }

        private int quizId;
        private string quizName;
        private readonly TeacherQuizResultController controller;

        public TeacherQuizResultScreen(int quizId, string quizName) : base()
        {
            InitializeComponent();
            this.quizId = quizId;
            this.quizName = quizName;
            this.controller = Controller as TeacherQuizResultController;
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
            this.Text = quizName;
        }

        private void SetupQuizesDataGridView()
        {
            QuizesDataGridView.MultiSelect = false;
        }

        //user actions
        private void BtnViewResults_Click(object sender, EventArgs e)
        {
            controller.OnUserClickedViewQuizResultsButton(GetSelectedUserId(), GetSelectedUserName());
        }


        //util
        private int GetSelectedUserId()
        {
            var selectedRow = QuizesDataGridView.SelectedCells[0].OwningRow;
            string quizId = (string)selectedRow.Cells[2].Value;
            return Int32.Parse(quizId);
        }

        private string GetSelectedUserName()
        {
            var selectedRow = QuizesDataGridView.SelectedCells[0].OwningRow;
            string quizName = (string)selectedRow.Cells[0].Value;
            return quizName;
        }
    }
}
