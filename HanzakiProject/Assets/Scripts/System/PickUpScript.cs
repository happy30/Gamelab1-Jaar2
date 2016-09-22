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
                if (stats.shurikenUnlocked != true)
                {
                    stats.shurikenUnlocked = true;
                    stats.shurikenAmount++;
                }
                else stats.shurikenAmount++;
                Destroy(gameObject);
            }
            if (pickUpTypes == PickUpTypes.SmokeBomb)
            {
                if (stats.smokeBombUnlocked != true)
                {
                    stats.smokeBombUnlocked = true;
                    stats.smokeBombAmount++;
                }
                else stats.smokeBombAmount++;
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
