namespace RPAQuiz.features.student_take_quiz.views
{
    partial class StudentTakeQuizScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentTakeQuizScreen));
            this.LblQuestion = new System.Windows.Forms.Label();
            this.BtnPreviousQuestion = new System.Windows.Forms.Button();
            this.LblQuestionNumber = new System.Windows.Forms.Label();
            this.BtnNextQuestion = new System.Windows.Forms.Button();
            this.RbFirstAnswer = new System.Windows.Forms.RadioButton();
            this.RbSecondAnswer = new System.Windows.Forms.RadioButton();
            this.RbThirdAnswer = new System.Windows.Forms.RadioButton();
            this.RbFourthAnswer = new System.Windows.Forms.RadioButton();
            this.BtnSubmitQuiz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblQuestion
            // 
            resources.ApplyResources(this.LblQuestion, "LblQuestion");
            this.LblQuestion.Name = "LblQuestion";
            // 
            // BtnPreviousQuestion
            // 
            resources.ApplyResources(this.BtnPreviousQuestion, "BtnPreviousQuestion");
            this.BtnPreviousQuestion.Name = "BtnPreviousQuestion";
            this.BtnPreviousQuestion.UseVisualStyleBackColor = true;
            this.BtnPreviousQuestion.Click += new System.EventHandler(this.BtnPreviousQuestion_Click);
            // 
            // LblQuestionNumber
            // 
            resources.ApplyResources(this.LblQuestionNumber, "LblQuestionNumber");
            this.LblQuestionNumber.Name = "LblQuestionNumber";
            // 
            // BtnNextQuestion
            // 
            resources.ApplyResources(this.BtnNextQuestion, "BtnNextQuestion");
            this.BtnNextQuestion.Name = "BtnNextQuestion";
            this.BtnNextQuestion.UseVisualStyleBackColor = true;
            this.BtnNextQuestion.Click += new System.EventHandler(this.BtnNextQuestion_Click);
            // 
            // RbFirstAnswer
            // 
            resources.ApplyResources(this.RbFirstAnswer, "RbFirstAnswer");
            this.RbFirstAnswer.Name = "RbFirstAnswer";
            this.RbFirstAnswer.UseVisualStyleBackColor = true;
            // 
            // RbSecondAnswer
            // 
            resources.ApplyResources(this.RbSecondAnswer, "RbSecondAnswer");
            this.RbSecondAnswer.Name = "RbSecondAnswer";
            this.RbSecondAnswer.UseVisualStyleBackColor = true;
            // 
            // RbThirdAnswer
            // 
            resources.ApplyResources(this.RbThirdAnswer, "RbThirdAnswer");
            this.RbThirdAnswer.Name = "RbThirdAnswer";
            this.RbThirdAnswer.UseVisualStyleBackColor = true;
            // 
            // RbFourthAnswer
            // 
            resources.ApplyResources(this.RbFourthAnswer, "RbFourthAnswer");
            this.RbFourthAnswer.Name = "RbFourthAnswer";
            this.RbFourthAnswer.UseVisualStyleBackColor = true;
            // 
            // BtnSubmitQuiz
            // 
            resources.ApplyResources(this.BtnSubmitQuiz, "BtnSubmitQuiz");
            this.BtnSubmitQuiz.Name = "BtnSubmitQuiz";
            this.BtnSubmitQuiz.UseVisualStyleBackColor = true;
            this.BtnSubmitQuiz.Click += new System.EventHandler(this.BtnSubmitQuiz_Click);
            // 
            // StudentTakeQuizScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnSubmitQuiz);
            this.Controls.Add(this.RbFourthAnswer);
            this.Controls.Add(this.RbThirdAnswer);
            this.Controls.Add(this.RbSecondAnswer);
            this.Controls.Add(this.RbFirstAnswer);
            this.Controls.Add(this.BtnNextQuestion);
            this.Controls.Add(this.LblQuestionNumber);
            this.Controls.Add(this.BtnPreviousQuestion);
            this.Controls.Add(this.LblQuestion);
            this.Name = "StudentTakeQuizScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblQuestion;
        private System.Windows.Forms.Button BtnPreviousQuestion;
        private System.Windows.Forms.Label LblQuestionNumber;
        private System.Windows.Forms.Button BtnNextQuestion;
        private System.Windows.Forms.RadioButton RbFirstAnswer;
        private System.Windows.Forms.RadioButton RbSecondAnswer;
        private System.Windows.Forms.RadioButton RbThirdAnswer;
        private System.Windows.Forms.RadioButton RbFourthAnswer;
        private System.Windows.Forms.Button BtnSubmitQuiz;
    }
}