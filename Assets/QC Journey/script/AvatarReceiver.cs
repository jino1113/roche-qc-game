using UnityEngine;
using UnityEngine.UI;
using System;

public class AvatarReceiver : MonoBehaviour
{
    public RawImage avatarImage; // UI image to show avatar
    public WebViewObject webViewObject;

    void Start()
    {
        Debug.Log("AvatarReceiver: Start called");

        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        Debug.Log("AvatarReceiver: WebViewObject created");

        webViewObject.Init((string msg) =>
        {
            Debug.Log("AvatarReceiver: Message received from WebView -> " + msg);

            if (msg.StartsWith("avatar:"))
            {
                string base64 = msg.Substring("avatar:".Length);
                Debug.Log("AvatarReceiver: Base64 string length = " + base64.Length);

                try
                {
                    byte[] bytes = Convert.FromBase64String(base64);
                    Texture2D tex = new Texture2D(2, 2);
                    tex.LoadImage(bytes);
                    avatarImage.texture = tex;

                    Debug.Log("AvatarReceiver: Avatar image applied successfully.");
                }
                catch (Exception ex)
                {
                    Debug.LogError("AvatarReceiver: Failed to convert base64 image -> " + ex.Message);
                }
            }
        });

        webViewObject.SetMargins(0, 100, 0, 0);
        webViewObject.SetVisibility(true);

        string url = Application.streamingAssetsPath + "/avatar.html";


        Debug.Log("AvatarReceiver: Loading HTML at URL -> " + url);
        webViewObject.LoadURL(url);
    }
}
