using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolRotate : MonoBehaviour
{
    Transform playerTransform;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        playerTransform = transform.parent.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var angleRotation = GetAngleRotation();

        transform.eulerAngles = new Vector3(0, 0, -angleRotation);
        Flip();
    }


    public float GetAngleRotation()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var directionVector = new Vector2(mousePosition.x, mousePosition.y) - new Vector2(playerTransform.position.x, playerTransform.position.y);

        var mouseDirection = mousePosition.y - playerTransform.position.y;

        float angleToEuler = Vector2.Angle(-playerTransform.right, directionVector);

        if (mouseDirection < 0)
        {
            angleToEuler *= -1;
        }

        return angleToEuler;
    }

    public void Flip()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var directionVector = new Vector2(mousePosition.x, mousePosition.y) - new Vector2(playerTransform.position.x, playerTransform.position.y);

        var mouseDirection = mousePosition.x - playerTransform.position.x;

        if (mouseDirection > 0)
        {
            spriteRenderer.flipY = true;
        }

        if (mouseDirection < 0)
        {
            spriteRenderer.flipY = false;
        }
    }
}
