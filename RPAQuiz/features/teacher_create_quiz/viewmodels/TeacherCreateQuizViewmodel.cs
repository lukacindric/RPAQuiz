using RPAQuiz.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.features.teacher_create_quiz.viewmodels
{
    public class TeacherCreateQuizViewmodel
    {
        private string question;
        private string firstAnswer;
        private string secondAnswer;
        private string thirdAnswer;
        private string fourthAnswer;
        private int correctAnswer;

        public TeacherCreateQuizViewmodel(string question, string firstAnswer, string secondAnswer, string thirdAnswer, string fourthAnswer, int correctAnswer)
        {
            this.question = question;
            this.firstAnswer = firstAnswer;
            this.secondAnswer = secondAnswer;
            this.thirdAnswer = thirdAnswer;
            this.fourthAnswer = fourthAnswer;
            this.correctAnswer = correctAnswer;
        }

        public string Question { get => question; set => question = value; }
        public string FirstAnswer { get => firstAnswer; set => firstAnswer = value; }
        public string SecondAnswer { get => secondAnswer; set => secondAnswer = value; }
        public string ThirdAnswer { get => thirdAnswer; set => thirdAnswer = value; }
        public string FourthAnswer { get => fourthAnswer; set => fourthAnswer = value; }
        public int CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }

        public bool IsValidModel()
        {
            if (Question.Trim().Length == 0) return false;
            if (FirstAnswer.Trim().Length == 0) return false;
            if (SecondAnswer.Trim().Length == 0) return false;
            if (ThirdAnswer.Trim().Length == 0) return false;
            if (FourthAnswer.Trim().Length == 0) return false;
            return true;
        }

        public string GetStringForInsertAnswersToDatabase(int questionId)
        {
            return "( '" + firstAnswer + "', " + questionId + ", '" + (correctAnswer == 1) + "' ),"
                + "( '" + secondAnswer + "', " + questionId + ", '" + (correctAnswer == 2) + "' ),"
                + "( '" + thirdAnswer + "', " + questionId + ", '" + (correctAnswer == 3) + "' ),"
                + "( '" + fourthAnswer + "', " + questionId + ", '" + (correctAnswer == 1) + "' );";
        }

        public override bool Equals(object obj)
        {
            return obj is TeacherCreateQuizViewmodel viewmodel &&
                   question == viewmodel.question &&
                   firstAnswer == viewmodel.firstAnswer &&
                   secondAnswer == viewmodel.secondAnswer &&
                   thirdAnswer == viewmodel.thirdAnswer &&
                   fourthAnswer == viewmodel.fourthAnswer &&
                   correctAnswer == viewmodel.correctAnswer;
        }

        public override int GetHashCode()
        {
            int hashCode = -448576203;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(question);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(firstAnswer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(secondAnswer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(thirdAnswer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(fourthAnswer);
            hashCode = hashCode * -1521134295 + correctAnswer.GetHashCode();
            return hashCode;
        }
    }
}
