using System;
 using System;

public class CustomRandom
{
    private int seed;

    public CustomRandom(int seed)
    {
        this.seed = seed;
    }

    public int Next(int maxValue)
    {
        seed = (seed * 9301 + 49297) % 233280;
        double result = seed / 233280.0;
        return (int)(result * maxValue);
    }
}

