namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_course = new Label();
            cmb_course = new ComboBox();
            btn_refresh = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lbl_course
            // 
            lbl_course.AutoSize = true;
            lbl_course.Location = new Point(15, 18);
            lbl_course.Name = "lbl_course";
            lbl_course.Size = new Size(47, 15);
            lbl_course.TabIndex = 0;
            lbl_course.Text = "Course:";
            // 
            // cmb_course
            // 
            cmb_course.FormattingEnabled = true;
            cmb_course.Location = new Point(65, 15);
            cmb_course.Name = "cmb_course";
            cmb_course.Size = new Size(271, 23);
            cmb_course.TabIndex = 1;
            cmb_course.SelectedIndexChanged += cmb_course_SelectedIndexChanged;
            // 
            // btn_refresh
            // 
            btn_refresh.Location = new Point(350, 15);
            btn_refresh.Name = "btn_refresh";
            btn_refresh.Size = new Size(75, 23);
            btn_refresh.TabIndex = 2;
            btn_refresh.Text = "Refresh Database";
            btn_refresh.UseVisualStyleBackColor = true;
            btn_refresh.Click += btn_refresh_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 50);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 3;
            label1.Text = "Students On Course:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(443, 274);
            Controls.Add(label1);
            Controls.Add(btn_refresh);
            Controls.Add(cmb_course);
            Controls.Add(lbl_course);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_course;
        private ComboBox cmb_course;
        private Button btn_refresh;
        private Label label1;
    }
}
