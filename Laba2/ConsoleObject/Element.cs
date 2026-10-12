using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleObject
{
    public abstract class Element : IElement, IPositionable
    {
        public string Id { get; }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public Element(string id)
        {
            Id = id;
        }

        public abstract void Print();

        public virtual void Execute()
        {

        }

    }
}
