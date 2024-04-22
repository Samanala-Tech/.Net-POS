namespace BeautyBoutiquePOS_TransactionsPage.UserControls.SubControls
{
    partial class addToCart
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
            this.label1 = new System.Windows.Forms.Label();
            this.textProduct = new System.Windows.Forms.TextBox();
            this.productGridView = new System.Windows.Forms.DataGridView();
            this.textQTY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prduct Name Or Code";
            // 
            // textProduct
            // 
            this.textProduct.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textProduct.Location = new System.Drawing.Point(130, 9);
            this.textProduct.Name = "textProduct";
            this.textProduct.Size = new System.Drawing.Size(348, 29);
            this.textProduct.TabIndex = 24;
            this.textProduct.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // productGridView
            // 
            this.productGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productGridView.Location = new System.Drawing.Point(0, 46);
            this.productGridView.Name = "productGridView";
            this.productGridView.Size = new System.Drawing.Size(802, 355);
            this.productGridView.TabIndex = 25;
            // 
            // textQTY
            // 
            this.textQTY.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textQTY.Location = new System.Drawing.Point(536, 8);
            this.textQTY.Name = "textQTY";
            this.textQTY.Size = new System.Drawing.Size(250, 29);
            this.textQTY.TabIndex = 26;
            this.textQTY.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "QTY";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(697, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 31);
            this.button1.TabIndex = 28;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textQTY);
            this.Controls.Add(this.productGridView);
            this.Controls.Add(this.textProduct);
            this.Controls.Add(this.label1);
            this.Name = "product";
            this.Text = "product";
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textProduct;
        private System.Windows.Forms.DataGridView productGridView;
        private System.Windows.Forms.TextBox textQTY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}