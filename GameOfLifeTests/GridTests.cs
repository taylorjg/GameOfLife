using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    internal class GridTests
    {
        [Test]
        public void IsLiveCellAt_GivenCoordsWhereThereIsNoLiveCell_ReturnsFalse()
        {
            // Arrange
            var grid = new Grid();
            var coords = Coords.Create(12, 13);

            // Act
            var actual = grid.IsLiveCellAt(coords);

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void IsLiveCellAt_GivenCoordsWhereThereIsALiveCell_ReturnsTrue()
        {
            // Arrange
            var grid = new Grid();
            var coords = Coords.Create(12, 13);
            grid.MarkLiveCellAt(coords);

            // Act
            var actual = grid.IsLiveCellAt(coords);

            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void IterateLiveCells_GivenGridWithOneLiveCell_InvokesActionOnce()
        {
            // Arrange
            var grid = new Grid();
            grid.MarkLiveCellAt(Coords.Create(12, 13));
            var numInvocations = 0;

            // Act
            grid.IterateLiveCells((_, __) => numInvocations++);

            // Assert
            Assert.That(numInvocations, Is.EqualTo(1));
        }

        [Test]
        public void IterateLiveCells_GivenGridWithTwoLiveCells_InvokesActionTwice()
        {
            // Arrange
            var grid = new Grid();
            grid.MarkLiveCellAt(Coords.Create(12, 13));
            grid.MarkLiveCellAt(Coords.Create(13, 13));
            var numInvocations = 0;

            // Act
            grid.IterateLiveCells((_, __) => numInvocations++);

            // Assert
            Assert.That(numInvocations, Is.EqualTo(2));
        }

        [Test]
        public void MarkLiveCellAt_CalledTwiceForTheSameCell_DoesNotAddCellTwice()
        {
            // Arrange
            var grid = new Grid();
            var coords = Coords.Create(12, 13);
            grid.MarkLiveCellAt(coords);
            grid.MarkLiveCellAt(coords);
            var numInvocations = 0;

            // Act
            grid.IterateLiveCells((_, __) => numInvocations++);

            // Assert
            Assert.That(numInvocations, Is.EqualTo(1));
        }
    }
}
