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
    [ApiController, Route("item_status_history")]
    public class ItemStatusHistoryController : Controller
    {
        private readonly HamsterDBContext _context;

        public ItemStatusHistoryController(HamsterDBContext context)
        {
            _context = context;
        }

        // GET: ItemStatusHistory
        [HttpGet("Index"), SwaggerOperation(Summary = "List all item status history")]
        public async Task<IActionResult> Index()
        {
            return _context.ItemStatusHistoryModel != null ?
                        this.Return(await _context.ItemStatusHistoryModel.ToListAsync()) :
                        Problem("Entity set 'HamsterDBContext.ItemStatusHistoryModel'  is null.");
        }

        // GET: ItemStatusHistory/Details/5
        [HttpGet("Details/{id}"), SwaggerOperation(Summary = "Get specific item status history using id")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemStatusHistoryModel == null)
            {
                return NotFound();
            }

            var itemStatusHistoryModel = await _context.ItemStatusHistoryModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemStatusHistoryModel == null)
            {
                return NotFound();
            }

            return this.Return(itemStatusHistoryModel);
        }

        // GET: ItemStatusHistory/Create
        [HttpGet("Create"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return this.Return();
        }

        // POST: ItemStatusHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create"), SwaggerOperation(Summary = "Create new item status history")]
        public async Task<IActionResult> Create([Bind("ID,ItemID,ATK,HP,DEF,CRI,Speed,CRIDMG,ASPD,EVA,CreatedAt")] ItemStatusHistoryModel itemStatusHistoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemStatusHistoryModel);
                await _context.SaveChangesAsync();
                return this.RedirectOrReturn(nameof(Index), itemStatusHistoryModel);
            }
            return this.Return(itemStatusHistoryModel);
        }

        // GET: ItemStatusHistory/Edit/5
        [HttpGet("Edit/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemStatusHistoryModel == null)
            {
                return NotFound();
            }

            var itemStatusHistoryModel = await _context.ItemStatusHistoryModel.FindAsync(id);
            if (itemStatusHistoryModel == null)
            {
                return NotFound();
            }
            return this.Return(itemStatusHistoryModel);
        }

        // POST: ItemStatusHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}"), SwaggerOperation(Summary = "Edit item status history using id")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ItemID,ATK,HP,DEF,CRI,Speed,CRIDMG,ASPD,EVA,CreatedAt")] ItemStatusHistoryModel itemStatusHistoryModel)
        {
            if (id != itemStatusHistoryModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemStatusHistoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemStatusHistoryModelExists(itemStatusHistoryModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectOrReturn(nameof(Index), itemStatusHistoryModel);
            }
            return this.Return(itemStatusHistoryModel);
        }

        // GET: ItemStatusHistory/Delete/5
        [HttpGet("Delete/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemStatusHistoryModel == null)
            {
                return NotFound();
            }

            var itemStatusHistoryModel = await _context.ItemStatusHistoryModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemStatusHistoryModel == null)
            {
                return NotFound();
            }

            return this.Return(itemStatusHistoryModel);
        }

        // POST: ItemStatusHistory/Delete/5
        [HttpPost("Delete/{id}"), SwaggerOperation(Summary = "Delete item status history using id")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemStatusHistoryModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemStatusHistoryModel'  is null.");
            }
            var itemStatusHistoryModel = await _context.ItemStatusHistoryModel.FindAsync(id);
            if (itemStatusHistoryModel != null)
            {
                _context.ItemStatusHistoryModel.Remove(itemStatusHistoryModel);
            }

            await _context.SaveChangesAsync();
            return this.RedirectOrReturn(nameof(Index), itemStatusHistoryModel);
        }

        [HttpGet("Search/{column}/{value}"), SwaggerOperation(Summary = "Search item status history using string column")]
        public async Task<IActionResult> Search(string column, string value)
        {
            if (_context.ItemStatusHistoryModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemStatusHistoryModel'  is null.");
            }

            return this.Return(await _context.ItemStatusHistoryModel.WhereContains(column, value).ToListAsync());
        }

        private bool ItemStatusHistoryModelExists(int id)
        {
            return (_context.ItemStatusHistoryModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
