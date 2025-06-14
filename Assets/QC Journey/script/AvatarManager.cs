using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AvatarManager : MonoBehaviour
{
    public RawImage avatarDisplay;

    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "avatar.png");
        if (File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(bytes);
            avatarDisplay.texture = tex;
        }
    }

    public void ReceiveFromWeb(string base64)
    {
        string clean = base64.Replace("data:image/png;base64,", "");
        byte[] bytes = Convert.FromBase64String(clean);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(bytes);
        avatarDisplay.texture = tex;

        string path = Path.Combine(Application.persistentDataPath, "avatar.png");
        File.WriteAllBytes(path, bytes);
    }

#if UNITY_WEBGL && !UNITY_EDITOR
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void SendAvatarOptions(string topType, string hairColor, string skinColor);
#endif

    public void SendOptions(string topType, string hairColor, string skinColor)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        SendAvatarOptions(topType, hairColor, skinColor);
#endif
    }
}
