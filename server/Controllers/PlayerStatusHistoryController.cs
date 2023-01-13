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
    [ApiController, Route("player_status_history")]
    public class PlayerStatusHistoryController : Controller
    {
        private readonly HamsterDBContext _context;

        public PlayerStatusHistoryController(HamsterDBContext context)
        {
            _context = context;
        }

        // GET: PlayerStatusHistory
        [HttpGet("Index"), SwaggerOperation(Summary = "List all player status history")]
        public async Task<IActionResult> Index()
        {
            return _context.PlayerStatusHistoryModel != null ?
                        this.Return(await _context.PlayerStatusHistoryModel.ToListAsync()) :
                        Problem("Entity set 'HamsterDBContext.PlayerStatusHistoryModel'  is null.");
        }

        // GET: PlayerStatusHistory/Details/5
        [HttpGet("Details/{id}"), SwaggerOperation(Summary = "Get specific player status history using id")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlayerStatusHistoryModel == null)
            {
                return NotFound();
            }

            var playerStatusHistoryModel = await _context.PlayerStatusHistoryModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (playerStatusHistoryModel == null)
            {
                return NotFound();
            }

            return this.Return(playerStatusHistoryModel);
        }

        // GET: PlayerStatusHistory/Create
        [HttpGet("Create"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return this.Return();
        }

        // POST: PlayerStatusHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create"), SwaggerOperation(Summary = "Create new player status history")]
        public async Task<IActionResult> Create([Bind("ID,PlayerID,ATK,HP,DEF,CRI,Speed,CRIDMG,ASPD,EVA,CreatedAt")] PlayerStatusHistoryModel playerStatusHistoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerStatusHistoryModel);
                await _context.SaveChangesAsync();
                return this.RedirectOrReturn(nameof(Index), playerStatusHistoryModel);
            }
            return this.Return(playerStatusHistoryModel);
        }

        // GET: PlayerStatusHistory/Edit/5
        [HttpGet("Edit/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlayerStatusHistoryModel == null)
            {
                return NotFound();
            }

            var playerStatusHistoryModel = await _context.PlayerStatusHistoryModel.FindAsync(id);
            if (playerStatusHistoryModel == null)
            {
                return NotFound();
            }
            return this.Return(playerStatusHistoryModel);
        }

        // POST: PlayerStatusHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}"), SwaggerOperation(Summary = "Edit player status history using id")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PlayerID,ATK,HP,DEF,CRI,Speed,CRIDMG,ASPD,EVA,CreatedAt")] PlayerStatusHistoryModel playerStatusHistoryModel)
        {
            if (id != playerStatusHistoryModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerStatusHistoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerStatusHistoryModelExists(playerStatusHistoryModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectOrReturn(nameof(Index), playerStatusHistoryModel);
            }
            return this.Return(playerStatusHistoryModel);
        }

        // GET: PlayerStatusHistory/Delete/5
        [HttpGet("Delete/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlayerStatusHistoryModel == null)
            {
                return NotFound();
            }

            var playerStatusHistoryModel = await _context.PlayerStatusHistoryModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (playerStatusHistoryModel == null)
            {
                return NotFound();
            }

            return this.Return(playerStatusHistoryModel);
        }

        // POST: PlayerStatusHistory/Delete/5
        [HttpPost("Delete/{id}"), SwaggerOperation(Summary = "Delete player status history using id")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlayerStatusHistoryModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.PlayerStatusHistoryModel'  is null.");
            }
            var playerStatusHistoryModel = await _context.PlayerStatusHistoryModel.FindAsync(id);
            if (playerStatusHistoryModel != null)
            {
                _context.PlayerStatusHistoryModel.Remove(playerStatusHistoryModel);
            }

            await _context.SaveChangesAsync();
            return this.RedirectOrReturn(nameof(Index), playerStatusHistoryModel);
        }

        [HttpGet("Search/{column}/{value}"), SwaggerOperation(Summary = "Search player status history using string column")]
        public async Task<IActionResult> Search(string column, string value)
        {
            if (_context.PlayerStatusHistoryModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.PlayerStatusHistoryModel'  is null.");
            }

            return this.Return(await _context.PlayerStatusHistoryModel.WhereContains(column, value).ToListAsync());
        }

        private bool PlayerStatusHistoryModelExists(int id)
        {
            return (_context.PlayerStatusHistoryModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
