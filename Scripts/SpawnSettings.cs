using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnSettings
{
   public int Radius;
   public List<MobTypeAmountPower> MobTypeAmountPowers = new List<MobTypeAmountPower>();
}

[Serializable]
public class MobTypeAmountPower
{
   public MobType mobType;
   public int amount;
   public MobProgression progression;
}
