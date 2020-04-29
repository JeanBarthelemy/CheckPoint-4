using System;
using Checkpoint4WPF;
using System.Collections.Generic;

namespace Checkpoint4_DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CircusDataContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();


                var troupe1 = new Troupe("The Flying Monkeys");

                var artist1 = new Artist("Tommy BRAVE", 29, "Animal Tamer", troupe1);
                var artist2 = new Artist("Myriam BOLD", 27, "Animal Tamer", troupe1);
                var artist3 = new Artist("Luna ARMSTRONG", 24, "Trapezist", troupe1);
                var artist4 = new Artist("John FLEX", 24, "Acrobat", troupe1);

                List<Artist> artistsTroupe1 = new List<Artist>();
                artistsTroupe1.Add(artist1);
                artistsTroupe1.Add(artist2);
                artistsTroupe1.Add(artist3);
                artistsTroupe1.Add(artist4);

                troupe1.Artists = artistsTroupe1;

                context.Add(troupe1);


                var troupe2 = new Troupe("The Indestructibles");

                var artist5 = new Artist("Rodolph LUCK", 38, "Clown", troupe2);
                var artist6 = new Artist("Lionel LOSE", 21, "Clown", troupe2);
                var artist7 = new Artist("Larry QUICK", 27, "Magician", troupe2);
                var artist8 = new Artist("Arthur CLUMSY", 31, "Juggler", troupe2);

                List<Artist> artistsTroupe2 = new List<Artist>();
                artistsTroupe2.Add(artist5);
                artistsTroupe2.Add(artist6);
                artistsTroupe2.Add(artist7);
                artistsTroupe2.Add(artist8);

                troupe2.Artists = artistsTroupe2;

                context.Add(troupe2);


                var troupe3 = new Troupe("The Dancing Moons");

                var artist9 = new Artist("Lara BLIND", 23, "Tightrope Walker", troupe3);
                var artist10 = new Artist("Stefan SALTO", 28, "Acrobat", troupe3);
                var artist11 = new Artist("Georges BALLS", 25, "Juggler", troupe3);
                var artist12 = new Artist("Alexa FLY", 26, "Aerial Silk Acrobat", troupe3);

                List<Artist> artistsTroupe3 = new List<Artist>();
                artistsTroupe3.Add(artist9);
                artistsTroupe3.Add(artist10);
                artistsTroupe3.Add(artist11);
                artistsTroupe3.Add(artist12);

                troupe3.Artists = artistsTroupe3;

                context.Add(troupe3);


                Event event1show1 = new Event();
                event1show1.StartTime = DateTime.Now.AddDays(25).AddHours(4);
                event1show1.EndTime = DateTime.Now.AddDays(25).AddHours(6);

                Event event2show1 = new Event();
                event2show1.StartTime = DateTime.Now.AddDays(30).AddHours(4);
                event2show1.EndTime = DateTime.Now.AddDays(30).AddHours(6);

                Event event3show1 = new Event();
                event3show1.StartTime = DateTime.Now.AddDays(35).AddHours(4);
                event3show1.EndTime = DateTime.Now.AddDays(35).AddHours(6);

                List<Event> eventsShow1 = new List<Event>();
                eventsShow1.Add(event1show1);
                eventsShow1.Add(event2show1);
                eventsShow1.Add(event3show1);



                Event event1show2 = new Event();
                event1show2.StartTime = DateTime.Now.AddDays(20).AddHours(4);
                event1show2.EndTime = DateTime.Now.AddDays(20).AddHours(6);

                Event event2show2 = new Event();
                event2show2.StartTime = DateTime.Now.AddDays(22).AddHours(4);
                event2show2.EndTime = DateTime.Now.AddDays(22).AddHours(6);

                Event event3show2 = new Event();
                event3show2.StartTime = DateTime.Now.AddDays(24).AddHours(4);
                event3show2.EndTime = DateTime.Now.AddDays(24).AddHours(6);

                List<Event> eventsShow2 = new List<Event>();
                eventsShow2.Add(event1show2);
                eventsShow2.Add(event2show2);
                eventsShow2.Add(event3show2);



                Event event1show3 = new Event();
                event1show3.StartTime = DateTime.Now.AddDays(40).AddHours(4);
                event1show3.EndTime = DateTime.Now.AddDays(40).AddHours(6);

                Event event2show3 = new Event();
                event2show3.StartTime = DateTime.Now.AddDays(43).AddHours(4);
                event2show3.EndTime = DateTime.Now.AddDays(43).AddHours(6);

                Event event3show3 = new Event();
                event3show3.StartTime = DateTime.Now.AddDays(46).AddHours(4);
                event3show3.EndTime = DateTime.Now.AddDays(46).AddHours(6);

                List<Event> eventsShow3 = new List<Event>();
                eventsShow3.Add(event1show3);
                eventsShow3.Add(event2show3);
                eventsShow3.Add(event3show3);


                Show show1 = new Show("Magic in the air", troupe1, "Come and see this amazing show, the most spectacular of all time, performed by talented artists.", eventsShow1, 15.90);
                Show show2 = new Show("In the Heart of a Sad Clown", troupe2, "Come and see this amazing show, the most spectacular of all time, performed by talented artists.", eventsShow2, 17.50);
                Show show3 = new Show("Over the Rainbow", troupe3, "Come and see this amazing show, the most spectacular of all time, performed by talented artists.", eventsShow3, 21.90);

                context.Add(show1);
                context.Add(show2);
                context.Add(show3);


                List<Show> manyShows1 = new List<Show>() { show1 };
                List<Show> manyShows2 = new List<Show>() { show2 };
                List<Show> manyShows3 = new List<Show>() { show3 };
               
                List<ShowEvent> showEventsList1 = AssociationEventWithShow(manyShows1, eventsShow1);
                List<ShowEvent> showEventsList2 = AssociationEventWithShow(manyShows2, eventsShow2);
                List<ShowEvent> showEventsList3 = AssociationEventWithShow(manyShows3, eventsShow3);

                context.AddRange(showEventsList1);
                context.AddRange(showEventsList2);
                context.AddRange(showEventsList3);
                


                Ticket ticket1 = new Ticket(show1.Name, DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(2), 15.90);
                Ticket ticket2 = new Ticket(show2.Name, DateTime.Now.AddDays(8), DateTime.Now.AddDays(8).AddHours(2), 17.50);
                Ticket ticket3 = new Ticket(show3.Name, DateTime.Now.AddDays(14), DateTime.Now.AddDays(14).AddHours(2), 21.90);

                context.Add(ticket1);
                context.Add(ticket2);
                context.Add(ticket3);


                Order order1 = new Order(ticket1, 4, 63.6, DateTime.Now);
                Order order2 = new Order(ticket2, 2, 35, DateTime.Now);
                Order order3 = new Order(ticket3, 8, 175.20, DateTime.Now);

                context.Add(order1);
                context.Add(order2);
                context.Add(order3);

                context.SaveChanges();


                static List<ShowEvent> AssociationEventWithShow(List<Show> manyShows, List<Event> manyEvents)
                {
                    List<ShowEvent> manyShowEvents = new List<ShowEvent>();

                    foreach (var oneEvent in manyEvents)
                    {
                        foreach (var show in manyShows)
                        {
                            var showEvent = new ShowEvent { Event = oneEvent, EventId = oneEvent.Id, Show = show, ShowId = show.Id};
                            manyShowEvents.Add(showEvent);
                        }
                    }
                    return manyShowEvents;

                }

            }
        }
    }
}
