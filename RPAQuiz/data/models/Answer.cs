using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.data.models
{
    public class Answer
    {
        private int id;
        private string text;
        private int questionId;
        private bool isCorrectAnswer;

        public Answer(int id, string text, int questionId, bool isCorrectAnswer)
        {
            this.id = id;
            this.text = text;
            this.questionId = questionId;
            this.isCorrectAnswer = isCorrectAnswer;
        }

        public int Id { get => id; set => id = value; }
        public string Text { get => text; set => text = value; }
        public int QuestionId { get => questionId; set => questionId = value; }
        public bool IsCorrectAnswer { get => isCorrectAnswer; set => isCorrectAnswer = value; }

        public override bool Equals(object obj)
        {
            return obj is Answer answer &&
                   id == answer.id &&
                   text == answer.text &&
                   questionId == answer.questionId &&
                   isCorrectAnswer == answer.isCorrectAnswer;
        }

        public override int GetHashCode()
        {
            int hashCode = 907033777;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(text);
            hashCode = hashCode * -1521134295 + questionId.GetHashCode();
            hashCode = hashCode * -1521134295 + isCorrectAnswer.GetHashCode();
            return hashCode;
        }
    }
}
