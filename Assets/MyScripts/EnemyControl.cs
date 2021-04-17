using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    private NavMeshAgent enemyNav;
    public GameObject target;

    public float chaseDistance=4f;                       // ne kadar uzakta fark etsin

    public int enemyHealth = 20;
    
    void Start()
    {
        enemyNav = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);         // düşman ve player arasındaki mesafe

        if (distance < chaseDistance)
        {
            Vector3 dirToPlayer = transform.position - target.transform.position;                        // player a yönelme
            Vector3 newPos = transform.position - dirToPlayer;
            enemyNav.SetDestination(newPos);
        }
    }
}
