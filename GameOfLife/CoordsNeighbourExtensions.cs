using System.Collections.Generic;

namespace GameOfLife
{
    public static class CoordsNeighbourExtensions
    {
        private static int LeftOfX(this Coords coords) { return coords.X - 1; }
        private static int RightOfX(this Coords coords) { return coords.X + 1; }
        private static int AboveY(this Coords coords) { return coords.Y + 1; }
        private static int BelowY(this Coords coords) { return coords.Y - 1; }

        public static Coords Left(this Coords coords) { return Coords.Create(coords.LeftOfX(), coords.Y); }
        public static Coords Right(this Coords coords) { return Coords.Create(coords.RightOfX(), coords.Y); }
        public static Coords Above(this Coords coords) { return Coords.Create(coords.X, coords.AboveY()); }
        public static Coords Below(this Coords coords) { return Coords.Create(coords.X, coords.BelowY()); }
        public static Coords AboveLeft(this Coords coords) { return Coords.Create(coords.LeftOfX(), coords.AboveY()); }
        public static Coords AboveRight(this Coords coords) { return Coords.Create(coords.RightOfX(), coords.AboveY()); }
        public static Coords BelowLeft(this Coords coords) { return Coords.Create(coords.LeftOfX(), coords.BelowY()); }
        public static Coords BelowRight(this Coords coords) { return Coords.Create(coords.RightOfX(), coords.BelowY()); }

        public static IEnumerable<Coords> Neighbours(this Coords coords)
        {
            return new[]
                       {
                           coords.Left(),
                           coords.Right(),
                           coords.BelowLeft(),
                           coords.Below(),
                           coords.BelowRight(),
                           coords.AboveLeft(),
                           coords.Above(),
                           coords.AboveRight()
                       };
        }
    }
}
