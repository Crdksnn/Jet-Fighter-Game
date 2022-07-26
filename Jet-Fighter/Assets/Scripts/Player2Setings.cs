using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using TMPro;
using UnityEngine;

public class Player2Setings : MonoBehaviour
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
    [SerializeField] private TextMeshProUGUI player2ScoreText;
    private int _player2Score;
    
    void Start()
    {
        _zAxisRotation = 0;
        _bulletSpawnWaitTime = 0;
    }

    
    void Update()
    {
        BoundryControl();
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKey(KeyCode.UpArrow))
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

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _zAxisRotation -= rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, _zAxisRotation);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _zAxisRotation += rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, _zAxisRotation);
        }
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
    
    public void AddScore()
    {
        _player2Score++;
        player2ScoreText.text = _player2Score.ToString();
    }
    
}
