using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.features.student_quizes_overview.view_models
{
    public class StudentQuizesOverviewTableViewModel
    {
        private int quizId;
        private string quizName;
        private string userResult;

        public StudentQuizesOverviewTableViewModel() { }

        public int QuizId { get => quizId; set => quizId = value; }
        public string QuizName { get => quizName; set => quizName = value; }
        public string UserResult { get => userResult; set => userResult = value; }

        public override bool Equals(object obj)
        {
            return obj is StudentQuizesOverviewTableViewModel model &&
                   quizId == model.quizId &&
                   quizName == model.quizName &&
                   userResult == model.userResult;
        }

        public override int GetHashCode()
        {
            int hashCode = 1778260507;
            hashCode = hashCode * -1521134295 + quizId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(quizName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(userResult);
            return hashCode;
        }
    }
}
