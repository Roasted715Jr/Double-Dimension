using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour {

    public string command;
    public string description;
    public bool collected;

	// Use this for initialization
	void Start () {
        collected = false;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        collected = true;
        gameObject.SetActive(false);
    }
}
