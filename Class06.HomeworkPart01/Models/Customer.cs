namespace Class06.HomeworkPart01.Models
{
    public class Customer
    {

        public Customer()
        {
            
        }

        public Customer(string cardNumber, int pinNumber, double balance, string customerName)
        {
            CardNumber = cardNumber;
            PinNumber = pinNumber;
            Balance = balance;
            CustomerName = customerName;
        }

        public string CardNumber { get; set; }
        private int PinNumber { get; set; }
        private double Balance { get; set; }
        public string CustomerName { get; set; }


        public string getNum()
        {
            return CardNumber;
        }

        public int getPin()
        {
            return PinNumber;
        }

        public string getCustomerName()
        {
            return CustomerName;
        }

        public double getBalance()
        {
            return Balance;
        }


        public double Withdraw(double withdrawSum)
        {
        double withdrawnBalance = Balance - withdrawSum;

                if (withdrawSum > 0 && withdrawSum <= Balance)
                {

                    Balance = withdrawnBalance;
                }
            else
            {
                Console.WriteLine("Insuficient funds");
            }

            return Balance;
        }



    }
}
