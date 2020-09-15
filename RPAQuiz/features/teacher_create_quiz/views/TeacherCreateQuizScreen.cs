using RPAQuiz.common;
using RPAQuiz.common.delegates;
using RPAQuiz.data.repositories;
using RPAQuiz.features.student_quiz_result.controllers;
using RPAQuiz.features.teacher_create_quiz.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPAQuiz.features.teacher_create_quiz.views
{
    public partial class TeacherCreateQuizScreen : BaseForm
    {
        public override BaseController Controller
        {
            get { return new TeacherCreateQuizController(this,quizCreatedDelegate); }
        }

        private readonly TeacherCreateQuizController controller;

        private QuizCreatedDelegate quizCreatedDelegate;

        public TeacherCreateQuizScreen(QuizCreatedDelegate quizCreatedDelegate) : base()
        {
            InitializeComponent();
            this.quizCreatedDelegate = quizCreatedDelegate;
            this.controller = Controller as TeacherCreateQuizController;
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
            int correctAnswer)
        {
            LblQuestionNumber.Text = currentQuestionText;
            TxtQuestion.Text = question;
            TxtFirstAnswer.Text = answer1;
            TxtSecondAnswer.Text = answer2;
            TxtThirdAnswer.Text = answer3;
            TxtFourthAnswer.Text = answer4;
            SetRadioButtonsForCorrectAnswer(correctAnswer);
        }

        private void SetRadioButtonsForCorrectAnswer(int index)
        {
            RbFirstAnswer.Checked = index == 1;
            RbSecondAnswer.Checked = index == 2;
            RbThirdAnswer.Checked = index == 3;
            RbFourthAnswer.Checked = index == 4;
        }


        //ui actions
        private void BtnPreviousQuestion_Click(object sender, EventArgs e)
        {
            controller.OnPreviousQuestionButtonClicked(TxtQuestion.Text,
                TxtFirstAnswer.Text,
                TxtSecondAnswer.Text,
                TxtThirdAnswer.Text,
                TxtFourthAnswer.Text,
                GetIndexOfSelectedAnswer());
        }

        private void BtnNextQuestion_Click(object sender, EventArgs e)
        {
            controller.OnNextQuestionButtonClicked(TxtQuestion.Text,
                TxtFirstAnswer.Text,
                TxtSecondAnswer.Text,
                TxtThirdAnswer.Text,
                TxtFourthAnswer.Text,
                GetIndexOfSelectedAnswer());
        }

        private void BtnCreateQuiz_Click(object sender, EventArgs e)
        {
            controller.OnCreateQuizButtonClicked(TxtQuestion.Text,
               TxtFirstAnswer.Text,
               TxtSecondAnswer.Text,
               TxtThirdAnswer.Text,
               TxtFourthAnswer.Text,
               GetIndexOfSelectedAnswer(),
               TxtInputQuizName.Text);
        }

        private void BtnDeleteQuestion_Click(object sender, EventArgs e)
        {
            controller.OnDeleteQuestionButtonClicked();
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
