using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Data;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.Models;

namespace FinanceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        private AppDbContext _context;

        public TransactionsController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Transactions.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            _context.Add(transaction);
            _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = transaction.Id }, transaction);
        }
            

    }
}
