using System.Data.SqlClient;
using System.Data;

namespace LibraryManagement


{
    public partial class Login : Form
    {
        SqlConnection connection;
        public Login() 
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=DESKTOP-7L2SU06\SQLEXPRESS01;Initial Catalog=ASM2;Integrated Security=True;");


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtuserName.Text.Trim();
            string password = txtpassWord.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtuserName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpassWord.Focus();
                return;
            }

            string validUsername = "admin";
            string validPassword = "12345";

            if (username != validUsername)
            {
                MessageBox.Show("Invalid username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtuserName.Focus();
                return;
            }
            if (password != validPassword)
            {
                MessageBox.Show("Invalid username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpassWord.Focus();
                return;
            }
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
