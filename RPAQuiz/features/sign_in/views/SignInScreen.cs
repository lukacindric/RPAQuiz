using RPAQuiz.common;
using RPAQuiz.features.sign_in.contollers;
using RPAQuiz.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPAQuiz.features.sign_in.views
{
    public partial class SignIn : BaseForm
    {
        private String initallySelectedLanguage;
        public override BaseController Controller
        {
            get { return new SignInController(this); }
        }

        private SignInController controller;

        public SignIn(String selectedLanguage)
        {
            InitializeComponent();
            this.initallySelectedLanguage = selectedLanguage;
            controller = Controller as SignInController;
            CboLanguage.Text = initallySelectedLanguage;
            SetupUI();
        }

        //UI setup
        private void SetupUI()
        {
            SetupFormSettings();
            SetupLanguageComboBox();
           
        }

        private void SetupFormSettings()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public void Bla() { }

        private void SetupLanguageComboBox()
        {
            switch (initallySelectedLanguage)
            {
                case "en":
                    CboLanguage.Text = "EN";
                    break;

                case "hr":
                    CboLanguage.Text = "HR";
                    break;

                default:
                    CboLanguage.Text = "EN";
                    break;
            }
           
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            controller.onSignInButtonClicked(TxtUsername.Text, TxtPassword.Text);
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
            controller.onSelectedLanguageChanged(initallySelectedLanguage, CboLanguage.SelectedItem);
        }
    }
}
