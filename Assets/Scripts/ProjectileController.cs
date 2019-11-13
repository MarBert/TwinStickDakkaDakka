using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public string tagToHit;
    
    public int damage;

    public float speed;

    public float timeToLive;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        StartCoroutine(DelayDestroy());
    }

    private void Update()
    {
        _transform.position += Time.deltaTime * speed * _transform.forward;
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HO COLPITO "+other.name);
        if(!other.CompareTag(tagToHit)) return;
        EventManager.Instance.onTargetHit.Invoke(damage,other.gameObject);
        Destroy(gameObject);
    }
}
