using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThinkArctBank.BusinessLogic;

namespace ThinkArctBank
{
    public partial class TransactionsControl : UserControl
    {

        public static string senderAccount = String.Empty;
        public static string recipientAccount = String.Empty;
        public static string recipientAccName = String.Empty;
        public static string descriptions = String.Empty;
        private static decimal amount = 0;
        private Validation validate = new Validation();
        public TransactionsControl()
        {
            InitializeComponent();
        }




        private void navWithdraw_Click(object sender, EventArgs e)
        {
            withdrawForm.Visible = true;
            depositForm.Visible = false;
            transferForm.Visible = false;
        }

        private void navDeposit_Click(object sender, EventArgs e)
        {
            withdrawForm.Visible = false;
            depositForm.Visible = true;
            transferForm.Visible = false;
        }

        private void recipientName_TextChanged(object sender, EventArgs e)
        {
            string recipientAccountName = ConfigService._authentication.GetAccountName(recipientAcc.Text);
            recipientName.Text = recipientAccountName;
        }

        private async void send_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(Validation.delay);
            task.Start();
            string validateBoolean = validate.TransferValidation(transferMessage.Text, transferAmount.Text, recipientAcc.Text, senderAcc.Text)[0];
            string validateMessage = validate.TransferValidation(transferMessage.Text, transferAmount.Text, recipientAcc.Text, senderAcc.Text)[1];

            if (string.IsNullOrEmpty(ConfigService._accountLogic.AccountNumberChecker(senderAcc.Text)))
            {
                transferMessage.ForeColor = Color.Red;
                transferMessage.Text = " Sender Account Number Not Found";
                return;
            }

            if (validateBoolean == "true")
            {
                transferMessage.ForeColor = Color.Red;
                transferMessage.Text = validateMessage;
                return;
            }

            try
            {
                if (ConfigService._accountLogic.Balance(senderAcc.Text) < Convert.ToDecimal(transferAmount.Text))
                {
                    transferMessage.ForeColor = Color.Red;
                    transferMessage.Text = "insufficient Balance";
                    return;
                }

            }
            catch (Exception)
            {
                transferMessage.ForeColor = Color.Red;
                transferMessage.Text = "Account Number Not Found";
                return;
            }
            if (string.IsNullOrEmpty(ConfigService._accountLogic.AccountNumberChecker(recipientAcc.Text)))
            {
                transferMessage.ForeColor = Color.Red;
                transferMessage.Text = " Recipient Account Number Not Found";
                return;
            }
            amount = Convert.ToDecimal(transferAmount.Text);
            ConfigService._transactionLogic.Transfer(senderAcc.Text, Convert.ToDecimal(transferAmount.Text), recipientAcc.Text, recipientName.Text, description.Text);
            EmptyTxtBox();
            transferMessage.ForeColor = Color.Green;
            transferMessage.Text = "Login Successful";
            await task;
            transferMessage.Text = String.Empty;
        }

        private void withdrawNav_Click(object sender, EventArgs e)
        {
            withdrawForm.Visible = true;
            depositForm.Visible = false;
            transferForm.Visible = false;
        }

        private void transferNav_Click(object sender, EventArgs e)
        {
            withdrawForm.Visible = false;
            depositForm.Visible = false;
            transferForm.Visible = true;
        }

        private async void depoForm_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(Validation.delay);
            task.Start();

            if (string.IsNullOrEmpty(ConfigService._accountLogic.AccountNumberChecker(depoAccNo.Text)))
            {
                depositMessage.ForeColor = Color.Red;
                depositMessage.Text = "Account Number Not Found";
                return;
            }
            string validateBoolean = validate.DepositValidation(depositMessage.Text, depoAmount.Text, depoAccNo.Text)[0];
            string validateMessage = validate.DepositValidation(depositMessage.Text, depoAmount.Text, depoAccNo.Text)[1];
            if (validateBoolean == "true")
            {
                depositMessage.ForeColor = Color.Red;
                depositMessage.Text = validateMessage;
                return;
            }
            amount = Convert.ToDecimal(depoAmount.Text);
            ConfigService._transactionLogic.Deposit(depoAccNo.Text, Convert.ToDecimal(depoAmount.Text));
            EmptyTxtBox();
            depositMessage.ForeColor = Color.Green;
            depositMessage.Text = "Login Successful";
            await task;
            depositMessage.Text = String.Empty;
        }

        private void transNav_Click(object sender, EventArgs e)
        {
            withdrawForm.Visible = false;
            depositForm.Visible = false;
            transferForm.Visible = true;
        }

        private void depositNav_Click(object sender, EventArgs e)
        {
            withdrawForm.Visible = false;
            depositForm.Visible = true;
            transferForm.Visible = false;
        }

        private async void withdrawBtn_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(Validation.delay);
            task.Start();
            if (string.IsNullOrEmpty(ConfigService._accountLogic.AccountNumberChecker(withdrawAccNo.Text)))
            {
                withdrawMessage.ForeColor = Color.Red;
                withdrawMessage.Text = "Account Number Not Found";
                return;
            }
            string validateBoolean = validate.WithdrawValidation(withdrawMessage.Text, withdrawAmount.Text, withdrawAccNo.Text)[0];
            string validateMessage = validate.WithdrawValidation(withdrawMessage.Text, withdrawAmount.Text, withdrawAccNo.Text)[1];
            if (validateBoolean == "true")
            {
                withdrawMessage.ForeColor = Color.Red;
                withdrawMessage.Text = validateMessage;
                return;
            }

            try
            {

                if (ConfigService._accountLogic.Balance(withdrawAccNo.Text) < Convert.ToDecimal(withdrawAmount.Text))
                {
                    withdrawMessage.ForeColor = Color.Red;
                    withdrawMessage.Text = "insufficient Balance";
                    return;
                }

            }
            catch (Exception)
            {
                withdrawMessage.ForeColor = Color.Red;
                withdrawMessage.Text = "Account Number Not Found";
                return;
            }
            amount = Convert.ToDecimal(withdrawAmount.Text);
            ConfigService._transactionLogic.Withdraw(withdrawAccNo.Text, Convert.ToDecimal(withdrawAmount.Text));
            EmptyTxtBox();
            withdrawMessage.ForeColor = Color.Green;
            withdrawMessage.Text = "Login Successful";
            await task;
            withdrawMessage.Text = String.Empty;
        }

        private void EmptyTxtBox()
        {
            senderAcc.Text = String.Empty;
            withdrawAccNo.Text = String.Empty;
            depoAccNo.Text = String.Empty;
            transferAmount.Text = String.Empty;
            withdrawAmount.Text = String.Empty;
            depoAmount.Text = String.Empty;
            recipientAcc.Text = null;
            recipientName.Text = string.Empty;
            description.Text = null;
        }
        private void TransactionsControl_Load(object sender, EventArgs e)
        {
            var currentUserId = Authentication.CurrentUser.Id;
            var accountNumbers = ConfigService._accountLogic.AddAccountToDropDown(currentUserId);
            senderAcc.DataSource = accountNumbers;
            depoAccNo.DataSource = accountNumbers;
            withdrawAccNo.DataSource = accountNumbers;
        }
    }
}
