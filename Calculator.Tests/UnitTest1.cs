using Assignment_01;

namespace Calculator.Tests
{
    public class UnitTestsOnCalculator
    {
        // ADDITION
        [Fact]
        public void When_TwoPlusSix_Expect_Eight()
        {
            int expected = 8;
            int actual = Program.Addition(2, 6);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_SevenTeenPlusThirtyEight_Expect_FiftyFive()
        {
            int expected = 55;
            int actual = Program.Addition(17, 38);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 25, 35)]
        [InlineData(-10, 25, 15)]
        [InlineData(-5, -25, -30)]
        public void Test_CalculateAddition(int numberOne, int numberTwo, int expected)
        {
            int actual = Program.Addition(numberOne, numberTwo);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_ArrrayPopulatedOneToTenAndAddAllItems_Expect_FiftyFive() 
        {
            int[] arrayOfInts = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int expected = 55;
            int actual = Program.Addition(arrayOfInts);

            Assert.Equal(expected, actual);
        }        


        // SUBTRACTION
        [Theory]
        [InlineData(100, 25, 75)]
        [InlineData(-100, 25, -125)]
        [InlineData(-240, 40, -280)]
        public void Test_CalculateSubtraction(int numberOne, int numberTwo, int expected)
        {
            int actual = Program.Subtraction(numberOne, numberTwo);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_ArrrayPopulatedOneToTenAndSubtractAllItems_Expect_MinusFiftyFive()
        {
            int[] arrayOfInts = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int expected = -55;
            int actual = Program.Subtraction(arrayOfInts);

            Assert.Equal(expected, actual);
        }

        // MULTIPLICATION
        [Theory]
        [InlineData(100, 25, 2500)]
        [InlineData(-100, 2, -200)]
        [InlineData(-240, -40, 9600)]
        public void Test_CalculateMultiplication(int numberOne, int numberTwo, int expected)
        {
            int actual = Program.Multiplication(numberOne, numberTwo);

            Assert.Equal(expected, actual);
        }


        // DIVISION
        [Fact]        
        public void When_TenDividedByZero_Expect_Infinity() 
        {
            //Hack for simulate infinity literal value
            double expected = 10.0 / 0.0;
            double actual = Program.Division(60, 0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_FiftenDividedByTwo_Expect_SevenAndHalf()         
        {
            double expected = 7.5;            
            double actual = Program.Division(15, 2);

            Assert.Equal(expected, actual);
        }
    }
}