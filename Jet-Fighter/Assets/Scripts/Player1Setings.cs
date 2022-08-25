using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using TMPro;
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

    [Header("Score Settings")] 
    [SerializeField] private TextMeshProUGUI player1scoreText;
    private int _player1score;
    
    [Header("Map Boundry")]
    [SerializeField] private float yAxisBoundry;
    [SerializeField] private float xAxisBoundry;
    
    void Start()
    {
        _zAxisRotation = 0;
        _bulletSpawnWaitTime = 0;
        _player1score = 0;
    }

    
    void Update()
    {
        Move();
        Fire();
        BoundryControl();
    }

    private void BoundryControl()
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
    
    private void Fire()
    {
        if (Input.GetKey(KeyCode.Space))
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

    public void AddScore()
    {
        _player1score++;
        player1scoreText.text = _player1score.ToString();
    }
    
}
