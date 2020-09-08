using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPAQuiz.features.sign_in.views
{
    public partial class SignInScreen : Form
    {
        public SignInScreen()
        {
            InitializeComponent();
            SetupUI();
        }

        //UI setup
        private void SetupUI()
        {
            SetupTitleBar();
        }

        private void SetupTitleBar()
        {
            this.Text = "Prijava";
        }
    }
}
