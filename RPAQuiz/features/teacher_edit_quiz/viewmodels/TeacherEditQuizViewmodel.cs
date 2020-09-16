using RPAQuiz.data.models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RPAQuiz.features.teacher_edit_quiz.viewmodels
{
    public class TeacherEditQuizViewmodel
    {
        private Question question;
        private List<Answer> answers;
        private bool wasChanged = false;
        private bool wasAdded = false;

        public TeacherEditQuizViewmodel(Question question, List<Answer> answers, bool wasChanged, bool wasAdded)
        {
            this.question = question;
            this.answers = answers;
            this.wasChanged = wasChanged;
            this.wasAdded = wasAdded;
        }

        public TeacherEditQuizViewmodel(string question,
            string answer1,
            string answer2,
            string answer3,
            string answer4,
            int correctAnswer)
        {
            Question = new Question(-1, question);
            var answer01 = new Answer(-1, answer1, -1, correctAnswer == 1);
            var answer02 = new Answer(-1, answer2, -1, correctAnswer == 2);
            var answer03 = new Answer(-1, answer3, -1, correctAnswer == 3);
            var answer04 = new Answer(-1, answer4, -1, correctAnswer == 4);
            Answers = new List<Answer>();
            Answers.Add(answer01);
            Answers.Add(answer02);
            Answers.Add(answer03);
            Answers.Add(answer04);
            WasAdded = true;
        }

        public Question Question { get => question; set => question = value; }
        public List<Answer> Answers { get => answers; set => answers = value; }
        public bool WasChanged { get => wasChanged; set => wasChanged = value; }
        public bool WasAdded { get => wasAdded; set => wasAdded = value; }

        public void SaveChangesIfNeeded(string question,
            string answer1,
            string answer2,
            string answer3,
            string answer4,
            int correctAnswer)
        {
            if (Answers[0].Text != answer1)
            {
                WasChanged = true;
                Answers[0].Text = answer1;
            }

            if (Answers[1].Text != answer2)
            {
                WasChanged = true;
                Answers[1].Text = answer2;
            }

            if (Answers[2].Text != answer3)
            {
                WasChanged = true;
                Answers[2].Text = answer3;
            }

            if (Answers[3].Text != answer4)
            {
                WasChanged = true;
                Answers[3].Text = answer4;
            }

            if (Question.Text != question)
            {
                WasChanged = true;
                Question.Text = question;
            }

            if ((Answers.FindIndex(ans => ans.IsCorrectAnswer)+1) != correctAnswer)
            {
                WasChanged = true;
                foreach (Answer answer in Answers)
                {
                    if ((Answers.IndexOf(answer) + 1) == correctAnswer)
                        answer.IsCorrectAnswer = true;
                    else
                        answer.IsCorrectAnswer = false;
                           
                }
            }
        }

        public string GetStringForInsertAnswersToDatabase(int questionId)
        {
            return "( '" + answers[0].Text + "', " + questionId + ", '" + answers[0].IsCorrectAnswer + "' ),"
                + "( '" + answers[1].Text + "', " + questionId + ", '" + answers[1].IsCorrectAnswer + "' ),"
                + "( '" + answers[2].Text + "', " + questionId + ", '" + answers[2].IsCorrectAnswer + "' ),"
                + "( '" + answers[3].Text + "', " + questionId + ", '" + answers[3].IsCorrectAnswer + "' );";
        }

        public override bool Equals(object obj)
        {
            return obj is TeacherEditQuizViewmodel viewmodel &&
                   EqualityComparer<Question>.Default.Equals(question, viewmodel.question) &&
                   EqualityComparer<List<Answer>>.Default.Equals(answers, viewmodel.answers) &&
                   wasChanged == viewmodel.wasChanged &&
                   wasAdded == viewmodel.wasAdded;
        }

        public override int GetHashCode()
        {
            int hashCode = 1206931427;
            hashCode = hashCode * -1521134295 + EqualityComparer<Question>.Default.GetHashCode(question);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Answer>>.Default.GetHashCode(answers);
            hashCode = hashCode * -1521134295 + wasChanged.GetHashCode();
            hashCode = hashCode * -1521134295 + wasAdded.GetHashCode();
            return hashCode;
        }
    }
}
