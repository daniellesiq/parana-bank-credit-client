﻿namespace Domain.Entity
{
    public record Client
    {
        public string Name { get; init; } = default!;
        public DateTime BirthDate { get; init; } = default!;
        public long Document { get; init; } = default!;
        public string Gender { get; init; } = default!;
        public string Status { get; init; } = default!;
        public Address Address { get; init; } = default!;
        public int PhoneNumber { get; init; } = default!;
        public string Email { get; init; } = default!;
        public string Job { get; init; } = default!;
        public decimal Income { get; init; } = default!;
        public int Score { get; init; } = default!;
        public DateTime CreateAt { get; init; } = DateTime.Now;
    }
}
