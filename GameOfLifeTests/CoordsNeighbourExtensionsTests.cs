using System.Linq;
using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    internal class CoordsNeighbourExtensionsTests
    {
        private Coords _coords;

        [SetUp]
        public void SetUp()
        {
            _coords = new Coords(12, 13);
        }

        [Test]
        public void MethodsReturningNeighbourCoords_GivenValidCoords_ReturnTheCorrectValues()
        {
            Assert.That(_coords.Left().X, Is.EqualTo(_coords.X - 1));
            Assert.That(_coords.Left().Y, Is.EqualTo(_coords.Y));

            Assert.That(_coords.Right().X, Is.EqualTo(_coords.X + 1));
            Assert.That(_coords.Right().Y, Is.EqualTo(_coords.Y));

            Assert.That(_coords.Above().X, Is.EqualTo(_coords.X));
            Assert.That(_coords.Above().Y, Is.EqualTo(_coords.Y + 1));

            Assert.That(_coords.Below().X, Is.EqualTo(_coords.X));
            Assert.That(_coords.Below().Y, Is.EqualTo(_coords.Y - 1));

            Assert.That(_coords.AboveLeft().X, Is.EqualTo(_coords.X - 1));
            Assert.That(_coords.AboveLeft().Y, Is.EqualTo(_coords.Y + 1));

            Assert.That(_coords.AboveRight().X, Is.EqualTo(_coords.X + 1));
            Assert.That(_coords.AboveRight().Y, Is.EqualTo(_coords.Y + 1));

            Assert.That(_coords.BelowLeft().X, Is.EqualTo(_coords.X - 1));
            Assert.That(_coords.BelowLeft().Y, Is.EqualTo(_coords.Y - 1));

            Assert.That(_coords.BelowRight().X, Is.EqualTo(_coords.X + 1));
            Assert.That(_coords.BelowRight().Y, Is.EqualTo(_coords.Y - 1));
        }

        [Test]
        public void Neighbours_GivenValidCoords_ReturnsACollectionOfNeighbourCoords()
        {
            // Arrange, Act
            var neighbours = _coords.Neighbours().ToList();

            // Assert
            Assert.That(neighbours.Count(), Is.EqualTo(8));
            Assert.That(neighbours, Is.Unique);
            foreach (var neighbour in neighbours)
            {
                var isNeighbour =
                    neighbour.Equals(_coords.Left()) ||
                    neighbour.Equals(_coords.Right()) ||
                    neighbour.Equals(_coords.Above()) ||
                    neighbour.Equals(_coords.Below()) ||
                    neighbour.Equals(_coords.AboveLeft()) ||
                    neighbour.Equals(_coords.AboveRight()) ||
                    neighbour.Equals(_coords.BelowLeft()) ||
                    neighbour.Equals(_coords.BelowRight());
                var message = string.Format("Cell ({0}, {1}) is not a neighbour of ({2}, {3})", neighbour.X, neighbour.Y, _coords.X, _coords.Y);
                Assert.That(isNeighbour, Is.True, message);
            }
        }
    }
}
