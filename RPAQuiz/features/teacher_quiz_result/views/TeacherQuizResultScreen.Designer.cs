namespace RPAQuiz.features.teacher_quiz_result.views
{
    partial class TeacherQuizResultScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherQuizResultScreen));
            this.QuizesDataGridView = new System.Windows.Forms.DataGridView();
            this.BtnViewResults = new System.Windows.Forms.Button();
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
            // BtnViewResults
            // 
            resources.ApplyResources(this.BtnViewResults, "BtnViewResults");
            this.BtnViewResults.Name = "BtnViewResults";
            this.BtnViewResults.UseVisualStyleBackColor = true;
            this.BtnViewResults.Click += new System.EventHandler(this.BtnViewResults_Click);
            // 
            // TeacherQuizOverviewScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnViewResults);
            this.Controls.Add(this.QuizesDataGridView);
            this.Name = "TeacherQuizOverviewScreen";
            ((System.ComponentModel.ISupportInitialize)(this.QuizesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView QuizesDataGridView;
        private System.Windows.Forms.Button BtnViewResults;
    }
}