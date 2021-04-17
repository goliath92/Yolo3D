using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    
    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool  isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    private NavMeshAgent enemyNav;
    public GameObject target;

    public float chaseDistance=4f;                       // ne kadar uzakta fark etsin

    public int enemyHealth = 20;
    
    void Start()
    {
        enemyNav = GetComponent<NavMeshAgent>(); // bu benim yorum satırım EFE benim
    }

    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);         // düşman ve player arasındaki mesafe

        if (distance < chaseDistance)
        {
            Vector3 dirToPlayer = transform.position - target.transform.position;                        // player a yönelme
            Vector3 newPos = transform.position - dirToPlayer;
            enemyNav.SetDestination(newPos);
            isWandering = false; //TODO: efe buraya dikkat
        }
        
        if(isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if(isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed); 
        }
        if(isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if(isWalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
    
    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3); // rotasyonun süreceği süre
        int rotateWait = Random.Range(1, 2); //rotasyon değişceği süre
        int rotateLorR = Random.Range(1, 2); //sağ mı sol mu 
        int walkWait = Random.Range(1, 4); //tekrardan yürümesi için beklediği süre
        int walkTime = Random.Range(1, 5); //ne kadar süre yürüyeceği

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;
    }
}
