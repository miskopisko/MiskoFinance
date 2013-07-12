using MPFinance.Core.Enums;
using MPFinance.Properties;
using System;
using System.Windows.Forms;

namespace MPFinance.Forms
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();

            GenderCmb.DataSource = Gender.Elements;
        }

        private void Done_Click(object sender, EventArgs e)
        {
            Settings.Default.RowsPerPage = Convert.ToInt32(RowsPerPageTxt.Text);
            Settings.Default.EnableCache = EnableCacheCheck.Checked;
            Settings.Default.Save();

            Dispose();
        }

        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            // Wait for the operator to load if it aint
            while (MPFinanceMain.Instance.Operator == null) { }

            UsernameTxt.Text = MPFinanceMain.Instance.Operator.Username;
            PasswordTxt.Text = MPFinanceMain.Instance.Operator.Password;
            FirstNameTxt.Text = MPFinanceMain.Instance.Operator.FirstName;
            LastNameTxt.Text = MPFinanceMain.Instance.Operator.LastName;
            EmailTxt.Text = MPFinanceMain.Instance.Operator.Email;
            GenderCmb.SelectedItem = MPFinanceMain.Instance.Operator.Gender;
            BirthdayPicker.Value = MPFinanceMain.Instance.Operator.Birthday.Value;
            RowsPerPageTxt.Text = Settings.Default.RowsPerPage.ToString(); ;
            EnableCacheCheck.Checked = Settings.Default.EnableCache;
        }
    }
}
