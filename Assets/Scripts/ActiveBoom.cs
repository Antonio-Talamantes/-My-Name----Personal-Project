using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoom : MonoBehaviour
{
    public GameObject[] active;

    void Start()
    {
        Vector3 spawnPos = new Vector3(-100, 0, 0);
    }

    void Update()
    {
       // Instantiate(active[0], spawnPos, active[0].transform.rotation);
    }
}
