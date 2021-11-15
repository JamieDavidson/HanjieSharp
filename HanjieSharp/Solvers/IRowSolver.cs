using HanjieSharp.Domain;

namespace HanjieSharp.Solvers
{
    internal interface IRowSolver
    {
        public void Solve(CellCollection cellCollection);
    }
}