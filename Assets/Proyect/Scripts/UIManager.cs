using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Material")]
    [SerializeField] private GameObject countdownPanel, gameoverPanel;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private TextMeshProUGUI winnerText;

    private int count = 3;

    [SerializeField] private GameManager gameOver;

    private void OnEnable()
    {
        gameOver.onPlayerWin += ShowWinnerPanel;
    }

    private void OnDisable()
    {
        gameOver.onPlayerWin -= ShowWinnerPanel;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    public void ShowWinnerPanel() 
    {
        GameManager.isPaused = true;
        gameoverPanel.SetActive(true);
        winnerText.text = GameManager.Instance.characterList[0].gameObject.name + " Wins";
        Time.timeScale = 0f;
    }

    private IEnumerator Timer()
    {
        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }
        countdownText.text = "Go!";
        yield return new WaitForSeconds(1);
        countdownPanel.SetActive(false);
        GameManager.isPaused = false;
    }
}
