using System.Linq;
using HanjieSharp.Domain;

namespace HanjieSharp.Solvers
{
    internal sealed class GuaranteedCellSolver : IRowSolver
    {
        public void Solve(CellCollection cellCollection)
        {
            if (cellCollection.Hints.Count != 1)
            {
                return;
            }

            var cellCount = cellCollection.Cells.Count;
            var hint = cellCollection.Hints.First();
            var difference = cellCount - hint;
            if (difference >= hint)
            {
                return;
            }

            var guaranteed = cellCollection.Cells.Skip(difference).Take(hint - difference).ToList();
            guaranteed.ForEach(c => c.UpdateNodeState(CellState.Yes));
        }
    }
}