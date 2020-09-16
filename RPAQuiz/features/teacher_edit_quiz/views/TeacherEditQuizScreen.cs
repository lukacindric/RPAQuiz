using RPAQuiz.common;
using RPAQuiz.common.delegates;
using RPAQuiz.data.repositories;
using RPAQuiz.features.student_quiz_result.controllers;
using RPAQuiz.features.teacher_create_quiz.controllers;
using RPAQuiz.features.teacher_edit_quiz.controllers;
using System;
using System.Windows.Forms;

namespace RPAQuiz.features.teacher_edit_quiz.views
{
    public partial class TeacherEditQuizScreen : BaseForm
    {
        public override BaseController Controller
        {
            get { return new EditQuizController(this, quizId, quizName, quizUpdatedDelegate); }
        }

        private int quizId;
        private string quizName;
        private QuizUpdatedDelegate quizUpdatedDelegate;
        private readonly EditQuizController controller;

        public TeacherEditQuizScreen(int quizId, string quizName, QuizUpdatedDelegate quizUpdatedDelegate) : base()
        {
            InitializeComponent();
            this.quizId = quizId;
            this.quizName = quizName;
            this.quizUpdatedDelegate = quizUpdatedDelegate;
            this.controller = Controller as EditQuizController;
            TxtInputQuizName.Text = quizName;
            controller.OnCreate();
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


        private void BtnDeleteQuestion_Click(object sender, EventArgs e)
        {
            controller.OnDeleteQuestionButtonClicked();
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            controller.OnSaveChanges(TxtQuestion.Text,
                TxtFirstAnswer.Text,
                TxtSecondAnswer.Text,
                TxtThirdAnswer.Text,
                TxtFourthAnswer.Text,
                GetIndexOfSelectedAnswer(),
                TxtInputQuizName.Text);
        }

        //utils

        private int GetIndexOfSelectedAnswer()
        {
            var index = 1;
            if (RbSecondAnswer.Checked) index = 2;
            if (RbThirdAnswer.Checked) index = 3;
            if (RbFourthAnswer.Checked) index = 4;
            return index;
        }

    }
}
