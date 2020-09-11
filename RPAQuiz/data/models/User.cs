using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.data.models
{
    public class User
    {
        private String username;
        private String password;
        private bool isStudent;

        public User(string username, string password, bool isStudent)
        {
            this.Username = username;
            this.Password = password;
            this.IsStudent = isStudent;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public bool IsStudent { get => isStudent; set => isStudent = value; }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Username == user.Username &&
                   Password == user.Password &&
                   IsStudent == user.IsStudent;
        }

        public override int GetHashCode()
        {
            int hashCode = 1221033594;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(password);
            hashCode = hashCode * -1521134295 + isStudent.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + IsStudent.GetHashCode();
            return hashCode;
        }
    }
}
