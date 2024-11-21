using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Camera mainCamera;
    public Transform spawnBullet;

    public float shootForce;
    public float spread;
    public int poolSize = 10;
    private Queue<GameObject> bulletPool; // Очередь для хранения пуль
    void Start()
    {
        // Инициализация пула
        bulletPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, spawnBullet.position, Quaternion.identity);
            bullet.SetActive(false); // Деактивируем пулю
            bulletPool.Enqueue(bullet);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    GameObject GetBulletFromPool()
    {
        // Берем пулю из пула
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true); // Активируем пулю
            return bullet;
        }
        else
        {
            // Если пула недостаточно, создаем новую пулю
            GameObject bullet = Instantiate(bulletPrefab, spawnBullet.position, Quaternion.identity);
            return bullet;
        }
    }

    void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
        {
            targetPoint = ray.GetPoint(5);
        }
        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread; //- new Vector3(x, y, 0);

        GameObject currentBullet = GetBulletFromPool();


        currentBullet.transform.forward = dirWithSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
    }
  /*  IEnumerator ReturnBulletToPool(GameObject bullet, Vector3 dirWithSpread,  float delay)
    {
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
       // bullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        bullet.transform.position = spawnBullet.position;
        // Деактивируем пулю и возвращаем её в пул
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }*/
}