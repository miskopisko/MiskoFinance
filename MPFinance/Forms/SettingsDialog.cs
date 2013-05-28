using System;
using System.Reflection;
using System.Windows.Forms;
using MPersist.Core.Enums;
using MPFinance.Core.Settings;
using MPFinance.Properties;
using System.ComponentModel.Design;

namespace MPFinance.Forms
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            PropertyTable proptable = new PropertyTable();
            //Construct PropertyTable entries from Settings class user-scoped properties 
            Settings settings = Settings.Default;
            Type type = typeof(Properties.Settings);
            MemberInfo[] pi = type.GetProperties();

            foreach (MemberInfo m in pi)
            {
                Object[] myAttributes = m.GetCustomAttributes(true);
                if (myAttributes.Length > 0)
                {
                    for (int j = 0; j < myAttributes.Length; j++)
                    {
                        if (myAttributes[j].ToString() == "System.Configuration.UserScopedSettingAttribute")
                        {
                            PropertySpec ps = new PropertySpec("property name", "System.String");
                            switch (m.Name)
                            {
                                case "DefaultUsername":
                                    ps = new PropertySpec("Default Username", typeof(String), "User Settings", "Default username used when application first loads", settings.DefaultUsername);
                                    break;
                                case "ConnectionType":
                                    ps = new PropertySpec("DB Connection Type", typeof(ErrorLevel), "User Settings", "Default database connection type", settings.ConnectionType);
                                    break;
                                case "RowsPerPage":
                                    ps = new PropertySpec("Rows Per Page", typeof(Int32), "User Settings", "Number of records fetched per page", settings.RowsPerPage);
                                    break;
                            }
                            proptable.Properties.Add(ps);
                        }
                    }
                }
            }

            //this line binds the PropertyTable object to the preferences PropertyGrid control
            SettingsPropertyGrid.SelectedObject = proptable;
            
            base.OnLoad(e);
        }

        private void Done_Click(object sender, EventArgs e)
        {
            //write property values back to Settings object properties
            PropertyGrid pg = SettingsPropertyGrid;
            PropertyTable proptable = (PropertyTable)pg.SelectedObject;
            //get the grid root
            GridItem gi = pg.SelectedGridItem;
            while (gi.Parent != null)
            {
                gi = gi.Parent;
            }
            //transfer all grid item values to Settings class properties
            foreach (GridItem item in gi.GridItems)
            {
                ParseGridItems(item); //recursive
            }

            Settings.Default.Save();

            Dispose();
        }

        private void ParseGridItems(GridItem gi)
        {
            Settings settings = Settings.Default;
            if (gi.GridItemType == GridItemType.Category)
            {
                foreach (GridItem item in gi.GridItems)
                {
                    ParseGridItems(item); //terminates at 1st Property
                }
            }
            switch (gi.Label)
            {
                case "Default Username":
                    settings. DefaultUsername = (String)gi.Value;
                    break;
                //case "DB Connection Type":
                //    settings.ConnectionType = (Int32)gi.Value;
                //    break;
                case "Rows Per Page":
                    settings.RowsPerPage = (Int32)gi.Value;
                    break;
                default:
                    break;
            }
        }
    }
}
