using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.data.models
{
    class Question
    {
        private int id;
        private String text;
        private int quizId;

        public Question(int id, string text, int quizId)
        {
            this.id = id;
            this.text = text;
            this.quizId = quizId;
        }

        public int Id { get => id; set => id = value; }
        public string Text { get => text; set => text = value; }
        public int QuizId { get => quizId; set => quizId = value; }

        public override bool Equals(object obj)
        {
            return obj is Question question &&
                   id == question.id &&
                   text == question.text &&
                   quizId == question.quizId;
        }

        public override int GetHashCode()
        {
            int hashCode = -1035133657;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(text);
            hashCode = hashCode * -1521134295 + quizId.GetHashCode();
            return hashCode;
        }
    }
}
