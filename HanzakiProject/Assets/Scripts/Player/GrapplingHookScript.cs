using UnityEngine;
using System.Collections;

public class GrapplingHookScript : MonoBehaviour
{
    public StatsManager stats;

    void Awake()
    {
        stats = GameObject.Find("GameManager").GetComponent<StatsManager>();
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(stats.grapplingHookUnlocked)
            {

            }
        }
    }

}
