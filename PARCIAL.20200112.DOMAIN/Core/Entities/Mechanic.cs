using System;
using System.Collections.Generic;

namespace PARCIAL._20200112.DOMAIN.Core.Entities;

public partial class Mechanic
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? HireDate { get; set; }

    public bool? IsActive { get; set; }
}
