using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    internal class CoordsTests
    {
        [Test]
        public void Create_GivenSomeCoords_CreatesAnInstanceOfCoordsWithCorrectProperties()
        {
            // Arrange, Act
            var coords = Coords.Create(12, 13);

            // Assert
            Assert.That(coords.X, Is.EqualTo(12));
            Assert.That(coords.Y, Is.EqualTo(13));
        }

        [TestCase(3, 4, true)]
        [TestCase(3, 5, false)]
        [TestCase(4, 4, false)]
        [TestCase(4, 5, false)]
        public void Equals_GivenRhsWithVariousXY_ReturnsCorrectResult(int x, int y, bool expected)
        {
            // Arrange
            var lhs = Coords.Create(3, 4);
            var rhs = Coords.Create(x, y);

            // Act
            var actual = lhs.Equals(rhs);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Equals_GivenItself_ReturnsTrue()
        {
            // Arrange
            var lhs = Coords.Create(3, 4);

            // Act
// ReSharper disable EqualExpressionComparison
            var actual = lhs.Equals(lhs);
// ReSharper restore EqualExpressionComparison

            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void Equals_GivenNull_ReturnsFalse()
        {
            // Arrange
            var lhs = Coords.Create(3, 4);

            // Act
            var actual = lhs.Equals(null);

            // Assert
            Assert.That(actual, Is.False);
        }

        [TestCase(3, 4, 3, 4, true)]
        [TestCase(3, 4, 5, 6, false)]
        [TestCase(3, 4, 4, 3, false)]
        [TestCase(4, 3, 3, 4, false)]
        public void GetHashCode_ForTwoInstancesOfCoords_ReturnsSameHashCodeForEqualObjects(int x1, int y1, int x2, int y2, bool expected)
        {
            // Arrange
            var coords1 = Coords.Create(x1, y1);
            var coords2 = Coords.Create(x2, y2);

            // Act
            var hashCode1 = coords1.GetHashCode();
            var hashCode2 = coords2.GetHashCode();

            // Assert
            Assert.That(hashCode1 == hashCode2, Is.EqualTo(expected));
        }
    }
}
