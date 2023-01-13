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
    [ApiController, Route("player")]
    public class PlayerController : Controller
    {
        private readonly HamsterDBContext _context;

        public PlayerController(HamsterDBContext context)
        {
            _context = context;
        }

        // GET: Player
        [HttpGet("Index"), SwaggerOperation(Summary = "List all players")]
        public async Task<IActionResult> Index()
        {
            return _context.PlayerModel != null ?
                        View(await _context.PlayerModel.ToListAsync()) :
                        Problem("Entity set 'HamsterDBContext.PlayerModel'  is null.");
        }

        // GET: Player/Details/5
        [HttpGet("Details/{id}"), SwaggerOperation(Summary = "Get specific player using id")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PlayerModel == null)
            {
                return NotFound();
            }

            var playerModel = await _context.PlayerModel
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (playerModel == null)
            {
                return NotFound();
            }

            return View(playerModel);
        }

        // GET: Player/Create
        [HttpGet("Create"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create"), SwaggerOperation(Summary = "Create new player")]
        public async Task<IActionResult> Create([Bind("PlayerID,UserID,CVA,Gold,Gem,TopScore,BestTimeMilliseconds")] PlayerModel playerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerModel);
                await _context.SaveChangesAsync();
                return this.RedirectOrReturn(nameof(Index), playerModel);
            }
            return View(playerModel);
        }

        // GET: Player/Edit/5
        [HttpGet("Edit/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PlayerModel == null)
            {
                return NotFound();
            }

            var playerModel = await _context.PlayerModel.FindAsync(id);
            if (playerModel == null)
            {
                return NotFound();
            }
            return View(playerModel);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}"), SwaggerOperation(Summary = "Edit player using id")]
        public async Task<IActionResult> Edit(string id, [Bind("PlayerID,UserID,CVA,Gold,Gem,TopScore,BestTimeMilliseconds")] PlayerModel playerModel)
        {
            if (id != playerModel.PlayerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerModelExists(playerModel.PlayerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectOrReturn(nameof(Index), playerModel);
            }
            return View(playerModel);
        }

        // GET: Player/Delete/5
        [HttpGet("Delete/{id}"), ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PlayerModel == null)
            {
                return NotFound();
            }

            var playerModel = await _context.PlayerModel
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (playerModel == null)
            {
                return NotFound();
            }

            return View(playerModel);
        }

        // POST: Player/Delete/5
        [HttpPost("Delete/{id}"), SwaggerOperation(Summary = "Delete player using id")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PlayerModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.PlayerModel'  is null.");
            }
            var playerModel = await _context.PlayerModel.FindAsync(id);
            if (playerModel != null)
            {
                _context.PlayerModel.Remove(playerModel);
            }

            await _context.SaveChangesAsync();
            return this.RedirectOrReturn(nameof(Index), playerModel);
        }

        [HttpGet("Search/{column}/{value}"), SwaggerOperation(Summary = "Search player using string column")]
        public async Task<IActionResult> Search(string column, string value)
        {
            if (_context.PlayerModel == null)
            {
                return Problem("Entity set 'HamsterDBContext.PlayerModel'  is null.");
            }

            return this.Return(await _context.PlayerModel.WhereContains(column, value).ToListAsync());
        }

        private bool PlayerModelExists(string id)
        {
            return (_context.PlayerModel?.Any(e => e.PlayerID == id)).GetValueOrDefault();
        }
    }
}
