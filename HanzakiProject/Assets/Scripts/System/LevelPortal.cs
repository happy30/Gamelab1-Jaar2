using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelPortal : MonoBehaviour {

    LoadController loadController;
    public string level;

    void Start()
    {
        loadController = GameObject.Find("GameManager").GetComponent<LoadController>();
    }
	// Use this for initialization
	void OnTriggerEnter (Collider other)
    {
        if (other.transform.tag == "Player")
        {
            loadController.LoadScene(level);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
