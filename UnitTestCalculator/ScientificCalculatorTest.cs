using Calculator.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCalculator
{
    [TestClass]
    public class ScientificCalculatorTest
    {
        [TestMethod]
        public void FuncBase10Logarithm_PositiveNumbers_Success()
        {
            double arg = Double.Parse("3,7");
            var result = ScientificCalculatorController.FuncBase10Logarithm(arg);

            Assert.AreEqual(result, Math.Log10(arg));
        }

        [TestMethod]
        public void FuncSquareRoot_PositiveNumbers_Success()
        {
            double arg = Double.Parse("3,7");
            var result = ScientificCalculatorController.FuncSquareRoot(arg);

            Assert.AreEqual(result, Math.Sqrt(arg));
        }

        [TestMethod]
        public void FuncSine_PositiveNumbers_Success()
        {
            double arg = Double.Parse("3,7");
            var result = ScientificCalculatorController.FuncSine(arg);

            Assert.AreEqual(result, Math.Sin(arg));
        }

        [TestMethod]
        public void FuncCosine_PositiveNumbers_Success()
        {
            double arg = Double.Parse("3,7");
            var result = ScientificCalculatorController.FuncCosine(arg);

            Assert.AreEqual(result, Math.Cos(arg));
        }

        [TestMethod]
        public void FuncTangent_PositiveNumbers_Success()
        {
            double arg = Double.Parse("3,7");
            var result = ScientificCalculatorController.FuncTangent(arg);

            Assert.AreEqual(result, Math.Tan(arg));
        }
    }
}
