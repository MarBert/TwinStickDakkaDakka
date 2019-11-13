using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    private GameObject _bodyCollider;
    
    public int health;
    
    private void Start()
    {
        _bodyCollider = GetComponentInChildren<Collider>().gameObject;
        EventManager.Instance.onTargetHit.AddListener(TargetHit);
    }

    private void TargetHit(int damage, GameObject g)
    {
        if(!g.Equals(_bodyCollider)) return;
        health -= damage;
        if(health<=0)
            Destroy(gameObject);
    }
}
