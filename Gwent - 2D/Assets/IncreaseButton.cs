using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;

public class IncreaseButton : MonoBehaviour
{
      public GameObject Panel;

     public GameObject SelectedCard;
    public GameObject AllCards; 
    private GameObject rowIncrease;
    private  GameObject hand;

    private Card card;
    
    void Onclick(){
        
         if(SelectedCard.transform.childCount!=0){
               card=EffectManager.Instance.AuxCard;
               Card increaseCard=SelectedCard.transform.GetChild(0).gameObject.GetComponent<data>().card;
               increaseCard.Rows=card.Rows;
               if(GameManager.Instance.State== GameManager.GameState.Player1Turn){
                    if(!GameManager.Instance.Pass[1]){
                        hand=GameObject.Find("Hand Player2");
                    if(card.Rows== Boards.Rows.M) rowIncrease=GameObject.Find("M Player2");
                    else if(card.Rows== Boards.Rows.R) rowIncrease=GameObject.Find("R Player2");
                    else if(card.Rows== Boards.Rows.S) rowIncrease=GameObject.Find("S Player2");
                    card.Effect.Action(GameManager.Instance.Players[1], increaseCard);
                    GameManager.Instance.Players[1].RefreshPoints();
                    SelectedCard.transform.GetChild(0).gameObject.transform.SetParent(rowIncrease.transform,false);
                    }else{
                          hand=GameObject.Find("Hand Player1");
                    if(card.Rows== Boards.Rows.M) rowIncrease=GameObject.Find("M Player1");
                    else if(card.Rows== Boards.Rows.R) rowIncrease=GameObject.Find("R Player1");
                    else if(card.Rows== Boards.Rows.S) rowIncrease=GameObject.Find("S Player1");
                    card.Effect.Action(GameManager.Instance.Players[0], increaseCard);
                    GameManager.Instance.Players[0].RefreshPoints();
                    SelectedCard.transform.GetChild(0).gameObject.transform.SetParent(rowIncrease.transform,false);
                    }
                  
                   
               } 
               
               else   if(GameManager.Instance.State== GameManager.GameState.Player2Turn){
                        if(!GameManager.Instance.Pass[0]){
                          hand=GameObject.Find("Hand Player1");
                    if(card.Rows== Boards.Rows.M) rowIncrease=GameObject.Find("M Player1");
                    else if(card.Rows== Boards.Rows.R) rowIncrease=GameObject.Find("R Player1");
                    else if(card.Rows== Boards.Rows.S) rowIncrease=GameObject.Find("S Player1");
                    card.Effect.Action(GameManager.Instance.Players[0], increaseCard);
                    GameManager.Instance.Players[0].RefreshPoints();
                    SelectedCard.transform.GetChild(0).gameObject.transform.SetParent(rowIncrease.transform,false);
                        } else{
                            hand=GameObject.Find("Hand Player2");
                    if(card.Rows== Boards.Rows.M) rowIncrease=GameObject.Find("M Player2");
                    else if(card.Rows== Boards.Rows.R) rowIncrease=GameObject.Find("R Player2");
                    else if(card.Rows== Boards.Rows.S) rowIncrease=GameObject.Find("S Player2");
                    card.Effect.Action(GameManager.Instance.Players[1], increaseCard);
                    GameManager.Instance.Players[1].RefreshPoints();
                    SelectedCard.transform.GetChild(0).gameObject.transform.SetParent(rowIncrease.transform,false);
                        }
                     
                     
               }
                   
            
         } 
               while(AllCards.transform.childCount!=0){
                         AllCards.transform.GetChild(0).gameObject.transform.SetParent(hand.transform,false);
                    }
                    Panel.SetActive(false);
    }
}
