using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AvatarCustomizer : MonoBehaviour
{
    public AvatarManager avatarManager;
    public TMP_Dropdown topTypeDropdown;
    public TMP_Dropdown hairColorDropdown;
    public TMP_Dropdown skinColorDropdown;

    public void OnClickGenerate()
    {
        string top = topTypeDropdown.options[topTypeDropdown.value].text;
        string hair = hairColorDropdown.options[hairColorDropdown.value].text;
        string skin = skinColorDropdown.options[skinColorDropdown.value].text;

        avatarManager.SendOptions(top, hair, skin);
    }
}
