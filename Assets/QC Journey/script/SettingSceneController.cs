using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingSceneController : MonoBehaviour
{
    // ���¡�͹������ Back In Game
    public void BackToGame()
    {
        SceneManager.LoadScene("GameScene"); // ���ͫչ����ͧ��á�Ѻ�
    }

    // ���¡�͹������ Menu
    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene"); // ���ͫչ������ѡ
    }
}
