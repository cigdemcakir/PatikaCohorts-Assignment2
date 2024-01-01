using TransactionManagementAPI.Entity;

namespace TransactionManagementAPI.Services.Interfaces;

// Defines the contract for transaction services.
// This interface will be used for implementing different transaction service types (like real and fake services).
public interface ITransactionService
{
    List<Transaction> GetAllTransactions();
    Transaction GetTransactionById(int id);
    Transaction AddTransaction(Transaction transaction);
    Transaction UpdateTransaction(int id, Transaction transaction);
    void DeleteTransaction(int id);
}