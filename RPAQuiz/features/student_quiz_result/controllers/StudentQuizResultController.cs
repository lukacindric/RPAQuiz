using RPAQuiz.common;
using RPAQuiz.data.models;
using RPAQuiz.data.repositories;
using RPAQuiz.features.student_quiz_result.viewmodels;
using RPAQuiz.features.student_quiz_result.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.features.student_quiz_result.controllers
{
    class StudentQuizResultController: BaseController
    {
        private readonly StudentQuizResultScreen View;

        private List<StudentQuizResultViewmodel> viewModels = new List<StudentQuizResultViewmodel>();

        private int currentQuestionIndex = 0;

        public StudentQuizResultController(StudentQuizResultScreen view) : base(view)
        {
            this.View = view;
        }

        public void OnCreate(int userId, int quizId)
        {
            viewModels = UserRepository.Instance.GetQuizResultForUser(userId, quizId);
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
            string currentQuestionText = "" + (currentQuestionIndex+1) + "/" + viewModels.Count;
            int correctAnswer = viewmodel.Answers.FindIndex(a => a.IsCorrectAnswer) + 1;
            int userAnswer = viewmodel.Answers.IndexOf(viewmodel.UserAnswer) + 1;
            View.ShowViewmodel(currentQuestionText, question, answer1, answer2, answer3, answer4, userAnswer, correctAnswer);

        }

        public void OnNextQuestionButtonClicked()
        {
            if (currentQuestionIndex < viewModels.Count -1)
            {
                currentQuestionIndex++;
                UpdateUI();
            }
        }

        public void OnPreviousQuestionButtonClicked()
        {
            if(currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                UpdateUI();
            }
        }
    }
}
