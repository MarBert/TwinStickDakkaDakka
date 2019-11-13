using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable PossibleLossOfFraction

public class PlayerController : MonoBehaviour
{
    //corpo del tank
    [SerializeField] private Transform tankBody;

    //"testa" del tank
    [SerializeField] private Transform tankTop;

    //punto di spawn dei proiettili
    [SerializeField] private Transform projectileSpawn;

    //prefab dei proiettili
    [SerializeField] private GameObject projectile;

    //velocità di movimento
    public float movementSpeed;

    //velocità di rotazione
    public float bodyRotationSpeed;

    public float topRotationSpeed;
    private Camera _camera;


    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        //Mi prendo gli assi 
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");
        var fireInput = Input.GetButtonDown("Fire1");

        //Ruoto e sposto il corpo del tank
        tankBody.Rotate(Time.deltaTime * horizontalInput * bodyRotationSpeed * tankBody.up);
        transform.position += verticalInput * movementSpeed * Time.deltaTime * tankBody.forward;

        //Sparo
        if (fireInput)
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(sceneBuildIndex: 0);
        
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void FixedUpdate()
    {
        var playerPlane = new Plane(Vector3.up, tankTop.position);

        if (_camera.Equals(null)) return;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!playerPlane.Raycast(ray, out var hitDistance)) return;

        var targetPoint = ray.GetPoint(hitDistance);

        var targetRotation = Quaternion.LookRotation(targetPoint - tankTop.position);

        tankTop.rotation = Quaternion.Slerp(transform.rotation, targetRotation, topRotationSpeed * Time.deltaTime);
    }
}