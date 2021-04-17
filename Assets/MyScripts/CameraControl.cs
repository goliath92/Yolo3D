using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform character;                                               // takip edilecek karakter
    public float mouseSensitivity=100f;
    public float rotationAmount = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;              // mouse x yönüne hareket
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;              // mouse y yönüne hareket

        rotationAmount -= mouseY;                                                             // bu değer normalde "-" olduğu için "+" ya çeviriyoruz
        rotationAmount = Mathf.Clamp(rotationAmount, -90f, 90f);               // kamera ile görülebilecek alan kısıtlanıyor bu şekilde (clamp)

        transform.localRotation = Quaternion.Euler(rotationAmount, 0f, 0f);           // fiziksel dönüş gerçekleşiyor
        character.Rotate(Vector3.up*mouseX);
    }
}
