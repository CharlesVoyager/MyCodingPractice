using MaxSubarrayDivisibleByK;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution test = new Solution();

            long result = test.MaxSubarraySum(new int[] { -41, -40, 1, -28, -14 }, 3);
            Assert.AreEqual(-41, result);

            result = test.MaxSubarraySum(new int[] { 0, -5 }, 1);
            Assert.AreEqual(0, result);
        }
    }
}