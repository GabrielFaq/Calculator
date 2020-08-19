using Calculator.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCalculator
{
    [TestClass]
    public class StandardCalculatorTest
    {
        [TestMethod]
        public void FuncAddition_PositiveNumbers_Success()
        {
            decimal arg1 = Decimal.Parse("3,7");
            decimal arg2 = Decimal.Parse("2,4");
            var result = StandardCalculatorController.FuncAddition(arg1, arg2);

            Assert.AreEqual(result, arg1 + arg2);
        }

        [TestMethod]
        public void FuncSubtraction_PositiveNumbers_Success()
        {
            decimal arg1 = Decimal.Parse("3,7");
            decimal arg2 = Decimal.Parse("2,4");
            var result = StandardCalculatorController.FuncSubtraction(arg1, arg2);

            Assert.AreEqual(result, arg1 - arg2);
        }

        [TestMethod]
        public void FuncDivision_PositiveNumbers_Success()
        {
            decimal arg1 = Decimal.Parse("3,7");
            decimal arg2 = Decimal.Parse("2,4");
            var result = StandardCalculatorController.FuncDivision(arg1, arg2);

            Assert.AreEqual(result, arg1 / arg2);
        }

        [TestMethod]
        public void FuncMultiplication_PositiveNumbers_Success()
        {
            decimal arg1 = Decimal.Parse("3,7");
            decimal arg2 = Decimal.Parse("2,4");
            var result = StandardCalculatorController.FuncMultiplication(arg1, arg2);

            Assert.AreEqual(result, arg1 * arg2);
        }
    }
}
