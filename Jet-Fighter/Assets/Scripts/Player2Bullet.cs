using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player2Bullet : MonoBehaviour
{

    [SerializeField] private float bulletSpeed;
    
    private string playerTag = "Player2"; 
    private string enemyTag = "Player1";
    
    private GameObject _player;
    private GameObject _enemy; //Player1

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(playerTag);
        _enemy = GameObject.FindGameObjectWithTag(enemyTag);   
    }

    void Update()
    {
        BoundryControl();
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, _enemy.transform.position) <= 0.475)
        {
            _player.GetComponent<Player2Setings>().AddScore();
            Destroy(gameObject);
        }

        transform.position += transform.right * bulletSpeed * Time.deltaTime;

        Destroy(gameObject, 8f);
    }
    
    private void BoundryControl()
    {
        //+Y Axis Control
        if (5.35 < transform.position.y)
            transform.position = new Vector3(transform.position.x, -5.25f, 0);
        
        //-Y Axis Control
        if (transform.position.y < -5.35)
            transform.position = new Vector3(transform.position.x, -transform.position.y, 0);
        
        //+X Axis Control
        if (9.25 < transform.position.x)
            transform.position = new Vector3(-9.15f, transform.position.y, 0);
        
        //-X Axis Control
        if (transform.position.x < -9.25)
            transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        
    }
}
