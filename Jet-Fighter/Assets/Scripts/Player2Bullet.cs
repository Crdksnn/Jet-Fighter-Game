using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player2Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private string enemyTag = "Player1"; 
    private GameObject enemy; //Player1
    void Start()
    {
        if (GameObject.FindGameObjectWithTag(enemyTag))
        {
            enemy = GameObject.FindGameObjectWithTag(enemyTag);
        }    
    }

    void Update()
    {
        
        if (Vector3.Distance(transform.position, enemy.transform.position) <= 0.475)
        {
            Destroy(enemy);
            Destroy(gameObject);
        }
        
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
        
        Destroy(gameObject, 8f);
    }
}
