﻿using System.Text.RegularExpressions;

namespace VerticalSlice.Models;
public sealed record PhoneNumber(string phoneNumber)
{
    public string Value => IsValid(phoneNumber) ? phoneNumber : throw new ApplicationException("Your phonenumber is not match!");
    private static bool IsValid(string value)
    {
        return Regex.IsMatch(value, @"^(0|\+)[1-9]\d{8,13}$");
    }

}
