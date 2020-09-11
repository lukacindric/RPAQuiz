using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.common.constants
{
    class SQLQueries
    {
        public const string GetUserWithUsernameQuery = "SELECT * FROM USERS WHERE Username =" + SQLParameters.Username +";"; 
    }
}
