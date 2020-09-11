using RPAQuiz.common;
using RPAQuiz.features.sign_in.views;
using System;
using System.Data.SqlClient;

namespace RPAQuiz.features.sign_in.contollers
{
    public class SignInController : BaseController
    {
        private readonly SignIn View;

        public SignInController(SignIn view): base(view)
        {
            this.View = view;
        }

        public void onSignInButtonClicked(String username, String password)
        {
            var con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\data\\database\\RPADatabase.mdf;Integrated Security=True";
            con.Open();
            SqlCommand getUsersCommand = new SqlCommand("SELECT * FROM USERS", con);
            using (SqlDataReader reader = getUsersCommand.ExecuteReader())
            {
                // Check is the reader has any rows at all before starting to read.
                if (reader.HasRows)
                {
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        String DbUsername = reader.GetString(reader.GetOrdinal("Username"));
                        Console.Out.WriteLine(DbUsername);

                    }
                }
                Console.Out.WriteLine("bla");
            }
        }

        public void onSelectedLanguageChanged(String initiallySelectedLanguage, object selectedLanguage)
        {
            String languageCode = "";
            switch (selectedLanguage)
            {
                case "EN":
                    languageCode = "en";
                    break;
                case "HR":
                    languageCode = "hr";
                    break;
                default:
                    return;
            }
            if (languageCode == initiallySelectedLanguage) return;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(languageCode);
            restartSignInForm(languageCode);
        }

        private void restartSignInForm(string languageCode)
        {
            SignIn form = new SignIn(languageCode);
            form.Show();
            View.Hide();
        }
    }
}
