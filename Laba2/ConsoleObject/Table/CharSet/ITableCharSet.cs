using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleObject.Table.CharSet
{
    public interface ITableCharSet
    {
        string LeftTopCorner { get; }
        string RightTopCorner { get; }
        string LeftBottomCorner { get; }
        string RightBottomCorner { get; }
        string TopBottomBorder { get; }
        string LeftRightBorderOrSeparator { get; }
        string RightSeparatorBorder { get; }
        string LeftSeparatorBorder { get; }
        public string MiddleSeparator { get; }
        public string BottomSeparator { get; }
        public string TopSeparator { get; }
    }
}
