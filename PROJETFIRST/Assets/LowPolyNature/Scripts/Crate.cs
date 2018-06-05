using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : InteractableItemBase {

    private bool mIsOpen = false;
    public GameObject torche;

    public override void OnInteract()
    {
        InteractText = "Press F to ";

        mIsOpen = !mIsOpen;
        InteractText += mIsOpen ? "to close" : "to open";

        GetComponent<Animator>().SetBool("open", mIsOpen);
          torche.GetComponent<BoxCollider>().enabled = !torche.GetComponent<BoxCollider>().enabled;

          GameObject [] t = GameObject.Find("torch_A").GetComponentsInChildren<GameObject>();
          t[0].active = !t[0].active;
          //GameObject.Find("torch_Particle").active = !GameObject.Find("torch_Particle").active;

    }
}
