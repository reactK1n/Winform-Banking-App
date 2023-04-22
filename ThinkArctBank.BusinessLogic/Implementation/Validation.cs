using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using ThinkArctBank.DataBase;

namespace ThinkArctBank.BusinessLogic
{
    public class Validation
    {
        private static bool IsNullOrEmptyOrWhiteSpace(string info)
        {
            return string.IsNullOrEmpty(info.Trim());
        }
        private static bool IsLessThanOneAndGreaterThanEleven(string info)
        {
            return info.Length >= 11;
        }

        private static bool IsLessThanOneAndGreaterThanTwenty(string info)
        {
            int infoLength = info.Length;
            return infoLength <= 0 || infoLength >= 21 ? true : false;
        }


        private static bool NotGreaterThanFive(string info)
        {
            int infoLength = info.Length;

            return infoLength <= 5;
        }

        public static bool IsCapitalise(string name)
        {
            return Regex.IsMatch(name, "^[A-Z]{1}[a-z]*$");
        }   
        public static bool UsernameValidation(string name)
        {
            return Regex.IsMatch(name, "^[\\w@#$%!-]{6,20}$");
        }

        public static bool IsStrong(string password)
        {
            return Regex.IsMatch(password, @"^.*(?=\S{6,})(?=\S*\d)(?=\S*[a-z])(?=\S*[!*@#$%^&+=])\S*$");
        }

        private static bool IsExist(string info)
        {
            var username = ConfigService._userDb.GetUserByUserName(info);
            bool isEqual;
            isEqual = username == info;
            if (isEqual)
            {
                return true;
            }
            return false;
        }


        private static bool ANumber(string index)
        {
            bool checker;
            foreach (var k in index)
            {
                checker = int.TryParse(k.ToString(), out int result);
                if (checker == true)
                {
                    return checker;
                }
            }

            return false;
        }



        private static bool UserNameExistOrIsInvalid(string info)
        {
            return IsNullOrEmptyOrWhiteSpace(info) || IsLessThanOneAndGreaterThanEleven(info) || IsExist(info) ? true : false;
        }
        private static bool UserNameIsInvalid(string info)
        {
            return IsNullOrEmptyOrWhiteSpace(info) ? true : false;
        }

        public static bool LoginValidationMessage(string username, string password)
        {
            if (IsNullOrEmptyOrWhiteSpace(username)
                || IsNullOrEmptyOrWhiteSpace(password))
            {
                return true;
            }
            return false;
        }

        public static bool SignUpNameValidation(string lastname, string firstname)
        {

            if (!IsCapitalise(firstname)
                || !IsCapitalise(lastname))
            {
                return true;
            }
            return false;

        }
        public static bool SignUpUserNameValidation(string username)
        {

            if (UserNameExistOrIsInvalid(username))
            {
                return true;
            }
            return false;

        }

        public static bool CreateAccountValidation(string accountType, string deposit)
        {

            if (string.IsNullOrEmpty(accountType)
                || !ANumber(deposit))
            {
                return true;
            }

            if (accountType != "Current"
                && accountType != "Savings")
            {
                return true;
            }

            if (accountType == "Current")
            {
                if (Convert.ToDecimal(deposit) <= 0)
                {
                    return true;
                }

            }
            return false;

        }

        public static bool CreateAccountValidation(string accountType)
        {

            if (string.IsNullOrEmpty(accountType))
            {
                return true;
            }

            if (accountType != "Current"
                && accountType != "Savings")
            {
                return true;
            }

            return false;

        }

        public static int delay()
        {
            Thread.Sleep(1000);
            return 1;
        }

        public static bool TransferSenderValidation(string sender)
        {
            //sender Account number box validation


            if (string.IsNullOrEmpty(sender))
            {
                return true;
            }
            return false;

        }

        public static bool TransferAmountValidation(string amount, string sender)
        {

            /*            var balance = GetAmount(sender);*/

            if (string.IsNullOrEmpty(amount)
                || !ANumber(amount))
            {
                return true;
            }
            return false;
        }

        public static bool TransferRecipientValidation(string recipient)
        {

            //Recippient Account number box validation
            if (IsNullOrEmptyOrWhiteSpace(recipient)
                || !ANumber(recipient))
            {
                return true;
            }

            return false;
        }

        public static bool WithdrawSenderValidation(string sender)
        {
            //sender Account number box validation

            if (string.IsNullOrEmpty(sender))
            {
                return true;
            }
            return false;
        }


        public static bool WithdrawAmountValidation(string amount, string sender)
        {

            //Amount box validation
            if (string.IsNullOrEmpty(amount)
                || !ANumber(amount))
            {
                return true;
            }
            return false;
        }

        public static bool DepositSenderValidation(string sender)
        {
            //sender Account number box validation
            if (string.IsNullOrEmpty(sender))
            {
                return true;
            }
            return false;
        }

        public static bool DepositAmountValidation(string amount)
        {

            if (string.IsNullOrEmpty(amount)
                || !ANumber(amount))
            {
                return true;
            }
            return false;
        }
        public static bool HistoryValidation(string account)
        {
            //sender Account number box validation
            if (string.IsNullOrEmpty(account))
            {
                return true;
            }
            return false;
        }

        public string[] signUpValidation(string lastname, string firstname, string userName, string passWord, string accountTypeSU, string signUpValidationMessage)
        {
            string confirm = "false";
            if (CreateAccountValidation(accountTypeSU))
            {
                signUpValidationMessage = "Please! Choose an Invalid Acccount Type";
                confirm = "true";
            }

            if (!IsStrong(passWord))
            {
                signUpValidationMessage = "Password is not Strong, Example: @#ahjshkVA12";
                confirm = "true";
            }
            if (SignUpUserNameValidation(userName))
            {
                signUpValidationMessage = "Username Exist, try Another username";
                confirm = "true";
            }
            if (UserNameIsInvalid(userName))
            {
                signUpValidationMessage = "Username is Invalid";
                confirm = "true";
            }
            if (SignUpNameValidation(lastname, firstname))
            {
                signUpValidationMessage = "Invalid Name";
                confirm = "true";
            }
            return new string[2] { confirm, signUpValidationMessage };
        }

        public string[] TransferValidation(string transferMessage, string transferAmount, string recipientAcc, string senderAcc)
        {

            string confirm = "false";
            if (TransferRecipientValidation(recipientAcc))
            {
                transferMessage = "fill Recipient Account Number Box";
                confirm = "true";
            }

            if (TransferAmountValidation(transferAmount, senderAcc))
            {
                transferMessage = "fill Amount Account Number Box";
                confirm = "true";
            }

            if (TransferSenderValidation(senderAcc))
            {
                transferMessage = "fill Sender Account Number Box";
                confirm = "true";
            }

            return new string[2] { confirm, transferMessage };
        }

        public string[] DepositValidation(string depositMessage, string depoAmount, string depoAccNo)
        {
            string confirm = "false";
            try
            {
                if (Convert.ToDecimal(depoAmount) < 0)
                {
                    depositMessage = "Amount must be greater than 0!";
                    confirm = "true";
                }

            }
            catch (Exception e)
            {
                depositMessage = "Amount must be greater than 0!";
                confirm = "true";
            }

            if (DepositAmountValidation(depoAmount))
            {
                depositMessage = "Enter Amount!";
                confirm = "true";
            }

            return new string[2] { confirm, depositMessage };
        }

        public string[] WithdrawValidation(string withdrawMessage, string withdrawAmount, string withdrawAccNo)
        {

            string confirm = "false";

            if (WithdrawAmountValidation(withdrawAmount, withdrawAccNo))
            {
                withdrawMessage = "Insufficient Balance!";
                confirm = "true";
            }

            return new string[2] { confirm, withdrawMessage };
        }

    }

}
