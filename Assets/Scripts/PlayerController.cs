using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform tankBody;

    [SerializeField] private Transform tankTop;

    [SerializeField] private Transform projectileSpawn;

    [SerializeField] private GameObject projectile;
    
    public float movementSpeed;

    public float rotationSpeed;

    private void Update()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");
        
        tankBody.Rotate(Time.deltaTime*horizontalInput*rotationSpeed*tankBody.up);
        transform.position += verticalInput * movementSpeed * Time.deltaTime * tankBody.forward;
    }
}
