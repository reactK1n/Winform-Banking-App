using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThinkArctBank.BusinessLogic;

namespace ThinkArctBank
{
    public partial class LoginPage : Form
    {
        public static string userName = String.Empty;
        public static string passWord = String.Empty;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void signUpMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpPage navigateToSignUp = new SignUpPage();
            navigateToSignUp.Show();

        }

        private void NavigateToAccount()
        {
            Home navigateToHomePage = new Home();
            navigateToHomePage.Show();
        }


        private async void loginBtn_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(Validation.delay);
            task.Start();
            userName = usernameLogin.Text;
            passWord = passwordLogin.Text;
            try
            {
                if (Validation.LoginValidationMessage(userName, passWord))
                {
                    loginValidationMessage.ForeColor = Color.Red;
                    loginValidationMessage.Text = "Invalid Username or Password";
                    return;
                }

                if (string.IsNullOrEmpty(ConfigService._authentication.Login(userName, passWord).FullName))
                {

                    loginValidationMessage.ForeColor = Color.Red;
                    loginValidationMessage.Text = "Invalid Username or Password";
                    return;

                }

            }
            catch (Exception ex)
            {
                loginValidationMessage.ForeColor = Color.Red;
                loginValidationMessage.Text = "Invalid Username or Password";
                return;
            }

            usernameLogin.Text = string.Empty;
            passwordLogin.Text = string.Empty;
            loginValidationMessage.ForeColor = Color.Green;
            loginValidationMessage.Text = "Login Successfull";
            await task;
            NavigateToAccount();
            this.Hide();
        }

        private void loginPageExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
