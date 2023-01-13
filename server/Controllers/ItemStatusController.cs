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
    [ApiController, Route("item_status")]
    public class ItemStatusController : Controller
    {
        private readonly HamsterDBContext _context;

        public ItemStatusController(HamsterDBContext context)
        {
            _context = context;
        }

        // GET: ItemStatus
        [HttpGet("Index"), SwaggerOperation(Summary = "List all item status")]
        public async Task<IActionResult> Index()
        {
            return _context.ItemStatusModel != null ?
                        this.Return(await _context.ItemStatusModel.ToListAsync()) :
                        Problem("Entity set 'HamsterDBContext.ItemStatusModel'  is null.");
        }

        // GET: ItemStatus/Details/5
        [HttpGet("Details/{id}"), SwaggerOperation(Summary = "Get specific item status using id")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ItemStatusModel == null)
            {
                return NotFound();
            }

            var itemStatusModel = await _context.ItemStatusModel
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (itemStatusModel == null)
            {
                return NotFound();
            }

            return this.Return(itemStatusModel);
        }

        // GET: ItemStatus/Create
        [HttpGet("Create"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return this.Return();
        }

        // POST: ItemStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create"), SwaggerOperation(Summary = "Create new item status")]
        public async Task<IActionResult> Create([Bind("ItemID,ATK,HP,DEF,CRI,Speed,CRIDMG,ASPD,EVA")] ItemStatusModel itemStatusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemStatusModel);
                await _context.SaveChangesAsync();
                return this.RedirectOrReturn(nameof(Index), itemStatusModel);
            }
            return this.Return(itemStatusModel);
        }

        // GET: ItemStatus/Edit/5
        [HttpGet("Edit/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ItemStatusModel == null)
            {
                return NotFound();
            }

            var itemStatusModel = await _context.ItemStatusModel.FindAsync(id);
            if (itemStatusModel == null)
            {
                return NotFound();
            }
            return this.Return(itemStatusModel);
        }

        // POST: ItemStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}"), SwaggerOperation(Summary = "Edit item status using id")]
        public async Task<IActionResult> Edit(string id, [Bind("ItemID,ATK,HP,DEF,CRI,Speed,CRIDMG,ASPD,EVA")] ItemStatusModel itemStatusModel)
        {
            if (id != itemStatusModel.ItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemStatusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemStatusModelExists(itemStatusModel.ItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectOrReturn(nameof(Index), itemStatusModel);
            }
            return this.Return(itemStatusModel);
        }

        // GET: ItemStatus/Delete/5
        [HttpGet("Delete/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ItemStatusModel == null)
            {
                return NotFound();
            }

            var itemStatusModel = await _context.ItemStatusModel
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (itemStatusModel == null)
            {
                return NotFound();
            }

            return this.Return(itemStatusModel);
        }

        // POST: ItemStatus/Delete/5
        [HttpPost("Delete/{id}"), SwaggerOperation(Summary = "Delete item status using id")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ItemStatusModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemStatusModel'  is null.");
            }
            var itemStatusModel = await _context.ItemStatusModel.FindAsync(id);
            if (itemStatusModel != null)
            {
                _context.ItemStatusModel.Remove(itemStatusModel);
            }

            await _context.SaveChangesAsync();
            return this.RedirectOrReturn(nameof(Index), itemStatusModel);
        }

        [HttpGet("Search/{column}/{value}"), SwaggerOperation(Summary = "Search item status using string column")]
        public async Task<IActionResult> Search(string column, string value)
        {
            if (_context.ItemStatusModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemStatusModel'  is null.");
            }

            return this.Return(await _context.ItemStatusModel.WhereContains(column, value).ToListAsync());
        }

        private bool ItemStatusModelExists(string id)
        {
            return (_context.ItemStatusModel?.Any(e => e.ItemID == id)).GetValueOrDefault();
        }
    }
}
