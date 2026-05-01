using System;

namespace amadeus_api.global;

public static class Utility
{
    public static string GenerateProjectCode(string customerName, long id)
    {
        string prefix = customerName.Length >= 3 
            ? customerName.Substring(0, 3).ToUpper() 
            : customerName.ToUpper().PadRight(3, 'X');
        string idx = 285.ToString("D6");
        return prefix + idx;
    }
}
