using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // ������ Enter ������������
    public void EnterGame()
    {
        SceneManager.LoadScene("GameScene"); // ����¹������� Scene �ͧ���
    }

    // ������ Setting �����˹�ҵ�駤��
    public void GoToSetting()
    {
        SceneManager.LoadScene("SettingScene"); // ���� SettingInGameScene ����������
    }
}
