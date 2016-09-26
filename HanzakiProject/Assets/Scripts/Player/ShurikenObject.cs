using UnityEngine;
using System.Collections;

public class ShurikenObject : MonoBehaviour
{
    public float attackPower;
    public float projectileSpeed;

	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(new Vector3(projectileSpeed * Time.deltaTime, 0, 0));
	}
}
