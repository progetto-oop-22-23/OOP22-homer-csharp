using Homer;

namespace HomerTest
{
    [TestClass]
    public class BoundsTest
    {
        private static readonly int s_lowerBound = 0;
        private static readonly int s_upperBound = 1;
        private readonly Bounds<int> _bounds = new(s_lowerBound, s_upperBound);

        [TestMethod]
        public void TestLowerBound()
        {
            Assert.AreEqual(s_lowerBound, _bounds.LowerBound);
        }

        [TestMethod]
        public void TestUpperBound()
        {
            Assert.AreEqual(s_upperBound, _bounds.UpperBound);
        }

        [TestMethod]
        public void TestException()
        {
            Assert.ThrowsException<InvertedBoundsException>(() => new Bounds<int>(s_upperBound, s_lowerBound));
        }
    }
}
