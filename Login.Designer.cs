namespace LibraryManagement
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            txtuserName = new TextBox();
            txtpassWord = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(173, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(414, 131);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(173, 149);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(71, 68);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.password_icon_1;
            pictureBox3.Location = new Point(173, 247);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(71, 59);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // txtuserName
            // 
            txtuserName.Location = new Point(276, 167);
            txtuserName.Name = "txtuserName";
            txtuserName.Size = new Size(302, 27);
            txtuserName.TabIndex = 3;
            // 
            // txtpassWord
            // 
            txtpassWord.Location = new Point(276, 257);
            txtpassWord.Name = "txtpassWord";
            txtpassWord.PasswordChar = '*';
            txtpassWord.Size = new Size(302, 27);
            txtpassWord.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(314, 315);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 64);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(446, 315);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 64);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtpassWord);
            Controls.Add(txtuserName);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Login";
            Text = "Login Form";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TextBox txtuserName;
        private TextBox txtpassWord;
        private Button btnLogin;
        private Button btnExit;
    }
}
