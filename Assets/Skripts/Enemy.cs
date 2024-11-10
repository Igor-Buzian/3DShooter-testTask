using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private int killCount;
    private int MydeadCount;
    private int victoryCount;
    private int health = 4;
    int enemyCount;

    VictoryCanvas VictoryCanvas;
    private UnityEngine.Object exploison;
    [SerializeField] private CanvasGroup youLosedPanel; // Цель для преследования
    //[SerializeField] private GameObject victoryPanel; // Цель для преследования

    


    private void Start()
    {
        VictoryCanvas = FindObjectOfType<VictoryCanvas>();
        exploison = Resources.Load("Exploison");
        GameObject loseCanvasObject = GameObject.Find("LosedCanvas");
        if (loseCanvasObject != null)
        {
            youLosedPanel = loseCanvasObject.GetComponent<CanvasGroup>();
        }
        else
        {
            Debug.LogWarning("LoseCanvas не найден!");
        }
    }
    /*    private void Update()
        {
            Vector3 direction = (target.position - transform.position);
            direction.y = transform.position.y; // Обнуляем компоненту y вектора направления
            direction.Normalize(); // Нормализуем вектор, чтобы сохранить постоянную скорость

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3);
            // Двигаем врага в направлении цели
            transform.Translate(-direction * moveSpeed * Time.deltaTime);



        }*/

    private void OnDisable()
    {
        enemyCount = PlayerPrefs.GetInt("enemyCount", 0);
        enemyCount--;
        PlayerPrefs.SetInt("enemyCount", enemyCount);
        if (enemyCount == 0)
        {
            VictoryCanvas.VictoryPanel();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            health--;
            
            if (health <= 0)
            {
                killCount++;
                killCount += PlayerPrefs.GetInt("killCount");
                PlayerPrefs.SetInt("killCount", killCount);
               
                KillEnemy();
            }
        }

        if (other.CompareTag("Player"))
        {
            MydeadCount++;
            MydeadCount += PlayerPrefs.GetInt("MydeadCount");
            PlayerPrefs.SetInt("MydeadCount", MydeadCount);
            youLosedPanel.alpha =1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
    }

    void KillEnemy()
    {
        GameObject exploisonRef = (GameObject)Instantiate(exploison);
        exploisonRef.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        gameObject.SetActive(false);
    }
}
