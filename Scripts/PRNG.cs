using UnityEngine;

public class PRNG
{
    private System.Random random;

    public PRNG(int seed)
    {
        random = new System.Random(seed);
    }

    public int Next()
    {
        return random.Next();
    }

    public int Next(int maxValue)
    {
        return random.Next(maxValue);
    }

    public float NextFloat()
    {
        return (float)random.NextDouble();
    }
}
