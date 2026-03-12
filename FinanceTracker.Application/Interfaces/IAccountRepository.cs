using System;
using System.Collections.Generic;
using System.Text;

using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Interfaces;

public interface IAccountRepository
{
    Task<Account> AddAsync(Account account);
    Task<IReadOnlyList<Account>> GetAllAsync();
    Task<Account?> GetByIdAsync(Guid id);
    Task UpdateAsync(Account account);
    Task DeleteAsync(Guid id);
}