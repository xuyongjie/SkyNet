using Microsoft.EntityFrameworkCore;
using SkyNet.Data;
using SkyNet.Models;
using SkyNet.Models.BusinessModels;
using SkyNet.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Repo
{
    public class EventRepository : Repository<UserEvent>
    {
        public EventRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {

        }

        public IEnumerable<Event> GetEvents(string userId)
        {
            return _dbSet.Where(ue => ue.UserId == userId).Include(ue => ue.Event).Select(ue=>ue.Event).ToList();
        }

        public IEnumerable<Event> GetOwnerEvents(string userId)
        {
            return _dbSet.Where(ue => ue.IsOwner && ue.UserId == userId).Include(ue => ue.Event).Select(ue => ue.Event).ToList();
        }

        public IEnumerable<Event> GetParticipateEvents(string userId)
        {
            return _dbSet.Where(ue => !ue.IsOwner && ue.UserId == userId).Include(ue=>ue.Event).Select(ue => ue.Event).ToList();
        }
        
        public EventDTO GetEventDetail(int eventId)
        {
            Event eve = _dbContext.Events.Include(e=>e.EventNodes).First(e => e.Id == eventId);
            if(eve==null)
            {
                return null;
            }
            EventDTO detail = new EventDTO();
            detail.Event = eve;
            detail.Owner = GetOwner(eventId);
            detail.Participants = GetParticipants(eventId);
            detail.TotalCost = GetEventTotalCost(eve);
            return detail;
        }

        public IEnumerable<ApplicationUser> GetParticipants(int eventId)
        {
            return _dbSet.Where(ue =>!ue.IsOwner&&ue.EventId == eventId).Include(ue => ue.User).Select(ue => ue.User).ToList();
        }
        public ApplicationUser GetOwner(int eventId)
        {
            return _dbSet.Where(ue =>ue.IsOwner&&ue.EventId == eventId).Include(ue => ue.User).Select(ue => ue.User).FirstOrDefault();
        }

        public decimal GetEventTotalCost(int eventId)
        {
            Event eve = _dbContext.Events.Include(e=>e.EventNodes).First(e => e.Id == eventId);
            return GetEventTotalCost(eve);
        }
        public decimal GetEventTotalCost(Event eve)
        {
            if (eve == null)
            {
                return 0;
            }
            var Nodes = eve.EventNodes;
            decimal total = 0;
            foreach (var item in Nodes)
            {
                if (item.HasCost)
                {
                    total += item.Cost;
                }
            }
            return total;
        }

        public void AddEvent(Event eve)
        {
            _dbContext.Events.Add(eve);
        }

        public bool EventExist(int eventId)
        {
            return _dbContext.Events.Any(e => e.Id == eventId);
        }
    }
}
