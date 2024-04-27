using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform playerTransform;
    public float speed = 10;
    
    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    
    void Update()
    {
        Movement();
    }


    public void Movement()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");

        transform.position += Vector3.right * speed * horizontal * Time.deltaTime;

        var vertical = Input.GetAxisRaw("Vertical");

        transform.position += Vector3.up * speed * vertical * Time.deltaTime;
    }
}
