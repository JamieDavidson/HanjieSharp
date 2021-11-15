using System.Linq;
using HanjieSharp.Domain;

namespace HanjieSharp.Solvers
{
    internal sealed class TrivialRowSolver : IRowSolver
    {
        public void Solve(CellCollection cellCollection)
        {
            var hintLength = cellCollection.Hints.Count;
            var collectionLength = cellCollection.Cells.Count;

            if (cellCollection.Hints.Sum() + (hintLength - 1) != collectionLength)
            {
                return;
            }

            var index = 0;
            foreach (var hint in cellCollection.Hints)
            {
                var toFill = cellCollection.Cells.Skip(index).Take(hint);
                index += hint;
                foreach (var f in toFill)
                {
                    f.UpdateNodeState(CellState.Yes);
                }

                if (index < cellCollection.Cells.Count)
                {
                    var cell = cellCollection.Cells.ElementAt(index);
                    index++;
                    cell.UpdateNodeState(CellState.No);
                }
            }
        }
    }
}