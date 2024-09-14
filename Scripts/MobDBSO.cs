using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "MobDBSO", menuName = "Scriptable Objects/MobDBSO")]
public class MobDBSO : ScriptableObject
{
    [SerializeField] List<GameObject> FodderMobs,
        EliteMobs,
        ThreatMobs;

    [SerializeField] private Texture myTexture;

    public List<GameObject> SelectMobs(MobType mobType, MobSettings mobSettings)
    {
        SpawnerPRNG.PRNGInit();
        List<GameObject> mobs = new List<GameObject>();
        List<GameObject> mobTypes = new List<GameObject>(SelectMobGroup(mobType));
        
        // if (mobSettings.diversity > mobTypes.Count) //if not enough diversity caping diversity at max amount of mob types
        // {                                           // can be handled differently
        //     Debug.Log("Not enough mob diversity");
        //     mobSettings.diversity = mobTypes.Count; 
        // }
        
        List<int> listOf6 = new List<int>(){1,2,3,4,5,6,7,8,9,10,11,12};
        
        for (int i = 0; i < mobSettings.diversity; i++)
        {
            // This is what code should be doing, but i am just going to change colour hue instead for the demo
            // int r = Random.Range(0, mobTypes.Count);
            // mobs.Add(mobTypes[r]);
            // mobTypes.RemoveAt(r); //removing mob to prevent mob duplication;

            int r = SpawnerPRNG.Range(PRNGType.RoomRandomness, 0, listOf6.Count);//Random.Range(0, listOf6.Count);
            
             mobs.Add(Instantiate(mobTypes[0]));
             mobs[i].SetActive(false);
             //select "random" colour to simulate different mob types and remove this colour from selection.
             Renderer myRenderer = mobs[i].GetComponent<Renderer>();
             Material myNewMaterial = new Material(myRenderer.sharedMaterial);
             // myNewMaterial.SetTexture("_MainTex", myTexture);
             myRenderer.material = myNewMaterial;
             myRenderer.material.color = Color.HSVToRGB((float)listOf6[r]*1f/12f, 2*1f/6f,1f);
             Debug.Log(mobType + "diversity" + myRenderer.material.color);
             //Debug.Log(mobTypes[0].GetComponent<Renderer>().sharedMaterial.color);
             listOf6.RemoveAt(r);
        }
        return mobs;
    }

    private List<GameObject> SelectMobGroup(MobType mobType)
    {
        switch (mobType)
        {
            case MobType.Elite:
                return EliteMobs;
            case MobType.Threat:
                return ThreatMobs;
            case MobType.Fodder:
                return FodderMobs;
            default:
                Debug.LogError("MobDBSO.SelectMobGroup: Invalid mob type");
                return null;
        }
    }
}

[Serializable]
public enum MobType
{
    Fodder,
    Elite,
    Threat,
}
