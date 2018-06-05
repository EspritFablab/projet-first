using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour {

	public PlayerController player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (player.Moutonkill <= 0 && transform.position.y < 7)
		{
				OpenGate();
		}
	}

	void OpenGate()	{
		transform.position += new Vector3(0f, 1 * Time.deltaTime, 0f);
	}

}
