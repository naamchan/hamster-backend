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
    [ApiController, Route("item_group")]
    public class ItemGroupController : Controller
    {
        private readonly HamsterDBContext _context;

        public ItemGroupController(HamsterDBContext context)
        {
            _context = context;
        }

        // GET: ItemGroup
        [HttpGet("Index"), SwaggerOperation(Summary = "List all item group")]
        public async Task<IActionResult> Index()
        {
            return _context.ItemGroupModel != null ?
                        this.Return(await _context.ItemGroupModel.ToListAsync()) :
                        Problem("Entity set 'HamsterDBContext.ItemGroupModel'  is null.");
        }

        // GET: ItemGroup/Details/5
        [HttpGet("Details/{id}"), SwaggerOperation(Summary = "Get specific item group using id")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ItemGroupModel == null)
            {
                return NotFound();
            }

            var itemGroupModel = await _context.ItemGroupModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemGroupModel == null)
            {
                return NotFound();
            }

            return this.Return(itemGroupModel);
        }

        // GET: ItemGroup/Create
        [HttpGet("Create"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return this.Return();
        }

        // POST: ItemGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create"), SwaggerOperation(Summary = "Create new item group")]
        public async Task<IActionResult> Create([Bind("ID,Name,MaxLevel")] ItemGroupModel itemGroupModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemGroupModel);
                await _context.SaveChangesAsync();
                return this.RedirectOrReturn(nameof(Index), itemGroupModel);
            }
            return this.Return(itemGroupModel);
        }

        // GET: ItemGroup/Edit/5
        [HttpGet("Edit/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ItemGroupModel == null)
            {
                return NotFound();
            }

            var itemGroupModel = await _context.ItemGroupModel.FindAsync(id);
            if (itemGroupModel == null)
            {
                return NotFound();
            }
            return this.Return(itemGroupModel);
        }

        // POST: ItemGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}"), SwaggerOperation(Summary = "Edit item group using id")]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name,MaxLevel")] ItemGroupModel itemGroupModel)
        {
            if (id != itemGroupModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemGroupModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemGroupModelExists(itemGroupModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectOrReturn(nameof(Index), itemGroupModel);
            }
            return this.Return(itemGroupModel);
        }

        // GET: ItemGroup/Delete/5
        [HttpGet("Delete/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ItemGroupModel == null)
            {
                return NotFound();
            }

            var itemGroupModel = await _context.ItemGroupModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemGroupModel == null)
            {
                return NotFound();
            }

            return this.Return(itemGroupModel);
        }

        // POST: ItemGroup/Delete/5
        [HttpPost("Delete/{id}"), SwaggerOperation(Summary = "Delete item group using id")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ItemGroupModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemGroupModel'  is null.");
            }
            var itemGroupModel = await _context.ItemGroupModel.FindAsync(id);
            if (itemGroupModel != null)
            {
                _context.ItemGroupModel.Remove(itemGroupModel);
            }

            await _context.SaveChangesAsync();
            return this.RedirectOrReturn(nameof(Index), itemGroupModel);
        }

        [HttpGet("Search/{column}/{value}"), SwaggerOperation(Summary = "Search item group using string column")]
        public async Task<IActionResult> Search(string column, string value)
        {
            if (_context.ItemGroupModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemGroupModel'  is null.");
            }

            return this.Return(await _context.ItemGroupModel.WhereContains(column, value).ToListAsync());
        }

        private bool ItemGroupModelExists(string id)
        {
            return (_context.ItemGroupModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
