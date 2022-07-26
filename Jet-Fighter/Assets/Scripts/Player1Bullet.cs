using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player1Bullet : MonoBehaviour
{

    [SerializeField] private float bulletSpeed;
    
    private string playerTag = "Player1"; 
    private string enemyTag = "Player2"; 
    
    private GameObject _player;
    private GameObject _enemy; //Player2
    
    void Start()
    {
        
        _enemy = GameObject.FindGameObjectWithTag(enemyTag);
        _player = GameObject.FindGameObjectWithTag(playerTag);
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
            _player.GetComponent<Player1Setings>().AddScore();
            Destroy(gameObject);
        }

        transform.position += transform.right * bulletSpeed * Time.deltaTime;

        Destroy(gameObject, 10f);
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
