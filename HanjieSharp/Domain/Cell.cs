using System;

namespace HanjieSharp.Domain
{
    internal sealed class Cell
    {
        public int X { get; }
        public int Y { get; }
        public CellState State { get; private set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            State = CellState.None;
        }

        public void UpdateNodeState(CellState newState)
        {
            State = newState;
        }

        public override string ToString()
        {
            return State switch
            {
                CellState.None => " ",
                CellState.Yes => "O",
                CellState.No => "X",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    internal enum CellState
    {
        None,
        Yes,
        No
    }
}