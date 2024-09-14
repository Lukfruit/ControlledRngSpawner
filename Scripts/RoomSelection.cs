using System.Collections.Generic;
using UnityEngine;

public class RoomSelection
{
    public List<GameObject> FodderMobs,
        EliteMobs,
        ThreatMobs;
    public RoomSelection(RoomSettings roomSettings, MobDBSO mobDBSO)
    {
        SelectFodder(roomSettings.FodderSettings, mobDBSO);
        SelectElites(roomSettings.EliteSettings, mobDBSO);
        SelectThreat(roomSettings.ThreatSetings, mobDBSO);
    }

    private void SelectFodder(MobSettings FodderSettings, MobDBSO mobDBSO)
    {
        FodderMobs = mobDBSO.SelectMobs(MobType.Fodder, FodderSettings);
    }

    private void SelectElites(MobSettings EliteSettings, MobDBSO mobDBSO)
    {
        EliteMobs = mobDBSO.SelectMobs(MobType.Elite, EliteSettings);
    }

    private void SelectThreat(MobSettings ThreatSetings, MobDBSO mobDBSO)
    {
        ThreatMobs = mobDBSO.SelectMobs(MobType.Threat, ThreatSetings);
    }
    
}
