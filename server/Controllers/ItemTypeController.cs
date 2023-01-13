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
    [ApiController, Route("item_type")]
    public class ItemTypeController : Controller
    {
        private readonly HamsterDBContext _context;

        public ItemTypeController(HamsterDBContext context)
        {
            _context = context;
        }

        // GET: ItemType
        [HttpGet("Index"), SwaggerOperation(Summary = "List all item types")]
        public async Task<IActionResult> Index()
        {
            return _context.ItemTypeModel != null ?
                        this.Return(await _context.ItemTypeModel.ToListAsync()) :
                        Problem("Entity set 'HamsterDBContext.ItemTypeModel'  is null.");
        }

        // GET: ItemType/Details/5
        [HttpGet("Details/{id}"), SwaggerOperation(Summary = "Get specific item type using id")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ItemTypeModel == null)
            {
                return NotFound();
            }

            var itemTypeModel = await _context.ItemTypeModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemTypeModel == null)
            {
                return NotFound();
            }

            return this.Return(itemTypeModel);
        }

        // GET: ItemType/Create
        [HttpGet("Create"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return this.Return();
        }

        // POST: ItemType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create"), SwaggerOperation(Summary = "Create new item type")]
        public async Task<IActionResult> Create([Bind("ID,Name")] ItemTypeModel itemTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemTypeModel);
                await _context.SaveChangesAsync();
                return this.RedirectOrReturn(nameof(Index), itemTypeModel);
            }
            return this.Return(itemTypeModel);
        }

        // GET: ItemType/Edit/5
        [HttpGet("Edit/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ItemTypeModel == null)
            {
                return NotFound();
            }

            var itemTypeModel = await _context.ItemTypeModel.FindAsync(id);
            if (itemTypeModel == null)
            {
                return NotFound();
            }
            return this.Return(itemTypeModel);
        }

        // POST: ItemType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}"), SwaggerOperation(Summary = "Edit item type using id")]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name")] ItemTypeModel itemTypeModel)
        {
            if (id != itemTypeModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemTypeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemTypeModelExists(itemTypeModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectOrReturn(nameof(Index), itemTypeModel);
            }
            return this.Return(itemTypeModel);
        }

        // GET: ItemType/Delete/5
        [HttpGet("Delete/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ItemTypeModel == null)
            {
                return NotFound();
            }

            var itemTypeModel = await _context.ItemTypeModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemTypeModel == null)
            {
                return NotFound();
            }

            return this.Return(itemTypeModel);
        }

        // POST: ItemType/Delete/5
        [HttpPost("Delete/{id}"), SwaggerOperation(Summary = "Delete item type using id")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ItemTypeModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemTypeModel'  is null.");
            }
            var itemTypeModel = await _context.ItemTypeModel.FindAsync(id);
            if (itemTypeModel != null)
            {
                _context.ItemTypeModel.Remove(itemTypeModel);
            }

            await _context.SaveChangesAsync();
            return this.RedirectOrReturn(nameof(Index), itemTypeModel);
        }

        [HttpGet("Search/{column}/{value}"), SwaggerOperation(Summary = "Search item type using string column")]
        public async Task<IActionResult> Search(string column, string value)
        {
            if (_context.ItemTypeModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemTypeModel'  is null.");
            }

            return this.Return(await _context.ItemTypeModel.WhereContains(column, value).ToListAsync());
        }

        private bool ItemTypeModelExists(string id)
        {
            return (_context.ItemTypeModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
