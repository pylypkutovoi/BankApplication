﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public class DepositAccount : Account
    {
        public DepositAccount(decimal sum, int percentage)
            : base(sum, percentage)
        {

        }

        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs($"A new deposit account has been opened! Account Id: {this.Id}", this.Sum));
        }

        public override void Put(decimal sum)
        {
            if (_days % 30 == 0)
            {
                base.Put(sum);
            }
            else
            {
                base.OnAdded(new AccountEventArgs("You can only deposit to your account after a 30-day period", 0));
            }
        }

        public override decimal Withdraw(decimal sum)
        {
            if (_days % 30 == 0)
            {
                return base.Withdraw(sum);
            }
            else
            {
                base.OnWithdrawed(new AccountEventArgs("You can withdraw funds only after a 30-day period", 0));
            }
            return 0;
        }

        protected internal override void Calculate()
        {
            if (_days % 30 == 0)
            {
                base.Calculate();
            }
        }
    }
}
