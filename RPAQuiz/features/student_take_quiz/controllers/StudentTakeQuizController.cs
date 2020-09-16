using RPAQuiz.common;
using RPAQuiz.common.constants;
using RPAQuiz.common.delegates;
using RPAQuiz.data.repositories;
using RPAQuiz.features.student_quiz_result.viewmodels;
using RPAQuiz.features.student_take_quiz.viewmodels;
using RPAQuiz.features.student_take_quiz.views;
using System.Collections.Generic;
using System.Resources;

namespace RPAQuiz.features.student_take_quiz.controllers
{
    class StudentTakeQuizController : BaseController
    {
        private QuizTakenDelegate quizTakenDelegate;

        private readonly StudentTakeQuizScreen View;

        private readonly ResourceManager resourceManager = new ResourceManager(typeof(StudentTakeQuizScreen));

        private List<StudentTakeQuizViewmodel> viewModels = new List<StudentTakeQuizViewmodel>();

        private int currentQuestionIndex = 0;

        private int userId;

        private int quizId;

        public StudentTakeQuizController(StudentTakeQuizScreen view) : base(view)
        {
            this.View = view;
        }

        public void OnCreate(int userId, int quizId, QuizTakenDelegate quizTakenDelegate)
        {
            this.userId = userId;
            this.quizId = quizId;
            this.quizTakenDelegate = quizTakenDelegate;
            viewModels = QuizRepository.Instance.GetQuizQuestions(quizId);
            UpdateUI();
        }

        private void UpdateUI()
        {
            var viewmodel = viewModels[currentQuestionIndex];
            string question = viewmodel.Question.Text;
            string answer1 = viewmodel.Answers[0].Text;
            string answer2 = viewmodel.Answers[1].Text;
            string answer3 = viewmodel.Answers[2].Text;
            string answer4 = viewmodel.Answers[3].Text;
            string currentQuestionText = "" + (currentQuestionIndex + 1) + "/" + viewModels.Count;
            int userAnswer = viewmodel.Answers.IndexOf(viewmodel.UserAnswer) + 1;
            View.ShowViewmodel(currentQuestionText, question, answer1, answer2, answer3, answer4, userAnswer);

        }

        public void OnNextQuestionButtonClicked(int indexOfUserSelectedAnswer)
        {
            if (currentQuestionIndex < viewModels.Count - 1)
            {
                viewModels[currentQuestionIndex].UserAnswer = viewModels[currentQuestionIndex].Answers[indexOfUserSelectedAnswer];
                currentQuestionIndex++;
                UpdateUI();
            }
        }

        public void OnPreviousQuestionButtonClicked(int indexOfUserSelectedAnswer)
        {
            if (currentQuestionIndex > 0)
            {
                viewModels[currentQuestionIndex].UserAnswer = viewModels[currentQuestionIndex].Answers[indexOfUserSelectedAnswer];
                currentQuestionIndex--;
                UpdateUI();
            }
        }

        public void OnSubmitAnswersButtonClicked(int indexOfUserSelectedAnswer)
        {
            viewModels[currentQuestionIndex].UserAnswer = viewModels[currentQuestionIndex].Answers[indexOfUserSelectedAnswer];
            var didInsert = QuizRepository.Instance.InsertUserAnswersForQuiz(viewModels, userId, quizId);
           if (didInsert)
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.StudentTakeQuizInsertAnswersSuccessMessage));
                quizTakenDelegate.OnQuizTaken();
                View.Close();
            } else
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.StudentTakeQuizInsertAnswersErrorMessage));
            }
        }
    }
}
