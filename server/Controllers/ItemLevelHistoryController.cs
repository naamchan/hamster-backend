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
    [ApiController, Route("item_level_history")]
    public class ItemLevelHistoryController : Controller
    {
        private readonly HamsterDBContext _context;

        public ItemLevelHistoryController(HamsterDBContext context)
        {
            _context = context;
        }

        // GET: ItemLevelHistory
        [HttpGet("Index"), SwaggerOperation(Summary = "List all item level history")]
        public async Task<IActionResult> Index()
        {
            return _context.ItemLevelHistoryModel != null ?
                        this.Return(await _context.ItemLevelHistoryModel.ToListAsync()) :
                        Problem("Entity set 'HamsterDBContext.ItemLevelHistoryModel'  is null.");
        }

        // GET: ItemLevelHistory/Details/5
        [HttpGet("Details/{id}"), SwaggerOperation(Summary = "Get specific item level history using id")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemLevelHistoryModel == null)
            {
                return NotFound();
            }

            var itemLevelHistoryModel = await _context.ItemLevelHistoryModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemLevelHistoryModel == null)
            {
                return NotFound();
            }

            return this.Return(itemLevelHistoryModel);
        }

        // GET: ItemLevelHistory/Create
        [HttpGet("Create"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return this.Return();
        }

        // POST: ItemLevelHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create"), SwaggerOperation(Summary = "Create new item level history")]
        public async Task<IActionResult> Create([Bind("ID,ItemID,Level,CreatedAt")] ItemLevelHistoryModel itemLevelHistoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemLevelHistoryModel);
                await _context.SaveChangesAsync();
                return this.RedirectOrReturn(nameof(Index), itemLevelHistoryModel);
            }
            return this.Return(itemLevelHistoryModel);
        }

        // GET: ItemLevelHistory/Edit/5
        [HttpGet("Edit/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemLevelHistoryModel == null)
            {
                return NotFound();
            }

            var itemLevelHistoryModel = await _context.ItemLevelHistoryModel.FindAsync(id);
            if (itemLevelHistoryModel == null)
            {
                return NotFound();
            }
            return this.Return(itemLevelHistoryModel);
        }

        // POST: ItemLevelHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}"), SwaggerOperation(Summary = "Edit item level history using id")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ItemID,Level,CreatedAt")] ItemLevelHistoryModel itemLevelHistoryModel)
        {
            if (id != itemLevelHistoryModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemLevelHistoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemLevelHistoryModelExists(itemLevelHistoryModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectOrReturn(nameof(Index), itemLevelHistoryModel);
            }
            return this.Return(itemLevelHistoryModel);
        }

        // GET: ItemLevelHistory/Delete/5
        [HttpGet("Delete/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemLevelHistoryModel == null)
            {
                return NotFound();
            }

            var itemLevelHistoryModel = await _context.ItemLevelHistoryModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemLevelHistoryModel == null)
            {
                return NotFound();
            }

            return this.Return(itemLevelHistoryModel);
        }

        // POST: ItemLevelHistory/Delete/5
        [HttpPost("Delete/{id}"), SwaggerOperation(Summary = "Delete item level history using id")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemLevelHistoryModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemLevelHistoryModel'  is null.");
            }
            var itemLevelHistoryModel = await _context.ItemLevelHistoryModel.FindAsync(id);
            if (itemLevelHistoryModel != null)
            {
                _context.ItemLevelHistoryModel.Remove(itemLevelHistoryModel);
            }

            await _context.SaveChangesAsync();
            return this.RedirectOrReturn(nameof(Index), itemLevelHistoryModel);
        }

        [HttpGet("Search/{column}/{value}"), SwaggerOperation(Summary = "Search item level history using string column")]
        public async Task<IActionResult> Search(string column, string value)
        {
            if (_context.ItemLevelHistoryModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemLevelHistoryModel'  is null.");
            }

            return this.Return(await _context.ItemLevelHistoryModel.WhereContains(column, value).ToListAsync());
        }

        private bool ItemLevelHistoryModelExists(int id)
        {
            return (_context.ItemLevelHistoryModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
