namespace PHOTOCENTER
{
    partial class FormAddDiller
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
            this.textBoxNameDiller = new System.Windows.Forms.TextBox();
            this.textBoxPhoneDiller = new System.Windows.Forms.TextBox();
            this.textBoxProduct = new System.Windows.Forms.TextBox();
            this.textBoxAddres = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNameDiller
            // 
            this.textBoxNameDiller.Location = new System.Drawing.Point(68, 57);
            this.textBoxNameDiller.Name = "textBoxNameDiller";
            this.textBoxNameDiller.Size = new System.Drawing.Size(184, 20);
            this.textBoxNameDiller.TabIndex = 0;
            this.textBoxNameDiller.Text = "Введите имя диллера";
            this.textBoxNameDiller.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBoxNameDiller.Leave += new System.EventHandler(this.login_textBox_Leave);
            // 
            // textBoxPhoneDiller
            // 
            this.textBoxPhoneDiller.Location = new System.Drawing.Point(68, 100);
            this.textBoxPhoneDiller.Name = "textBoxPhoneDiller";
            this.textBoxPhoneDiller.Size = new System.Drawing.Size(184, 20);
            this.textBoxPhoneDiller.TabIndex = 1;
            this.textBoxPhoneDiller.Text = "Введите номер телефона диллера";
            this.textBoxPhoneDiller.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBoxPhoneDiller.Leave += new System.EventHandler(this.login_textBox_Leave);
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.Location = new System.Drawing.Point(68, 142);
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.Size = new System.Drawing.Size(184, 20);
            this.textBoxProduct.TabIndex = 2;
            this.textBoxProduct.Text = "Введите продукт диллера";
            this.textBoxProduct.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBoxProduct.Leave += new System.EventHandler(this.login_textBox_Leave);
            // 
            // textBoxAddres
            // 
            this.textBoxAddres.Location = new System.Drawing.Point(68, 189);
            this.textBoxAddres.Name = "textBoxAddres";
            this.textBoxAddres.Size = new System.Drawing.Size(184, 20);
            this.textBoxAddres.TabIndex = 3;
            this.textBoxAddres.Text = "Введите адрес диллера";
            this.textBoxAddres.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBoxAddres.Leave += new System.EventHandler(this.login_textBox_Leave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Добавить диллера";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAddDiller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 373);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxAddres);
            this.Controls.Add(this.textBoxProduct);
            this.Controls.Add(this.textBoxPhoneDiller);
            this.Controls.Add(this.textBoxNameDiller);
            this.Name = "FormAddDiller";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNameDiller;
        private System.Windows.Forms.TextBox textBoxPhoneDiller;
        private System.Windows.Forms.TextBox textBoxProduct;
        private System.Windows.Forms.TextBox textBoxAddres;
        private System.Windows.Forms.Button button1;
    }
}