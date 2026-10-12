using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleObject.Menu
{
    public class Menu : Element, ICollectionElement<MenuItem>
    {
        public void OpenMenu()
        {
            Print();
            Execute();
        }

        public string Header { get; set; }
        public string RequestTitle { get; set; } = "Выберите ответ";
        public Menu(string id, string header, IList<MenuItem> gameMenuItems) : base(id)
        {
            Header = header;
            items = new List<MenuItem>(gameMenuItems);

        }
        public override void Print()
        {
            Console.WriteLine(Header);
            foreach (var item in Items)
            {
                item.Print();
            }
        }
        public override void Execute()
        {
            Console.WriteLine(RequestTitle);
            var Answer = Console.ReadLine();
            foreach (var item in Items)
            {
                if (item.Id == Answer)
                {
                    item.Execute();
                }
            }
        }

        private List<MenuItem> items;
        public IList<MenuItem> Items => items;

        public void SetMarkerForItems(string marker)
        {
            foreach(var item in items)
            {
                item.Marker = marker;
            }
        }
    }
}
