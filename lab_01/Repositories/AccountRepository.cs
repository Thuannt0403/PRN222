﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessObjects;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {

        public AccountMember GetAccountById(string accountID)
            => AccountDAO.GetAccountById(accountID);
        public AccountMember GetAccountByEmail(string email)
    => AccountDAO.GetAccountByEmail(email);
    }
}
