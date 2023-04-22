using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThinkArctBank.BusinessLogic;

namespace ThinkArctBank
{
    public partial class TransactHistory : UserControl
    {
        private static string historyAccount = String.Empty;
        private string firstDate = String.Empty;
        private string secondDate = String.Empty;
        private string date = String.Empty;
        private string description = String.Empty;
        private decimal? amount = null;
        private decimal? balance = null;
        private string balances = String.Empty;
        public TransactHistory()
        {
            InitializeComponent();
        }

        private void historyDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void searchHistory_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(Validation.delay);
            task.Start();
            if (Validation.HistoryValidation(historyAcct.Text))
            {
                historyMessage.ForeColor = Color.Red;
                historyMessage.Text = "Invalid account Number";
                return;
            };
            try
            {
                ConfigService._accountLogic.AccountNumberChecker(historyAcct.Text);
            }
            catch (Exception)
            {
                historyMessage.ForeColor = Color.Red;
                historyMessage.Text = "Account Number Not Found";
                return;
            }
            historyDataGrid.DataSource = null;
            historyMessage.ForeColor = Color.Green;
            historyMessage.Text = "Creating Transaction >>>>>>>>";
            firstDate = dateTimePicker1.Text;
            secondDate = dateTimePicker2.Text;
            await task;
            DataGridEmpty();
            DataTable myData = new DataTable();
            myData = ConfigService._transactionLogic.GetTransaction(historyAcct.Text, firstDate, secondDate);
            historyDataGrid.DataSource = myData;
            historyMessage.Text = String.Empty;
            historyAcct.Text = String.Empty;
        }

        private void DataGridEmpty()
        {
            date = String.Empty;
            description = String.Empty;
            amount = null;
            balance = null;
        }

        private void TransactHistory_Load(object sender, EventArgs e)
        {
            var currentUserId = Authentication.CurrentUser.Id;
            var accountNumbers = ConfigService._accountLogic.AddAccountToDropDown(currentUserId);
            historyAcct.DataSource = accountNumbers;

        }

        private void historyAcct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
