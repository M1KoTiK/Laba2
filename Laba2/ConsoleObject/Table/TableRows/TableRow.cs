using ConsoleApp.ConsoleObject.Table.CharSet;
using ConsoleApp.ConsoleObject.Table.TableRows;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laba2.ConsoleObject.Table.TableRows
{
    public class TableRow: TableRowBase
    {
        public TableRow(IList<object> elements, ITableCharSet? characterSet = null) : base(elements, characterSet)
        {
        
        }
    }
}
