using System;

namespace GameOfLife
{
    public class Universe
    {
        private Grid _currentGrid = new Grid();
        private Grid _previousGrid;

        public void AddSeedCellAt(Coords coords)
        {
            _currentGrid.MarkLiveCellAt(coords);
        }

        public void Tick()
        {
            _previousGrid = _currentGrid;
            _currentGrid = Rules.NextGeneration(_currentGrid);
        }

        public void IterateLiveCells(Action<Coords, CellState> action)
        {
            _currentGrid.IterateLiveCells(action);
        }

        public void IterateCellsThatHaveComeAlive(Action<Coords, CellState> action)
        {
            _currentGrid.IterateLiveCells((coords, cellState) =>
                                              {
                                                  if (CellWasDeadInPreviousGrid(coords))
                                                  {
                                                      action(coords, cellState);
                                                  }
                                              });
        }

        public void IterateCellsThatHaveDied(Action<Coords, CellState> action)
        {
            if (_previousGrid == null)
            {
                return;
            }

            _previousGrid.IterateLiveCells((coords, cellState) =>
                                               {
                                                   if (CellIsDeadInCurrentGrid(coords))
                                                   {
                                                       action(coords, cellState);
                                                   }
                                               });
        }

        private bool CellWasDeadInPreviousGrid(Coords coords)
        {
            var cellHasComeAlive = true;

            if (_previousGrid != null)
            {
                cellHasComeAlive = !_previousGrid.IsLiveCellAt(coords);
            }

            return cellHasComeAlive;
        }

        private bool CellIsDeadInCurrentGrid(Coords coords)
        {
            return !_currentGrid.IsLiveCellAt(coords);
        }
    }
}
