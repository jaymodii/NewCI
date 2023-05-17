﻿using System;
using System.Collections.Generic;

namespace NewCI.Entities.Models;

public partial class ContactU
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int Id { get; set; }
}
