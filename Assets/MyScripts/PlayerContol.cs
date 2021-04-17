using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerContol : MonoBehaviour
{

    public Text playerHealthText;
    public int playerHealth = 100;

    public float speed = 10f;
    public float gravity = -10f;
    public float jumpHeight = 5f;
    public float offset = 2f; // merkezden yere kaç birim uzunluk

    public CharacterController charController;

    public Transform groundCheck;
    public LayerMask groundLayer; // ground mı değil mi kontrolü için

    private Vector3 velocity;
    private bool isGrounded = false; // yere değiyor mu değmiyor mu

    public float damageRate = 3f; // enemy attack cooldown
    private float nextDamage;

    public GameObject bullet;
    public Transform bulletPosition;
    public Transform bulletPoint;




    void Update()
    {
        playerHealthText.text = "Health: " + playerHealth; // UI üzerinde canı gösterme

        isGrounded = Physics.CheckSphere(groundCheck.position, offset, groundLayer);

        if (isGrounded && velocity.y < 0) // eğer cisim yere değiyorsa ve yukarı yöne hareket yoksa
        {
            velocity.y = -1f; // gravity
        }

        float x = Input.GetAxis("Horizontal"); // w a s d tuş algılama
        float z = Input.GetAxis("Vertical");

        Vector3
            movementDirection =
                transform.right * x +
                transform.forward *
                z; // alınan x değerine göre yana, z değerine göre ileri geri - Vektör içerisine eklenir
        charController.Move(movementDirection * speed * Time.deltaTime); // algılanan yönlere gere hareket 


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //zıplama
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -gravity);
        }

        velocity.y += gravity * Time.deltaTime; // gravity zıplamasak bile etki etsin
        charController.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bulletObj = Instantiate(bullet, bulletPosition.position, bulletPosition.transform.rotation);
            bulletObj.GetComponent<Rigidbody>()
                .AddForce((bulletPoint.position - bulletPosition.position).normalized * 900);
        }


        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("EnemyRange"))                                                   // range içerisine girilince 3f cooldown sonrası saldırı alıyoruz
            {
                if (Time.time > nextDamage)
                {
                    nextDamage = Time.time + damageRate;
                    playerHealth -= 20;
                }
            }
        }




    }
}
