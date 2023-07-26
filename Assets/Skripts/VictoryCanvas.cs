using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryCanvas : MonoBehaviour
{
    [SerializeField]private Text winText;
    [SerializeField] private Text loseText;
    [SerializeField] private Button Restart;
    [SerializeField] private Button Quit;
    [SerializeField] private GameObject victoryPanel;
    private int victoryCount;
    private void Update()
    {
        if (PlayerPrefs.GetInt("killCount") == 5)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PlayerPrefs.SetInt("killCount", 0);
            victoryCount++;
            victoryCount += PlayerPrefs.GetInt("victoryCount");
            PlayerPrefs.SetInt("victoryCount", victoryCount);
            winText.text = $"Win counter: {PlayerPrefs.GetInt("victoryCount")}";
            loseText.text = $"Lose counter: {PlayerPrefs.GetInt("MydeadCount")}";
            victoryPanel.gameObject.SetActive(true);

        }
        UnityEngine.Debug.Log("victoryCount: " + PlayerPrefs.GetInt("victoryCount"));
        UnityEngine.Debug.Log("MydeadCount: " + PlayerPrefs.GetInt("MydeadCount"));
    }
    public void Res()
    {
        Time.timeScale = 1.0f;
        victoryPanel.SetActive(false);
        SceneManager.LoadScene("lvl1");
    }
    public void Menu()
    {
        Time.timeScale = 1.0f;
        victoryPanel.SetActive(false);
        SceneManager.LoadScene("lvl1");
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Application.Quit();
    }
}
