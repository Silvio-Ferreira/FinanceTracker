using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Domain.ValueObjects;

public readonly struct Money
{
    public decimal Value { get; }

    public Money(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Money value cannot be negative.");

        Value = value;
    }

    public static implicit operator decimal(Money money) => money.Value;
    public static implicit operator Money(decimal value) => new(value);
}