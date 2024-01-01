using TransactionManagementAPI.Entity;
using TransactionManagementAPI.Services.Interfaces;

namespace TransactionManagementAPI.Services.Concretes;

// A fake service implementation of ITransactionService for testing and development purposes.
// This service mimics the behavior of a real transaction service without the need for actual data storage or processing.
public class FakeTransactionService:ITransactionService
{
    private readonly List<Transaction> _transactions;

    public FakeTransactionService()
    {
        // Initialize with sample data or empty list
        _transactions = new List<Transaction>();
    }
    
    // Implementations of ITransactionService methods...

    public List<Transaction> GetAllTransactions() => _transactions;

    public Transaction GetTransactionById(int id) => _transactions.FirstOrDefault(t => t.Id == id);

    public Transaction AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
        return transaction;
    }

    public Transaction UpdateTransaction(int id, Transaction transaction)
    {
        var existingTransaction = GetTransactionById(id);
        if (existingTransaction != null)
        {
        }
        return existingTransaction;
    }

    public void DeleteTransaction(int id)
    {
        var transaction = GetTransactionById(id);
        if (transaction != null)
        {
            _transactions.Remove(transaction);
        }
    }
}