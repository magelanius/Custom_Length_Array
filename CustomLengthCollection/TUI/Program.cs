using CustomLengthCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = new int[5];
            
            CustomLengthCollection<int> collection = new CustomLengthCollection<int>(5, 9);
            collection[5] = 6;
        }
    }
}
