using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolRotate : MonoBehaviour
{
    Transform playerTransform;

    void Start()
    {
        playerTransform = transform.parent.transform;
    }

    void Update()
    {
        var angleRotation = GetAngleRotation();

        transform.eulerAngles = new Vector3(0, 0, -angleRotation);
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
}
