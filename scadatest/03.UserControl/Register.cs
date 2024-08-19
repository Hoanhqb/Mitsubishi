using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace scadatest
{
    public partial class Register : Form
    {
        // Form cominication
        Login formLogin;
        // Xử lý sự kiện Đăng Ký
        string username = string.Empty;
        string password = string.Empty;

        public Register()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Font = new Font(checkBox1.Font, FontStyle.Bold);
                checkBox1.Font = new Font(checkBox1.Font, FontStyle.Underline);
            }



        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            if (formLogin == null || formLogin.Disposing)
            {
                formLogin = new Login();

            }
            formLogin.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (formLogin == null || formLogin.Disposing)
            {
                formLogin = new Login();
                this.Close();
            }
            this.Close();
            formLogin.ShowDialog();
        }
        //  bool passwordcheck ;
        private bool CheckReapeatPassword(string password, string repeatpassword)
        {
            if (password == repeatpassword)
            {
                return true;
            }
            return false;
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {

            if (!CheckReapeatPassword(txbNewPassWord.Text, txbRepeatPassWord.Text))
            {
                lbNotifyRepeatNewPassword.Text = "Mật khẩu xác nhận không đúng";
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
            }
            username = txbEnterUserName.Text;
            password = txbNewPassWord.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }

            // Đường dẫn đến file lưu thông tin tài khoản
            string filePath = "accounts.txt";

            // Kiểm tra tên đăng nhập đã tồn tại
            if (IsUsernameExists(username, filePath))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.");
                return;
            }

            // Mã hóa mật khẩu trước khi lưu trữ
            string hashedPassword = HashPassword(password);

            // Lưu thông tin vào file
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{username},{hashedPassword}");
            }

            MessageBox.Show("Đăng ký thành công!");
            this.Close();
            if (formLogin == null || formLogin.Disposing)
            {
                formLogin = new Login();

            }
            formLogin.ShowDialog();
        }
        //
        private bool IsUsernameExists(string username, string filePath)
        {
            // Kiểm tra xem tên đăng nhập đã tồn tại trong file chưa
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts[0] == username)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private string HashPassword(string password)
        {
            // Hàm mã hóa mật khẩu (ví dụ sử dụng SHA256)
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
