using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{

    [SerializeField] private Transform HitGreen;
    [SerializeField] private Transform HitRed;

    private Rigidbody bulletRigidbody;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletTarget>() != null)
        {
            // Hit target
            Instantiate(HitRed, transform.position, Quaternion.identity);
        }
        else
        {
            // Hit something else
            Instantiate(HitGreen, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

}