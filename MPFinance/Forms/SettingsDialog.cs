using MPFinance.Core.Enums;
using MPFinance.Properties;
using System;
using System.Windows.Forms;
using MPersist.Core;
using MPFinance.Core.Message.Requests;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Forms
{
    public partial class SettingsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(SettingsDialog));

        #region Variable Declarations



        #endregion

        #region Parameters



        #endregion

        #region Constructors

        public SettingsDialog()
        {
            InitializeComponent();

            GenderCmb.DataSource = Gender.Elements;
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            UsernameTxt.Text = MPFinanceMain.Instance.Operator.Username;
            mPassword1Txt_.Text = MPFinanceMain.Instance.Operator.Password;
            mPassword2Txt_.Text = MPFinanceMain.Instance.Operator.Password;
            FirstNameTxt.Text = MPFinanceMain.Instance.Operator.FirstName;
            LastNameTxt.Text = MPFinanceMain.Instance.Operator.LastName;
            EmailTxt.Text = MPFinanceMain.Instance.Operator.Email;
            GenderCmb.SelectedItem = MPFinanceMain.Instance.Operator.Gender;
            BirthdayPicker.Value = MPFinanceMain.Instance.Operator.Birthday.Value;
            RowsPerPageTxt.Text = Settings.Default.RowsPerPage.ToString(); ;
            EnableCacheCheck.Checked = Settings.Default.EnableCache;
        }

        #endregion

        #region Private Methods

        private void UpdateOperatorError(ResponseMessage Response)
        {
            
        }

        private void UpdateOperatorSuccess(ResponseMessage Response)
        {
            Settings.Default.RowsPerPage = Convert.ToInt32(RowsPerPageTxt.Text);
            Settings.Default.EnableCache = EnableCacheCheck.Checked;
            Settings.Default.Save();

            MPFinanceMain.Instance.Operator.FirstName = ((UpdateOperatorRS)Response).Operator.FirstName;
            MPFinanceMain.Instance.Operator.LastName = ((UpdateOperatorRS)Response).Operator.LastName;
            MPFinanceMain.Instance.Operator.Email = ((UpdateOperatorRS)Response).Operator.Email;
            MPFinanceMain.Instance.Operator.Password = ((UpdateOperatorRS)Response).Operator.Password;
            MPFinanceMain.Instance.Operator.Gender = ((UpdateOperatorRS)Response).Operator.Gender;
            MPFinanceMain.Instance.Operator.Birthday = ((UpdateOperatorRS)Response).Operator.Birthday;

            Dispose();
        }

        #endregion

        #region Public Methods



        #endregion

        #region Event Listenners

        private void Done_Click(object sender, EventArgs e)
        {
            Operator operatorToUpdate = MPFinanceMain.Instance.Operator;
            operatorToUpdate.FirstName = FirstNameTxt.Text.Trim();
            operatorToUpdate.LastName = LastNameTxt.Text.Trim();
            operatorToUpdate.Email = EmailTxt.Text.Trim();
            operatorToUpdate.Birthday = BirthdayPicker.Value;
            operatorToUpdate.Gender = (Gender)GenderCmb.SelectedItem;

            UpdateOperatorRQ request = new UpdateOperatorRQ();
            request.Operator = operatorToUpdate;
            request.Password1 = mPassword1Txt_.Text;
            request.Password2 = mPassword2Txt_.Text;
            MessageProcessor.SendRequest(request, UpdateOperatorSuccess, UpdateOperatorError);
        }        

        #endregion
    }
}
