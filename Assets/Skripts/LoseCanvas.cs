using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseCanvas : MonoBehaviour
{
    [SerializeField] private Button Restart;
    [SerializeField] private Button Quit;
    [SerializeField] private GameObject losePanel;
    private void Start()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Res()
    {
        Time.timeScale = 1.0f;
        losePanel.SetActive(false);
        SceneManager.LoadScene("lvl1");
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Application.Quit();
    }
}
