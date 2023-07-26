
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        enemies[1].gameObject?.SetActive(true);
        yield return new WaitForSeconds(2f);
        enemies[2].gameObject?.SetActive(true);
        yield return new WaitForSeconds(2f);
        enemies[3].gameObject?.SetActive(true);
        yield return new WaitForSeconds(2f);
        enemies[4].gameObject?.SetActive(true);
        yield return new WaitForSeconds(2f);
    }
}





/*using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ ����������
    public float spawnInterval = 2f; // �������� ����� ��������
    public int maxEnemies = 10; // ������������ ���������� ����������� �� �����

    private int currentEnemies = 0;

    private void Start()
    {
        // ��������� ����� �����������
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // ���������, �� ���������� �� ������������ ���������� ����������� �� �����
            if (currentEnemies < maxEnemies)
            {
                // ������� ����� ��������� ������� ���������� � ����� ������
                GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                // ����������� ������� ����������� �� �����
                currentEnemies++;
            }

            // ���� ��������� �������� ����� ��������� �������
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // �����, ���������� ������������ ��� ���������� �������� ����������� �� �����
    public void EnemyDied()
    {
        currentEnemies--;
    }
}*/




/*using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // ������ ����������
    public float spawnInterval = 1f;
    public int maxEnemies;
    public float minX = -10f; // ����������� �������� �� ��� X
    public float maxX = 10f; // ������������ �������� �� ��� X
    public float minZ = -10f; // ����������� �������� �� ��� Z
    public float maxZ = 10f; // ������������ �������� �� ��� Z

    private int currentEnemies = 0;
    private int diedEnemies = 0;

    private void Start()
    {
        //StartCoroutine(SpawnEnemies());
    }
    private void Update()
    {
        diedEnemies = PlayerPrefs.GetInt("deadCount");
        UnityEngine.Debug.Log("deadCount: "+ diedEnemies);
        UnityEngine.Debug.Log("currentEnemies: " + currentEnemies);
        switch (diedEnemies)
        {
            case 1:
                maxEnemies = 2;
                StartCoroutine(SpawnEnemies());
                break;
            case 2:
                maxEnemies = 3;
                StartCoroutine(SpawnEnemies()); 
                break;
            case 3:
                maxEnemies = 4;
                StartCoroutine(SpawnEnemies()); 
                break;
            default:
                maxEnemies = 1;
                StartCoroutine(SpawnEnemies());
                break;
        }
    }
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (currentEnemies < maxEnemies)
            {
                float randomX = Random.Range(minX, maxX);
                float randomZ = Random.Range(minZ, maxZ);
                Vector3 spawnPosition = new Vector3(randomX, 0f, randomZ);
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                currentEnemies++;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void EnemyDied()
    {
        currentEnemies--;
    }
}
*/