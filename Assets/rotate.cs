using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    public float speed = 10;

    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddTorque(Time.deltaTime*speed*transform.up);
        //transform.Rotate(transform.forward,speed * Time.deltaTime);
        
    }
}
