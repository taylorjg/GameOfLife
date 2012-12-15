using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    internal class RulesTests
    {
        [Test]
        public void AnyLiveCellWithNoLiveNeighboursDies()
        {
            // Arrange
            var grid = new Grid();
            var cellCoords = Coords.Create(1, 1);
            grid.MarkLiveCellAt(cellCoords);

            // Act
            var actual = Rules.CurrentlyAliveCellWillStillBeALiveInTheNextGeneration(grid, cellCoords);

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void AnyLiveCellWithOneLiveNeighbourDies()
        {
            // Arrange
            var grid = new Grid();
            var cellCoords = Coords.Create(1, 1);
            grid.MarkLiveCellAt(cellCoords);
            grid.MarkLiveCellAt(cellCoords.Above());

            // Act
            var actual = Rules.CurrentlyAliveCellWillStillBeALiveInTheNextGeneration(grid, cellCoords);

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void AnyLiveCellWithTwoLiveNeighboursLivesOnToTheNextGeneration()
        {
            // Arrange
            var grid = new Grid();
            var cellCoords = Coords.Create(1, 1);
            grid.MarkLiveCellAt(cellCoords);
            grid.MarkLiveCellAt(cellCoords.Above());
            grid.MarkLiveCellAt(cellCoords.Below());

            // Act
            var actual = Rules.CurrentlyAliveCellWillStillBeALiveInTheNextGeneration(grid, cellCoords);

            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void AnyLiveCellWithThreeLiveNeighboursLivesOnToTheNextGeneration()
        {
            // Arrange
            var grid = new Grid();
            var cellCoords = Coords.Create(1, 1);
            grid.MarkLiveCellAt(cellCoords);
            grid.MarkLiveCellAt(cellCoords.Above());
            grid.MarkLiveCellAt(cellCoords.Below());
            grid.MarkLiveCellAt(cellCoords.BelowLeft());

            // Act
            var actual = Rules.CurrentlyAliveCellWillStillBeALiveInTheNextGeneration(grid, cellCoords);

            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void AnyLiveCellWithFourLiveNeighboursLivesOnToTheNextGeneration()
        {
            // Arrange
            var grid = new Grid();
            var cellCoords = Coords.Create(1, 1);
            grid.MarkLiveCellAt(cellCoords);
            grid.MarkLiveCellAt(cellCoords.Above());
            grid.MarkLiveCellAt(cellCoords.Below());
            grid.MarkLiveCellAt(cellCoords.BelowLeft());
            grid.MarkLiveCellAt(cellCoords.BelowRight());

            // Act
            var actual = Rules.CurrentlyAliveCellWillStillBeALiveInTheNextGeneration(grid, cellCoords);

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void AnyDeadCellWithExactlyThreeLiveNeighboursBecomesALiveCell()
        {
            // Arrange
            var grid = new Grid();
            var cellCoords = Coords.Create(1, 1);
            grid.MarkLiveCellAt(cellCoords.Above());
            grid.MarkLiveCellAt(cellCoords.Below());
            grid.MarkLiveCellAt(cellCoords.BelowLeft());

            // Act
            var actual = Rules.CurrentlyDeadCellWillBecomeALiveInTheNextGeneration(grid, cellCoords);

            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void AnyDeadCellWithExactlyTwoLiveNeighboursStaysDead()
        {
            // Arrange
            var grid = new Grid();
            var cellCoords = Coords.Create(1, 1);
            grid.MarkLiveCellAt(cellCoords.Below());
            grid.MarkLiveCellAt(cellCoords.BelowLeft());

            // Act
            var actual = Rules.CurrentlyDeadCellWillBecomeALiveInTheNextGeneration(grid, cellCoords);

            // Assert
            Assert.That(actual, Is.False);
        }
    }
}
