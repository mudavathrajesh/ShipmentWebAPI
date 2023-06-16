using System;
using System.Collections.Generic;

namespace ShipmentWebAPI.Models;

public partial class Person
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string? FirstName { get; set; }

    public int? Age { get; set; }
}
