using RPAQuiz.common;
using RPAQuiz.common.constants;
using RPAQuiz.data.models;
using RPAQuiz.data.repositories;
using RPAQuiz.features.teacher_quizes_overview.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPAQuiz.features.teacher_quizes_overview.views
{
    public partial class TeacherQuizesOverviewScreen : BaseForm
    {

        public override BaseController Controller
        {
            get { return new TeacherQuizesOverviewController(this); }
        }

        private readonly TeacherQuizesOverviewController controller;

        private readonly ResourceManager resourceManager = new ResourceManager(typeof(TeacherQuizesOverviewScreen));

        public TeacherQuizesOverviewScreen() : base()
        {
            InitializeComponent();
            this.controller = Controller as TeacherQuizesOverviewController;
            SetupUI();
            controller.OnCreate();
        }

        public void UpdateDataGridViewSource(DataTable dataTable)
        {
            QuizesDataGridView.DataSource = null;
            QuizesDataGridView.DataSource = dataTable;
            QuizesDataGridView.Columns[1].Visible = false;
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

        public void ShowConfirmQuizDeleteDialog()
        {
            MessageBoxManager.Yes = resourceManager.GetString(StringKeys.TeacherQuizesOverviewDialogYesButton);
            MessageBoxManager.No = resourceManager.GetString(StringKeys.TeacherQuizesOverviewDialogNoButton);
            var confirmResult = MessageBox.Show(resourceManager.GetString(StringKeys.TeacherQuizesOverviewDialogMessage) +" " + GetSelectedQuizName()+"?",
                                     resourceManager.GetString(StringKeys.TeacherQuizesOverviewDialogTitle),
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                controller.OnUserConfirmedDeleteQuiz(GetSelectedQuizId());
            }
        }
   
        //user actions
        private void BtnCreateQuiz_Click(object sender, EventArgs e)
        {
            controller.OnUserClickedCreateQuizButton();
        }

        private void BtnEditQuiz_Click(object sender, EventArgs e)
        {
            controller.OnUserClickedEditQuizButton(GetSelectedQuizId(), GetSelectedQuizName());
        }

        private void BtnDeleteQuiz_Click(object sender, EventArgs e)
        {
            controller.OnUserClickedDeleteQuizButton();
        }

        private void BtnCheckResults_Click(object sender, EventArgs e)
        {
            controller.OnUserClickedViewQuizResultsButton(GetSelectedQuizId(), GetSelectedQuizName());
        }

        //util
        private int GetSelectedQuizId()
        {
            var selectedRow = QuizesDataGridView.SelectedCells[0].OwningRow;
            string quizId = (string)selectedRow.Cells[1].Value;
            return Int32.Parse(quizId);
        }

        private string GetSelectedQuizName()
        {
            var selectedRow = QuizesDataGridView.SelectedCells[0].OwningRow;
            string quizName = (string)selectedRow.Cells[0].Value;
            return quizName;
        }
    }
}
