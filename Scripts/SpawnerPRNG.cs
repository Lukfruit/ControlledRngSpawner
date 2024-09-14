using System;
using System.Collections.Generic;
using UnityEngine;

public static class SpawnerPRNG //: PRNG
{
    // private List<int> wavesRandomness;
    // private int wavesRandomnessIndex;
    //
    // private List<int> RoomSelectionRandomness;
    // private int RoomSelectionRandomnessIndex;
    
    private static Dictionary<PRNGType,System.Random> PRNGs = new Dictionary<PRNGType,System.Random>();
    private static System.Random MasterPRNG;
    private static bool isInitialized = false;
    private static int defaultSeed = 10000;

    // public SpawnerPRNG(int seed) //: base(seed)
    // {
    //     System.Random RoomRandomness = new System.Random(Next());
    //     PRNGs.Add(PRNGType.RoomRandomness,RoomRandomness);
    //     // wavesRandomness = GenerateAnRNGList(100);
    //     // wavesRandomnessIndex = 0;
    //     
    //     System.Random MobChoiceRandomness = new System.Random(Next());
    //     PRNGs.Add(PRNGType.MobChoiceRandomness,MobChoiceRandomness);
    //     // RoomSelectionRandomness = GenerateAnRNGList(10);
    //     // RoomSelectionRandomnessIndex = 0;
    // }
    public static void PRNGInit()
    {
        if (isInitialized)
        {
            Debug.LogWarning("PRNG is already initialized. Skipping re-initialization.");
            return;
        }
        
        Init(defaultSeed);
    }

    public static void InitSeed(PRNGType PRNGType)
    {
        if (!PRNGs.ContainsKey(PRNGType))
            PRNGs[PRNGType] = new System.Random();
    }

    public static int Next(PRNGType type)
    {
        CheckInitialization();
        return PRNGs[type].Next();
    }
    public static int Next(PRNGType PRNGType, int maxValue)
    {
        CheckInitialization();
        return PRNGs[PRNGType].Next(maxValue);
    }

    public static float NextFloat(PRNGType PRNGType)
    {
        CheckInitialization();
        return (float)PRNGs[PRNGType].NextDouble();
    }
    
    public static int Range(PRNGType PRNGType, int minInclusive, int maxExclusive)
    {
        CheckInitialization();
        return PRNGs[PRNGType].Next(minInclusive, maxExclusive);
    }

    // New method: Range for floats
    public static float Range(PRNGType PRNGType, float minInclusive, float maxInclusive)
    {
        CheckInitialization();
        float t = (float)PRNGs[PRNGType].NextDouble();
        return minInclusive + (maxInclusive - minInclusive) * t;
    }

    
    private static void CheckInitialization()
    {
        if (!isInitialized)
        {
            throw new InvalidOperationException("PRNG is not initialized. Call Initialize() first.");
        }
    }
    
    public static void ResetWithSeed(int newMasterSeed)
    {
        Init(newMasterSeed);
    }

    private static void Init(int seed)
    {
        MasterPRNG = new System.Random(seed);
        
        PRNGs.Clear();
        foreach (PRNGType type in Enum.GetValues(typeof(PRNGType)))
        {
            int subSeed = MasterPRNG.Next();
            PRNGs[type] = new System.Random(subSeed);
        }
        
        isInitialized = true;
    }

    // public List<int> GenerateAnRNGList(int size)
    // {
    //     List<int> list = new List<int>();
    //     int rng;
    //     for (int i = 0; i < size; i++)
    //     {
    //         rng = Next();
    //         list.Add(rng);
    //     }
    //     return list;
    // }
}

public enum PRNGType
{
    RoomRandomness,
    MobChoiceRandomness,
}
