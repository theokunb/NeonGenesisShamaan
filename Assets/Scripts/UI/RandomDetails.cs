using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDetails : MonoBehaviour
{
    public GameObject[] details;
    public List<Transform> spawnPoints;
    void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        SpawnDetails();
    }
    void SpawnDetails()
    {

        var rand = Random.Range(details.Length, 6);
        for(int i = 0; i < rand; i++)
        {
            var spawn = Random.Range(0, spawnPoints.Count);
            Instantiate(details[Random.Range(0,3)], spawnPoints[spawn].transform.position, Quaternion.identity);
            spawnPoints.RemoveAt(spawn);
        }
    }
}
