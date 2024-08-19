namespace scadatest
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            picBoxLogo = new PictureBox();
            picBoxUserName = new PictureBox();
            txbEnterUserName = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            txbEnterPassword = new TextBox();
            picBoxPassword = new PictureBox();
            btnSignIn = new Button();
            btnRegister = new Button();
            label1 = new Label();
            panel3 = new Panel();
            txbEnterEmail = new TextBox();
            picBoxEmail = new PictureBox();
            button1 = new Button();
            panelNotify = new Panel();
            panel4 = new Panel();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)picBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxUserName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxEmail).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // picBoxLogo
            // 
            picBoxLogo.BackColor = Color.Transparent;
            picBoxLogo.Image = (Image)resources.GetObject("picBoxLogo.Image");
            picBoxLogo.Location = new Point(161, 33);
            picBoxLogo.Name = "picBoxLogo";
            picBoxLogo.Size = new Size(80, 80);
            picBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxLogo.TabIndex = 0;
            picBoxLogo.TabStop = false;
            // 
            // picBoxUserName
            // 
            picBoxUserName.BackColor = Color.Transparent;
            picBoxUserName.Image = (Image)resources.GetObject("picBoxUserName.Image");
            picBoxUserName.Location = new Point(66, 192);
            picBoxUserName.Name = "picBoxUserName";
            picBoxUserName.Size = new Size(30, 30);
            picBoxUserName.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxUserName.TabIndex = 1;
            picBoxUserName.TabStop = false;
            // 
            // txbEnterUserName
            // 
            txbEnterUserName.BackColor = Color.Gainsboro;
            txbEnterUserName.Font = new Font("Microsoft Sans Serif", 11F);
            txbEnterUserName.ForeColor = Color.Black;
            txbEnterUserName.Location = new Point(104, 194);
            txbEnterUserName.Name = "txbEnterUserName";
            txbEnterUserName.Size = new Size(229, 28);
            txbEnterUserName.TabIndex = 3;
            txbEnterUserName.Text = "Username";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(66, 228);
            panel1.Name = "panel1";
            panel1.Size = new Size(271, 3);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Location = new Point(66, 306);
            panel2.Name = "panel2";
            panel2.Size = new Size(271, 3);
            panel2.TabIndex = 7;
            // 
            // txbEnterPassword
            // 
            txbEnterPassword.BackColor = Color.WhiteSmoke;
            txbEnterPassword.Font = new Font("Microsoft Sans Serif", 11F);
            txbEnterPassword.ForeColor = Color.Black;
            txbEnterPassword.Location = new Point(104, 267);
            txbEnterPassword.Name = "txbEnterPassword";
            txbEnterPassword.Size = new Size(229, 28);
            txbEnterPassword.TabIndex = 6;
            txbEnterPassword.Text = "Password";
            txbEnterPassword.UseSystemPasswordChar = true;
            // 
            // picBoxPassword
            // 
            picBoxPassword.BackColor = Color.Transparent;
            picBoxPassword.Image = (Image)resources.GetObject("picBoxPassword.Image");
            picBoxPassword.Location = new Point(66, 268);
            picBoxPassword.Name = "picBoxPassword";
            picBoxPassword.Size = new Size(30, 30);
            picBoxPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxPassword.TabIndex = 5;
            picBoxPassword.TabStop = false;
            // 
            // btnSignIn
            // 
            btnSignIn.BackColor = Color.FromArgb(78, 184, 206);
            btnSignIn.FlatAppearance.BorderSize = 0;
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.ForeColor = Color.FromArgb(34, 36, 49);
            btnSignIn.Location = new Point(66, 430);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(271, 48);
            btnSignIn.TabIndex = 8;
            btnSignIn.Text = "Login";
            btnSignIn.UseVisualStyleBackColor = false;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(34, 36, 49);
            btnRegister.FlatAppearance.BorderSize = 2;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 10F);
            btnRegister.ForeColor = SystemColors.Window;
            btnRegister.Location = new Point(66, 500);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(271, 48);
            btnRegister.TabIndex = 12;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(152, 548);
            label1.Name = "label1";
            label1.Size = new Size(89, 23);
            label1.TabIndex = 13;
            label1.Text = "Login with";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Location = new Point(66, 381);
            panel3.Name = "panel3";
            panel3.Size = new Size(271, 3);
            panel3.TabIndex = 10;
            // 
            // txbEnterEmail
            // 
            txbEnterEmail.BackColor = Color.FromArgb(34, 36, 49);
            txbEnterEmail.BorderStyle = BorderStyle.None;
            txbEnterEmail.Font = new Font("Microsoft Sans Serif", 11F);
            txbEnterEmail.ForeColor = Color.FloralWhite;
            txbEnterEmail.Location = new Point(104, 351);
            txbEnterEmail.Name = "txbEnterEmail";
            txbEnterEmail.Size = new Size(229, 21);
            txbEnterEmail.TabIndex = 9;
            txbEnterEmail.Text = "Email";
            // 
            // picBoxEmail
            // 
            picBoxEmail.BackColor = Color.Transparent;
            picBoxEmail.ErrorImage = (Image)resources.GetObject("picBoxEmail.ErrorImage");
            picBoxEmail.Image = (Image)resources.GetObject("picBoxEmail.Image");
            picBoxEmail.Location = new Point(66, 343);
            picBoxEmail.Name = "picBoxEmail";
            picBoxEmail.Size = new Size(30, 30);
            picBoxEmail.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxEmail.TabIndex = 8;
            picBoxEmail.TabStop = false;
            // 
            // button1
            // 
            button1.AllowDrop = true;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(355, 12);
            button1.Name = "button1";
            button1.Size = new Size(44, 29);
            button1.TabIndex = 15;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panelNotify
            // 
            panelNotify.Location = new Point(66, 128);
            panelNotify.Name = "panelNotify";
            panelNotify.Size = new Size(275, 63);
            panelNotify.TabIndex = 14;
            // 
            // panel4
            // 
            panel4.Controls.Add(checkBox1);
            panel4.Controls.Add(panelNotify);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(picBoxLogo);
            panel4.Location = new Point(0, -5);
            panel4.Name = "panel4";
            panel4.Size = new Size(394, 581);
            panel4.TabIndex = 16;
            panel4.Paint += panel4_Paint;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = SystemColors.ButtonHighlight;
            checkBox1.Location = new Point(67, 398);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(199, 24);
            checkBox1.TabIndex = 16;
            checkBox1.Text = "Nhớ Mật khẩu đăng nhập";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 36, 49);
            ClientSize = new Size(406, 582);
            Controls.Add(panel3);
            Controls.Add(txbEnterEmail);
            Controls.Add(picBoxEmail);
            Controls.Add(btnRegister);
            Controls.Add(btnSignIn);
            Controls.Add(panel2);
            Controls.Add(txbEnterPassword);
            Controls.Add(panel1);
            Controls.Add(picBoxPassword);
            Controls.Add(txbEnterUserName);
            Controls.Add(picBoxUserName);
            Controls.Add(panel4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)picBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxUserName).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxEmail).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picBoxLogo;
        private PictureBox picBoxUserName;
        private TextBox txbEnterUserName;
        private Panel panel1;
        private Panel panel2;
        private TextBox txbEnterPassword;
        private PictureBox picBoxPassword;
        private Button btnSignIn;
        private Button btnRegister;
        private Label label1;
        private Panel panel3;
        private TextBox txbEnterEmail;
        private PictureBox picBoxEmail;
        private Button button1;
        private Panel panelNotify;
        private Panel panel4;
        private CheckBox checkBox1;
    }
}