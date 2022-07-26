using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
        
        Destroy(gameObject, 8f);
    }
}
