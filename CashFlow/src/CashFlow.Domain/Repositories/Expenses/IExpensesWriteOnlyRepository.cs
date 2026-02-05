using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesWriteOnlyRepository
{
  Task AddAsync(Expense expense);
  /// <summary>
  /// this function returns TRUE if the expense was deleted with success, FALSE if the expense was not found
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  Task<bool> Delete(long id);
}
