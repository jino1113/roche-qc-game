using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AvatarLoader : MonoBehaviour
{
    public RawImage avatarDisplay;
    [TextArea(3, 10)]
    public string imageUrl; // ใส่ base64 ได้ด้วย

    void Start()
    {
        // เช็กว่าเป็น base64 หรือไม่
        if (imageUrl.StartsWith("data:image/png;base64,"))
        {
            LoadFromBase64(imageUrl);
        }
        else
        {
            StartCoroutine(LoadAvatarImage(imageUrl));
        }
    }

    IEnumerator LoadAvatarImage(string url)
    {
        using (UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequestTexture.GetTexture(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityEngine.Networking.UnityWebRequest.Result.Success)
            {
                Texture2D avatarTexture = UnityEngine.Networking.DownloadHandlerTexture.GetContent(request);
                avatarDisplay.texture = avatarTexture;
            }
            else
            {
                Debug.LogError("Error loading avatar image: " + request.error);
            }
        }
    }

    void LoadFromBase64(string base64)
    {
        try
        {
            string cleanBase64 = base64.Replace("data:image/png;base64,", "");
            byte[] bytes = Convert.FromBase64String(cleanBase64);

            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(bytes);
            avatarDisplay.texture = tex;
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to load avatar from base64: " + e.Message);
        }
    }
}
