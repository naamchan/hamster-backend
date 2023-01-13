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
    [ApiController, Route("item_energy_history")]
    public class ItemEnergyHistoryController : Controller
    {
        private readonly HamsterDBContext _context;

        public ItemEnergyHistoryController(HamsterDBContext context)
        {
            _context = context;
        }

        // GET: ItemEnergyHistory
        [HttpGet("Index"), SwaggerOperation(Summary = "List all item energy history")]
        public async Task<IActionResult> Index()
        {
            return _context.ItemEnergyHistoryModel != null ?
                        this.Return(await _context.ItemEnergyHistoryModel.ToListAsync()) :
                        Problem("Entity set 'HamsterDBContext.ItemEnergyHistoryModel'  is null.");
        }

        // GET: ItemEnergyHistory/Details/5
        [HttpGet("Details/{id}"), SwaggerOperation(Summary = "Get specific item energy history using id")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemEnergyHistoryModel == null)
            {
                return NotFound();
            }

            var itemEnergyHistoryModel = await _context.ItemEnergyHistoryModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemEnergyHistoryModel == null)
            {
                return NotFound();
            }

            return this.Return(itemEnergyHistoryModel);
        }

        // GET: ItemEnergyHistory/Create
        [HttpGet("Create"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return this.Return();
        }

        // POST: ItemEnergyHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create"), SwaggerOperation(Summary = "Create new item energy history")]
        public async Task<IActionResult> Create([Bind("ID,ItemID,Energy,CreatedAt")] ItemEnergyHistoryModel itemEnergyHistoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemEnergyHistoryModel);
                await _context.SaveChangesAsync();
                return this.RedirectOrReturn(nameof(Index), itemEnergyHistoryModel);
            }
            return this.Return(itemEnergyHistoryModel);
        }

        // GET: ItemEnergyHistory/Edit/5
        [HttpGet("Edit/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemEnergyHistoryModel == null)
            {
                return NotFound();
            }

            var itemEnergyHistoryModel = await _context.ItemEnergyHistoryModel.FindAsync(id);
            if (itemEnergyHistoryModel == null)
            {
                return NotFound();
            }
            return this.Return(itemEnergyHistoryModel);
        }

        // POST: ItemEnergyHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}"), SwaggerOperation(Summary = "Edit item energy history using id")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ItemID,Energy,CreatedAt")] ItemEnergyHistoryModel itemEnergyHistoryModel)
        {
            if (id != itemEnergyHistoryModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemEnergyHistoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemEnergyHistoryModelExists(itemEnergyHistoryModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectOrReturn(nameof(Index), itemEnergyHistoryModel);
            }
            return this.Return(itemEnergyHistoryModel);
        }

        // GET: ItemEnergyHistory/Delete/5
        [HttpGet("Delete/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemEnergyHistoryModel == null)
            {
                return NotFound();
            }

            var itemEnergyHistoryModel = await _context.ItemEnergyHistoryModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemEnergyHistoryModel == null)
            {
                return NotFound();
            }

            return this.Return(itemEnergyHistoryModel);
        }

        // POST: ItemEnergyHistory/Delete/5
        [HttpPost("Delete/{id}"), SwaggerOperation(Summary = "Delete item energy history using id")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemEnergyHistoryModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemEnergyHistoryModel'  is null.");
            }
            var itemEnergyHistoryModel = await _context.ItemEnergyHistoryModel.FindAsync(id);
            if (itemEnergyHistoryModel != null)
            {
                _context.ItemEnergyHistoryModel.Remove(itemEnergyHistoryModel);
            }

            await _context.SaveChangesAsync();
            return this.RedirectOrReturn(nameof(Index), itemEnergyHistoryModel);
        }

        [HttpGet("Search/{column}/{value}"), SwaggerOperation(Summary = "Search item energy history using string column")]
        public async Task<IActionResult> Search(string column, string value)
        {
            if (_context.ItemEnergyHistoryModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemEnergyHistoryModel'  is null.");
            }

            return this.Return(await _context.ItemEnergyHistoryModel.WhereContains(column, value).ToListAsync());
        }

        private bool ItemEnergyHistoryModelExists(int id)
        {
            return (_context.ItemEnergyHistoryModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
