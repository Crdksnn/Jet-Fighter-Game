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
    
    private GameObject player;
    private Transform enemy; //Player1

    private List<Vector2> enemyBoundries = new List<Vector2>();

    private Vector2 leftUpPoint;
    private Vector2 leftDownPoint;
    private Vector2 rightUpPoint;
    private Vector2 rightDownPoint;

    [SerializeField] private float xAxisBoundry;
    [SerializeField] private float yAxisBoundry;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
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
        
        Debug.DrawLine(transform.position, pos + movement,Color.red);

        if (LineIntersectionControl(pos, pos + movement))
        {
            player.GetComponent<Player2Setings>().AddScore();
            Destroy(gameObject);
        }
        
        transform.position = newPos;

        Destroy(gameObject, 8f);
    }
    
    private void MapBoundryControl()
    {
        //+Y Axis Control
        if (yAxisBoundry < transform.position.y)
            transform.position = new Vector3(transform.position.x, -yAxisBoundry, 0);
        
        //-Y Axis Control
        if (transform.position.y < -yAxisBoundry)
            transform.position = new Vector3(transform.position.x, yAxisBoundry, 0);
        
        //+X Axis Control
        if (xAxisBoundry < transform.position.x)
            transform.position = new Vector3(-xAxisBoundry, transform.position.y, 0);
        
        //-X Axis Control
        if (transform.position.x < -xAxisBoundry)
            transform.position = new Vector3(xAxisBoundry, transform.position.y, 0);
        
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
    
    private bool LineIntersectionControl(Vector2 bulletCenter, Vector2 bulletMovement)
    {
        for (int i = 0; i < enemyBoundries.Count; i += 2)
        {
            if (Math2d.LineSegmentsIntersection(bulletCenter, bulletMovement, enemyBoundries[i], enemyBoundries[i + 1]))
            {
                return true;
            }
        }

        return false;
    }
    
}
