using UnityEngine;
using System.Collections;

public class EnemyBoss : MonoBehaviour {
    private RaycastHit hit;
    public float rayDis;
    private bool attackMode;
    private NavMeshAgent agent;
    private Animator anim;
    public Transform player;

    private float attackRate;
    public float attackDamage;
    public float attackRange;
    private float mayAttack;
    


	void Awake () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
	}
	
	void Update () {
	    if(Physics.Raycast(transform.position,transform.right,out hit, rayDis))
        {
            if(hit.transform.tag == "Player")
            {
                attackMode = true;
            }
        }
        if (attackMode)
        {
            Attacking();
        }
	}
    
    void Attacking()
    {
        agent.SetDestination(player.position);
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange)
        {
            if(attackRate <= 0)
            {
                anim.SetBool("Attacking", true);
            }
            else
            {
                if(mayAttack <= anim.runtimeAnimatorController.animationClips.Length)
                {
                    anim.SetBool("Attacking", false);
                }
                attackRate -= Time.deltaTime;
                mayAttack -= Time.deltaTime;

            }
        }
    }

    void GetHit()
    {

    }
}
