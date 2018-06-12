using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crafting : InteractableItemBase {

	public GameObject[] slotinv;
	public GameObject[] slotcraft;
	public GameObject[] Item;
	public Sprite[] ItemImage;

	private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
     };

	public GameObject craftgui;

	public GameObject quest;

	public HUD Hud;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
public override void OnInteract() {
	craftgui.SetActive(!craftgui.active);
	Debug.Log(craftgui.active);
	this.GetComponent<BoxCollider>().enabled = false;
	System.Threading.Thread.Sleep(10);
	this.GetComponent<BoxCollider>().enabled = true;
}

void Update () {
for(int i = 0 ; i < keyCodes.Length; i ++ ){
if(Input.GetKeyDown(keyCodes[i])){
int numberPressed = i;
Debug.Log(numberPressed);
if(craftgui.active && slotinv[numberPressed].gameObject.GetComponent<Image> ().sprite != null){
slotcraft[numberPressed].gameObject.active = !slotcraft[numberPressed].gameObject.active;
slotcraft[numberPressed].gameObject.GetComponent<Image> ().sprite = slotinv[numberPressed].gameObject.GetComponent<Image> ().sprite;
Debug.Log(slotcraft[numberPressed].gameObject.GetComponent<Image> ().sprite);
}
}
}
}

void OnTriggerExit(Collider other)
	 {
			 craftgui.SetActive(false);
	 }
}
