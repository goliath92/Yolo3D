using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletControl : MonoBehaviour
{
    void FixedUpdate()
    {
        StartCoroutine(BulletLife());
        

    }

    IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(1);                  // Mermi belirlenen süre kadar hayatta kalır ve sonra yok olur 
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))           // mermi düşmana değince yok oluyor
        {
            Destroy(gameObject);
        }
    }
}
