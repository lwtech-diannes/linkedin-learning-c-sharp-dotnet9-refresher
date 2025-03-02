// C# code​​​​​​‌‌​​‌‌​​‌‌​‌‌‌​‌​‌‌​‌‌​‌‌ below
using System;

// Write your answer here, and then test your code.
// Your job is to implement the findLargest() method.

public class Program
{
    static void Main(string[] args)
    {
        // This is how your code will be called.
        // You can edit this code to try different testing cases.
        bool IsSuccessful = true;
        // Create the Checking Account with initial balance.
        CheckingAcct checking = new CheckingAcct("John", "Doe", 2500.0m);
        IsSuccessful &= (checking.Balance == 2500.0m);
        IsSuccessful &= (checking.AccountOwner == "John Doe");

        // Create the Savings Account with interest and initial balance.
        SavingsAcct saving = new SavingsAcct("Jane", "Doe", 0.03m, 1000.0m);
        IsSuccessful &= (saving.Balance == 1000.0m);
        IsSuccessful &= (saving.AccountOwner == "Jane Doe");

        // Deposit some money in each account.
        checking.Deposit(200.0m);
        saving.Deposit(150.0m);
        IsSuccessful &= (checking.Balance == 2700.0m);
        IsSuccessful &= (saving.Balance == 1150.0m);

        // Make some withdrawals from each account.
        checking.Withdraw(50.0m);
        saving.Withdraw(125.0m);
        IsSuccessful &= (checking.Balance == 2650.0m);
        IsSuccessful &= (saving.Balance == 1025.0m);

        // Apply the Savings interest.
        saving.ApplyInterest();
        IsSuccessful &= (saving.Balance == 1055.75m);

        // More than three Savings withdrawals should result in $2 charge.
        saving.Withdraw(10.0m);
        saving.Withdraw(20.0m);
        saving.Withdraw(30.0m);
        IsSuccessful &= (saving.Balance == 993.75m);

        // try to overdraw savings - this should be denied
        saving.Withdraw(2000.0m);
        // try to overdraw checking - should be allowed and result in extra charge
        checking.Withdraw(3000.0m);
        IsSuccessful &= (saving.Balance == 993.75m);
        IsSuccessful &= (checking.Balance == -385.00m);

    }




}

public class BankAccount
{

    private string _firstname;
    private string _lastname;
    public decimal Balance { get; set; }
    public BankAccount(string firstName, string lastName, decimal startingBal = 0.0m)
    {
        _firstname = firstName;
        _lastname = lastName;
        Balance = startingBal;
    }

    public string AccountOwner
    {
        get => $"{_firstname} {_lastname}";
    }

    public virtual void Deposit(decimal deposit)
    {
        Balance += deposit;
    }

    public virtual void Withdraw(decimal withdrawal)
    {
        Balance -= withdrawal;
    }

}

public class CheckingAcct : BankAccount
{
    private const decimal OVERDRAFT_FEE = 35.0m;
    public CheckingAcct(string firstName, string lastName, decimal startingBal)
        : base(firstName, lastName, startingBal)
    {
    }

    public override void Withdraw(decimal withdrawal)
    {
        if (withdrawal > Balance)
        {
            withdrawal += OVERDRAFT_FEE;
        }
        base.Withdraw(withdrawal);
    }
}

public class SavingsAcct : BankAccount
{
    private int _count = 0;
    private const decimal WITHDRAWAL_FEE = 2.0m;
    private const int WITHDRAWAL_LIMIT = 3;

    public SavingsAcct(string firstName, string lastName, decimal interestRate, decimal startingBal)
        : base(firstName, lastName, startingBal)
    {
        InterestRate = interestRate;
    }

    public decimal InterestRate { get; set; }
    public void ApplyInterest()
    {
        // add the new amount to the existing balance
        Balance += (Balance * InterestRate);
    }

    public override void Withdraw(decimal withdrawal)
    {
        if (withdrawal > Balance)
        {
            Console.WriteLine("Withdrawal denied: Insufficient funds.");
        }
        else
        {
            base.Withdraw(withdrawal);
            // Increase count to charge for more than 3 withdrawals
            _count++;
            if (_count > WITHDRAWAL_LIMIT)
            {
                Console.WriteLine("Withdrawal limit exceeded. Additional fee applied.");
                base.Withdraw(WITHDRAWAL_FEE);
            }
        }

    }

}
