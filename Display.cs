using HotelManager.Controllers;
using HotelManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.View
{
    public class Display
    {
        HotelController hotelController = new HotelController();
        public async Task ShowMenu()
        {
            while(true)
            {
                Menu();
                int num = int.Parse(Console.ReadLine());    
                if(num == 0)
                {
                    break;
                }
                switch (num)
                {
                    case 1:
                        await ViewAllGuest();
                        break;
                    case 2:
                        await InsetGuest();
                        break;
                    case 3:
                        await RoomsWithPriceBetween80And100OrderByDesc();
                        break;
                    case 4:
                        await DeleteReservationById();
                        break;
                    case 5:
                        await AvailableRooms();
                        break;
                    case 6:
                        await MinimalPriceByStatus();
                        break;
                    case 7:
                        await ReservationIdThatNotCompletedYet();
                        break;
                    default:
                        Console.WriteLine("There is no such option");
                        break;

                }

            }
        }
        public async Task ViewAllGuest()
        {
            List<Guest> guests = await hotelController.ViewAllGuest();
            foreach (var guest in guests)
            {
                Console.WriteLine($"{guest.FirstName} {guest.LastName}");
            }
            if(guests.Count == 0)
            {
                Console.WriteLine("There is no guests in the hotel!");
            }
        }
        public async Task InsetGuest()
        {
            Console.WriteLine("Enter guest first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter guest last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter guest ucn: ");
            string ucn = Console.ReadLine();
            Console.WriteLine("Enter guest phone number: ");
            string phoneNumber = Console.ReadLine();
            await hotelController.AddGuest(firstName, lastName, ucn, phoneNumber);
            Console.WriteLine("Guest was added successfully!");
        }
        public async Task RoomsWithPriceBetween80And100OrderByDesc()
        {
            List<Room> rooms = await hotelController.RoomsWithPriceBetween80And100OrderByDesc();
            foreach(var room in rooms)
            {
                Console.WriteLine(room.Number);
            }
        }
        public async Task DeleteReservationById()
        {
            Console.WriteLine("Enter reservation id to delete: ");
            int id = int.Parse(Console.ReadLine());
            await hotelController.DeleteReservationById(id);
            Console.WriteLine($"Reservation with id {id} was delete successfully!");
        }
        public async Task AvailableRooms()
        {
            List<Room> rooms = await hotelController.AvailableRooms();
            Console.WriteLine($"Free rooms: {rooms.Count}");
        }
        public async Task MinimalPriceByStatus()
        {
            Console.WriteLine("Enter room status: ");
            string status = Console.ReadLine();
            var price = await hotelController.MinimalPriceByStatus(status);
            Console.WriteLine($"Minimal price: {price} BGN");
        }
        public async Task ReservationIdThatNotCompletedYet()
        {
            List<Reservation> reservations = await hotelController.ReservationIdThatNotCompletedYet();
            Console.WriteLine($"Reservation that not have been completed yet: ");
            foreach (var reservation in reservations)
            {
                Console.WriteLine(reservation.Id);
            }
        }
        public void Menu()
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1.View all guests");
            Console.WriteLine("2.Add new guest");
            Console.WriteLine("3.Rooms priced between 80 and 100 BGN (in descending order)");
            Console.WriteLine("4.Delete reservation by ID");
            Console.WriteLine("5.Number of available rooms");
            Console.WriteLine("6.Minimum price by status");
            Console.WriteLine("7.IDs of active reservations");
            Console.WriteLine("0.Exit");
        }
    }
}
