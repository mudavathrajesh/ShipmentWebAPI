using System;
using System.Collections.Generic;

namespace ShipmentWebAPI.Models;

public partial class ShipmentTestResult
{
    public string? LatestShipmentStatus  { get; set; }

    public DateTime? ShipmentDate { get; set; }

    public DateTime? StatusDate {get;set;}

    public string? TrackingNumber { get; set; }
}
