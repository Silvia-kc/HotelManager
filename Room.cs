using System;
using System.Collections.Generic;

namespace HotelManager.Data.Models;

public partial class Room
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Status { get; set; } = null!;

    public decimal Price { get; set; }

    public int? RoomTypeId { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual RoomType? RoomType { get; set; }
}
