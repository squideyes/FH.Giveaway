// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

namespace FH.Giveaway;

public static class MiscExtenders
{
    public static string ToDateString(this DateOnly date) => 
        date.ToString("yyyy-MM-dd");
}