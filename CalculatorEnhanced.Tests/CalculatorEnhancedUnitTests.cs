using CalculatorEnhanced;

// AAA Pattern I choose to follow
// Arrange 
// Act
// Assert

namespace CalculatorEnhanced.Tests
{
    public class CalculatorEnhancedUnitTests
    {
        // ADDITION
        [Fact]
        public void When_TwoPlusSix_Expect_Eight()
        {
            //Arrange
            Calculator unitTestCalculator = new Calculator(2, 6);
            int expected = 8;

            //Act
            int actual = unitTestCalculator.Addition();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given_TwoPlusTwo_When_AdditionPerformed_Then_ExpectEight() 
        {
            //Arrange
            Calculator unitTestCalculator = new Calculator(2, 6);
            int expected = 8;

            //Act
            int actual = unitTestCalculator.Addition();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_SevenTeenPlusThirtyEight_Expect_FiftyFive()
        {
            //Arrange
            Calculator unitTestCalculator = new Calculator(17, 38);
            int expected = 55;

            //Act
            int actual = unitTestCalculator.Addition();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 25, 35)]
        [InlineData(-10, 25, 15)]
        [InlineData(-5, -25, -30)]
        public void Test_CalculateAddition(int operandOne, int operandTwo, int expected)
        {
            //Arrange
            Calculator unitTestCalculator = new Calculator(operandOne, operandTwo);

            //Act
            int actual = unitTestCalculator.Addition();

            //Assert
            Assert.Equal(expected, actual);
        }

        // SUBTRACTION
        [Theory]
        [InlineData(100, 25, 75)]
        [InlineData(-100, 25, -125)]
        [InlineData(-240, 40, -280)]
        public void Test_CalculateSubtraction(int operandOne, int operandTwo, int expected)
        {
            //Arrange
            Calculator unitTestCalculator = new Calculator(operandOne, operandTwo);

            //Act
            int actual = unitTestCalculator.Subtraction();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_ArrrayPopulatedOneToTenAndSubtractAllItems_Expect_MinusFiftyFive()
        {
            //Arrange
            Calculator unitTestCalculator = new Calculator(0,0);        //Any operand will do here
            int[] arrayOfInts = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int expected = -55;

            //Act
            int actual = unitTestCalculator.Subtraction(arrayOfInts);

            //Assert
            Assert.Equal(expected, actual);
        }

        // MULTIPLICATION
        [Theory]
        [InlineData(100, 25, 2500)]
        [InlineData(-100, 2, -200)]
        [InlineData(-240, -40, 9600)]
        public void Test_CalculateMultiplication(int operandOne, int operandTwo, int expected)
        {
            //Arrange
            Calculator unitTestCalculator = new Calculator(operandOne, operandTwo);

            //Act 
            int actual = unitTestCalculator.Multiplication();

            //Assert
            Assert.Equal(expected, actual);
        }


        // DIVISION
        [Fact]
        public void When_TenDividedByZero_Expect_Infinity()
        {
            //Arrange
            Calculator unitTestCalculator = new Calculator(10, 0);            
            double expected = 50.0 / 0.0;   //Hack for simulate infinity literal value
            
            //Act
            double actual = unitTestCalculator.Division();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_FiftenDividedByTwo_Expect_SevenAndHalf()
        {
            //Arrange
            Calculator unitTestCalculator = new Calculator(15, 2);
            double expected = 7.5;

            //Act
            double actual = unitTestCalculator.Division();

            //Assert
            Assert.Equal(expected, actual);
        }


    }
    
}