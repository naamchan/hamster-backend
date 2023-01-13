using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using server.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace server.Controllers
{
    [ApiController, Route("transfer_transaction")]
    public class TransferTransactionController : Controller
    {
        private readonly HamsterDBContext _context;

        public TransferTransactionController(HamsterDBContext context)
        {
            _context = context;
        }

        // GET: TransferTransaction
        [HttpGet("Index"), SwaggerOperation(Summary = "List all transfer transactions")]
        public async Task<IActionResult> Index()
        {
            return _context.TransferTransactionModel != null ?
                        this.Return(await _context.TransferTransactionModel.ToListAsync()) :
                        Problem("Entity set 'HamsterDBContext.TransferTransactionModel'  is null.");
        }

        // GET: TransferTransaction/Details/5
        [HttpGet("Details/{id}"), SwaggerOperation(Summary = "Get specific transfer transaction using id")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TransferTransactionModel == null)
            {
                return NotFound();
            }

            var transferTransactionModel = await _context.TransferTransactionModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (transferTransactionModel == null)
            {
                return NotFound();
            }

            return this.Return(transferTransactionModel);
        }

        // GET: TransferTransaction/Create
        [HttpGet("Create"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return this.Return();
        }

        // POST: TransferTransaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create"), SwaggerOperation(Summary = "Create new transfer transaction")]
        public async Task<IActionResult> Create([Bind("ID,FromPlayerID,ToPlayerID,CreatedAt,transfer transactionID,CVAAmount,GoldAmount,GemAmount")] TransferTransactionModel transferTransactionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transferTransactionModel);
                await _context.SaveChangesAsync();
                return this.RedirectOrReturn(nameof(Index), transferTransactionModel);
            }
            return this.Return(transferTransactionModel);
        }

        // GET: TransferTransaction/Edit/5
        [HttpGet("Edit/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TransferTransactionModel == null)
            {
                return NotFound();
            }

            var transferTransactionModel = await _context.TransferTransactionModel.FindAsync(id);
            if (transferTransactionModel == null)
            {
                return NotFound();
            }
            return this.Return(transferTransactionModel);
        }

        // POST: TransferTransaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}"), SwaggerOperation(Summary = "Edit transfer transaction using id")]
        public async Task<IActionResult> Edit(string id, [Bind("ID,FromPlayerID,ToPlayerID,CreatedAt,transfer transactionID,CVAAmount,GoldAmount,GemAmount")] TransferTransactionModel transferTransactionModel)
        {
            if (id != transferTransactionModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transferTransactionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransferTransactionModelExists(transferTransactionModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectOrReturn(nameof(Index), transferTransactionModel);
            }
            return this.Return(transferTransactionModel);
        }

        // GET: TransferTransaction/Delete/5
        [HttpGet("Delete/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TransferTransactionModel == null)
            {
                return NotFound();
            }

            var transferTransactionModel = await _context.TransferTransactionModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (transferTransactionModel == null)
            {
                return NotFound();
            }

            return this.Return(transferTransactionModel);
        }

        // POST: TransferTransaction/Delete/5
        [HttpPost("Delete/{id}"), SwaggerOperation(Summary = "Delete transfer transaction using id")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TransferTransactionModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.TransferTransactionModel'  is null.");
            }
            var transferTransactionModel = await _context.TransferTransactionModel.FindAsync(id);
            if (transferTransactionModel != null)
            {
                _context.TransferTransactionModel.Remove(transferTransactionModel);
            }

            await _context.SaveChangesAsync();
            return this.RedirectOrReturn(nameof(Index), transferTransactionModel);
        }

        [HttpGet("Search/{column}/{value}"), SwaggerOperation(Summary = "Search transfer transaction using string column")]
        public async Task<IActionResult> Search(string column, string value)
        {
            if (_context.TransferTransactionModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.TransferTransactionModel'  is null.");
            }

            return this.Return(await _context.TransferTransactionModel.WhereContains(column, value).ToListAsync());
        }

        private bool TransferTransactionModelExists(string id)
        {
            return (_context.TransferTransactionModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
