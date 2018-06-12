using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class moveitem: MonoBehaviour {

	public GameObject slotinv;
	public GameObject slotcraft;

	public GameObject[] myCollection;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.V))
		{
		this.gameObject.GetComponent<Image>().enabled = !this.gameObject.GetComponent<Image>().enabled;
		slotcraft.gameObject.GetComponent<Image> ().sprite = slotinv.gameObject.GetComponent<Image> ().sprite;
		}
	}
 }
