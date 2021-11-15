using System.Collections.Generic;
using System.Linq;
using HanjieSharp.Domain;
using HanjieSharp.Solvers;
using NUnit.Framework;

namespace HanjieSharp.Tests.Solvers
{
    public sealed class TrivialRowSolverTests
    {
        [TestCase("OOOOOOOOOO", 10)]
        [TestCase("OOXOOOOOOO", 2, 7)]
        [TestCase("OOOOOOOXOO", 7, 2)]
        [TestCase("OOOXOOXOOO", 3, 2, 3)]
        public void TrivialLinesAreCalculatedCorrectly(string expectedAnswer, params int[] hints)
        {
            var solver = new TrivialRowSolver();

            var length = hints.Sum() + hints.Length - 1;
            var cellCollection = new CellCollection(0, hints, CreateCellCollection(length));
            
            solver.Solve(cellCollection);

            Assert.That(cellCollection.ToString(), Is.EqualTo(expectedAnswer));
        }

        private static IReadOnlyCollection<Cell> CreateCellCollection(int length)
        {
            return Enumerable.Range(0, length).Select(i => new Cell(0, i)).ToArray();
        }
    }
}