﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (player.mouton >= 3)
		{
				openGate();
		}
	}

	void openGate()	{
		transform.position = new Vector3 (transform.position.x, 5.5f, transform.position.z);
	}

}
