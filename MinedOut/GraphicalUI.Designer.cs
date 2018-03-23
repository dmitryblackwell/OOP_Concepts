namespace OOP_Concepts.MinedOut
{
    partial class GraphicalUI
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.ratingBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.saveBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.saveBtn.Location = new System.Drawing.Point(462, 57);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(72, 31);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.loadBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.loadBtn.Location = new System.Drawing.Point(462, 103);
            this.loadBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(72, 31);
            this.loadBtn.TabIndex = 1;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = false;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.createBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.createBtn.Location = new System.Drawing.Point(462, 11);
            this.createBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(72, 31);
            this.createBtn.TabIndex = 2;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = false;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // ratingBtn
            // 
            this.ratingBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ratingBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.ratingBtn.Location = new System.Drawing.Point(462, 152);
            this.ratingBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ratingBtn.Name = "ratingBtn";
            this.ratingBtn.Size = new System.Drawing.Size(72, 31);
            this.ratingBtn.TabIndex = 3;
            this.ratingBtn.Text = "Rating";
            this.ratingBtn.UseVisualStyleBackColor = false;
            this.ratingBtn.Click += new System.EventHandler(this.ratingBtn_Click);
            // 
            // GraphicalUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(556, 470);
            this.Controls.Add(this.ratingBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GraphicalUI";
            this.Text = "GraphicalUI";
            this.Load += new System.EventHandler(this.GraphicalUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button ratingBtn;
    }
}