using Common.Contracts;
using NUnit.Framework;

namespace MartianRobots.Test
{
    [TestFixture]
    public class MarsSurfaceTest
    {
        private MarsSurface _testee;

        [SetUp]
        public void Setup()
        {
            _testee = new MarsSurface(new Vector2(5, 3));
        }
        [Test]
        public void InSurface_WhenCoordinateInSurface_ReturnTrue()
        {
            Assert.AreEqual( true, _testee.InSurface( new Vector2(1, 1) ) );
            Assert.AreEqual( true, _testee.InSurface( new Vector2(0, 0) ) );
            Assert.AreEqual( true, _testee.InSurface( new Vector2(4, 2) ) );
            Assert.AreEqual( true, _testee.InSurface( new Vector2(2, 2) ) );
        }

        [Test]
        public void InSurface_WhenCoordinateNotInSurface_ReturnFalse()
        {
            Assert.AreEqual(false, _testee.InSurface(new Vector2(-1, 1)));
            Assert.AreEqual(false, _testee.InSurface(new Vector2(6, 0)));
            Assert.AreEqual(false, _testee.InSurface(new Vector2(4, 4)));
            Assert.AreEqual(false, _testee.InSurface(new Vector2(5, -1)));
        }
    }
}