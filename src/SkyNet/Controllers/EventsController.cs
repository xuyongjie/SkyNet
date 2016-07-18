using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkyNet.Data;
using SkyNet.Models.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SkyNet.Repo;
using SkyNet.Models;

namespace SkyNet.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly EventRepository _repo;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _repo = new EventRepository(context);
            _userManager = userManager;
        }

        // GET: Events
        public IActionResult Index()
        {
            return View(_repo.GetEvents(_userManager.FindByNameAsync(User.Identity.Name).Result.Id));
        }

        // GET: Events/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventDetail = _repo.GetEventDetail((int)id);
            if (eventDetail == null)
            {
                return NotFound();
            }
            return View(eventDetail);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Description,Title")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _repo.AddEvent(@event);
                _repo.SavaChanges();
                UserEvent ue = new UserEvent();
                ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                ue.UserId = user.Id;
                ue.User = user;
                ue.EventId = @event.Id;
                ue.Event = @event;
                ue.IsOwner = true;
                _repo.Add(ue);
                _repo.SavaChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        //// GET: Events/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var @event = await _context.Events.SingleOrDefaultAsync(m => m.Id == id);
        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(@event);
        //}

        //// POST: Events/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("EventId,CreateTime,Description,ModifyTime,Title")] Event @event)
        //{
        //    if (id != @event.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(@event);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EventExists(@event.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(@event);
        //}

        //// GET: Events/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var @event = await _context.Events.SingleOrDefaultAsync(m => m.Id == id);
        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(@event);
        //}

        //// POST: Events/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var @event = await _context.Events.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Events.Remove(@event);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
