using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private int killCount;
    private int MydeadCount;
    private int victoryCount;
    private int health = 4;
    public float moveSpeed = 3f; // �������� �������� �����

    private UnityEngine.Object exploison;
    [SerializeField] private Canvas youLosedPanel; // ���� ��� �������������
    //[SerializeField] private GameObject victoryPanel; // ���� ��� �������������
    [SerializeField]private Transform target; // ���� ��� �������������
    


    private void Start()
    {
        exploison = Resources.Load("Exploison");
    }
    private void Update()
    {
        Vector3 direction = (target.position - transform.position);
        direction.y = transform.position.y; // �������� ���������� y ������� �����������
        direction.Normalize(); // ����������� ������, ����� ��������� ���������� ��������

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3);
        // ������� ����� � ����������� ����
        transform.Translate(-direction * moveSpeed * Time.deltaTime);

        

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
            youLosedPanel.gameObject.SetActive(true);

        }
    }

    void KillEnemy()
    {
        GameObject exploisonRef = (GameObject)Instantiate(exploison);
        exploisonRef.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Destroy(gameObject);
        //UnityEngine.Debug.Log("deadCount: " + PlayerPrefs.GetInt("deadCount"));
        //FindObjectOfType<EnemySpawner>()?.EnemyDied();
    }
}
