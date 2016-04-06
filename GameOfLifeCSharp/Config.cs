using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeCSharp
{
    public static class Config
    {
        public static int Reptitions => 2;
        public static string LiveCell => "*";
        public static string DeadCell => ".";
        public static int MaxRow => 4;
        public static int MaxColumns => 8;
    }
}
