using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpawnButton : MonoBehaviour
{
   [SerializeField] private Slider
      FodderSliderAmount,
      FodderPowerSlider,
      EliteSliderAmount,
      ElitePowerSlider,
      ThreatSliderAmount,
      ThreatPowerSlider,
      RadiusSlider;
   
   [SerializeField] Spawner spawner;
   public void OnButtonClick()
   {
      SpawnSettings spawnSettings = new SpawnSettings();
      
      spawnSettings.Radius = (int)RadiusSlider.value;
      
      List<MobTypeAmountPower> list = new List<MobTypeAmountPower>();
      MobTypeAmountPower mobTypeAmount = new MobTypeAmountPower();
      mobTypeAmount.mobType = MobType.Fodder;
      mobTypeAmount.amount = (int)FodderSliderAmount.value;
      mobTypeAmount.progression = new MobProgression();
      mobTypeAmount.progression.MobPower = (int)FodderPowerSlider.value;
      list.Add(mobTypeAmount);
      mobTypeAmount = new MobTypeAmountPower();
      mobTypeAmount.mobType = MobType.Elite;
      mobTypeAmount.amount = (int)EliteSliderAmount.value;
      mobTypeAmount.progression = new MobProgression();
      mobTypeAmount.progression.MobPower = (int)ElitePowerSlider.value;
      list.Add(mobTypeAmount);
      mobTypeAmount = new MobTypeAmountPower();
      mobTypeAmount.mobType = MobType.Threat;
      mobTypeAmount.amount = (int)ThreatSliderAmount.value;
      mobTypeAmount.progression = new MobProgression();
      mobTypeAmount.progression.MobPower = (int)ThreatPowerSlider.value;
      list.Add(mobTypeAmount);
      spawnSettings.MobTypeAmountPowers = list;
      
      spawner.SpawnMobs(spawnSettings);
   }
}
