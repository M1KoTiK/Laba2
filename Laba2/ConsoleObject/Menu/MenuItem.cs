using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleObject.Menu
{
    public class MenuItem : Element
    {
        public string Separator { get; set; } = " : ";
        public string Marker { get; set; } = " ";
        public string ItemContent { get; set; }
        private Action? action;

        public MenuItem(string id, string itemContent, Action? executeAction = null) : base(id)
        {
            ItemContent = itemContent;
            action = executeAction;
        }

        public override void Print()
        {
            Console.WriteLine(Marker + Id + Separator + ItemContent);
        }

        public override void Execute()
        {
            action?.Invoke();
        }
    }
}
