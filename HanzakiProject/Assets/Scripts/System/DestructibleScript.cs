//Made by Sascha Greve

using UnityEngine;
using System.Collections;

public class DestructibleScript : MonoBehaviour {

    void Destroy ()
    {
        Destroy(gameObject);
    }
}
