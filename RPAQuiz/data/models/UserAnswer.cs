using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAQuiz.data.models
{
    public class UserAnswer
    {
        private int id;
        private int userId;
        private int questionId;
        private int answerId;
        private int quizId;

        public UserAnswer(int id, int userId, int questionId, int answerId, int quizId)
        {
            this.id = id;
            this.userId = userId;
            this.questionId = questionId;
            this.answerId = answerId;
            this.quizId = quizId;
        }

        public int Id { get => id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public int QuestionId { get => questionId; set => questionId = value; }
        public int AnswerId { get => answerId; set => answerId = value; }
        public int QuizId { get => quizId; set => quizId = value; }

        public override bool Equals(object obj)
        {
            return obj is UserAnswer answer &&
                   id == answer.id &&
                   userId == answer.userId &&
                   questionId == answer.questionId &&
                   answerId == answer.answerId &&
                   quizId == answer.quizId;
        }

        public override int GetHashCode()
        {
            int hashCode = -1666201631;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + userId.GetHashCode();
            hashCode = hashCode * -1521134295 + questionId.GetHashCode();
            hashCode = hashCode * -1521134295 + answerId.GetHashCode();
            hashCode = hashCode * -1521134295 + quizId.GetHashCode();
            return hashCode;
        }
    }
}
