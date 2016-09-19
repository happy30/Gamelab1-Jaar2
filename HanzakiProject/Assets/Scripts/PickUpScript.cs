using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {

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

    void OnTriggerEnter(Collider other)
    {

    }
}
