using System;
using System.Collections.Generic;
using System.Linq;

namespace EnFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1:Add 3 hotels to DB, one with name 'Edelweiss’

            using (HotelContext db = new HotelContext())
            {
                Hotel hotel1 = new Hotel { Name = "Laguna", FoundationYear = 1977, Address = "Paris,Pupur45", IsActive = true };
                Hotel hotel2 = new Hotel { Name = "Edelweiss", FoundationYear = 1999, Address = "German,Platz 34", IsActive = false };
                Hotel hotel3 = new Hotel { Name = "Radisson", FoundationYear = 2000, Address = "Ukraine,Bukovel", IsActive = true };

                db.Hotels.Add(hotel1);
                db.Hotels.Add(hotel2);
                db.Hotels.Add(hotel3);
                db.SaveChanges();
                Console.WriteLine("There are 3 new hotels!");
            }

            //Task2:Get All hotels from DB

            using (HotelContext db = new HotelContext())
            {
                foreach (var hotel in db.Hotels)
                    Console.WriteLine($"Hotel ID:{hotel.HotelId},Hotel name:{hotel.Name},FounddationYear:{hotel.FoundationYear}");
            }

            //Task3:Update first hotel foundation year from existing value to 1937

            using (HotelContext db = new HotelContext())
            {
                var hotels = db.Hotels;
                Hotel newFD = (from x in hotels
                               where x.FoundationYear == 1977
                               select x).FirstOrDefault();
                newFD.FoundationYear = 1937;
                db.SaveChanges();

            }

            //Task4:Delete 3d hotel from DB by Id

            using (HotelContext db = new HotelContext())
            {
                Hotel hotel = db.Hotels.FirstOrDefault(x => x.HotelId == 3);
                db.Hotels.Remove(hotel);
                db.SaveChanges();
                Console.WriteLine("Grate!You deleted third hotel!");
            }

            //Task5:Insert 10 users to Database, but have at least 2 users with Name Andrew or Anton
            using (HotelContext db = new HotelContext())
            {
                User user1 = new User { Name = "Alina", Email = "kolodiy@gmail.com" };
                User user2 = new User { Name = "Anton", Email = "popov@mail.ru" };
                User user3 = new User { Name = "Andrew", Email = "lipov@gmail.com" };
                User user4 = new User { Name = "Polina", Email = "abramova@gmail.com" };
                User user5 = new User { Name = "Anton", Email = "horbachov@gmail.com" };
                User user6 = new User { Name = "Ira", Email = "lavrinok1@gmail.com" };
                User user7 = new User { Name = "Inna", Email = "kaprosh@email.com" };
                User user8 = new User { Name = "Anastasia", Email = "kalap121@gmail.com" };
                User user9 = new User { Name = "Ira", Email = "kalaputenko199@gmail.com" };
                User user10 = new User { Name = "Anton", Email = "qwer2@gmail.com" };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.Users.Add(user3);
                db.Users.Add(user4);
                db.Users.Add(user5);
                db.Users.Add(user6);
                db.Users.Add(user7);
                db.Users.Add(user8);
                db.Users.Add(user9);
                db.Users.Add(user10);
                db.SaveChanges();
                Console.WriteLine("Greate!There are 10 users!");
            }
        //Task6: Get all users which name starts from "A"
            using (HotelContext db = new HotelContext())
            {
                var users = db.Users;
                var allUsers = db.Users.Where(x => x.Name.StartsWith("A")).ToList();
                foreach (var user in allUsers)
                {
                    Console.WriteLine(" ID: " + user.UserId + " Name: " + user.Name);
                }
            }
            //Task7:
            using (HotelContext db = new HotelContext())
            {
                var hotel = db.Hotels;
                Hotel firstH = (from x in hotel
                                where x.HotelId == 1
                                select x).FirstOrDefault();
                Hotel secondH = (from x in hotel
                                 where x.HotelId == 2
                                 select x).FirstOrDefault();
                Room room1 = new Room { Hotel = firstH, Number = 101, Comfort = Room.Comforts.FirstLevel, Price = 1000, Capability = Room.Capabilities.Quadruple };
                Room room2 = new Room { Hotel = firstH, Number = 102, Comfort = Room.Comforts.FirstLevel, Price = 800, Capability = Room.Capabilities.Single };
                Room room3 = new Room { Hotel = firstH, Number = 103, Comfort = Room.Comforts.SecondLevel, Price = 2000, Capability = Room.Capabilities.Triple };
                Room room4 = new Room { Hotel = firstH, Number = 111, Comfort = Room.Comforts.ThirdLevel, Price = 3000, Capability = Room.Capabilities.Triple };
                Room room5 = new Room { Hotel = firstH, Number = 112, Comfort = Room.Comforts.SecondLevel, Price = 3000, Capability = Room.Capabilities.Quadruple };
                Room room6 = new Room { Hotel = firstH, Number = 114, Comfort = Room.Comforts.ThirdLevel, Price = 1800, Capability = Room.Capabilities.Single };
                Room room7 = new Room { Hotel = firstH, Number = 115, Comfort = Room.Comforts.ThirdLevel, Price = 2600, Capability = Room.Capabilities.Double };
                Room room8 = new Room { Hotel = secondH, Number = 301, Comfort = Room.Comforts.SecondLevel, Price = 2600, Capability = Room.Capabilities.Double };
                Room room9 = new Room { Hotel = secondH, Number = 303, Comfort = Room.Comforts.SecondLevel, Price = 4000, Capability = Room.Capabilities.Quadruple };
                Room room10 = new Room { Hotel = secondH, Number = 309, Comfort = Room.Comforts.SecondLevel, Price = 1500, Capability = Room.Capabilities.Single };

                db.Rooms.Add(room1);
                db.Rooms.Add(room2);
                db.Rooms.Add(room3);
                db.Rooms.Add(room4);
                db.Rooms.Add(room5);
                db.Rooms.Add(room6);
                db.Rooms.Add(room7);
                db.Rooms.Add(room8);
                db.Rooms.Add(room9);
                db.Rooms.Add(room10);
                db.SaveChanges();

                Console.WriteLine("10 rooms are there!");

            }
        //Task8: Select All rooms from DB sorted by Price
            using (HotelContext db = new HotelContext())
            {
                var allRooms = db.Rooms.OrderBy(x => x.Price);
                foreach (var room in allRooms)
                {
                    Console.WriteLine("Room number: " + room.Number + " Price: " + room.Price);
                }

            }
        //Task9: Select All rooms from DB that belong to 'Edelweiss' hotel and sorted by price
            using (HotelContext db = new HotelContext())
            {
                var hotels = db.Hotels;
                var rooms = db.Rooms.OrderBy(x => x.Price);
                var orderByRoomPrice = (from x in db.Hotels
                                        join y in db.Rooms on x.HotelId equals y.Hotel.HotelId
                                        where x.Name == "Edelweiss"
                                        select new { y.Number, y.Price });
                foreach (var room in orderByRoomPrice)
                {
                    Console.WriteLine(room);
                }


            }
        //Task10: Select Hotels that have rooms with comfort level 3
            using (HotelContext db = new HotelContext())
            {
                var hotels = db.Hotels;
                var roomsWithThirdComfortLevel = (from x in hotels
                                                  join y in db.Rooms on x.HotelId equals y.Hotel.HotelId
                                                  where y.Comfort == Room.Comforts.ThirdLevel
                                                  select new { y.Number, y.Price });
                foreach (var room in roomsWithThirdComfortLevel)
                {
                    Console.WriteLine("Room number : " + room.Number + " Price for room: " + room.Price);
                }

            }
        //Task11: Select Hotelname and room number for rooms that have comfort level 1
            using (HotelContext db = new HotelContext())
                {
                    var hotels = db.Hotels;
                    var roomsWithThirdComfortLevel = (from x in hotels
                                                      join y in db.Rooms on x.HotelId equals y.Hotel.HotelId
                                                      where y.Comfort == Room.Comforts.FirstLevel
                                                      select new { y.Number, y.Price, x.Name });
                    foreach (var room in roomsWithThirdComfortLevel)
                    {
                        Console.WriteLine($"Room number:{room.Number},Price for room:{room.Price},Hotel name:{room.Name}");
                    }

                }
            //Task12: Select Hotel names and count of hotel rooms
            using (HotelContext db = new HotelContext())
            {
                var hotels = db.Hotels;
                var hotelNamesAndCountOfRooms = (from x in hotels
                                                 join y in db.Rooms on x.HotelId equals y.Hotel.HotelId
                                                 select new { x.Name }
                                                 ).GroupBy(x => x.Name).Select(x => new { Name = x.Key, CountofRooms = x.Count() });


                foreach (var hotel in hotelNamesAndCountOfRooms)
                {
                    Console.WriteLine($"Hotel name:{hotel.Name},  Count of rooms:{hotel.CountofRooms}");
                }

            }
        //Task13: Insert 10 different reservations to db.
                using (HotelContext db = new HotelContext())
            {
                var hotels = db.Hotels;
                var users = db.Users;
                var rooms = db.Rooms;
                var user = (from x in users
                            select x).ToList();
                var room = (from x in rooms
                            select x).ToList();
                Booking booking1 = new Booking { User = user[0], Room = room[1], StartDate = new DateTime(2016, 2, 12) };
                booking1.SetEndDate(new DateTime(2016, 3, 12));
                Booking booking2 = new Booking { User = user[1], Room = room[0], StartDate = new DateTime(2018, 3, 12) };
                booking2.SetEndDate(new DateTime(2018, 4, 1));
                Booking booking3 = new Booking { User = user[2], Room = room[1], StartDate = new DateTime(2019, 1, 1) };
                booking3.SetEndDate(new DateTime(2019, 1, 10));
                Booking booking4 = new Booking { User = user[3], Room = room[0], StartDate = new DateTime(2018, 2, 2) };
                booking4.SetEndDate(new DateTime(2018, 2, 4));
                Booking booking5 = new Booking { User = user[8], Room = room[3], StartDate = new DateTime(2017, 2, 4) };
                booking5.SetEndDate(new DateTime(2017, 4, 1));
                Booking booking6 = new Booking { User = user[5], Room = room[3], StartDate = new DateTime(2019, 10, 12) };
                booking6.SetEndDate(new DateTime(2019, 10, 24));
                Booking booking7 = new Booking { User = user[4], Room = room[5], StartDate = new DateTime(2015, 8, 2) };
                booking7.SetEndDate(new DateTime(2015, 8, 13));
                Booking booking8 = new Booking { User = user[6], Room = room[7], StartDate = new DateTime(2014, 9, 12) };
                booking8.SetEndDate(new DateTime(2014, 9, 21));
                Booking booking9 = new Booking { User = user[4], Room = room[5], StartDate = new DateTime(2017, 1, 2) };
                booking9.SetEndDate(new DateTime(2017, 2, 2));
                Booking booking10 = new Booking { User = user[6], Room = room[4], StartDate = new DateTime(2018, 1, 1) };
                booking10.SetEndDate(new DateTime(2018, 2, 3));

                db.Bookings.Add(booking1);
                db.Bookings.Add(booking2);
                db.Bookings.Add(booking3);
                db.Bookings.Add(booking4);
                db.Bookings.Add(booking5);
                db.Bookings.Add(booking6);
                db.Bookings.Add(booking7);
                db.Bookings.Add(booking8);
                db.Bookings.Add(booking9);
                db.Bookings.Add(booking10);
                db.SaveChanges();

                Console.WriteLine("Greate job!You made 10 bookings!");
            }
        //Task14: Select Username, room number, reservation period
                using (HotelContext db = new HotelContext())
            {
                var bookings = db.Bookings;
                var rooms = db.Rooms;
                var users = db.Users;
                var joinBookingAndRooms = (from b in bookings
                                           join r in rooms on b.Room.RoomId equals r.RoomId
                                           select new { r.Number, period = b.StartDate - b.EndDate, b.User.UserId });
                var joinBookingAndUser = (from b in joinBookingAndRooms
                                          join u in users on b.UserId equals u.UserId
                                          select new { u.Name, b.Number, b.period });

                foreach (var booking in joinBookingAndUser)
                {
                    Console.WriteLine($"Name of user:{booking.Name},Number of room:{booking.Number},Period booking:{booking.period}");
                }

            }
        }
    }
}
