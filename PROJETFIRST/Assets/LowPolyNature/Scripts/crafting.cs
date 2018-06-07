using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crafting : InteractableItemBase {

	public GameObject craftgui;

	public HUD Hud;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
public override void OnInteract() {
	craftgui.SetActive(!craftgui.active);
	if(craftgui.active) {
	Hud.CloseMessagePanel();
	}
	else {
	Hud.MessagePanel.SetActive(true);
	}
}

void OnTriggerExit(Collider other)
	 {
			 craftgui.SetActive(false);
	 }
}
