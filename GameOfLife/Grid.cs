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

        public void MarkWasPreviouslyAliveCellAt(Coords coords)
        {
            _cells[coords] = CellState.WasPreviouslyAliveCellState();
        }

        public void MarkZombieCellAt(Coords coords)
        {
            _cells[coords] = CellState.ZombieCellState();
        }

        public bool IsLiveCellAt(Coords coords)
        {
            return _cells.ContainsKey(coords) && _cells[coords].IsAlive;
        }

        public bool CellWasPreviouslyAliveAt(Coords coords)
        {
            return _cells.ContainsKey(coords) && _cells[coords].WasPreviouslyAlive;
        }

        public void IterateLiveCells(Action<Coords, CellState> action)
        {
            foreach (var kvp in _cells.Where(kvp => IsLiveCellAt(kvp.Key)))
            {
                action(kvp.Key, kvp.Value);
            }
        }
    }
}
