using System;
using HanjieSharp.Domain;

namespace HanjieSharp
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var columnHints = new[]
            {
                new[] {10},
                new[] {1, 1},
                new[] {1, 1, 1, 1, 1},
                new[] {1, 1, 1, 1, 1},
                new[] {1, 1, 1, 1, 1},
                new[] {1, 1},
                new[] {1, 1},
                new[] {1, 1, 1},
                new[] {1, 1},
                new[] {10}
            };

            var rowHints = new[]
            {
                new[] {10},
                new[] {1, 1},
                new[] {1, 1, 1},
                new[] {1, 3, 1},
                new[] {1, 1},
                new[] {1, 3, 1},
                new[] {1, 1},
                new[] {1, 3, 1},
                new[] {1, 1},
                new[] {10}
            };
            
            var grid = new Grid(10, 10, columnHints, rowHints);
            
            grid.Solve();
            
            Console.WriteLine(grid.ToString());
        }
    }
}