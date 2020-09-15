using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.features.teacher_quiz_result.viewmodels
{
    public class TeacherQuizResultTableViewModel
    {
        private int userId;
        private string username;
        private string result;

        public TeacherQuizResultTableViewModel(int userId, string username, string result)
        {
            this.userId = userId;
            this.username = username;
            this.result = result;
        }

        public int UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string Result { get => result; set => result = value; }

        public override bool Equals(object obj)
        {
            return obj is TeacherQuizResultTableViewModel model &&
                   userId == model.userId &&
                   username == model.username &&
                   result == model.result;
        }

        public override int GetHashCode()
        {
            int hashCode = 2094199572;
            hashCode = hashCode * -1521134295 + userId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(result);
            return hashCode;
        }
    }
}
