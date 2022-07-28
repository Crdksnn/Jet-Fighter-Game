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
    private Transform enemy; //Player1

    private List<Vector2> enemyBoundries = new List<Vector2>();

    private Vector2 leftUpPoint;
    private Vector2 leftDownPoint;
    private Vector2 rightUpPoint;
    private Vector2 rightDownPoint;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(playerTag);
        enemy = GameObject.FindGameObjectWithTag(enemyTag).transform;   
    }

    void Update()
    {   
        EnemyBoundryClear();
        EnemyBoundryUpdate();
        
        MapBoundryControl();
        Move();
    }

    private void Move()
    {
        
        var pos = transform.position;
        var movement = bulletSpeed * transform.right * Time.deltaTime;
        var newPos = pos + movement;

        transform.position = newPos;

        Destroy(gameObject, 8f);
    }
    
    private void MapBoundryControl()
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
    
    private void EnemyBoundryUpdate()
    {
        
        leftUpPoint = new Vector2(enemy.position.x - enemy.localScale.x / 2, enemy.position.y + enemy.localScale.y / 2);
        leftDownPoint = new Vector2(enemy.position.x - enemy.localScale.x / 2, enemy.position.y - enemy.localScale.y / 2);
        
        rightUpPoint = new Vector2(enemy.position.x + enemy.localScale.x / 2, enemy.position.y + enemy.localScale.y / 2);
        rightDownPoint = new Vector2(enemy.position.x + enemy.localScale.x / 2, enemy.position.y - enemy.localScale.y / 2);
        
        Debug.DrawLine(leftUpPoint,leftDownPoint,Color.red);
        Debug.DrawLine(leftUpPoint, rightUpPoint, Color.red);
        Debug.DrawLine(rightUpPoint,rightDownPoint,Color.red);
        Debug.DrawLine(rightDownPoint,leftDownPoint,Color.red);
        
        enemyBoundries.Add(leftUpPoint);
        enemyBoundries.Add(leftDownPoint);
        
        enemyBoundries.Add(leftDownPoint);
        enemyBoundries.Add(rightDownPoint);
        
        enemyBoundries.Add(rightDownPoint);
        enemyBoundries.Add(rightUpPoint);
        
        enemyBoundries.Add(rightUpPoint);
        enemyBoundries.Add(leftUpPoint);
        
    }
    
    private void EnemyBoundryClear()
    {
        enemyBoundries.Clear();
    }
    
}
