namespace RPAQuiz.features.student_quizes_overview.views
{
    partial class StudentQuizesOverviewScreen
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
            this.QuizesDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
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
            this.QuizesDataGridView.Location = new System.Drawing.Point(73, 57);
            this.QuizesDataGridView.Name = "QuizesDataGridView";
            this.QuizesDataGridView.ReadOnly = true;
            this.QuizesDataGridView.RowHeadersVisible = false;
            this.QuizesDataGridView.Size = new System.Drawing.Size(421, 280);
            this.QuizesDataGridView.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(596, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StudentQuizesOverviewScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.QuizesDataGridView);
            this.Name = "StudentQuizesOverviewScreen";
            this.Text = "StudentQuizesOverviewScreen";
            ((System.ComponentModel.ISupportInitialize)(this.QuizesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView QuizesDataGridView;
        private System.Windows.Forms.Button button1;
    }
}