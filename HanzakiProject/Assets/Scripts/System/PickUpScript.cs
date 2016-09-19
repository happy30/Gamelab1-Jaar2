using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {

    public StatsManager stats;

    public enum PickUpTypes
    {
        Hook,
        Rope,
        Heart,
        Health,
        Shuriken,
        SmokeBomb,
        Blade
    }
    public PickUpTypes pickUpTypes;

    void Start()
    {
        stats = GameObject.Find("GameManager").GetComponent<StatsManager>();

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(pickUpTypes == PickUpTypes.Hook)
            {
                stats.AddHookPart();
            }
            if(pickUpTypes == PickUpTypes.Rope)
            {
                stats.AddHookPart();
            }
            if (pickUpTypes == PickUpTypes.Heart)
            {
                stats.GetLife();
            }
        }
    }
}
