using RPAQuiz.data.repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPAQuiz.features.student_quiz_result.views
{
    public partial class StudentQuizResultScreen : Form
    {
        public StudentQuizResultScreen()
        {
            InitializeComponent();
           var viewModels = UserRepository.Instance.GetQuizResultForUser(1, 1);
            var bla = 1;
        }
        

    }
}
