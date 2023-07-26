using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayCanvas : MonoBehaviour
{
    [SerializeField] private Button Restart;
    [SerializeField] private Button Quit;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject Player;
    private void Start()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Play()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Destroy(losePanel);
        Player.SetActive(true);

    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Application.Quit();
    }
}
