using System;
using System.Collections.Generic;

namespace HotelManager.Data.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public DateOnly AccommodationDate { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public int Days { get; set; }

    public int? RoomId { get; set; }

    public int? GuestId { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual Room? Room { get; set; }
}
