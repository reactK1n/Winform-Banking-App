using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThinkArctBank.BusinessLogic;

namespace ThinkArctBank
{
    public partial class SignUpPage : Form
    {
        public  static string fullName = String.Empty;
        public  static string userName = String.Empty;
        public  static string passWord = String.Empty;
        private Validation validate = new Validation();

        public SignUpPage()
        {
            InitializeComponent();
        }

        private void NavigateToLogin()
        {
            LoginPage navigateToLoginPage = new LoginPage();
            navigateToLoginPage.Show();
            this.Dispose();
        }
        private void loginMenu_Click(object sender, EventArgs e)
        {
            NavigateToLogin();
        }

        private async void signUpBtn_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(Validation.delay);
            task.Start();
            fullName = $"{lastname.Text} {firstname.Text}";
            userName = usernameSU.Text;
            passWord = passwordSU.Text;
            string validateBoolean = validate.signUpValidation(lastname.Text, firstname.Text, userName, passWord,
                accountTypeSU.Text, signUpValidationMessage.Text)[0];
            string validateMessage = validate.signUpValidation(lastname.Text, firstname.Text, userName, passWord,
                accountTypeSU.Text, signUpValidationMessage.Text)[1];
            if (validateBoolean == "true")
            {
                signUpValidationMessage.ForeColor = Color.Red;
                signUpValidationMessage.Text = validateMessage;
                return;
            }
            List<string> userData = new List<string> { userName, passWord, fullName};

            ConfigService._authentication.UserSignUp(userName, fullName, passWord, accountTypeSU.Text);

            Empty();
            signUpValidationMessage.ForeColor = Color.Green;
            signUpValidationMessage.Text = "Login Successful";
            await task;
            NavigateToLogin();
            

        }
        private void signUpPageExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public void Empty()
        {
            lastname.Text = String.Empty;
            firstname.Text = String.Empty;
            usernameSU.Text = String.Empty;
            passwordSU.Text = String.Empty;
        }

        private void SignUpPage_Load(object sender, EventArgs e)
        {

        }
    }
}
