using System.Collections.Generic;
using System.Linq;

namespace HanjieSharp.Domain
{
    internal sealed class CellCollection
    {
        public int Index { get; }
        public IReadOnlyCollection<int> Hints { get; }
        public IReadOnlyCollection<Cell> Cells { get; }

        public CellCollection(int index, IReadOnlyCollection<int> hints, IReadOnlyCollection<Cell> cells)
        {
            Index = index;
            Hints = hints;
            Cells = cells;
        }

        public bool IsComplete()
        {
            return Cells.All(c => c.State != CellState.None);
        }

        public override string ToString()
        {
            return string.Join("", Cells.Select(c => c.ToString()));
        }
    }
}