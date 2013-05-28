using System.ComponentModel;
using System.Windows.Forms;
using MPersist.Core;

/*  Special thanks to Bart Mermuys who posted this solution on the PC review forumns
 * 
 *  http://www.pcreview.co.uk/forums/binging-custom-objects-datagridviewcomboboxcolumn-t2894140.html
 */

namespace MPFinance.Forms.Controls
{
    public class DGVComboBoxColumn : DataGridViewComboBoxColumn
    {
        private static Logger Log = Logger.GetInstance(typeof(DGVComboBoxColumn));

        public DGVComboBoxColumn()
        {
            CellTemplate = new DGVComboBoxCell();
        }
    }

    public class DGVComboBoxCell : DataGridViewComboBoxCell
    {
        private static Logger Log = Logger.GetInstance(typeof(DGVComboBoxCell));

        private PropertyDescriptor displayProp;

        private CurrencyManager ListManager
        {
            get
            {
                BindingMemberInfo bmi = new BindingMemberInfo(base.DisplayMember);

                if (DataGridView != null && DataSource != null)
                {
                    return (CurrencyManager)DataGridView.BindingContext[DataSource, bmi.BindingPath];
                }
                return null;
            }
        }

        private PropertyDescriptor DisplayProp
        {
            get
            {
                if (displayProp == null && ListManager != null)
                {
                    displayProp = ListManager.GetItemProperties().Find(DisplayMember, true);
                }
                return displayProp;
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter,TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value == null || value == cellStyle.DataSourceNullValue)
            {
                return "";
            }
            //else
            //{
            //    return value.ToString();
            //}

            return base.GetFormattedValue(DisplayProp.GetValue(value), rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }

        public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
        {
            foreach (object item in ListManager.List)
            {
                if ((string)DisplayProp.GetValue(item) == (string)formattedValue)
                {
                    return item;
                }
            }

            return base.ParseFormattedValue(formattedValue, cellStyle,formattedValueTypeConverter, valueTypeConverter);
        }
    }
}