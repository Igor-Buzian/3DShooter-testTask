
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
    public GameObject enemyPrefab; // Префаб противника
    public float spawnInterval = 2f; // Интервал между спаунами
    public int maxEnemies = 10; // Максимальное количество противников на сцене

    private int currentEnemies = 0;

    private void Start()
    {
        // Запускаем спавн противников
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Проверяем, не достигнуто ли максимальное количество противников на сцене
            if (currentEnemies < maxEnemies)
            {
                // Создаем новый экземпляр префаба противника в месте спавна
                GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                // Увеличиваем счетчик противников на сцене
                currentEnemies++;
            }

            // Ждем указанный интервал перед следующим спауном
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Метод, вызываемый противниками для уменьшения счетчика противников на сцене
    public void EnemyDied()
    {
        currentEnemies--;
    }
}*/




/*using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Префаб противника
    public float spawnInterval = 1f;
    public int maxEnemies;
    public float minX = -10f; // Минимальное значение по оси X
    public float maxX = 10f; // Максимальное значение по оси X
    public float minZ = -10f; // Минимальное значение по оси Z
    public float maxZ = 10f; // Максимальное значение по оси Z

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