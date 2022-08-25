using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player1Bullet : MonoBehaviour
{

    [SerializeField] private float bulletSpeed;
    
    private string playerTag = "Player1"; 
    private string enemyTag = "Player2"; 
    
    private GameObject player;
    private Transform enemy; //Player2

    private List<Vector2> enemyBoundries = new List<Vector2>();

    private Vector2 leftUpPoint = Vector2.zero;
    private Vector2 leftDownPoint = Vector2.zero;
    private Vector2 rightUpPoint = Vector2.zero;
    private Vector2 rightDownPoint = Vector2.zero;
    
    //Map Boundries

    [SerializeField] private float xAxisBoundry;
    [SerializeField] private float yAxisBoundry;
    
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag(enemyTag).transform;
        player = GameObject.FindGameObjectWithTag(playerTag);
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
        
        //Line intersection control and move
        var pos = transform.position;
        var movement = bulletSpeed * transform.right * Time.deltaTime;
        var newPos = pos + movement;
        
        Debug.DrawLine(transform.position, pos + movement,Color.red);
        
        if (LineIntersectionControl(pos, pos + movement))
        {
            player.GetComponent<Player1Setings>().AddScore();
            Destroy(gameObject);
        }

        else
        {
            transform.position = newPos;
        }
        
        Destroy(gameObject, 10f);
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
