﻿namespace BeautyBoutiquePOS_TransactionsPage.UserControls.SubControls
{
    partial class newCategory
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCategoryName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxCategoryDescription = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(592, 381);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(196, 57);
            this.saveBtn.TabIndex = 12;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label3.Location = new System.Drawing.Point(199, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name";
            // 
            // textBoxCategoryName
            // 
            this.textBoxCategoryName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCategoryName.Location = new System.Drawing.Point(267, 129);
            this.textBoxCategoryName.Name = "textBoxCategoryName";
            this.textBoxCategoryName.Size = new System.Drawing.Size(297, 33);
            this.textBoxCategoryName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label1.Location = new System.Drawing.Point(153, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Description";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 67);
            this.panel1.TabIndex = 15;
            // 
            // textBoxCategoryDescription
            // 
            this.textBoxCategoryDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCategoryDescription.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.textBoxCategoryDescription.Location = new System.Drawing.Point(267, 217);
            this.textBoxCategoryDescription.Name = "textBoxCategoryDescription";
            this.textBoxCategoryDescription.Size = new System.Drawing.Size(297, 101);
            this.textBoxCategoryDescription.TabIndex = 16;
            this.textBoxCategoryDescription.Text = "";
            // 
            // newCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxCategoryDescription);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCategoryName);
            this.Name = "newCategory";
            this.Text = "newCategory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCategoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox textBoxCategoryDescription;
    }
}