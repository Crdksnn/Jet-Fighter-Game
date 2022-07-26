using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class Player1Setings : MonoBehaviour
{
    [Header("Movement & Rotation")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private float _zAxisRotation;

    [Header("Fire Settings")] 
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpawnTime;
    private float _bulletSpawnWaitTime;
    
    void Start()
    {
        _zAxisRotation = 0;
        _bulletSpawnWaitTime = 0;
    }

    
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetMouseButton(0))
        {
            
            if (_bulletSpawnWaitTime <= 0)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                _bulletSpawnWaitTime = bulletSpawnTime;
            }
        }
        
        _bulletSpawnWaitTime -= Time.deltaTime;
    }

    private void Move()
    {
        transform.position += transform.right * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            _zAxisRotation -= rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, _zAxisRotation);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _zAxisRotation += rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, _zAxisRotation);
        }
    }
}
