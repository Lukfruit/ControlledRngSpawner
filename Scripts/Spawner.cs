using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Spawner : MonoBehaviour
{
    public MobDBSO mobDBSO;
    public RoomSelection roomSelection;
    public RoomSettings roomSettings;
    public WaveSettings waveSettings;
    public SpawnSettingsWrapperSO spawnSettingsWrapperSO;
    
    [Space]
    public TMPro.TextMeshProUGUI mobspawnCounterText;
    
    private List<GameObject> spawnedMobs = new List<GameObject>();
    void Start()
    {
        roomSelection = new RoomSelection(roomSettings, mobDBSO);
        foreach (var mobsmo in roomSelection.FodderMobs)
        {
            Debug.Log(mobsmo.name);
        }

        if (spawnSettingsWrapperSO != null)
        {
            Debug.Log(spawnSettingsWrapperSO);
            Debug.Log("spawning mobs");
            SpawnMobs(spawnSettingsWrapperSO.spawnSettings);
        }
        
        SpawnerPRNG.PRNGInit();
    }

    public void SpawnMobs(SpawnSettings spawnSettings)
    {
        Debug.Log("Spawning mobs" + spawnSettings.MobTypeAmountPowers.Count );
        GameObject obj = new GameObject();
        Color color;
        foreach (var mobType in spawnSettings.MobTypeAmountPowers)
        {
            Debug.Log("spawning " + mobType);
            for (int i = 0; i < mobType.amount; i++)
            {
                Vector2 randomCircle = Random.insideUnitCircle * (float)spawnSettings.Radius;
                Vector3 position = new Vector3(randomCircle.x, 5, randomCircle.y);
                

                switch (mobType.mobType)
                {
                    case MobType.Fodder:
                        obj = Instantiate(roomSelection.FodderMobs[SpawnerPRNG.Range(PRNGType.MobChoiceRandomness,0, roomSelection.FodderMobs.Count)], position,
                            Quaternion.identity);
                        break;
                    case MobType.Elite:
                        obj = Instantiate(roomSelection.EliteMobs[SpawnerPRNG.Range(PRNGType.MobChoiceRandomness,0, roomSelection.EliteMobs.Count)], position,
                            Quaternion.identity);
                        break;
                    case MobType.Threat:
                        obj = Instantiate(roomSelection.ThreatMobs[SpawnerPRNG.Range(PRNGType.MobChoiceRandomness,0, roomSelection.ThreatMobs.Count)], position,
                            Quaternion.identity);
                        break;
                    default:
                        Debug.LogError($"Mob type {mobType.mobType} is not supported");
                        break;
                }
                color = obj.GetComponent<Renderer>().material.color;
                Color.RGBToHSV(color, out float h, out float s, out float v);
                obj.GetComponent<Renderer>().material.color = Color.HSVToRGB(h, (float)mobType.progression.MobPower*1f/6f, v);
                obj.SetActive(true);
                spawnedMobs.Add(obj);
                
                Destroy(obj, Random.Range(3f,10f));
                
            }
        }
    }

    public void ChangeRoomSelection(RoomSettings newRoomSettings)
    {
        roomSelection = new RoomSelection(newRoomSettings, mobDBSO);
    }
}
