using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torche : InventoryItemBase {

  public Text QuestReaction;

    public override void OnPickup()
    {
      QuestReaction = GameObject.FindWithTag("Quest").GetComponent<quest>().QuestText[0];
      if(this.gameObject.active && QuestReaction.text == "RECUPERE UNE TORCHE PRES DU LAC"){
      QuestReaction.text = "bravo";
      this.gameObject.GetComponent<Torche>().enabled = false;
      this.gameObject.active = false;
    }
 }
}
