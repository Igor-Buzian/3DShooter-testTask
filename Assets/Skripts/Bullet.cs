using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletLife = 3;
    public float BulletDamage = 3;
    public Transform spawnBullet;
    WaitForSeconds Delay;
    Rigidbody rb;

    [Header("BulletProjectile")]
    [SerializeField] private GameObject HitGreen;
    [SerializeField] private GameObject HitRed;
    GameObject HitGreenPrticle;
    GameObject HitRedPrticle;
    private void Start()
    {
        Delay = new WaitForSeconds(BulletLife);
        rb = GetComponent<Rigidbody>();
        spawnBullet = FindObjectOfType<BulletTarget>().gameObject.transform;
        HitGreenPrticle = Instantiate(HitGreen, transform.position, Quaternion.identity);
        HitRedPrticle = Instantiate(HitRed, transform.position, Quaternion.identity);
        HitGreenPrticle.SetActive(false);
        HitRedPrticle.SetActive(false);
    }
    private void OnEnable()
    {
        gameObject.transform.position = spawnBullet.position;
        StartCoroutine(BulletLive());
    }
    IEnumerator BulletLive()
    {
        yield return Delay;     
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            HitRedPrticle.transform.position = spawnBullet.position;
            HitRedPrticle.SetActive(true);
        }
        else
        {
            HitRedPrticle.transform.position = spawnBullet.position;
            HitGreenPrticle.SetActive(true);
        }
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        gameObject.transform.position = spawnBullet.position;
    }
    /* private void Awake()
     {
         Destroy(gameObject, BulletLife);
     }*/

    /* private void OnCollisionEnter(Collision collision)
     {
         Destroy(collision.gameObject);
         Destroy(gameObject);
     }*/
}