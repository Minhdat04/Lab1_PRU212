using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text winText;
    public TMP_Text dustCounterText;

    private int totalDust;
    private int cleanedDust;

    void Start()
    {
        totalDust = GameObject.FindGameObjectsWithTag("Dust").Length;
        cleanedDust = 0;
        dustCounterText.text = $"Dust Collected: {cleanedDust}/{totalDust}";
        winText.gameObject.SetActive(false);
    }

    public void DustCollected()
    {
        cleanedDust++;
        dustCounterText.text = $"Dust Collected: {cleanedDust}/{totalDust}";

        if (cleanedDust >= totalDust)
        {
            winText.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}