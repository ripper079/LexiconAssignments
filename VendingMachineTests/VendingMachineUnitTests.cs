using Vending_Machine;

namespace VendingMachineTests
{
    public class VendingMachineUnitTests
    {
        [Fact]
        public void When_Inserted_1000krAnd500krAnd100krAnd50kr_And20kr_And1kr_Expect_Balance1671kr()
        {
            //Arrange
            VendingMachine unitTestVendingMachine = new VendingMachine();
            unitTestVendingMachine.InsertMoney(1000);
            unitTestVendingMachine.InsertMoney(500);
            unitTestVendingMachine.InsertMoney(100);
            unitTestVendingMachine.InsertMoney(50);
            unitTestVendingMachine.InsertMoney(20);
            unitTestVendingMachine.InsertMoney(1);

            int expected = 1671;

            //Act
            int actual = unitTestVendingMachine.MoneyPool;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_ThreeProductsPurchased_Expect_3ProductsInShoppingCart()
        {
            //Arrange
            VendingMachine unitTestVendingMachine = new VendingMachine();
            unitTestVendingMachine.InsertMoney(1000);                       
            unitTestVendingMachine.Purchase(new ProductIceCream());
            unitTestVendingMachine.Purchase(new ProductLotteryGame());
            unitTestVendingMachine.Purchase(new ProductPotatoChips());
            int expected = 3;

            //Act
            int actual = unitTestVendingMachine.CountInShoppingCart();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(8)]
        [InlineData(3)]
        public void Test_PurchasedProduct_AgainstCountInShoppingCart(int itemsPurchased)
        {
            //Arrange
            VendingMachine unitTestVendingMachine = new VendingMachine();
            unitTestVendingMachine.InsertMoney(500);

            int expected = itemsPurchased;
            
            //Act
            for (int i = 0; i < itemsPurchased; i++) 
            {
                //Any product will do
                unitTestVendingMachine.Purchase(new ProductPotatoChips());
            }

            //Act
            int actual = unitTestVendingMachine.CountInShoppingCart();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_Inserted110krLaterBuyPotatochipsAndIcecreamAndSoda_Expect_60krInReturn() 
        {
            //Arrange
            VendingMachine unitTestVendingMachine = new VendingMachine();
            unitTestVendingMachine.InsertMoney(100);
            unitTestVendingMachine.InsertMoney(10);
            unitTestVendingMachine.Purchase(new ProductPotatoChips());
            unitTestVendingMachine.Purchase(new ProductIceCream());
            unitTestVendingMachine.Purchase(new ProductSodaBeverage());
            int expected = 60;

            //Act
            int actual = unitTestVendingMachine.CalculateReturnChange();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_Inserted130krLaterBuyLotteryAndSoda_Expect_SodaPurchaseFail() 
        {
            //Arrange
            VendingMachine unitTestVendingMachine = new VendingMachine();
            unitTestVendingMachine.InsertMoney(50);
            unitTestVendingMachine.InsertMoney(50);
            unitTestVendingMachine.InsertMoney(20);
            unitTestVendingMachine.InsertMoney(10);

            Product lottery = new ProductLotteryGame();
            Product soda = new ProductSodaBeverage();
            
            unitTestVendingMachine.Purchase(lottery);

            //Act
            bool actual = unitTestVendingMachine.EnoughMoneyToBuyOneMoreProduct(soda);

            //Assert
            Assert.False(actual);

        }        
        
    }
}