// PlayerController by Jordi

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //Components
    Rigidbody _rb;
    public StatsManager stats;
    public UIManager ui;
    public GameObject playerModel;
    public OptionsSettings optionsSettings;


    //Movement
    float speed;
    public float jumpHeight;

    public float xMovement;
    public float zMovement;
    public float modelWidth;
    public bool inAir;

    //What Level
    public enum LevelType
    {
        SS,
        TD
    };
    public LevelType levelType;

    //Combat
    public bool invulnerable;
    public float invulnerableTime;
    public float invulnerableTimer;


    //Gather components
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        stats = GameObject.Find("GameManager").GetComponent<StatsManager>();
        optionsSettings = GameObject.Find("GameManager").GetComponent<OptionsSettings>();
        modelWidth = 1;
    }

    //Set the right controls
    void Start()
    {
        ChangeControlsDependingOnLevelType();
    }
	
	void Update ()
    {
        SetMovement();
        CheckForWall();
        Move();
        CheckVulnerability();
    }


    void ChangeControlsDependingOnLevelType()
    {
        if (levelType == LevelType.SS)
        {
            InputManager.Jump = InputManager.JumpSS;
        }
        else if (levelType == LevelType.TD)
        {
            InputManager.Jump = InputManager.JumpTD;
        }
    }

    //Change speed to runspeed if Shift is pressed
    void SetMovement()
    {
        speed = Input.GetKey(KeyCode.LeftShift) ? stats.runSpeed : stats.walkSpeed;
        xMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (xMovement > 0)
        {
            playerModel.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        if (xMovement < 0)
        {
            playerModel.transform.eulerAngles = new Vector3(0, -90, 0);
        }
        if(levelType == LevelType.TD)
        {
            zMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            if (zMovement > 0)
            {
                playerModel.transform.eulerAngles = new Vector3(0, -0, 0);
                if (xMovement > 0)
                {
                    playerModel.transform.eulerAngles = new Vector3(0, 45, 0);
                }
                if (xMovement < 0)
                {
                    playerModel.transform.eulerAngles = new Vector3(0, -45, 0);
                }
            }
            if (zMovement < 0)
            {
                playerModel.transform.eulerAngles = new Vector3(0, 180, 0);
                if (xMovement > 0)
                {
                    playerModel.transform.eulerAngles = new Vector3(0, 135, 0);
                }
                if (xMovement < 0)
                {
                    playerModel.transform.eulerAngles = new Vector3(0, -135, 0);
                }
            }
        }
    }

    //Move the player and let it jump
    void Move()
    {
        if (!Camera.main.gameObject.GetComponent<CameraController>().inCutscene)
        {
            transform.Translate(new Vector3(xMovement, 0, zMovement));
            if (Input.GetKey(InputManager.Jump))
            {
                //Check if player is standing on Ground
                if (IsTouching() != null)
                {
                    if (IsTouching().tag == "Ground")
                    {
                        Debug.Log("jump");
                        if (!CheckIfJumping() && !inAir)
                        {
                            Jump();
                        }
                    }
                }
            }
        }
    }

    //Make the player stop moving if it's humping a wall
    void CheckForWall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, modelWidth))
        {
            if (xMovement > 0)
            {
                xMovement = 0;
            }
        }
        if (Physics.Raycast(transform.position, -transform.forward, out hit, modelWidth))
        {
            if (xMovement < 0)
            {
                xMovement = 0;
            }
        }
    }

    //Check what object is beneath the player
    public GameObject IsTouching()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 2))
        {
            return hit.collider.gameObject;
        }
        else
        {
            inAir = true;
        }
        return null;
    }

    //Throw the player in the air
    public void Jump()
    {
        _rb.velocity = new Vector3(0, jumpHeight, 0);
    }

    public bool CheckIfJumping()
    {
        if(_rb.velocity.y > jumpHeight -0.1)
        {
            return true;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1))
        {
            if(hit.collider.tag == "Ground")
            {
                inAir = false;
            }
        }
        return false;
    }

    void CheckVulnerability()
    {
        if(invulnerable)
        {
            invulnerableTimer += Time.deltaTime;
            if(invulnerableTimer > invulnerableTime)
            {
                invulnerable = false;
                invulnerableTimer = 0;
            }
        }
    }

    public void GetHit(int damage)
    {
        if(!invulnerable)
        {
            stats.health--;
            //knockback maybe
        }
    }

    public void GetInvulnerable()
    {
        invulnerable = true;
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Interact")
        {
            if(col.gameObject.GetComponent<InteractScript>().interactType == InteractScript.InteractType.OnTrigger)
            {
                if(col.gameObject.GetComponent<InteractScript>().isHint)
                {
                    if (optionsSettings.displayHints)
                    {
                        col.gameObject.GetComponent<InteractScript>().Activate();
                    }
                }
                else
                {
                    col.gameObject.GetComponent<InteractScript>().Activate();
                }
                
            }
            else if(col.gameObject.GetComponent<InteractScript>().interactType == InteractScript.InteractType.OnInput)
            {
                ui.ChangeInteractText(col.gameObject.GetComponent<InteractScript>());
                if(Input.GetKey(InputManager.Slash))
                {
                    col.gameObject.GetComponent<InteractScript>().Activate();
                }
                if(col.gameObject.GetComponent<InteractScript>().linkedObject.GetComponent<Activate>().activated)
                {
                    ui.RemoveInteractText();
                }
            }
            
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Ground")
        {
            inAir = false;
        }
    }

    void OnTriggerExit()
    {
        ui.RemoveInteractText();
    }
}
