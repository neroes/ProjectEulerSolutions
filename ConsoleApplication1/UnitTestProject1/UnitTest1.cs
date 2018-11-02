using System;
using Microsoft.FSharp.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestProblem01()
        {
            long result = ProjectEuler001_100.Problem001(10, ListModule.OfSeq(new int[] { 3, 5}));
            long expected = 23L;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestProblem02()
        {
            long result = ProjectEuler001_100.Problem002(2, 4000000);
            long expected = 4613732L;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestProblem03()
        {
            long result = ProjectEuler001_100.Problem003(13195);
            long expected = 29L;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestProblem04()
        {
            long result = ProjectEuler001_100.Problem004;
            long expected = 906609L;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestProblem05()
        {
            long result = ProjectEuler001_100.Problem005(10);
            long expected = 2520L;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestProblem06()
        {
            long result = ProjectEuler001_100.Problem006(10);
            long expected = 2640L;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestProblem07()
        {
            long result = ProjectEuler001_100.Problem007(6);
            long expected = 13L;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestProblem08()
        {
            string searchtext = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            long result = ProjectEuler001_100.Problem008(searchtext, 4);
            long expected = 5832L;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestProblem09()
        {
            long result = ProjectEuler001_100.Problem009(25);
            long expected = 60L;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestProblem10()
        {
            long result = ProjectEuler001_100.Problem010(10);
            long expected = 17L;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestProblem11()// result test later
        {
            long result = ProjectEuler001_100.Problem011(25,5);
            long expected = 60L;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestProblem88()
        {
            long result = ProjectEuler001_100.Problem088(12L);
            long expected = 61L;
            Assert.AreEqual(expected, result);
        }
    }
}
