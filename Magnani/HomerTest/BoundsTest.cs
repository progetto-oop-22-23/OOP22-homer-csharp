using Homer;

namespace HomerTest
{
    [TestClass]
    public class BoundsTest
    {
        private static readonly int LOWER_BOUND = 0;
        private static readonly int UPPER_BOUND = 1;
        private readonly Bounds<int> bounds = new(LOWER_BOUND, UPPER_BOUND);

        [TestMethod]
        public void TestLowerBound()
        {
            Assert.AreEqual(LOWER_BOUND, bounds.LowerBound);
        }

        [TestMethod]
        public void TestUpperBound()
        {
            Assert.AreEqual(UPPER_BOUND, bounds.UpperBound);
        }

        [TestMethod]
        public void TestException()
        {
            Assert.ThrowsException<InvertedBoundsException>(() => new Bounds<int>(UPPER_BOUND, LOWER_BOUND));
        }
    }
}
