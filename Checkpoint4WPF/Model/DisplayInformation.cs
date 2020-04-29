using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Checkpoint4WPF
{
    public static class DisplayInformation
    {
        public static List<Show> DisplayAllShows()
        {
            using (var context = new CircusDataContext())
            {
                var defaultList = (from s in context.Show
                                   select s).ToList();
                return defaultList;
            }
        }

        public static Troupe GetTroupeFromShow(Show show)
        {
            using (var context = new CircusDataContext())
            {
                var troupe = (from s in context.Show
                              join t in context.Troupe
                              on s.Troupe.Id equals t.Id
                              where t.Id == show.Id
                              select t).FirstOrDefault();
                return troupe;
            }
        }

        public static List<Event> GetEventListFromShow(Show show)
        {
            using (var context = new CircusDataContext())
            {
                var eventlist = (from e in context.Event
                              join se in context.ShowEvent
                              on e.Id equals se.EventId
                              where se.ShowId == show.Id
                              select e).ToList();
                return eventlist;
            }
        }

        public static Show GetShowFromEvent(Event oneEvent)
        {
            using (var context = new CircusDataContext())
            {
                var show = (from s in context.Show
                            join se in context.ShowEvent
                            on s.Id equals se.ShowId
                            where se.EventId == oneEvent.Id
                            select s).FirstOrDefault();
                return show;
            }
        }

        public static List<Order> GetAllOrders()
        {
            using (var context = new CircusDataContext())
            {
                var ordersList = (from o in context.Order
                                  select o).ToList();
                return ordersList;
            }
        }

        public static List<Troupe> GetAllTroupes()
        {
            using (var context = new CircusDataContext())
            {
                var troupeList = (from t in context.Troupe
                                  select t).ToList();
                return troupeList;
            }
        }

        public static List<Artist> GetArtistsFromTroupe(Troupe troupe)
        {
            using (var context = new CircusDataContext())
            {
                var artistList = (from a in context.Artist
                                  join t in context.Troupe
                                  on a.Troupe.Id equals t.Id
                                  where t.Id == troupe.Id
                                  select a).ToList();
                return artistList;
            }
        }
    }
}
