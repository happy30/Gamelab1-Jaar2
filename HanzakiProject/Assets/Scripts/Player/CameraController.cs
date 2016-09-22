//CameraController by Jordi

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    float cameraOffset;

    public float followTime;
    public bool inCutscene;

    public GameObject followObject;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        followTime = 2;
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
            cameraOffset = 3;
        }
        else if (playerController.xMovement < -0.01)
        {
            cameraOffset = -3;
        }
        else
        {
            cameraOffset = 0;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + cameraOffset, transform.position.y, -10f), followTime * Time.deltaTime);
    }

    public void FollowObject(GameObject followThis)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(followThis.transform.position.x, transform.position.y, -8f), followTime * Time.deltaTime);
    }
}
