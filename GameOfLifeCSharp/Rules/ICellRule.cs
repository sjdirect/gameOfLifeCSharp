using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeCSharp.Rules
{
    public interface ICellRule
    {
        bool RuleApplies(string currentCellValue, INeighbors neighbors);
        string NewCellValue { get; }
    }
}
