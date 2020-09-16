using RPAQuiz.common;
using RPAQuiz.common.constants;
using RPAQuiz.common.delegates;
using RPAQuiz.data.repositories;
using RPAQuiz.features.teacher_edit_quiz.viewmodels;
using RPAQuiz.features.teacher_edit_quiz.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.features.teacher_edit_quiz.controllers
{
    class EditQuizController : BaseController
    {

        private readonly TeacherEditQuizScreen View;

        private readonly ResourceManager resourceManager = new ResourceManager(typeof(TeacherEditQuizScreen));

        private List<TeacherEditQuizViewmodel> viewModels = new List<TeacherEditQuizViewmodel>();

        private int currentQuestionIndex = 0;

        private int quizId;

        private string quizName;

        private QuizUpdatedDelegate quizUpdatedDelegate;

        public EditQuizController(TeacherEditQuizScreen view, int quizId, string quizName, QuizUpdatedDelegate quizUpdatedDelegate) : base(view)
        {
            this.View = view;
            this.quizId = quizId;
            this.quizName = quizName;
            this.quizUpdatedDelegate = quizUpdatedDelegate;
        }

        public void OnCreate()
        { 
            viewModels = QuizRepository.Instance.GetQuizDetails(quizId);
            UpdateUI();
        }

        private void UpdateUI()
        {
            string currentQuestionText = "" + (currentQuestionIndex + 1) + ".";
            if (viewModels.ElementAtOrDefault(currentQuestionIndex) == null)
            {
                View.ShowViewmodel(currentQuestionText, "", "", "", "", "", 1);
                return;
            }
            var viewmodel = viewModels[currentQuestionIndex];
            View.ShowViewmodel(currentQuestionText,
                viewmodel.Question.Text,
                viewmodel.Answers[0].Text,
                viewmodel.Answers[1].Text,
                viewmodel.Answers[2].Text,
                viewmodel.Answers[3].Text,
                viewmodel.Answers.FindIndex(ans => ans.IsCorrectAnswer) + 1);

        }

        public void OnNextQuestionButtonClicked(string question,
            string answer1,
            string answer2,
            string answer3,
            string answer4,
            int correctAnswer)
        {
            if (question.Trim().Length ==0 
                || answer1.Trim().Length ==0 
                || answer2.Trim().Length == 0 
                || answer3.Trim().Length == 0 
                || answer4.Trim().Length == 0)
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.TeacherEditQuizInputFieldsWarning));
                return;
            }
            if (viewModels.ElementAtOrDefault(currentQuestionIndex) != null)
            {
                viewModels[currentQuestionIndex].SaveChangesIfNeeded(question,
                answer1,
                answer2,
                answer3,
                answer4,
                correctAnswer);
            }
            else
            {
                var viewModel = new TeacherEditQuizViewmodel(question, answer1, answer2, answer3, answer4, correctAnswer);
                viewModels.Add(viewModel);
            }
            currentQuestionIndex++;
            UpdateUI();
        }

        public void OnPreviousQuestionButtonClicked(string question,
            string answer1,
            string answer2,
            string answer3,
            string answer4,
            int correctAnswer)
        {
            if (currentQuestionIndex == 0) return;
            if (question.Trim().Length == 0
              || answer1.Trim().Length == 0
              || answer2.Trim().Length == 0
              || answer3.Trim().Length == 0
              || answer4.Trim().Length == 0)
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.TeacherEditQuizInputFieldsWarning));
                return;
            }
            if (viewModels.ElementAtOrDefault(currentQuestionIndex) != null)
            {
                viewModels[currentQuestionIndex].SaveChangesIfNeeded(question,
                answer1,
                answer2,
                answer3,
                answer4,
                correctAnswer);
            }
            else
            {
                var viewModel = new TeacherEditQuizViewmodel(question, answer1, answer2, answer3, answer4, correctAnswer);
                viewModels.Add(viewModel);
            }
            currentQuestionIndex--;
            UpdateUI();
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

        public void OnSaveChanges(string question,
            string answer1,
            string answer2,
            string answer3,
            string answer4,
            int correctAnswer,
            string quizName)
        {
            if (question.Trim().Length == 0
               || answer1.Trim().Length == 0
               || answer2.Trim().Length == 0
               || answer3.Trim().Length == 0
               || answer4.Trim().Length == 0)
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.TeacherEditQuizInputFieldsWarning));
                return;
            }
            if (viewModels.ElementAtOrDefault(currentQuestionIndex) != null)
            {
                viewModels[currentQuestionIndex].SaveChangesIfNeeded(question,
                answer1,
                answer2,
                answer3,
                answer4,
                correctAnswer);
            }
            else
            {
                var viewModel = new TeacherEditQuizViewmodel(question, answer1, answer2, answer3, answer4, correctAnswer);
                viewModels.Add(viewModel);
            }
            
            if (quizName != this.quizName )
            {
                if (!QuizRepository.Instance.UpdateQuizName(quizId, quizName))
                {
                    View.ShowMessage(resourceManager.GetString(StringKeys.TeacherEditQuizErrorMessage));
                    return;
                }
            }

            if (!QuestionRepository.Instance.DeleteQuestionsFromQuizIfNeeded(quizId, viewModels))
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.TeacherEditQuizErrorMessage));
                return;
            }

            foreach (TeacherEditQuizViewmodel viewModel in viewModels)
            {
                if (viewModel.WasAdded)
                {
                    if (!QuestionRepository.Instance.InsertQuestionAndAnswers(quizId, viewModel))
                    {
                        View.ShowMessage(resourceManager.GetString(StringKeys.TeacherEditQuizErrorMessage));
                        return;
                    }
                }
                if (viewModel.WasChanged && !viewModel.WasAdded)
                {
                    if (!QuestionRepository.Instance.UpdateQuestionAndAnswer(viewModel))
                    {
                        View.ShowMessage(resourceManager.GetString(StringKeys.TeacherEditQuizErrorMessage));
                        return;
                    }
                }
            }
            View.ShowMessage(resourceManager.GetString(StringKeys.TeacherEditQuizSuccessMessage));
            quizUpdatedDelegate.OnQuizUpdated();
            View.Close();
        }
    }
}
