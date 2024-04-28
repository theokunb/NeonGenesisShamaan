using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoomSpawner : MonoBehaviour
{

    public Direction direction;
    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right,
        None
    }

    private RoomVariant variant;
    private int rand;
    private bool spawned = false;
    private float waitTime = 3f;

    private void Start()
    {
        variant = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariant>();
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.2f);
    }

    public void Spawn()
    {
        if (!spawned) {
            if(direction == Direction.Top)
            {
                rand = Random.Range(0, variant.topRoom.Length);
                Instantiate(variant.topRoom[rand], transform.position, variant.topRoom[rand].transform.rotation);
            }
            else if (direction == Direction.Bottom)
            {
                rand = Random.Range(0, variant.bottomRoom.Length);
                Instantiate(variant.bottomRoom[rand], transform.position, variant.bottomRoom[rand].transform.rotation);
            }
            else if (direction == Direction.Left)
            {
                rand = Random.Range(0, variant.leftRoom.Length);
                Instantiate(variant.leftRoom[rand], transform.position, variant.leftRoom[rand].transform.rotation);
            }
            else if (direction == Direction.Right)
            {
                rand = Random.Range(0, variant.rightRoom.Length);
                Instantiate(variant.rightRoom[rand], transform.position, variant.rightRoom[rand].transform.rotation);
            }
            spawned = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("RoomPoint") && other.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(gameObject);
        }
    }
}
