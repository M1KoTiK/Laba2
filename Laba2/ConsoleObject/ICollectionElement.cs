using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleObject
{
    public interface ICollectionElement<T>: IElement
    {
        public IList<T> Items { get; }
    }
}
