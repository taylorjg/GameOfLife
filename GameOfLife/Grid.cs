using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Grid
    {
        private readonly IDictionary<Coords, CellState> _cells = new Dictionary<Coords, CellState>();

        public void MarkLiveCellAt(Coords coords)
        {
            _cells[coords] = CellState.AliveCellState();
        }

        public bool IsLiveCellAt(Coords coords)
        {
            return _cells.ContainsKey(coords) && _cells[coords].IsAlive;
        }

        public void IterateLiveCells(Action<Coords> action)
        {
            foreach (var coords in _cells.Keys.Where(IsLiveCellAt))
            {
                action(coords);
            }
        }
    }
}
