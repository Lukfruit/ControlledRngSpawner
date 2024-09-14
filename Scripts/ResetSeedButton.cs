using TMPro;
using UnityEngine;

public class ResetSeedButton : MonoBehaviour
{
    public TMP_InputField inputField;

    public void OnClick()
    {
        int.TryParse(inputField.text, out int seed);
        SpawnerPRNG.ResetWithSeed(seed);
    }
}
