using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;

public class ConfirmButton : MonoBehaviour
{
     public GameObject Panel;

     public GameObject SelectedCard;
    public GameObject AllCards; 

    private Card card;

    public void Onclick(){
          if(SelectedCard.transform.childCount!=0){
             GameObject hand;
             card=EffectManager.Instance.AuxCard;
              if(GameManager.Instance.State== GameManager.GameState.Player1Turn){
                 if(!GameManager.Instance.Pass[1]){
                       hand=GameObject.Find("Hand Player2");
                  CardsManager.Instance.cardsPlayer2.Add(SelectedCard.transform.GetChild(0).gameObject);
                  card.Effect.Action(GameManager.Instance.Players[1],SelectedCard.transform.GetChild(0).gameObject.GetComponent<data>().card);
                  GameManager.Instance.Players[1].RefreshPoints();
                  GameObject cardBack = Resources.Load<GameObject>("Prefabs/" + "CardBack");
                  GameObject card1=Instantiate(cardBack,new Vector3(0,0,0),Quaternion.identity);
                  card1.transform.SetParent(hand.transform,false);
                 SelectedCard.transform.GetChild(0).gameObject.transform.SetParent(CardsManager.Instance.gameObject.transform,false);
                 } else{
                     hand=GameObject.Find("Hand Player1");
                  CardsManager.Instance.cardsPlayer1.Add(SelectedCard.transform.GetChild(0).gameObject);
                  card.Effect.Action(GameManager.Instance.Players[0],SelectedCard.transform.GetChild(0).gameObject.GetComponent<data>().card);
                  GameManager.Instance.Players[0].RefreshPoints();
                   SelectedCard.transform.GetChild(0).gameObject.transform.SetParent(hand.transform,false);
                 }
              
                
                
                  
                 
              
              } 
                else  if(GameManager.Instance.State== GameManager.GameState.Player2Turn){
                     if(!GameManager.Instance.Pass[0]){
                           hand=GameObject.Find("Hand Player1");
                         CardsManager.Instance.cardsPlayer1.Add(SelectedCard.transform.GetChild(0).gameObject);
                        card.Effect.Action(GameManager.Instance.Players[0],SelectedCard.transform.GetChild(0).gameObject.GetComponent<data>().card);
                        GameManager.Instance.Players[0].RefreshPoints();
                        GameObject cardBack = Resources.Load<GameObject>("Prefabs/" + "CardBack");
                         GameObject card1=Instantiate(cardBack,new Vector3(0,0,0),Quaternion.identity);
                        card1.transform.SetParent(hand.transform,false);
                        SelectedCard.transform.GetChild(0).gameObject.transform.SetParent(CardsManager.Instance.gameObject.transform,false);
                     } else{
                            hand=GameObject.Find("Hand Player2");
                CardsManager.Instance.cardsPlayer2.Add(SelectedCard.transform.GetChild(0).gameObject);
                 card.Effect.Action(GameManager.Instance.Players[0],SelectedCard.transform.GetChild(0).gameObject.GetComponent<data>().card);
                 GameManager.Instance.Players[1].RefreshPoints();
                  SelectedCard.transform.GetChild(0).gameObject.transform.SetParent(hand.transform,false);
                     }
                 
             
                 
                 
               
                 
              }  

                 
               


               
          }    
             ReturnCardsToPosition(); 
              Panel.SetActive(false);
          
    }
       
        public void ReturnCardsToPosition(){
               GameObject MRow;
               GameObject RRow;
               GameObject SRow;
               
            if(GameManager.Instance.State== GameManager.GameState.Player1Turn && !GameManager.Instance.Pass[1]){
                MRow=GameObject.Find("M Player2");
                RRow=GameObject.Find("R Player2");
                SRow=GameObject.Find("S Player2");

                foreach (Transform card in AllCards.transform )
                {
                     if(card.gameObject.GetComponent<data>().card.Rows== Boards.Rows.M){
                        card.gameObject.transform.SetParent(MRow.transform,false);
                     } else if(card.gameObject.GetComponent<data>().card.Rows== Boards.Rows.R){
                         card.gameObject.transform.SetParent(RRow.transform,false);
                     } else if(card.gameObject.GetComponent<data>().card.Rows== Boards.Rows.S){
                         card.gameObject.transform.SetParent(SRow.transform,false);
                     }
                }
               } else  if(GameManager.Instance.State== GameManager.GameState.Player2Turn && !GameManager.Instance.Pass[0]){
                MRow=GameObject.Find("M Player1");
                RRow=GameObject.Find("R Player1");
                SRow=GameObject.Find("S Player1");

                foreach (Transform card in AllCards.transform )
                {
                     if(card.gameObject.GetComponent<data>().card.Rows== Boards.Rows.M){
                        card.gameObject.transform.SetParent(MRow.transform,false);
                     } else if(card.gameObject.GetComponent<data>().card.Rows== Boards.Rows.R){
                         card.gameObject.transform.SetParent(RRow.transform,false);
                     } else if(card.gameObject.GetComponent<data>().card.Rows== Boards.Rows.S){
                         card.gameObject.transform.SetParent(SRow.transform,false);
                     }
                }
               } else    if(GameManager.Instance.State== GameManager.GameState.Player1Turn && GameManager.Instance.Pass[1]){
                MRow=GameObject.Find("M Player1");
                RRow=GameObject.Find("R Player1");
                SRow=GameObject.Find("S Player1");

                foreach (Transform card in AllCards.transform )
                {
                     if(card.gameObject.GetComponent<data>().card.Rows== Boards.Rows.M){
                        card.gameObject.transform.SetParent(MRow.transform,false);
                     } else if(card.gameObject.GetComponent<data>().card.Rows== Boards.Rows.R){
                         card.gameObject.transform.SetParent(RRow.transform,false);
                     } else if(card.gameObject.GetComponent<data>().card.Rows== Boards.Rows.S){
                         card.gameObject.transform.SetParent(SRow.transform,false);
                     }
                }
               } else    if(GameManager.Instance.State== GameManager.GameState.Player2Turn && GameManager.Instance.Pass[0]){
                MRow=GameObject.Find("M Player2");
                RRow=GameObject.Find("R Player2");
                SRow=GameObject.Find("S Player2");

                foreach (Transform card in AllCards.transform )
                {
                     if(card.gameObject.GetComponent<data>().card.Rows== Boards.Rows.M){
                        card.gameObject.transform.SetParent(MRow.transform,false);
                     } else if(card.gameObject.GetComponent<data>().card.Rows== Boards.Rows.R){
                         card.gameObject.transform.SetParent(RRow.transform,false);
                     } else if(card.gameObject.GetComponent<data>().card.Rows== Boards.Rows.S){
                         card.gameObject.transform.SetParent(SRow.transform,false);
                     }
                }
               }
          }

       
}
