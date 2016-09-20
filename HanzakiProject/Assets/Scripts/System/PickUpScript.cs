using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {

    public StatsManager stats;

    public enum PickUpTypes { Hook, Rope, Heart, Health, Shuriken, SmokeBomb, Katana }
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
                Destroy(gameObject);
            }
            if(pickUpTypes == PickUpTypes.Rope)
            {
                stats.AddHookPart();
                Destroy(gameObject);
            }
            if (pickUpTypes == PickUpTypes.Heart)
            {
                stats.GetLife();
                Destroy(gameObject);
            }
            if(pickUpTypes == PickUpTypes.Health)
            {
                stats.GetHealth();
                Destroy(gameObject);
            }
            if (pickUpTypes == PickUpTypes.Shuriken)
            {
                stats.shurikenUnlocked = true;
                Destroy(gameObject);
            }
            if (pickUpTypes == PickUpTypes.SmokeBomb)
            {
                stats.smokeBombUnlocked = true;
                Destroy(gameObject);
            }
            if (pickUpTypes == PickUpTypes.Katana)
            {
                stats.katanaUnlocked = true;
                Destroy(gameObject);
            }
        }
    }
}
