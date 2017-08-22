using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Paper paper;
    public Text paperContents;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (paper.collected)
        {
            paperContents.text = paper.command + "\n\n" + paper.description;

            if (Input.GetKeyDown(KeyCode.E))
            {
                //Toggle the value of the boolean
                paperContents.enabled = !paperContents.enabled;
            }
        }
	}
}
