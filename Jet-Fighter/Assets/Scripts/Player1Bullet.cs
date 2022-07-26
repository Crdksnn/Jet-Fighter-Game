using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private string enemyTag = "Player2"; 
    private GameObject enemy; //Player2
    
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
        
        Destroy(gameObject, 10f);
    }
}
