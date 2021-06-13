using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPractice_DSA
{
    public static class Extensions
    {
        public static DataGridViewRow GetRowByValue(this DataGridView dataGridView, string value, int columnIndex = 0)
        {
            for (var i = 0; i < dataGridView.Rows.Count; i++)
            {
                var currValue = dataGridView[0, i].Value.ToString();
                if (currValue == value)
                    return dataGridView.Rows[i];
            }
            return null;
        }
    }
}
