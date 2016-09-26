using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour {

    public StatsManager stats;
    public float attackPower;

    public GameObject shurikenObject;
    GameObject spawnedShurikenObject;



    void Awake()
    {
        stats = GameObject.Find("GameManager").GetComponent<StatsManager>();
    }

	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKey(InputManager.Shuriken))
        {
            //Animatorplay blabla
        }
	}

    public void ThrowShuriken(float attackPower)
    {
        Destroy(spawnedShurikenObject = (GameObject)Instantiate(shurikenObject, transform.position, Quaternion.identity), 3);
        spawnedShurikenObject.GetComponent<ShurikenObject>().attackPower = attackPower;
    }
}
