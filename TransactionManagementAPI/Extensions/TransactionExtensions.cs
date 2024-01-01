using TransactionManagementAPI.Entity;

namespace TransactionManagementAPI.Extensions;

// Extension methods for IEnumerable<Transaction> to provide additional functionalities.
// These methods can be used directly on any IEnumerable<Transaction> instance.
public static class TransactionExtensions
{
    // Filters the transactions based on a minimum amount.
    // This method is useful for querying transactions above a certain value.
    public static IEnumerable<Transaction> FilterByMinimumAmount(this IEnumerable<Transaction> transactions, decimal minimumAmount)
    {
        return transactions.Where(t => t.Amount >= minimumAmount);
    }
}
