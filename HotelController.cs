using HotelManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    public class HotelController
    {
        HotelManagerContext context = new HotelManagerContext();
        public async Task<List<Guest>> ViewAllGuest()
        {
            var guests = await context.Guests.ToListAsync();
            return guests;
        }
        public async Task AddGuest(string firstName, string lastName, string ucn, string phoneNumber)
        {
            Guest guest = new Guest()
            { 
                FirstName = firstName,
                LastName = lastName,
                Ucn = ucn,
                PhoneNumber = phoneNumber
            };
            await context.Guests.AddAsync(guest);
            await context.SaveChangesAsync();
        }
        public async Task<List<Room>> RoomsWithPriceBetween80And100OrderByDesc()
        {
            var rooms = await context.Rooms.Where(r=>r.Price>=80 && r.Price<=100)
                                           .OrderByDescending(r=>r.Price)
                                           .ToListAsync();
            return rooms;
        }
        public async Task DeleteReservationById(int id)
        {
            var reservation = await context.Reservations.FirstOrDefaultAsync(r=>r.Id==id);
            context.Reservations.Remove(reservation);
            await context.SaveChangesAsync();

        }
        public async Task<List<Room>> AvailableRooms()
        {
            var rooms = await context.Rooms.Where(r => r.Status == "free")
                                           .ToListAsync();
            return rooms;
        }
        public async Task<decimal> MinimalPriceByStatus(string status)
        {
            var room = await context.Rooms.Where(r => r.Status == status)
                                          .OrderBy(r => r.Price)
                                          .FirstAsync();
            return room.Price;                              
        }
        public async Task<List<Reservation>> ReservationIdThatNotCompletedYet()
        {
            var reservation = await context.Reservations
                               .Where(r => r.ReleaseDate > DateOnly.FromDateTime(DateTime.Now))
                               .ToListAsync();
            return reservation;
        }
    }
}
