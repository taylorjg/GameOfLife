using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    internal class IntegrationTests
    {
        [Test]
        public void TheExpectedPatternShouldBeGeneratedWhenTheSeedIsToad()
        {
            // http://en.wikipedia.org/wiki/File:Game_of_life_toad.gif

            // 
            //  XXX
            // XXX
            // 
            var setOfCoords1 = new[]
                                  {
                                      Coords.Create(0, 0),
                                      Coords.Create(1, 0),
                                      Coords.Create(2, 0),
                                      Coords.Create(1, 1),
                                      Coords.Create(2, 1),
                                      Coords.Create(3, 1)
                                  };

            //   X
            // X  X
            // X  X
            //  X
            var setOfCoords2 = new[]
                                  {
                                      Coords.Create(2, 2),
                                      Coords.Create(3, 0),
                                      Coords.Create(3, 1),
                                      Coords.Create(0, 0),
                                      Coords.Create(0, 1),
                                      Coords.Create(1, -1)
                                  };

            var universe = new Universe();
            MarkLiveCells(universe, setOfCoords1);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords2);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords1);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords2);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords1);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords2);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords1);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords2);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords1);
        }

        [Test]
        public void TheExpectedPatternShouldBeGeneratedWhenTheSeedIsBeacon()
        {
            // http://en.wikipedia.org/wiki/File:Game_of_life_beacon.gif

            // XX
            // XX
            //   XX
            //   XX
            var setOfCoords1 = new[]
                                   {
                                       Coords.Create(-1, 1),
                                       Coords.Create(-2, 1),
                                       Coords.Create(-1, 0),
                                       Coords.Create(-2, 0),
                                       Coords.Create(0, -1),
                                       Coords.Create(1, -1),
                                       Coords.Create(0, -2),
                                       Coords.Create(1, -2)
                                   };

            // XX
            // X
            //    X
            //   XX
            var setOfCoords2 = new[]
                                  {
                                       Coords.Create(-1, 1),
                                       Coords.Create(-2, 1),
                                       Coords.Create(-2, 0),
                                       Coords.Create(1, -1),
                                       Coords.Create(0, -2),
                                       Coords.Create(1, -2)
                                  };

            var universe = new Universe();
            MarkLiveCells(universe, setOfCoords1);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords2);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords1);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords2);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords1);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords2);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords1);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords2);
            AssertThatGridContainsExpectedLiveCellsAfterTick(universe, setOfCoords1);
        }

        private void MarkLiveCells(Universe universe, params Coords[] setOfcoords)
        {
            foreach (var coords in setOfcoords)
            {
                universe.AddSeedCellAt(coords);
            }
        }

        private void AssertThatGridContainsExpectedLiveCellsAfterTick(Universe universe, Coords[] setOfExpectedCoords)
        {
            universe.Tick();

            var coordsOfLiveCells = new List<Coords>();
            universe.IterateLiveCells((coords, cellState) => coordsOfLiveCells.Add(coords));

            Assert.That(setOfExpectedCoords, Is.Unique);
            Assert.That(coordsOfLiveCells, Is.Unique);

            Assert.That(coordsOfLiveCells.Count(), Is.EqualTo(setOfExpectedCoords.Count()), "Found the wrong number of live cells");

            foreach (var expectedCoords in setOfExpectedCoords)
            {
                var match = coordsOfLiveCells.FirstOrDefault(coords => coords.Equals(expectedCoords));
                var message = string.Format("Expected to find a live cell at ({0}, {1})", expectedCoords.X, expectedCoords.Y);
                Assert.That(match, Is.Not.Null, message);
            }
        }
    }
}
