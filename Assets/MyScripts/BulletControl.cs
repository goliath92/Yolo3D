using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletControl : MonoBehaviour
{
    //public float bulletLifeTime = 10000f;
    //public float bulletLife;
    void FixedUpdate()
    {
        StartCoroutine(BulletLife());
        

    }

    IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerRange"))
        {
            Destroy(gameObject);
        }
        
    }
    */

    
}
