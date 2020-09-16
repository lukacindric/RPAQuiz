namespace RPAQuiz.features.teacher_quizes_overview.views
{
    partial class TeacherQuizesOverviewScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherQuizesOverviewScreen));
            this.QuizesDataGridView = new System.Windows.Forms.DataGridView();
            this.BtnCreateQuiz = new System.Windows.Forms.Button();
            this.BtnEditQuiz = new System.Windows.Forms.Button();
            this.BtnDeleteQuiz = new System.Windows.Forms.Button();
            this.BtnCheckResults = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuizesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // QuizesDataGridView
            // 
            this.QuizesDataGridView.AllowUserToAddRows = false;
            this.QuizesDataGridView.AllowUserToDeleteRows = false;
            this.QuizesDataGridView.AllowUserToResizeColumns = false;
            this.QuizesDataGridView.AllowUserToResizeRows = false;
            this.QuizesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.QuizesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.QuizesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.QuizesDataGridView, "QuizesDataGridView");
            this.QuizesDataGridView.Name = "QuizesDataGridView";
            this.QuizesDataGridView.ReadOnly = true;
            this.QuizesDataGridView.RowHeadersVisible = false;
            // 
            // BtnCreateQuiz
            // 
            resources.ApplyResources(this.BtnCreateQuiz, "BtnCreateQuiz");
            this.BtnCreateQuiz.Name = "BtnCreateQuiz";
            this.BtnCreateQuiz.UseVisualStyleBackColor = true;
            this.BtnCreateQuiz.Click += new System.EventHandler(this.BtnCreateQuiz_Click);
            // 
            // BtnEditQuiz
            // 
            resources.ApplyResources(this.BtnEditQuiz, "BtnEditQuiz");
            this.BtnEditQuiz.Name = "BtnEditQuiz";
            this.BtnEditQuiz.UseVisualStyleBackColor = true;
            this.BtnEditQuiz.Click += new System.EventHandler(this.BtnEditQuiz_Click);
            // 
            // BtnDeleteQuiz
            // 
            resources.ApplyResources(this.BtnDeleteQuiz, "BtnDeleteQuiz");
            this.BtnDeleteQuiz.Name = "BtnDeleteQuiz";
            this.BtnDeleteQuiz.UseVisualStyleBackColor = true;
            this.BtnDeleteQuiz.Click += new System.EventHandler(this.BtnDeleteQuiz_Click);
            // 
            // BtnCheckResults
            // 
            resources.ApplyResources(this.BtnCheckResults, "BtnCheckResults");
            this.BtnCheckResults.Name = "BtnCheckResults";
            this.BtnCheckResults.UseVisualStyleBackColor = true;
            this.BtnCheckResults.Click += new System.EventHandler(this.BtnCheckResults_Click);
            // 
            // TeacherQuizesOverviewScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnCheckResults);
            this.Controls.Add(this.BtnDeleteQuiz);
            this.Controls.Add(this.BtnEditQuiz);
            this.Controls.Add(this.BtnCreateQuiz);
            this.Controls.Add(this.QuizesDataGridView);
            this.Name = "TeacherQuizesOverviewScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeacherQuizesOverviewScreen_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.QuizesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView QuizesDataGridView;
        private System.Windows.Forms.Button BtnCreateQuiz;
        private System.Windows.Forms.Button BtnEditQuiz;
        private System.Windows.Forms.Button BtnDeleteQuiz;
        private System.Windows.Forms.Button BtnCheckResults;
    }
}