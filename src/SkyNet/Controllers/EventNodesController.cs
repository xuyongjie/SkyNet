using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkyNet.Data;
using SkyNet.Models.BusinessModels;

namespace SkyNet.Controllers
{
    public class EventNodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventNodesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: EventNodes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventNodes.Include(e => e.Event).Include(e => e.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EventNodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventNode = await _context.EventNodes.SingleOrDefaultAsync(m => m.Id == id);
            if (eventNode == null)
            {
                return NotFound();
            }

            return View(eventNode);
        }

        // GET: EventNodes/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Title");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: EventNodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comment,Cost,EventId,HasCost,IsPublic,UserId")] EventNode eventNode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventNode);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Title", eventNode.EventId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", eventNode.UserId);
            return View(eventNode);
        }

        // GET: EventNodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventNode = await _context.EventNodes.SingleOrDefaultAsync(m => m.Id == id);
            if (eventNode == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Title", eventNode.EventId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", eventNode.UserId);
            return View(eventNode);
        }

        // POST: EventNodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Comment,Cost,CreateTime,EventId,HasCost,IsPublic,ModifyTime,UserId")] EventNode eventNode)
        {
            if (id != eventNode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventNode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventNodeExists(eventNode.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Title", eventNode.EventId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", eventNode.UserId);
            return View(eventNode);
        }

        // GET: EventNodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventNode = await _context.EventNodes.SingleOrDefaultAsync(m => m.Id == id);
            if (eventNode == null)
            {
                return NotFound();
            }

            return View(eventNode);
        }

        // POST: EventNodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventNode = await _context.EventNodes.SingleOrDefaultAsync(m => m.Id == id);
            _context.EventNodes.Remove(eventNode);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EventNodeExists(int id)
        {
            return _context.EventNodes.Any(e => e.Id == id);
        }
    }
}
