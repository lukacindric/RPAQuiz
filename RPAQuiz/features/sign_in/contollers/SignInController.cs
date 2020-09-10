using RPAQuiz.common;
using RPAQuiz.features.sign_in.views;
using System;


namespace RPAQuiz.features.sign_in.contollers
{
    public class SignInController : BaseController
    {
        private readonly SignIn View;

        public SignInController(SignIn view): base(view)
        {
            this.View = view;
        }

        public void onSignInButtonClicked(String username, String password)
        {

        }

        public void onSelectedLanguageChanged(String initiallySelectedLanguage, object selectedLanguage)
        {
            String languageCode = "";
            switch (selectedLanguage)
            {
                case "EN":
                    languageCode = "en";
                    break;
                case "HR":
                    languageCode = "hr";
                    break;
                default:
                    return;
            }
            if (languageCode == initiallySelectedLanguage) return;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(languageCode);
            restartSignInForm(languageCode);
        }

        private void restartSignInForm(string languageCode)
        {
            SignIn form = new SignIn(languageCode);
            form.Show();
            View.Hide();
        }
    }
}
