using RPAQuiz.common.constants;
using RPAQuiz.features.sign_in.views;
using RPAQuiz.features.student_quizes_overview.views;
using RPAQuiz.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.data.models
{
    public class User
    {
        private int id;
        private String username;
        private String password;
        private bool isStudent;

        public User(int id, string username, string password, bool isStudent)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.IsStudent = isStudent;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public bool IsStudent { get => isStudent; set => isStudent = value; }
        public int Id { get => id; set => id = value; }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id == user.Id &&
                   Username == user.Username &&
                   Password == user.Password &&
                   IsStudent == user.IsStudent;
        }

        public override int GetHashCode()
        {
            int hashCode = -145226646;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(password);
            hashCode = hashCode * -1521134295 + isStudent.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + IsStudent.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            return hashCode;
        }
    }
}

