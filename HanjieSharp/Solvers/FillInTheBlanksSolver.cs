using System.Linq;
using HanjieSharp.Domain;

namespace HanjieSharp.Solvers
{
    internal sealed class FillInTheBlanksSolver : IRowSolver
    {
        public void Solve(CellCollection cellCollection)
        {
            if (cellCollection.Cells.Count(c => c.State == CellState.Yes) != cellCollection.Hints.Sum())
            {
                return;
            }

            foreach (var cell in cellCollection.Cells.Where(c => c.State == CellState.None))
            {
                cell.UpdateNodeState(CellState.No);
            }
        }
    }
}