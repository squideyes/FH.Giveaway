﻿namespace FH.Giveaway;

public class Entrant
{
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool WantsEmails { get; set; } = true;
}