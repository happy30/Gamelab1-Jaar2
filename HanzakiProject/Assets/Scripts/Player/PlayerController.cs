// PlayerController by Jordi

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //Components
    Rigidbody _rb;
    public StatsManager stats;

    //Movement
    float speed;
    public float jumpHeight;

    public float xMovement;
    public float modelWidth;


	void Start ()
    {
        _rb = GetComponent<Rigidbody>();
        stats = GameObject.Find("GameManager").GetComponent<StatsManager>();
        modelWidth = 1;

    }
	
	void Update ()
    {
        //Change speed to runspeed if Shift is pressed
        speed = Input.GetKey(KeyCode.LeftShift) ? stats.runSpeed : stats.walkSpeed;


         xMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        


        //Make the player not able to hump the wall
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.right, out hit, modelWidth))
        {
            if(xMovement > 0 )
            {
                xMovement = 0;
            }
        }
        if (Physics.Raycast(transform.position, -transform.right, out hit, modelWidth))
        {
            if (xMovement < 0)
            {
                xMovement = 0;
            }
        }

        if (!Camera.main.gameObject.GetComponent<CameraController>().inCutscene)
        {
            transform.Translate(new Vector3(xMovement, 0, 0));
        }



        if (Input.GetButtonDown("Jump"))
        {
            //Check if player is standing on Ground
            if (IsTouching().tag == "Ground")
            {
                print("jump");
            }
        }
    }


    //Check what object is beneath the player
    public GameObject IsTouching()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1))
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Interact")
        {
            if(col.gameObject.GetComponent<InteractScript>().interactType == InteractScript.InteractType.OnTrigger)
            {
                col.gameObject.GetComponent<InteractScript>().linkedObject.GetComponent<Activate>().activated = true;
            }
            else if(col.gameObject.GetComponent<InteractScript>().interactType == InteractScript.InteractType.OnInput)
            {
                //ui.show interact text
                if(Input.GetKey(InputManager.Slash))
                {
                    col.gameObject.GetComponent<InteractScript>().linkedObject.GetComponent<Activate>().activated = true;
                }
            }
        }
    }
}
