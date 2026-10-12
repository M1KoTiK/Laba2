using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.ConsoleObject.Table.TableRows;

namespace ConsoleApp.ConsoleObject.Table
{
    public class Table : Element, ICollectionElement<ITableRow>
    {
        public IList<ITableRow> Items { get; }
        public ITableRow Headers { get; set; }
        public Table(string id, IList<ITableRow> table) : base(id)
        {
            this.Items = table;
        }

        public override void Print()
        {
            var measures = ColumnMeasure();

            Items[0].PrintTopLine(measures);
            Console.WriteLine();
            if (Headers != null)
            {
                Headers.PrintElementLine(measures);
                Console.WriteLine();
                Headers.PrintSeparatorLine(measures);
                Console.WriteLine();
            }

            for(var i = 0; i < Items.Count - 1; i++)
            {
                Items[i].PrintElementLine(measures);
                Console.WriteLine();
                Items[i].PrintSeparatorLine(measures);
                Console.WriteLine();
            }
            Items[Items.Count-1].PrintElementLine(measures);
            Console.WriteLine();
            Items[Items.Count-1].PrintBottomLine(measures);
        }

        private int ColumnCount()
        {

            var maxCount = 0;

            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Row.Count > maxCount)
                {
                    maxCount = Items[i].Row.Count;
                }
            }
            return maxCount;
        }

        private IList<int> ColumnMeasure()
        {
            
            var meausures = Enumerable.Repeat(0, ColumnCount()).ToList();
            
            for (int i = 0; i < Items.Count; i++)
            {
                var column = Items[i];
                for (int j = 0; j < Items[i].Row.Count; j++)
                {
                    var row = column.Row[j];
                    var rowValue = row.ToString();
                    if (rowValue.Length > meausures[j])
                    {
                        meausures[j] = rowValue.Length;
                    }
                }
            }
            return meausures;
        }

    }
}
