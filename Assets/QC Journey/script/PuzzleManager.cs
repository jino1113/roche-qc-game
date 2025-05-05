using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    public TextMeshProUGUI progressText;
    public int totalIncorrectItems = 3;
    private int foundItems = 0;

    public TextMeshProUGUI alertText;
    public float alertDuration = 2f;

    public GameObject dailyCompletePanel;

    public GameObject losePanel;
    private int wrongAttempts = 3;
    public int maxWrongAttempts = 3;

    public TextMeshProUGUI wrongText;

    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    void Awake()
    {
        instance = this;
    }

    public void FoundIncorrectItem(PuzzleItem item)
    {
        foundItems++;
        UpdateProgress();

        if (foundItems >= totalIncorrectItems)
        { 
            // Debug.Log("You found them all!");
            dailyCompletePanel.SetActive(true);
        }
    }

    public void ClickedWrongItem()
    {
        wrongAttempts--;
        ShowAlert($"That's wrong. {wrongAttempts}/{maxWrongAttempts}");

        wrongText.text = $"Attempts : {wrongAttempts}/{maxWrongAttempts}";

        if (wrongAttempts <= 0)
        {
            losePanel.SetActive(true);
            Debug.Log("You lost!");
        }
    }

    void UpdateProgress()
    {
        progressText.text = $"FoundItems : {foundItems}/{totalIncorrectItems}";
    }

    public void ShowAlert(string message)
    {
        StopAllCoroutines();
        StartCoroutine(ShowAlertRoutine(message));
    }

    IEnumerator ShowAlertRoutine(string message)
    {
        alertText.text = message;
        alertText.alpha = 1;
        yield return new WaitForSeconds(alertDuration);
        alertText.text = "";
        alertText.alpha = 0;
    }
}
