using RPAQuiz.common;
using RPAQuiz.common.delegates;
using RPAQuiz.features.student_take_quiz.controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RPAQuiz.features.student_take_quiz.views
{
    public partial class StudentTakeQuizScreen : BaseForm
    {
        public override BaseController Controller
        {
            get { return new StudentTakeQuizController(this); }
        }

        private readonly StudentTakeQuizController controller;

        public StudentTakeQuizScreen(int userId, int quizId, string quizName, QuizTakenDelegate quizTakenDelegate) : base()
        {
            InitializeComponent();
            this.controller = Controller as StudentTakeQuizController;
            controller.OnCreate(userId, quizId, quizTakenDelegate);
            this.Text = quizName;
            this.Icon = Properties.Resources.efzg_logo;
        }

        public override void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        //ui setup

        public void ShowViewmodel(string currentQuestionText,
            string question,
            string answer1,
            string answer2,
            string answer3,
            string answer4,
            int userAnswer)
        {
            LblQuestion.Text = question;
            LblQuestionNumber.Text = currentQuestionText;
            RbFirstAnswer.Text = answer1;
            RbSecondAnswer.Text = answer2;
            RbThirdAnswer.Text = answer3;
            RbFourthAnswer.Text = answer4;
            SetRadioButtonsForUserAnswer(userAnswer);
        }

        private void SetRadioButtonsForUserAnswer(int index)
        {
            RbFirstAnswer.Checked = index == 1;
            RbSecondAnswer.Checked = index == 2;
            RbThirdAnswer.Checked = index == 3;
            RbFourthAnswer.Checked = index == 4;
        }

        //ui actions
        private void BtnPreviousQuestion_Click(object sender, EventArgs e)
        {

            controller.OnPreviousQuestionButtonClicked(GetIndexOfSelectedAnswer());
        }

        private void BtnNextQuestion_Click(object sender, EventArgs e)
        {
            controller.OnNextQuestionButtonClicked(GetIndexOfSelectedAnswer());
        }

        private void BtnSubmitQuiz_Click(object sender, EventArgs e)
        {
            controller.OnSubmitAnswersButtonClicked(GetIndexOfSelectedAnswer());
        }

        //utils

        private int GetIndexOfSelectedAnswer()
        {
            var index = 0;
            if (RbSecondAnswer.Checked) index = 1;
            if (RbThirdAnswer.Checked) index = 2;
            if (RbFourthAnswer.Checked) index = 3;
            return index;
        }
    }
}
