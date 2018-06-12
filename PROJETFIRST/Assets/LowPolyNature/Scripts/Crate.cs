using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : InteractableItemBase {

    private bool mIsOpen = false;

    public Transform objet;

    public override void OnInteract()
    {
        InteractText = "Press F to ";

        mIsOpen = !mIsOpen;
        this.GetComponent<BoxCollider>().enabled = false;
        System.Threading.Thread.Sleep(10);
        this.GetComponent<BoxCollider>().enabled = true;
        InteractText += mIsOpen ? "to close" : "to open";

        Debug.Log(mIsOpen);

        GetComponent<Animator>().SetBool("open", mIsOpen);

        // PRENDRE LA TORCHE OU UN OBJET SEULEMENT QUAND ON OUVRE LE COFFRE ET l'ALLUME
        if(transform.childCount >= 2)
        {
          objet = transform.GetChild(1);
          objet.GetComponent<BoxCollider>().enabled = !objet.GetComponent<BoxCollider>().enabled;

          if(objet.name == "torch_A")
          {
          objet.transform.GetChild(0).gameObject.SetActive(!objet.transform.GetChild(0).gameObject.active);
          objet.transform.GetChild(1).gameObject.SetActive(!objet.transform.GetChild(1).gameObject.active);
          }
            //objet.transform.GetChild(0).gameObject.SetActive(!objet.transform.GetChild(0).gameObject.active);
        }

    }
}
