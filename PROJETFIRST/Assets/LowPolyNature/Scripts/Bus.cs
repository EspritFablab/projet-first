using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bus : InteractableItemBase {

  public Text QuestReaction;
  public InteractableItemBase QuestGain;
  public Inventory Inventory;

    public override void OnInteract()
    {
      QuestGain = GameObject.FindWithTag("Quest").GetComponent<quest>().QuestItem[0];
      QuestReaction = GameObject.FindWithTag("Quest").GetComponent<quest>().QuestText[0];
      if(this.gameObject.active && QuestReaction.text == ""){
      QuestReaction.text = "RECUPERE UNE TORCHE PRES DU LAC";
      this.gameObject.GetComponent<Bus>().enabled = false;
    }
      else if(this.gameObject.active && QuestReaction.text == "bravo"){
      QuestReaction.text = "VOICI TON ITEM";
      Inventory.AddItem(QuestGain as InventoryItemBase);
      this.gameObject.GetComponent<Bus>().enabled = false;
    }
  }
 }
