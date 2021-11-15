using System;
using System.Collections.Generic;
using System.Linq;
using HanjieSharp.Solvers;

namespace HanjieSharp.Domain
{
    internal sealed class Grid
    {
        private readonly IRowSolver[] m_RuleSolvers =
        {
            new TrivialRowSolver(),
            new GuaranteedCellSolver(),
            new FillInTheBlanksSolver(),
        };
        
        public int ColumnCount { get; }
        public int RowCount { get; }
        public IReadOnlyCollection<CellCollection> Rows { get; }
        public IReadOnlyCollection<CellCollection> Columns { get; }

        public Grid(int columnCount, int rowCount, IEnumerable<int[]> columnHints, IEnumerable<int[]> rowHints)
        {
            ColumnCount = columnCount;
            RowCount = rowCount;

            var allCells = new List<Cell>();

            for (var x = 0; x < columnCount; x++)
            {
                for (var y = 0; y < rowCount; y++)
                {
                    allCells.Add(new Cell(x, y));
                }
            }

            Columns = columnHints
                .Select((h, i) => new CellCollection(i, h, allCells.Where(c => c.X == i).ToArray()))
                .ToArray();
            
            Rows = rowHints
                .Select((h, i) => new CellCollection(i, h, allCells.Where(c => c.Y == i).ToArray()))
                .ToArray();
        }

        public void Solve()
        {
            foreach (var solver in m_RuleSolvers)
            {
                var allCollections = Columns.Concat(Rows);

                foreach (var collection in allCollections)
                {
                    if (collection.IsComplete())
                    {
                        continue;
                    }
                    
                    solver.Solve(collection);
                }
            }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Rows.Select(r => r.ToString()));
        }
    }
}