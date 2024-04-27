using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform playerTransform;
    Animator animator;
    public float speed = 10;

    void Start()
    {
        playerTransform = GetComponent<Transform>();

        animator = GetComponentInChildren<Animator>();
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


        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("isMove", true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }
    }
}
