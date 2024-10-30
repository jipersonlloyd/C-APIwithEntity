﻿using C_BackendEntity.Model;
using C_BackendEntity.Repository;

namespace C_BackendEntity.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _loginRepository;
        public AccountService(IAccountRepository loginRepository) 
        {
            _loginRepository = loginRepository;
        }


        public async Task<AccountModel> IsAccountExist(string email) => await _loginRepository.IsAccountExist(u => u.Email == email);
        public void AddModel(AccountModel createAccountModel) => _loginRepository.AddModel(createAccountModel);

    }
}