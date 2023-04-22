using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThinkArctBank.BusinessLogic;


namespace ThinkArctBank
{
    public partial class Home : Form
    {
        public static string accountType = string.Empty;
        public static decimal amount = 0;
        private string balances;




        public Home()
        {
            InitializeComponent();
        }

        private void accounttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            accountType = accounttype.Text;
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            btnColorChanger(homeBtn);
            CloseCheckBalance();
        }
        private void transactionBtn_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            btnColorChanger(transactionBtn);
            CloseCheckBalance();
        }

        private void transHistoryBtn_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            btnColorChanger(transHistoryBtn);
            CloseCheckBalance();
        }
        private void CreateAccBtn_Click(object sender, EventArgs e)
        {
            btnColorChanger(CreateAccBtn);
            CloseCheckBalance();
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            LoginPage logout = new LoginPage();
            logout.Show();
            this.Dispose();
        }

        private async void createAccountBtn_Click(object sender, EventArgs e)
        {

            Task<int> task = new Task<int>(Validation.delay);
            task.Start();
            if (newDeposit.Text == string.Empty)
            {
                amount = 0;
            }
            else
            {
                amount = Convert.ToDecimal(newDeposit.Text);
            }
            if (Validation.CreateAccountValidation(accountType, amount.ToString()))
            {
                creating.ForeColor = Color.Red;
                creating.Text = "Invalid account type or deposit.......";
                return;
            }
            var user = Authentication.CurrentUser;
            ConfigService._accountLogic.CreateAccount(accountType, amount, user.Id);
            Empty();
            creating.ForeColor = Color.DarkBlue;
            creating.Text = "creating Account......";
            await task;
            creating.Text = string.Empty;
            var data = ConfigService._accountLogic.GetAccountDetails(user.Id);
            createAccDataGrid.DataSource = data;

        }

        private void createPageExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Empty()
        {
            accountType = String.Empty;
            accounttype.Text = String.Empty;
            newDeposit.Text = String.Empty;
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            var accNo = balanceAccNo.Text;
            decimal balance = 0;
            if (balanceAccNo.Text == String.Empty)
            {
                showBalance.ForeColor = Color.Red;
                showBalance.Text = "Account Not Found!";
                return;
            }
            try
            {
                balance = ConfigService._accountLogic.Balance(accNo);

            }
            catch (Exception)
            {
                showBalance.ForeColor = Color.Red;
                showBalance.Text = "Account Not Found!";
                return;
            }
            showBalance.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            showBalance.Text = balance.ToString();
        }

        private int count = 0;
        private void checkBalance_Click(object sender, EventArgs e)
        {
            var currentUserId = Authentication.CurrentUser.Id;
            var accountNumbers = ConfigService._accountLogic.AddAccountToDropDown(currentUserId);
            balanceAccNo.DataSource = accountNumbers;
            count++;
            if (count == 1 || count % 2 != 0)
            {
                checkBalance.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                checkBalance.ForeColor = Color.White;
                OpenCheckBalance();
            }

            if (count % 2 == 0)
            {
                checkBalance.BackColor = Color.White;
                checkBalance.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                CloseCheckBalance();
            }
        }

        public void OpenCheckBalance()
        {
            createAccBalanceForm.Visible = true;
            balanceAccNo.Visible = true;
            showBalance.Visible = true;
            acclbl.Visible = true;
            btnBalance.Visible = true;
        }

        public void CloseCheckBalance()
        {
            createAccBalanceForm.Visible = false;
            balanceAccNo.Visible = false;
            showBalance.Visible = false;
            acclbl.Visible = false;
            btnBalance.Visible = false;
        }


        private void CreateAccount_Load(object sender, EventArgs e)
        {
        }

        private void mainUI_Load(object sender, EventArgs e)
        {

        }

        public void btnColorChanger(Button btn)
        {
            transHistoryBtn.BackColor = Color.White;
            transHistoryBtn.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            CreateAccBtn.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            CreateAccBtn.BackColor = Color.White;
            transactionBtn.BackColor = Color.White;
            transactionBtn.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            homeBtn.BackColor = Color.White;
            homeBtn.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            btn.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            btn.ForeColor = Color.White;

            if (btn == homeBtn)
            {
                transactionUC.Visible = false;
                transactHistoryUC.Visible = false;
                mainUI.BringToFront();
                mainUI.Visible = true;
            }

            if (btn == transHistoryBtn)
            {
                transactHistoryUC.BringToFront();
                mainUI.Visible = false;
                transactHistoryUC.Visible = true;
            }

            if (btn == CreateAccBtn)
            {
                mainUI.Visible = false;
                transactionUC.Visible = false;
                transactHistoryUC.Visible = false;
                var user = Authentication.CurrentUser;
                var data = ConfigService._accountLogic.GetAccountDetails(user.Id);
                createAccDataGrid.DataSource = data;
            }

            if (btn == transactionBtn)
            {

                transactionUC.BringToFront();
                mainUI.Visible = false;
                transactionUC.Visible = true;
            }
            createPageExit.BringToFront();
        }

        private void transactHistoryUC_Load(object sender, EventArgs e)
        {

        }
    }
}
