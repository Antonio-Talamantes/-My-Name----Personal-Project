using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public GameObject battleCam1;
    private Vector3 offsetOverWorld = new Vector3(0, 5, -4);
    private Vector3 offsetBattle = new Vector3(0, 25, 0);
    private PlayerController playerController;



    public bool backVeiw;

    public float speed = 1;
    public float battleRotation = 10;

    void Start()
    {
        transform.position = player.transform.position + offsetOverWorld;
        playerController = GameObject.FindObjectOfType<PlayerController>();



    }


    void Update()
    {
        backVeiw = playerController.onOverWorld;
        if (backVeiw == true)
        {
            isOnoverworld();
        }
        if (backVeiw == false)
        {
            isOnBattle();
        }
    }
    void isOnoverworld()
    {

        transform.position = player.transform.position + offsetOverWorld;
        transform.rotation = player.transform.rotation;
        float desiredAngle = player.transform.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(-30, desiredAngle, 0);
        transform.position = player.transform.position + (rotation * offsetOverWorld);

    }
    void isOnBattle()
    {
        

        Vector3 battleCamOffset = new Vector3(0, 25, 0);

        battleCam1.transform.position = player.transform.position + battleCamOffset;
        battleCam1.transform.Rotate(Vector3.forward, battleRotation * Time.fixedDeltaTime);

    }
}
