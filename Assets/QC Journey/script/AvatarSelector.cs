using UnityEngine;
using UnityEngine.UI;

public class AvatarSelector : MonoBehaviour
{
    [Header("Group that contains all avatar buttons")]
    public Transform unlockableAvatarGroup;

    private Image playerAvatarImage;

    void Awake()
    {
        // Automatically find the top avatar image display
        GameObject avatarImageObj = GameObject.Find("Player current Avatar/Image");
        if (avatarImageObj != null)
        {
            playerAvatarImage = avatarImageObj.GetComponent<Image>();
        }
        else
        {
            Debug.LogError("Could not find 'Player current Avatar/Image'");
            return;
        }

        // Ensure the avatar group is assigned
        if (unlockableAvatarGroup == null)
        {
            Debug.LogError("Please assign the Unlockable Avatar Group in the inspector.");
            return;
        }

        // Loop through all children (each avatar entry)
        foreach (Transform avatar in unlockableAvatarGroup)
        {
            Button btn = avatar.GetComponentInChildren<Button>();
            Image avatarImage = avatar.Find("Image")?.GetComponent<Image>();

            if (btn != null && avatarImage != null)
            {
                Sprite spriteToUse = avatarImage.sprite;

                // Clear any existing events and assign this one
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => SetAvatar(spriteToUse));
            }
        }
    }

    public void SetAvatar(Sprite avatarSprite)
    {
        if (playerAvatarImage != null)
        {
            playerAvatarImage.sprite = avatarSprite;
        }
    }
}
