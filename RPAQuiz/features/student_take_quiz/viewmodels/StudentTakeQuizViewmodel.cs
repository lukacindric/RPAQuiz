using RPAQuiz.data.models;
using System.Collections.Generic;

namespace RPAQuiz.features.student_take_quiz.viewmodels
{
    public class StudentTakeQuizViewmodel
    {
        private Question question;
        private List<Answer> answers;
        private Answer userAnswer;

        public StudentTakeQuizViewmodel(Question question, List<Answer> answers, Answer userAnswer)
        {
            this.question = question;
            this.answers = answers;
            this.userAnswer = userAnswer;
        }

        internal Question Question { get => question; set => question = value; }
        internal List<Answer> Answers { get => answers; set => answers = value; }
        internal Answer UserAnswer { get => userAnswer; set => userAnswer = value; }


        public bool DidStudentAnswerCorrectly()
        {
            return UserAnswer.IsCorrectAnswer;
        }

        public string getStringRepresentationForInsertInDatabase(int userId, int quizId)
        {
            return "(" + userId + ", " + Question.Id + ", " + UserAnswer.Id + ", " + quizId + ")";
        }


        public override bool Equals(object obj)
        {
            return obj is StudentTakeQuizViewmodel viewmodel &&
                   EqualityComparer<Question>.Default.Equals(question, viewmodel.question) &&
                   EqualityComparer<List<Answer>>.Default.Equals(answers, viewmodel.answers) &&
                   EqualityComparer<Answer>.Default.Equals(userAnswer, viewmodel.userAnswer);
        }

        public override int GetHashCode()
        {
            int hashCode = -1524373507;
            hashCode = hashCode * -1521134295 + EqualityComparer<Question>.Default.GetHashCode(question);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Answer>>.Default.GetHashCode(answers);
            hashCode = hashCode * -1521134295 + EqualityComparer<Answer>.Default.GetHashCode(userAnswer);
            return hashCode;
        }
    }
}

