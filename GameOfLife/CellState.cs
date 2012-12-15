namespace GameOfLife
{
    internal class CellState
    {
        private CellState()
        {
            IsAlive = false;
        }

        public bool IsAlive { get; private set; }

        public static CellState AliveCellState()
        {
            return new CellState { IsAlive = true };
        }
    }
}
