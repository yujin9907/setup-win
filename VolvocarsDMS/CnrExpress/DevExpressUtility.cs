using DevExpress.XtraGrid.Columns;
using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvocarsDMS
{
    internal class DevExpressUtility
    {
        public static void GridInit(DevExpress.XtraGrid.GridControl gridControl, DevExpress.XtraGrid.Views.Grid.GridView gridView, bool isMultiSelect = false, bool isShowFooter = false)
        {
            gridView.Appearance.FocusedCell.ForeColor = Color.FromArgb(192, 0, 0);
            gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsView.ColumnAutoWidth = false;

            if (isMultiSelect)
            {
                gridView.OptionsSelection.MultiSelect = true;
                gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            }

            if (isShowFooter)
            {
                gridView.OptionsView.ShowFooter = true;
            }
        }
        public static void SetGridColumnWidth(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            //gridView.OptionsView.ColumnAutoWidth = isAuto;
            if (gridView.RowCount > 0)
            {
                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    //gridView.Columns[i].Width = gridView.Columns[i].GetBestWidth() + 10;
                    gridView.Columns[i].BestFit();
                }
            }
        }

        public static DevExpress.XtraGrid.Columns.GridColumn GetGridColumn(string name, string fieldName, string caption, bool visible)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = new()
            {
                Name = name,
                FieldName = fieldName,
                Caption = caption,
                Visible = visible
            };

            return column;
        }
        public static void Clear(DevExpress.XtraGrid.GridControl gridControl, DevExpress.XtraGrid.Views.Grid.GridView gridView, bool isColumnClear = false)
        {
            gridControl.DataSource = null;
            //gridView.RefreshData();

            if (isColumnClear)
            {
                gridView.Columns.Clear();
            }
        }
        public static void TextEditDisable(DevExpress.XtraEditors.ComboBoxEdit cbo, bool IsDisableTextEditor)
        {
            if (IsDisableTextEditor)
            {
                cbo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }
            else
            {
                cbo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            }
        }

        public static string? GetText(DevExpress.XtraEditors.ComboBoxEdit cbo)
        {
            return cbo.SelectedItem.ToString();
        }
        public static string GetCode(DevExpress.XtraEditors.ComboBoxEdit cbo)
        {
            string ret = string.Empty;

            if (cbo.SelectedIndex >= 0)
            {
                ret = ((ComboValues)cbo.SelectedItem).Code;
            }

            return ret;
        }
        public static string GetName(DevExpress.XtraEditors.ComboBoxEdit cbo)
        {
            string ret = string.Empty;

            if (cbo.SelectedIndex >= 0)
            {
                ret = ((ComboValues)cbo.SelectedItem).Name;
            }

            return ret;
        }

    }



    public class ComboValues
    {
        private readonly string _Code;
        private readonly string _Name;

        public string Code { get { return _Code; } }
        public string Name { get { return _Name; } }

        public ComboValues(string code, string name)
        {
            _Code = code;
            _Name = name;
        }

        public override string ToString()
        {
            return _Name;
        }

    }
}
