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
    public float walkSpeed;
    public float runSpeed;
    public float jumpHeight;


	void Start ()
    {
        _rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        //Change speed to runspeed if Shift is pressed
        speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            //Check if player is standing on Ground
            if (IsTouching().tag == "Ground")
            {
                Jump();
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

}
