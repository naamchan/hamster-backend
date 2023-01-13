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
    [ApiController, Route("player_status")]
    public class PlayerStatusController : Controller
    {
        private readonly HamsterDBContext _context;

        public PlayerStatusController(HamsterDBContext context)
        {
            _context = context;
        }

        // GET: PlayerStatus
        [HttpGet("Index"), SwaggerOperation(Summary = "List all player status")]
        public async Task<IActionResult> Index()
        {
            return _context.PlayerStatusModel != null ?
                        this.Return(await _context.PlayerStatusModel.ToListAsync()) :
                        Problem("Entity set 'HamsterDBContext.PlayerStatusModel'  is null.");
        }

        // GET: PlayerStatus/Details/5
        [HttpGet("Details/{id}"), SwaggerOperation(Summary = "Get specific player status using id")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PlayerStatusModel == null)
            {
                return NotFound();
            }

            var playerStatusModel = await _context.PlayerStatusModel
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (playerStatusModel == null)
            {
                return NotFound();
            }

            return this.Return(playerStatusModel);
        }

        // GET: PlayerStatus/Create
        [HttpGet("Create"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return this.Return();
        }

        // POST: PlayerStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create"), SwaggerOperation(Summary = "Create new player status")]
        public async Task<IActionResult> Create([Bind("PlayerID,ATK,HP,DEF,CRI,Speed,CRIDMG,ASPD,EVA")] PlayerStatusModel playerStatusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerStatusModel);
                await _context.SaveChangesAsync();
                return this.RedirectOrReturn(nameof(Index), playerStatusModel);
            }
            return this.Return(playerStatusModel);
        }

        // GET: PlayerStatus/Edit/5
        [HttpGet("Edit/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PlayerStatusModel == null)
            {
                return NotFound();
            }

            var playerStatusModel = await _context.PlayerStatusModel.FindAsync(id);
            if (playerStatusModel == null)
            {
                return NotFound();
            }
            return this.Return(playerStatusModel);
        }

        // POST: PlayerStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}"), SwaggerOperation(Summary = "Edit player status using id")]
        public async Task<IActionResult> Edit(string id, [Bind("PlayerID,ATK,HP,DEF,CRI,Speed,CRIDMG,ASPD,EVA")] PlayerStatusModel playerStatusModel)
        {
            if (id != playerStatusModel.PlayerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerStatusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerStatusModelExists(playerStatusModel.PlayerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectOrReturn(nameof(Index), playerStatusModel);
            }
            return this.Return(playerStatusModel);
        }

        // GET: PlayerStatus/Delete/5
        [HttpGet("Delete/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PlayerStatusModel == null)
            {
                return NotFound();
            }

            var playerStatusModel = await _context.PlayerStatusModel
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (playerStatusModel == null)
            {
                return NotFound();
            }

            return this.Return(playerStatusModel);
        }

        // POST: PlayerStatus/Delete/5
        [HttpPost("Delete/{id}"), SwaggerOperation(Summary = "Delete player status using id")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PlayerStatusModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.PlayerStatusModel'  is null.");
            }
            var playerStatusModel = await _context.PlayerStatusModel.FindAsync(id);
            if (playerStatusModel != null)
            {
                _context.PlayerStatusModel.Remove(playerStatusModel);
            }

            await _context.SaveChangesAsync();
            return this.RedirectOrReturn(nameof(Index), playerStatusModel);
        }

        [HttpGet("Search/{column}/{value}"), SwaggerOperation(Summary = "Search player status using string column")]
        public async Task<IActionResult> Search(string column, string value)
        {
            if (_context.PlayerStatusModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.PlayerStatusModel'  is null.");
            }

            return this.Return(await _context.PlayerStatusModel.WhereContains(column, value).ToListAsync());
        }

        private bool PlayerStatusModelExists(string id)
        {
            return (_context.PlayerStatusModel?.Any(e => e.PlayerID == id)).GetValueOrDefault();
        }
    }
}
