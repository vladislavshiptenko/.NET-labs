using Core.Models.Transactions;
using Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionHistoryController : Controller
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionHistoryController(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    [Authorize(Policy = "AllowUser")]
    [HttpGet("GetAllTransactionsByAccountId")]
    public async Task<IActionResult> GetAllTransactionsByAccountId(long id)
    {
        IReadOnlyList<Transaction>? transactions = await _transactionRepository.GetAllTransactions(id).ConfigureAwait(false);

        return Ok(transactions);
    }
}