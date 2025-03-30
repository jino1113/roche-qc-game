using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class RewardSlot
{
    public string rewardName;                 // ชื่อรางวัล
    public int cost;                          // แต้มที่ใช้
    public Button button;                     // ปุ่มแลก
    public TextMeshProUGUI label;             // ข้อความกำกับ
}

public class QCPointSystem : MonoBehaviour
{
    public int qcPoint = 0;
    public TextMeshProUGUI pointText;
    public GameObject rewardPanel;

    //public TextMeshProUGUI rewardPanelText;

    public TextMeshProUGUI floatingRewardText; // ข้อความรางวัลที่โชว์
    public float fadeDuration = 2f; // ระยะเวลาค่อย ๆ หาย

    public List<RewardSlot> rewards = new List<RewardSlot>();

    void Start()
    {
        UpdatePointUI();
        UpdateRewardButtons();
        UpdateRewardLabels();
    }

    public void AddTestPoint(int amount)
    {
        qcPoint += amount;
        UpdatePointUI();
        UpdateRewardButtons();
    }

    void UpdatePointUI()
    {
        pointText.text = "QC Point: " + qcPoint.ToString();
    }

    void UpdateRewardButtons()
    {
        foreach (var r in rewards)
            r.button.interactable = qcPoint >= r.cost;
    }

    void UpdateRewardLabels()
    {
        foreach (var r in rewards)
            if (r.label != null)
                r.label.text = $"Cost {r.cost}: {r.rewardName}";
    }

    public void RedeemReward(int index)
    {
        if (index < 0 || index >= rewards.Count) return;

        var r = rewards[index];
        if (qcPoint >= r.cost)
        {
            qcPoint -= r.cost;
            UpdatePointUI();
            UpdateRewardButtons();
            ShowReward($"You got: {r.rewardName}!");
        }
    }

    void ShowReward(string msg)
    {
        if (floatingRewardText != null)
        {
            floatingRewardText.text = msg;
            floatingRewardText.alpha = 1f;
            StartCoroutine(FadeOutReward());
        }
    }


    public void CloseRewardPanel()
    {
        rewardPanel.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeOutReward()
    {
        float t = 0;
        Color originalColor = floatingRewardText.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            floatingRewardText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        floatingRewardText.text = ""; // ล้างข้อความเมื่อจางหายหมด
    }
}
