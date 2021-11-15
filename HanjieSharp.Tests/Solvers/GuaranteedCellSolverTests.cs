using System.Collections.Generic;
using System.Linq;
using HanjieSharp.Domain;
using HanjieSharp.Solvers;
using NUnit.Framework;

namespace HanjieSharp.Tests.Solvers
{
    public class GuaranteedCellSolverTests
    {
        [TestCase("  O  ", 5, 3)]
        [TestCase(" OOOOOOOO ", 10, 9)]
        public void Guaranteed_cells_are_calculated_correctly(string expectedAnswer, int length, params int[] hints)
        {
            var solver = new GuaranteedCellSolver();

            var cellCollection = new CellCollection(0, hints, CreateCellCollection(length));
            
            solver.Solve(cellCollection);

            Assert.That(cellCollection.ToString(), Is.EqualTo(expectedAnswer));
        }

        [TestCase(5, 1)]
        [TestCase(5, 2)]
        [TestCase(7, 3)]
        [TestCase(10, 5)]
        public void Cell_collection_with_no_guaranteed_cells_is_left_alone(int length, params int[] hints)
        {
            var solver = new GuaranteedCellSolver();

            var cellCollection = new CellCollection(0, hints, CreateCellCollection(length));
            
            solver.Solve(cellCollection);

            foreach (var cell in cellCollection.Cells)
            {
                Assert.That(cell.State, Is.EqualTo(CellState.None));
            }
        }
        
        private static IReadOnlyCollection<Cell> CreateCellCollection(int length)
        {
            return Enumerable.Range(0, length).Select(i => new Cell(0, i)).ToArray();
        }
    }
}