using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;


namespace scadatest
{
    public partial class Login : Form
    {
        public string DataToSend;
        private string _userName;
        private Main form1;
        private Register formRegister;

        private string defaultUsername = "admin";
        protected string defaultUserPassword = "admin";

        public Login()
        {
            InitializeComponent();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string HashPassword(string password)
        {
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

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txbEnterUserName.Text;
            string password = txbEnterPassword.Text;

            string hashedPassword = HashPassword(password);

            string filePath = "accounts.txt";
            bool isAuthenticated = false;

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts[0] == username && parts[1] == hashedPassword)
                        {
                            isAuthenticated = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file: {ex.Message}");
                return;
            }

            if (isAuthenticated)
            {
                MessageBox.Show("Đăng nhập thành công!");


                this.Hide() ;
                if (form1 == null)
                {
                    form1 = new Main(this); // Truyền tham chiếu của Form1 vào Form2
                }
                //form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            }
        }
        string path = "data.txt";
        bool enable = false;

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            if (formRegister == null || formRegister.IsDisposed)
            {
                formRegister = new Register();
            }

            formRegister.StartPosition = FormStartPosition.CenterScreen;
            formRegister.Location = this.Location;
            formRegister.ShowDialog();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

    

      
    }
}
