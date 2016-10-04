﻿//CameraController by Jordi

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    float cameraOffsetX;
    public float cameraOffsetY;

    public float followTime;
    public bool inCutscene;

    public GameObject followObject;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        followTime = 2;
        if(playerController.levelType == PlayerController.LevelType.TD)
        {
            cameraOffsetY = 10;
            transform.eulerAngles = new Vector3(30, 0, 0);
        }
        else
        {
            cameraOffsetY = 4;
            transform.eulerAngles = new Vector3(18, 0, 0);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!inCutscene)
        {
            FollowPlayer();
        }
        else
        {
            if(followObject != null)
            {
                FollowObject(followObject);
            }
        }

        
    }

    //Make the camera follow the player. If the player moves the camera offset will change so that it gives a better vision of what's in front of the player.
    public void FollowPlayer()
    {
        if(playerController.xMovement > 0.01)
        {
            cameraOffsetX = 5;
        }
        else if (playerController.xMovement < -0.01)
        {
            cameraOffsetX = -5;
        }
        else
        {
            cameraOffsetX = 0;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + cameraOffsetX, player.transform.position.y + cameraOffsetY, player.transform.position.z - 10f), followTime * Time.deltaTime);
    }

    //Focus the camera on an object
    public void FollowObject(GameObject followThis)
    {
        if(playerController.levelType == PlayerController.LevelType.SS)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(followThis.transform.position.x, transform.position.y, -8f), followTime * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(followThis.transform.position.x, followThis.transform.position.y + 5, -8f), followTime * Time.deltaTime);
        }
        
    }
}
