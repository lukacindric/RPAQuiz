using RPAQuiz.features.sign_in.contollers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPAQuiz.common
{
    public abstract class BaseForm : Form
    {
        public abstract BaseController Controller
        {
            get;

        }
    }
}
