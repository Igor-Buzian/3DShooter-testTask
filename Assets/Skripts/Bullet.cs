using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletLife = 3;
    public float BulletDamage = 3;

    private void Awake()
    {
        Destroy(gameObject, BulletLife);
    }

    /* private void OnCollisionEnter(Collision collision)
     {
         Destroy(collision.gameObject);
         Destroy(gameObject);
     }*/
}
