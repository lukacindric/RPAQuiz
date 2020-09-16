using RPAQuiz.common.constants;
using RPAQuiz.features.sign_in.views;
using RPAQuiz.features.student_quizes_overview.views;
using RPAQuiz.features.teacher_quizes_overview.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPAQuiz
{
    static class RPAQuiz
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetLanguage(LanguageCodes.Croatian);
            MessageBoxManager.Register();
            Application.Run(new SignIn(LanguageCodes.Croatian));
        }

       public static void SetLanguage(string languageCode)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(languageCode);
        }
    }
}
