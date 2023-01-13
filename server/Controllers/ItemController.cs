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
    [ApiController, Route("item")]
    public class ItemController : Controller
    {
        private readonly HamsterDBContext _context;
        private readonly ILogger logger;

        public ItemController(HamsterDBContext context, ILogger<ItemController> logger)
        {
            _context = context;
            this.logger = logger;
        }



        [HttpGet("Index"), SwaggerOperation(Summary = "List all items")]
        public async Task<IActionResult> Index()
        {
            return _context.ItemModel != null ?
                        this.Return(await _context.ItemModel.ToListAsync()) :
                        Problem("Entity set 'HamsterDBContext.ItemModel'  is null.");
        }

        // GET: Item/Details/5
        [HttpGet("Details/{id}"), SwaggerOperation(Summary = "Get specific item using id")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ItemModel == null)
            {
                return NotFound();
            }

            var itemModel = await _context.ItemModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return this.Return(itemModel);
        }

        // GET: Item/Create
        [HttpGet("Create"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return this.Return();
        }

        // POST: Item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create"), SwaggerOperation(Summary = "Create new item")]
        public async Task<IActionResult> Create([Bind("ID,Name,Picture,CVA,Gold,Gem,SellStatus,Level,Energy,CreatedAt,UpdatedAt,ItemGroupRefID,PlayerID")] ItemModel itemModel)
        {
            logger.LogInformation("Create Item");
            if (ModelState.IsValid)
            {
                _context.Add(itemModel);
                await _context.SaveChangesAsync();
                logger.LogInformation("Redirecting");
                return this.RedirectOrReturn(nameof(Index), itemModel);
            }
            logger.LogInformation("Returning");
            return this.Return(itemModel);
        }

        // GET: Item/Edit/5
        [HttpGet("Edit/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ItemModel == null)
            {
                return NotFound();
            }

            var itemModel = await _context.ItemModel.FindAsync(id);
            if (itemModel == null)
            {
                return NotFound();
            }
            return this.Return(itemModel);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}"), SwaggerOperation(Summary = "Edit item using id")]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name,Picture,CVA,Gold,Gem,SellStatus,Level,Energy,CreatedAt,UpdatedAt,ItemGroupRefID,PlayerID")] ItemModel itemModel)
        {
            if (id != itemModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemModelExists(itemModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectOrReturn(nameof(Index), itemModel);
            }
            return this.Return(itemModel);
        }

        // GET: Item/Delete/5
        [HttpGet("Delete/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ItemModel == null)
            {
                return NotFound();
            }

            var itemModel = await _context.ItemModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return this.Return(itemModel);
        }

        // POST: Item/Delete/5
        [HttpPost("Delete/{id}"), SwaggerOperation(Summary = "Delete item using id")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ItemModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemModel'  is null.");
            }
            var itemModel = await _context.ItemModel.FindAsync(id);
            if (itemModel != null)
            {
                _context.ItemModel.Remove(itemModel);
            }

            await _context.SaveChangesAsync();
            return this.RedirectOrReturn(nameof(Index), itemModel);
        }

        [HttpGet("SearchView"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> SearchView(string column, string value)
        {
            return View("Index", await _context.ItemModel.WhereContains(column, value).ToListAsync());
        }

        [HttpGet("Search/{column}/{value}"), SwaggerOperation(Summary = "Search item using string column")]
        public async Task<IActionResult> Search(string column, string value)
        {
            if (_context.ItemModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.ItemModel'  is null.");
            }

            return this.Return(await _context.ItemModel.WhereContains(column, value).ToListAsync());
        }

        private bool ItemModelExists(string id)
        {
            return (_context.ItemModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
