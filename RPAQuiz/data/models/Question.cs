using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.data.models
{
   public class Question
    {
        private int id;
        private String text;

        public Question(int id, string text)
        {
            this.id = id;
            this.text = text;
        }

        public int Id { get => id; set => id = value; }
        public string Text { get => text; set => text = value; }

        public override bool Equals(object obj)
        {
            return obj is Question question &&
                   id == question.id &&
                   text == question.text;
        }

        public override int GetHashCode()
        {
            int hashCode = -1035133657;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(text);
            return hashCode;
        }
    }
}
