using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton so other scripts can reach it easily
    public static GameManager Instance;

    [Header("Souls")]
    public int totalSouls = 5;
    private int soulsCollected = 0;

    [Header("UI (assign in Inspector)")]
    public Text soulsText;   // Legacy UI Text — swap for TMP_Text if using TextMeshPro

    [Header("Win / Lose panels (optional)")]
    public GameObject winPanel;
    public GameObject losePanel;

    private bool gameOver = false;

    void Awake()
    {
        // Simple singleton setup
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
        if (winPanel)  winPanel.SetActive(false);
        if (losePanel) losePanel.SetActive(false);
    }

    public void CollectSoul()
    {
        if (gameOver) return;

        soulsCollected++;
        Debug.Log($"Soul collected: {soulsCollected} / {totalSouls}");
        UpdateUI();

        if (soulsCollected >= totalSouls)
            Win();
    }

    public void Win()
    {
        if (gameOver) return;
        gameOver = true;

        Debug.Log("YOU WIN!");
        if (winPanel) winPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void Lose()
    {
        if (gameOver) return;
        gameOver = true;

        Debug.Log("YOU LOSE — detected too long!");
        if (losePanel) losePanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    private void UpdateUI()
    {
        if (soulsText != null)
            soulsText.text = $"Souls: {soulsCollected} / {totalSouls}";
    }
}
