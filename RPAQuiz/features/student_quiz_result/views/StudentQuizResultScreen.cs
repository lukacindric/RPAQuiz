using RPAQuiz.common;
using RPAQuiz.data.repositories;
using RPAQuiz.features.student_quiz_result.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPAQuiz.features.student_quiz_result.views
{
    public partial class StudentQuizResultScreen : BaseForm
    {
        public override BaseController Controller
        {
            get { return new StudentQuizResultController(this); }
        }

        private readonly StudentQuizResultController controller;

        public StudentQuizResultScreen(int userId, int quizId, string formName) : base()
        {
            InitializeComponent();
            this.controller = Controller as StudentQuizResultController;
            controller.OnCreate(userId,quizId);
            this.Text = formName;
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
            int userAnswer, 
            int correctAnswer)
        {
            LblQuestion.Text = question;
            LblQuestionNumber.Text = currentQuestionText;
            RbFirstAnswer.Text = answer1;
            RbSecondAnswer.Text = answer2;
            RbThirdAnswer.Text = answer3;
            RbFourthAnswer.Text = answer4;
            SetRadioButtonsForUserAnswer(userAnswer);
            SetRadioButtonsForCorrectAnswer(correctAnswer);
        }

        private void SetRadioButtonsForUserAnswer(int index)
        {
            RbFirstAnswer.Checked = index == 1;
            RbSecondAnswer.Checked = index == 2;
            RbThirdAnswer.Checked = index == 3;
            RbFourthAnswer.Checked = index == 4;
        }

        private void SetRadioButtonsForCorrectAnswer(int index)
        {
            var underlinedFont = new Font(RbFirstAnswer.Font, FontStyle.Underline);
            var regularFont = new Font(RbFirstAnswer.Font, FontStyle.Regular);
            RbFirstAnswer.Font = index == 1 ? underlinedFont : regularFont;
            RbSecondAnswer.Font = index == 2 ? underlinedFont : regularFont;
            RbThirdAnswer.Font = index == 3 ? underlinedFont : regularFont;
            RbFourthAnswer.Font = index == 4 ? underlinedFont : regularFont;
        }

        //ui actions
        private void BtnPreviousQuestion_Click(object sender, EventArgs e)
        {
            controller.OnPreviousQuestionButtonClicked();
        }

        private void BtnNextQuestion_Click(object sender, EventArgs e)
        {
            controller.OnNextQuestionButtonClicked();
        }
    }
}
