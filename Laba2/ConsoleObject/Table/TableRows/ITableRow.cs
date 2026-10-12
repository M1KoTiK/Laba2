using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleObject.Table.TableRows
{
    public interface ITableRow
    {
        public IList<object> Row { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public void PrintTopLine(IList<int> widths);

        /// <summary>
        /// Отрисовка таблицы с краями 
        /// c разделениями от предыдущей строки
        /// </summary>
        public void PrintElementLine(IList<int> widths);

        public void PrintSeparatorLine(IList<int> widths);

        /// <summary>
        /// 
        /// </summary>
        public void PrintBottomLine(IList<int> widths);
    }
}
