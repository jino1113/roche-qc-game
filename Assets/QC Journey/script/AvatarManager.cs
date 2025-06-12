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
        Debug.Log("Avatar path: " + path);

        if (File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(bytes);
            avatarDisplay.texture = tex;
            Debug.Log("Loaded avatar: " + path);
        }
        else
        {
            Debug.LogWarning("avatar.png not found at: " + path);
        }
    }


    public void ReceiveFromWeb(string base64)
    {
        Debug.Log("Received base64 avatar from web");

        try
        {
            string clean = base64.Replace("data:image/png;base64,", "");
            byte[] bytes = Convert.FromBase64String(clean);

            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(bytes);
            avatarDisplay.texture = tex;

            string path = Path.Combine(Application.persistentDataPath, "avatar.png");
            File.WriteAllBytes(path, bytes);
            Debug.Log("Avatar saved at: " + path);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to save avatar: " + e.Message);
        }
    }
}
