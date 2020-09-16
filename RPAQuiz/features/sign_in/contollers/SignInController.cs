using RPAQuiz.common;
using RPAQuiz.common.constants;
using RPAQuiz.data.models;
using RPAQuiz.data.repositories;
using RPAQuiz.features.sign_in.views;
using RPAQuiz.features.student_quizes_overview.views;
using RPAQuiz.features.teacher_quizes_overview.views;
using System;
using System.Resources;

namespace RPAQuiz.features.sign_in.contollers
{
    public class SignInController : BaseController
    {
        private readonly SignIn View;

        private readonly ResourceManager resourceManager = new ResourceManager(typeof(SignIn));

        public SignInController(SignIn view): base(view)
        {
            this.View = view;
        }

        public void OnSignInButtonClicked(String username, String password)
        {
            if(username.Length == 0 || password.Length == 0)
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.SignInScreenEmptyFieldsKey));
                return;
            }
            User user = UserRepository.Instance.GetUserWithUserName(username);
            if (user == null)
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.SignInScreenNoUsernameKey));
            } else if (password != user.Password)
            {
                View.ShowMessage(resourceManager.GetString(StringKeys.SignInScreenWrongPasswordKey));
            } else
            {
                ShowMainScreen(user);
            }
      
        }

        public void OnSelectedLanguageChanged(String initiallySelectedLanguage, object selectedLanguage)
        {
            string languageCode;
            switch (selectedLanguage)
            {
                case LanguageCodes.English:
                    languageCode = LanguageCodes.English;
                    break;
                case LanguageCodes.Croatian:
                    languageCode = LanguageCodes.Croatian;
                    break;
                default:
                    return;
            }
            if (languageCode == initiallySelectedLanguage) return;
            RPAQuiz.SetLanguage(languageCode);
            RestartSignInForm(languageCode);
        }

        private void RestartSignInForm(string languageCode)
        {
            SignIn form = new SignIn(languageCode);
            form.Show();
            View.Hide();
        }

        private void ShowMainScreen(User user)
        {
            if (user.IsStudent)
            {
                StudentQuizesOverviewScreen form = new StudentQuizesOverviewScreen(user.Id);
                form.Show();
                View.Hide();
            } else
            {
                TeacherQuizesOverviewScreen form = new TeacherQuizesOverviewScreen();
                form.Show();
                View.Hide();
            }
        }
    }
}
