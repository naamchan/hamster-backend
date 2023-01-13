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
    [ApiController, Route("item_rarity")]
    public class ItemRarityController : Controller
    {
        private readonly HamsterDBContext _context;

        public ItemRarityController(HamsterDBContext context)
        {
            _context = context;
        }

        // GET: ItemRarity
        [HttpGet("Index"), SwaggerOperation(Summary = "List all items rarity")]
        public async Task<IActionResult> Index()
        {
            return _context.ItemRarityModel != null ?
                        this.Return(await _context.ItemRarityModel.ToListAsync()) :
                        Problem("Entity set 'HamsterDBContext.ItemRarityModel'  is null.");
        }

        // GET: ItemRarity/Details/5
        [HttpGet("Details/{id}"), SwaggerOperation(Summary = "Get specific item rarity using id")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ItemRarityModel == null)
            {
                return NotFound();
            }

            var itemRarityModel = await _context.ItemRarityModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemRarityModel == null)
            {
                return NotFound();
            }

            return this.Return(itemRarityModel);
        }

        // GET: ItemRarity/Create
        [HttpGet("Create"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return this.Return();
        }

        // POST: ItemRarity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create"), SwaggerOperation(Summary = "Create new item rarity")]
        public async Task<IActionResult> Create([Bind("ID,Name")] ItemRarityModel itemRarityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemRarityModel);
                await _context.SaveChangesAsync();
                return this.RedirectOrReturn(nameof(Index), itemRarityModel);
            }
            return this.Return(itemRarityModel);
        }

        // GET: ItemRarity/Edit/5
        [HttpGet("Edit/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ItemRarityModel == null)
            {
                return NotFound();
            }

            var itemRarityModel = await _context.ItemRarityModel.FindAsync(id);
            if (itemRarityModel == null)
            {
                return NotFound();
            }
            return this.Return(itemRarityModel);
        }

        // POST: ItemRarity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}"), SwaggerOperation(Summary = "Edit item rarity using id")]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name")] ItemRarityModel itemRarityModel)
        {
            if (id != itemRarityModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemRarityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemRarityModelExists(itemRarityModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectOrReturn(nameof(Index), itemRarityModel);
            }
            return this.Return(itemRarityModel);
        }

        // GET: ItemRarity/Delete/5
        [HttpGet("Delete/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ItemRarityModel == null)
            {
                return NotFound();
            }

            var itemRarityModel = await _context.ItemRarityModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemRarityModel == null)
            {
                return NotFound();
            }

            return this.Return(itemRarityModel);
        }

        // POST: ItemRarity/Delete/5
        [HttpPost("Delete/{id}"), SwaggerOperation(Summary = "Delete item rarity using id")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ItemRarityModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemRarityModel'  is null.");
            }
            var itemRarityModel = await _context.ItemRarityModel.FindAsync(id);
            if (itemRarityModel != null)
            {
                _context.ItemRarityModel.Remove(itemRarityModel);
            }

            await _context.SaveChangesAsync();
            return this.RedirectOrReturn(nameof(Index), itemRarityModel);
        }

        [HttpGet("Search/{column}/{value}"), SwaggerOperation(Summary = "Search item rarity using string column")]
        public async Task<IActionResult> Search(string column, string value)
        {
            if (_context.ItemRarityModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemRarityModel'  is null.");
            }

            return this.Return(await _context.ItemRarityModel.WhereContains(column, value).ToListAsync());
        }

        private bool ItemRarityModelExists(string id)
        {
            return (_context.ItemRarityModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
