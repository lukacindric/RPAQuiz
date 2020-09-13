using RPAQuiz.common;
using RPAQuiz.common.constants;
using RPAQuiz.features.sign_in.contollers;
using System;
using System.Windows.Forms;

namespace RPAQuiz.features.sign_in.views
{
    public partial class SignIn : BaseForm
    {
        private readonly string initallySelectedLanguage;
        public override BaseController Controller
        {
            get { return new SignInController(this); }
        }

        private readonly SignInController controller;

        //constructor
        public SignIn(String selectedLanguage): base()
        {
            InitializeComponent();
            this.initallySelectedLanguage = selectedLanguage;
            controller = Controller as SignInController;
            CboLanguage.Text = initallySelectedLanguage;
            SetupUI();
        }

        //parent methods

        public override void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        //UI setup
        private void SetupUI()
        {
            SetupLanguageComboBox();
        }

        private void SetupLanguageComboBox()
        {
            switch (initallySelectedLanguage)
            {
                case LanguageCodes.English:
                    CboLanguage.Text = LanguageCodes.English;
                    break;

                case LanguageCodes.Croatian:
                    CboLanguage.Text = LanguageCodes.Croatian;
                    break;

                default:
                    CboLanguage.Text = LanguageCodes.Croatian;
                    break;
            }
           
        }

        // user actions
        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            controller.OnSignInButtonClicked(TxtUsername.Text, TxtPassword.Text);
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnSignIn.PerformClick();
        }


        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CboLanguage_DropDownClosed(object sender, EventArgs e)
        {
            controller.OnSelectedLanguageChanged(initallySelectedLanguage, CboLanguage.SelectedItem);
        }
    }
}
