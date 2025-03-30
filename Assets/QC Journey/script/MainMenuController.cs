using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // กดปุ่ม Enter เพื่อเข้าสู่เกม
    public void EnterGame()
    {
        SceneManager.LoadScene("GameScene"); // เปลี่ยนตามชื่อ Scene ของเจ้า
    }

    // กดปุ่ม Setting เพื่อไปหน้าตั้งค่า
    public void GoToSetting()
    {
        SceneManager.LoadScene("SettingScene"); // หรือ SettingInGameScene แล้วแต่ที่ใช้
    }
}
