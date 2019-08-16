using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod]
        [DataRow(99)]
        [DataRow(99.99)]
        [DataRow(10000)]
        [DataRow(10.9995)]
        [TestCategory("Deposit")]
        public void Deposit_SinglePositiveAmounts_AddToBalance(double amt)
        {
            //Arrange
            Account checking = new Account();
            double expectedBalance = amt;

            //Act
            checking.Deposit(amt);

            Assert.AreEqual(expectedBalance, checking.Balance);
        }

        [TestMethod()]
        [TestCategory("Deposit")]
        public void Deposit_PositiveAmount_AddsToBalance()
        {
            //AAA Pattern (Arrang, Act, Assert)

            //Arrange - Init objects/variables
            Account checking = new Account();
            double depositAmt = 10;
            double expectedBalance = 10;

            //Act -Call method under test
            checking.Deposit(depositAmt);

            //Assert - Verification step
            Assert.AreEqual(expectedBalance, checking.Balance);

        }


        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
        {
            //Arrange
            Account acc = new Account();
            double depositAmt = 10.55;
            double expectedReturn = 10.55;

            //Act
            double result = acc.Deposit(depositAmt);

            //Assert
            Assert.AreEqual(expectedReturn, result);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_NegativeAmount_ThrowsArgumentException()
        {
            //Arrange
            Account acc = new Account();
            double depositAmt = -1;

            //Assert => Act
            Assert.ThrowsException<ArgumentException>
                (() => acc.Deposit(depositAmt));
        }

        [TestInitialize]    // This runs before Every unit test
        public void InitTest()
        {
            acc = new Account();
            acc.Owner = "Some Person";
            acc.AccountNumber = "ABC123";
        }

        //Field
        Account acc;

        [TestMethod]
        public void Withdraw_PositiveAmount_ReducesBalances()
        {
            double initialDeposit = 100;
            double withdrawlAmount = 10;
            double expectedAmount = 90;

            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawlAmount);

            Assert.AreEqual(expectedAmount, acc.Balance);
        }

        [TestMethod]
        [DataRow("123456")]
        [DataRow("ABC123")]
        [DataRow("A")]
        [DataRow("99999999")]
        public void AccountNum_SetValidAcc_UpdateAccNum(string validAcc)
        {
            acc.AccountNumber = validAcc;

            Assert.AreEqual(validAcc, acc.AccountNumber);
        }

        [TestMethod]
        [DataRow("ABC#")]
        [DataRow("#ABC")]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("     ")]
        public void AccountNum_SetInvalidAcc_ThrowsException(string invalidAcc)
        {
            //Split this into multiple tests with specific exceptions
            Assert.ThrowsException<Exception>(() => acc.AccountNumber = invalidAcc);
        }
    }
}