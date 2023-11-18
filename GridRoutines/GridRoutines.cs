using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridRoutines
{
    public class Grids
    {
        public static int GetIntRef(DataGridView _dataGridView, int _columnIndex) //Get integer value using column index
        {
            object cellValue = null;
            cellValue = GetValue(_dataGridView, _columnIndex);
            if (cellValue == null)
            {
                return 0;
            }
            else
            {
                return (int)cellValue;
            }
        }

        public static int GetIntRef(DataGridView _dataGridView, string _columnIndex) //Get integer value using column name
        {
            object cellValue = null;
            cellValue = GetValue(_dataGridView, _columnIndex);
            if (cellValue == null)
            {
                return 0;
            }
            else
            {
                return (int)cellValue;
            }
        }

        public static string GetStringRef(DataGridView _dataGridView, int _columnIndex) //Get string value using column index
        {
            object cellValue = null;
            cellValue = GetValue(_dataGridView, _columnIndex);
            if (cellValue == null)
            {
                return "";
            }
            else
            {
                return cellValue.ToString();
            }
        }

        public static string GetStringRef(DataGridView _dataGridView, string _columnIndex) //Get string value using column name
        {
            object cellValue = null;
            cellValue = GetValue(_dataGridView, _columnIndex);
            if (cellValue == null)
            {
                return "";
            }
            else
            {
                return cellValue.ToString();
            }

        }

        public static double GetDoubleRef(DataGridView _dataGridView, int _columnIndex) //Get double value using column index
        {
            object cellValue = null;
            cellValue = GetValue(_dataGridView, _columnIndex);
            if (cellValue == null)
            {
                return 0D;
            }
            else
            {
                return (double)cellValue;
            }
        }

        public static double GetDoubleRef(DataGridView _dataGridView, string _columnIndex) //Get double value using colum name
        {
            object cellValue = null;
            cellValue = GetValue(_dataGridView, _columnIndex);
            if (cellValue == null)
            {
                return 0D;
            }
            else
            {
                return (double)cellValue;
            }
        }

        public static decimal GetDecimalRef(DataGridView _dataGridView, string _columnIndex) //Get decimal value using column name
        {
            object cellValue = null;
            cellValue = GetValue(_dataGridView, _columnIndex);
            if (cellValue == null)
            {
                return 0M;
            }
            else
            {
                return (decimal)cellValue;
            }
        }

        public static decimal GetDecimalRef(DataGridView _dataGridView, int _columnIndex) //Get decimal value using column index
        {
            object cellValue = null;
            cellValue = GetValue(_dataGridView, _columnIndex);
            if (cellValue == null)
            {
                return 0M;
            }
            else
            {
                return (decimal)cellValue;
            }
        }


        public static object GetValue(DataGridView _dataGridView, string _columnIndex) //Get value using column name
        {
            int rowIndex = 0; //int columnIndex = 0;
            int countMess = _dataGridView.RowCount; //Check whether there are any records in grid
            if (countMess < 1)  //if none return null (alsways check if GetInRef() returns 0)
            {
                return null;
            }
            DataGridViewRow row = _dataGridView.Rows[rowIndex];
            DataGridViewCell cell = row.Cells[_columnIndex];
            object cellValue = cell.Value;
            if (_dataGridView.SelectedRows.Count > 0) //have to select a full row...
            {
                int selectedRow = _dataGridView.SelectedRows[0].Index; //Get the index of the first selected row
                object rowValue = GetCellValue(_dataGridView, _columnIndex, selectedRow);
                cellValue = rowValue;
            }
            else if (_dataGridView.SelectedCells.Count > 0) //Selected a cell
            {
                int selectedRow = _dataGridView.SelectedCells[0].RowIndex; //Get the row index of the first selected cell
                object rowValue = GetCellValue(_dataGridView, _columnIndex, selectedRow);
                cellValue = rowValue;
            }
            else
            {
                cellValue = null;
            }
            return cellValue;
        }

        public static object GetValue(DataGridView _dataGridView, int _columnIndex) //Get value using column index
        {
            int rowIndex = 0; //int columnIndex = 0;
            int countMess = _dataGridView.RowCount; //Check whether there are any records in grid
            if (countMess < 1)  //if none return 0 (alsways check if GetInRef() returns 0)
            {
                return null;
            }
            DataGridViewRow row = _dataGridView.Rows[rowIndex];
            DataGridViewCell cell = row.Cells[_columnIndex];
            object cellValue = cell.Value;
            if (_dataGridView.SelectedRows.Count > 0) //have to select a full row...
            {
                DataGridViewRow selectedRow = _dataGridView.SelectedRows[0];
                object rowValue = selectedRow.Cells[_columnIndex].Value;
                cellValue = rowValue;
            }
            else if (_dataGridView.SelectedCells.Count > 0) //Selected a cell
            {
                cell = _dataGridView.SelectedCells[0];
                row = _dataGridView.Rows[cell.RowIndex];
                cellValue = row.Cells[_columnIndex].Value;
            }
            else
            {
                cellValue = null;
            }
            return cellValue;
        }

        public static object GetCellValue(DataGridView _dataGridView, string _columnName, int _rowIndex)
        {
            object cellValue = _dataGridView.Rows[_rowIndex].Cells[_columnName].Value;
            return cellValue;
        }
    }
}
