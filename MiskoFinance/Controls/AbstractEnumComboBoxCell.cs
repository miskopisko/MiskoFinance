using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MiskoFinance.Controls
{
    public partial class AbstractEnumComboBoxCell : DataGridViewComboBoxCell
	{
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
				return ListManager != null ? ListManager.GetItemProperties().Find(DisplayMember, true) : null;
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
