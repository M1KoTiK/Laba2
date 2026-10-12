using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleObject.Table.CharSet
{
    public class TableCharSet : ITableCharSet
    {
        public string LeftTopCorner { get; set; } = "┌";
        public string RightTopCorner { get; set; } = "┐";
        public string LeftBottomCorner { get; set; } = "└";
        public string RightBottomCorner { get; set; } = "┘";
        public string TopBottomBorder { get; set; } = "─";
        public string LeftRightBorderOrSeparator { get; set; } = "│";
        public string RightSeparatorBorder { get; set; } = "┤";
        public string LeftSeparatorBorder { get; set; } = "├";
        public string MiddleSeparator { get; set; } = "┼";
        public string BottomSeparator { get; set; } = "┴";
        public string TopSeparator { get; set; } = "┬";
    }
}
