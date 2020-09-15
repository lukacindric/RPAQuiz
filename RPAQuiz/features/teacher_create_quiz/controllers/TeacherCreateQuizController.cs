using RPAQuiz.common;
using RPAQuiz.common.constants;
using RPAQuiz.common.delegates;
using RPAQuiz.data.repositories;
using RPAQuiz.features.teacher_create_quiz.viewmodels;
using RPAQuiz.features.teacher_create_quiz.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.features.teacher_create_quiz.controllers
{
    class TeacherCreateQuizController : BaseController
    {

        private readonly TeacherCreateQuizScreen View;

        private readonly ResourceManager resourceManager = new ResourceManager(typeof(TeacherCreateQuizScreen));

        private List<TeacherCreateQuizViewmodel> viewModels = new List<TeacherCreateQuizViewmodel>();

        private int currentQuestionIndex = 0;

        private QuizCreatedDelegate quizCreatedDelegate;

        public TeacherCreateQuizController(TeacherCreateQuizScreen view, QuizCreatedDelegate quizCreatedDelegate) : base(view)
        {
            this.View = view;
            this.quizCreatedDelegate = quizCreatedDelegate;
        }

        private void UpdateUI()
        {
            string currentQuestionText = "" + (currentQuestionIndex + 1) + ".";
            if (viewModels.ElementAtOrDefault(currentQuestionIndex) == null)
            {
                View.ShowViewmodel(currentQuestionText,"","","","","",1);
                return;
            }
            var viewmodel = viewModels[currentQuestionIndex];
            View.ShowViewmodel(currentQuestionText,
                viewmodel.Question,
                viewmodel.FirstAnswer,
                viewmodel.SecondAnswer, 
                viewmodel.ThirdAnswer,
                viewmodel.FourthAnswer, 
                viewmodel.CorrectAnswer);

        }

        public void OnNextQuestionButtonClicked(string question,
            string answer1,
            string answer2,
            string answer3,
            string answer4,
            int correctAnswer)
        {
            var viewmodel = new TeacherCreateQuizViewmodel(question, answer1, answer2, answer3, answer4, correctAnswer);
            if(viewmodel.IsValidModel())
            {
                if (viewModels.ElementAtOrDefault(currentQuestionIndex) != null) 
                    viewModels[currentQuestionIndex] = viewmodel;
                else 
                    viewModels.Add(viewmodel);
                currentQuestionIndex++;
                UpdateUI();
            }
            else
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.TeacherCreateQuizInputFieldsWarning));
            }
        }

        public void OnPreviousQuestionButtonClicked(string question,
            string answer1,
            string answer2,
            string answer3,
            string answer4,
            int correctAnswer)
        {
            if (currentQuestionIndex == 0) return;
            var viewmodel = new TeacherCreateQuizViewmodel(question, answer1, answer2, answer3, answer4, correctAnswer);
            if (viewmodel.IsValidModel())
            {
                if (viewModels.ElementAtOrDefault(currentQuestionIndex) != null)
                    viewModels[currentQuestionIndex] = viewmodel;
                else
                    viewModels.Add(viewmodel);
                currentQuestionIndex--;
                UpdateUI();
            }
            else
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.TeacherCreateQuizInputFieldsWarning));
            }
        }

        public void OnDeleteQuestionButtonClicked()
        {
            if (viewModels.ElementAtOrDefault(currentQuestionIndex) != null)
            {
                viewModels.RemoveAt(currentQuestionIndex);

            }
            if (viewModels.ElementAtOrDefault(currentQuestionIndex) == null && currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
            }
            UpdateUI();
        }

        public void OnCreateQuizButtonClicked(string question,
            string answer1,
            string answer2,
            string answer3,
            string answer4,
            int correctAnswer,
            string quizName)
        {

            var viewmodel = new TeacherCreateQuizViewmodel(question, answer1, answer2, answer3, answer4, correctAnswer);
            if (viewmodel.IsValidModel() && quizName.Trim().Length > 0)
            {
                if (viewModels.ElementAtOrDefault(currentQuestionIndex) != null)
                    viewModels[currentQuestionIndex] = viewmodel;
                else
                    viewModels.Add(viewmodel);
                InsertQuizToDB(quizName);
                
            }
            else
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.TeacherCreateQuizInputFieldsWarning));
            }
        }

        private void InsertQuizToDB(string quizName)
        {
            if (QuizRepository.Instance.InsertNewQuiz(quizName, viewModels))
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.TeacherCreateQuizSuccessMessage));
                quizCreatedDelegate.OnQuizCreated();
                View.Close();
            }
            else
                View.ShowMessage(resourceManager.GetString(StringKeys.TeacherCreateQuizSuccessMessage));
        }
    }
}
