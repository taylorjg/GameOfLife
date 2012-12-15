namespace GameOfLife
{
    public class CellState
    {
        private CellState()
        {
            IsAlive = false;
            IsZombie = false;
            WasPreviouslyAlive = false;
        }

        public bool IsAlive { get; private set; }
        public bool IsZombie { get; private set; }
        public bool WasPreviouslyAlive { get; private set; }

        public static CellState AliveCellState()
        {
            return new CellState {IsAlive = true};
        }

        public static CellState ZombieCellState()
        {
            return new CellState {IsAlive = true, IsZombie = true};
        }

        public static CellState WasPreviouslyAliveCellState()
        {
            return new CellState {WasPreviouslyAlive = true};
        }
    }
}
