using ConsoleApp.ConsoleObject.Table.CharSet;
using ConsoleApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleObject.Table.TableRows
{
    public abstract class TableRowBase : ITableRow
    {
        public IList<object> Row { get; set; }
        public TableRowBase(IList<object> row, ITableCharSet? characterSet = null)
        {
            if (characterSet == null)
            {
                this.characterSet = new TableCharSet();
            }
            else
            {
                this.characterSet = characterSet;
            }

            Row = row;
            foreach (var item in row)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                symbolsCount.Add(item.ToString().Length);
            }
        }

        private ITableCharSet characterSet;
        private List<int> symbolsCount = new List<int>();


        public void PrintTopLine(IList<int> widths)
        {
            Console.Write(characterSet.LeftTopCorner);
            for (int i = 0; i < symbolsCount.Count; i++)
            {
                var lenght = symbolsCount[i];

                if (lenght < widths[i])
                {
                    lenght = widths[i];
                }
                if (i < symbolsCount.Count - 1)
                {
                    Console.Write(characterSet.TopBottomBorder.Multiply(lenght));
                    Console.Write(characterSet.TopSeparator);
                }
                else
                {
                    Console.Write(characterSet.TopBottomBorder.Multiply(lenght));
                    Console.Write(characterSet.RightTopCorner);
                }
            }
        }

        public void PrintElementLine(IList<int> widths)
        {
            Console.Write(characterSet.LeftRightBorderOrSeparator);
            for (int i = 0; i < symbolsCount.Count; i++)
            {
                var lenght = symbolsCount[i];
                if (lenght < widths[i])
                {
                    lenght = widths[i];
                }
                if (i < symbolsCount.Count - 1)
                {
                    var countSpaces = lenght - symbolsCount[i];
                    Console.Write(Row[i]);
                    Console.Write(" ".Multiply(countSpaces));
                    Console.Write(characterSet.LeftRightBorderOrSeparator);
                }
                else
                {
                    var countSpaces = lenght - symbolsCount[i];
                    Console.Write(Row[i]);
                    Console.Write(" ".Multiply(countSpaces));
                    Console.Write(characterSet.LeftRightBorderOrSeparator);
                }
            }
        }

        public void PrintBottomLine(IList<int> widths)
        {
            Console.Write(characterSet.LeftBottomCorner);
            for (int i = 0; i < symbolsCount.Count; i++)
            {
                var lenght = symbolsCount[i];
                if (lenght < widths[i])
                {
                    lenght = widths[i];
                }
                if (i < symbolsCount.Count - 1)
                {
                    Console.Write(characterSet.TopBottomBorder.Multiply(lenght));
                    Console.Write(characterSet.BottomSeparator);
                }
                else
                {
                    Console.Write(characterSet.TopBottomBorder.Multiply(lenght));
                    Console.Write(characterSet.RightBottomCorner);
                }
            }
        }


        public void PrintSeparatorLine(IList<int> widths)
        {
            Console.Write(characterSet.LeftSeparatorBorder);
            for (int i = 0; i < symbolsCount.Count; i++)
            {
                var lenght = symbolsCount[i];
                if (lenght < widths[i])
                {
                    lenght = widths[i];
                }
                if (i < symbolsCount.Count - 1)
                {
                    Console.Write(characterSet.TopBottomBorder.Multiply(lenght));
                    Console.Write(characterSet.MiddleSeparator);
                }
                else
                {
                    Console.Write(characterSet.TopBottomBorder.Multiply(lenght));
                    Console.Write(characterSet.RightSeparatorBorder);
                }
            }
        }
    }
}
