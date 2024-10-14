using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("GamePrefs")]
    public static bool isPaused = true;

    [Header("GameControllers")]
    public static GameManager Instance;
    public List<Character> characterList;

    public delegate void OnPlayerWin();
    public event OnPlayerWin onPlayerWin;

    private void Awake()
    {
        Time.timeScale = 1f;

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RemovePlayers(Character character)
    {
        characterList.Remove(character);
        if (characterList.Count == 1 )
        {
            onPlayerWin?.Invoke();
        }
    }

    public void SelectScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
