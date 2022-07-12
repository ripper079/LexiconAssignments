using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    //Code requirement 2-0
    public interface IVending
    {
        //Code requirement 2-1
        public void Purchase(Product aProduct);         //to buy a product.
        
        //Code requirement 2-2
        public void ShowAll();                          //show all products.

        //Code requirement 2-3
        public void InsertMoney(int amountMoney);       //add money to the pool.

        //Code requirement 2-4
        public string EndTransaction();                  //returns money left in appropriate amount of change(Dictionary

    }
}
