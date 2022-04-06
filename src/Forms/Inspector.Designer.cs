namespace PasManPC.Forms
{
    partial class Inspector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inspector));
            this.nameBox = new System.Windows.Forms.TextBox();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.passBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.discard = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.NameChecker = new System.Windows.Forms.Button();
            this.closebutt = new System.Windows.Forms.Button();
            this.hidePassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(12, 60);
            this.nameBox.MaxLength = 128;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(261, 20);
            this.nameBox.TabIndex = 0;
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(12, 167);
            this.loginBox.MaxLength = 128;
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(261, 20);
            this.loginBox.TabIndex = 1;
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(12, 312);
            this.passBox.MaxLength = 128;
            this.passBox.Name = "passBox";
            this.passBox.Size = new System.Drawing.Size(261, 20);
            this.passBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "password";
            // 
            // discard
            // 
            this.discard.Location = new System.Drawing.Point(360, 167);
            this.discard.Name = "discard";
            this.discard.Size = new System.Drawing.Size(75, 23);
            this.discard.TabIndex = 7;
            this.discard.Text = "Discard";
            this.discard.UseVisualStyleBackColor = true;
            this.discard.Click += new System.EventHandler(this.discard_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(360, 267);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 8;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // NameChecker
            // 
            this.NameChecker.Location = new System.Drawing.Point(360, 60);
            this.NameChecker.Name = "NameChecker";
            this.NameChecker.Size = new System.Drawing.Size(75, 48);
            this.NameChecker.TabIndex = 9;
            this.NameChecker.Text = "Check Name";
            this.NameChecker.UseVisualStyleBackColor = true;
            this.NameChecker.Click += new System.EventHandler(this.NameChecker_Click);
            // 
            // closebutt
            // 
            this.closebutt.Location = new System.Drawing.Point(360, 354);
            this.closebutt.Name = "closebutt";
            this.closebutt.Size = new System.Drawing.Size(75, 23);
            this.closebutt.TabIndex = 10;
            this.closebutt.Text = "Close";
            this.closebutt.UseVisualStyleBackColor = true;
            this.closebutt.Click += new System.EventHandler(this.closebutt_Click);
            // 
            // hidePassword
            // 
            this.hidePassword.Location = new System.Drawing.Point(12, 399);
            this.hidePassword.Name = "hidePassword";
            this.hidePassword.Size = new System.Drawing.Size(261, 23);
            this.hidePassword.TabIndex = 6;
            this.hidePassword.Text = "Hide password";
            this.hidePassword.UseVisualStyleBackColor = true;
            this.hidePassword.Click += new System.EventHandler(this.hidePassword_Click);
            // 
            // Inspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.closebutt);
            this.Controls.Add(this.NameChecker);
            this.Controls.Add(this.save);
            this.Controls.Add(this.discard);
            this.Controls.Add(this.hidePassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.nameBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inspector";
            this.Text = "Inspector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button discard;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button NameChecker;
        private System.Windows.Forms.Button closebutt;
        private System.Windows.Forms.Button hidePassword;
    }
}