using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingSceneController : MonoBehaviour
{
    // เรียกตอนกดปุ่ม Back In Game
    public void BackToGame()
    {
        SceneManager.LoadScene("GameScene"); // ชื่อซีนที่ต้องการกลับไป
    }

    // เรียกตอนกดปุ่ม Menu
    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene"); // ชื่อซีนเมนูหลัก
    }
}
