using UnityEngine;
using UnityEngine.UI;

public class RoomSettingsButton : MonoBehaviour
{
    [SerializeField] private Slider
        FodderDiversitySlider,
        EliteDiversitySlider,
        ThreatDiversitySlider;
   
    [SerializeField] Spawner spawner;
    public void OnButtonClick()
    {
        RoomSettings roomSettings = new RoomSettings();
        roomSettings.FodderSettings = new MobSettings();
        roomSettings.FodderSettings.diversity = (int)FodderDiversitySlider.value;
        roomSettings.EliteSettings = new MobSettings();
        roomSettings.EliteSettings.diversity = (int)EliteDiversitySlider.value;
        roomSettings.ThreatSetings = new MobSettings();
        roomSettings.ThreatSetings.diversity = (int)ThreatDiversitySlider.value;
        spawner.ChangeRoomSelection(roomSettings);
    }
}
