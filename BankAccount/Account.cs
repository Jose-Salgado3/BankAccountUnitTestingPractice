﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a customers bank account
    /// </summary>
    public class Account
    {
        private string _accountNumber;

        // Name of account holder
        // Account number
        // Balance
        public string AccountNumber
        {
            get
            {
               return _accountNumber;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException
                        ($"{nameof(AccountNumber)} cannot be null");
                }
                if (value.Trim() == string.Empty)
                {
                    throw new ArgumentException("Empty/Whitespace is not allowed");
                }
                const string illegalCharacter = "#";
                if (value.Contains(illegalCharacter))
                {
                    throw new ArgumentException
                        ($"{nameof(AccountNumber)} cannot contain # signs");
                }
                _accountNumber = value;
            }
        }
        public string Owner { get; set; }

        public double Balance { get; private set; }

        /// <summary>
        /// Adds an amount to the current balance and returns the updated balance
        /// </summary>
        /// <param name="amt">The amount to add</param>
        /// <returns></returns>
        public double Deposit(double amt)
        {
            if (amt < 0)
                throw new ArgumentException($"{nameof(amt)} cannot be negative");

            Balance += amt;
            return Balance;
        }

        /// <summary>
        /// Subtracts an amount ot the current balance and returns the updated balance
        /// </summary>
        /// <param name="amt">The amount to be withdrawn</param>
        /// <returns></returns>
        public double Withdraw(double amt)
        {
            Balance -= amt;
            return Balance;
        }
    }
}
