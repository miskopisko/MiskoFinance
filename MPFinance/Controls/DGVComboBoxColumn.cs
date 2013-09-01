using System;
using System.ComponentModel;
using System.Windows.Forms;
using MPersist.Core;

/*  Special thanks to Bart Mermuys who posted this solution on the PC review forumns
 * 
 *  http://www.pcreview.co.uk/forums/binging-custom-objects-datagridviewcomboboxcolumn-t2894140.html
 */

namespace MPFinance.Controls
{
    public class DGVComboBoxColumn : DataGridViewComboBoxColumn
    {
        private static Logger Log = Logger.GetInstance(typeof(DGVComboBoxColumn));

        #region Constructor

        public DGVComboBoxColumn()
        {
            CellTemplate = new DGVComboBoxCell();
        }

        #endregion
    }

    public class DGVComboBoxCell : DataGridViewComboBoxCell
    {
        private static Logger Log = Logger.GetInstance(typeof(DGVComboBoxCell));

        #region Properties

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
                if (ListManager != null)
                {
                    return ListManager.GetItemProperties().Find(DisplayMember, true);
                }
                return null;
            }
        }

        #endregion

        #region Override Methods

        protected override Object GetFormattedValue(Object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value == null || value == cellStyle.DataSourceNullValue)
            {
                return "";
            }

            return base.GetFormattedValue(DisplayProp.GetValue(value), rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }

        public override Object ParseFormattedValue(Object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
        {
            foreach (Object item in ListManager.List)
            {
                if ((String)DisplayProp.GetValue(item) == (String)formattedValue)
                {
                    return item;
                }
            }

            return base.ParseFormattedValue(formattedValue, cellStyle,formattedValueTypeConverter, valueTypeConverter);
        }

        #endregion
    }
}