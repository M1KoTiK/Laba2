using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleObject
{
    public interface IElement
    {   
        string Id { get; }
        public void Print();
        public void Execute();
    }
}
