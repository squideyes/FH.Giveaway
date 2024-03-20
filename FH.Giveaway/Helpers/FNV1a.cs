namespace FH.Giveaway;

public static class FNV1a
{
    private const ulong FNVPrime = 1099511628211ul;
    private const ulong OffsetBasis = 14695981039346656037ul;

    public static string Hash(string data)
    {
        ulong hashValue = OffsetBasis;

        foreach (char ch in data)
        {
            hashValue ^= ch;
            hashValue *= FNVPrime;
        }

        return hashValue.ToString("x16");
    }
}