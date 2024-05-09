using System.Collections;
using System.Collections.Generic;
using Logic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
   public GameObject Panel;
    public GameObject DeleteCard;
    public GameObject AllCards;

     
      
    public void Onclick(){
         if(DeleteCard.transform.childCount!=0){
             Card card=DeleteCard.transform.GetChild(0).gameObject.GetComponent<data>().card;
             Card card1=EffectManager.Instance.AuxCard;
              if(card is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){
               
                   if(GameManager.Instance.State== GameManager.GameState.Player1Turn){
                    if(!GameManager.Instance.Pass[1]){
                      card1.Effect.Action(GameManager.Instance.Players[0],card);
                    GameManager.Instance.Players[0].RefreshPoints();
                     GameObject grave=GameObject.Find("Graveyard Player1");
                  if(grave.transform.childCount!=0){
                     Destroy(grave.transform.GetChild(0).gameObject);
                     DeleteCard.transform.GetChild(0).gameObject.transform.SetParent(grave.transform,false);
                  } else{
                    DeleteCard.transform.GetChild(0).gameObject.transform.SetParent(grave.transform,false);
                  }
                    } else{
                          card1.Effect.Action(GameManager.Instance.Players[1],card);
                    GameManager.Instance.Players[1].RefreshPoints();
                 GameObject grave=GameObject.Find("Graveyard Player2");
                  if(grave.transform.childCount!=0){
                     Destroy(grave.transform.GetChild(0).gameObject);
                     DeleteCard.transform.GetChild(0).gameObject.transform.SetParent(grave.transform,false);
                  } else{
                    DeleteCard.transform.GetChild(0).gameObject.transform.SetParent(grave.transform,false);
                  }
                    }
                   
             } else if(GameManager.Instance.State== GameManager.GameState.Player2Turn){
                  if(!GameManager.Instance.Pass[0]){
                      card1.Effect.Action(GameManager.Instance.Players[1],card);
                  GameManager.Instance.Players[1].RefreshPoints();
                  GameObject grave=GameObject.Find("Graveyard Player2");
                    if(grave.transform.childCount!=0){
                     Destroy(grave.transform.GetChild(0).gameObject);
                     DeleteCard.transform.GetChild(0).gameObject.transform.SetParent(grave.transform,false);
                  } else{
                    DeleteCard.transform.GetChild(0).gameObject.transform.SetParent(grave.transform,false);
                  }
                  } else{
                    card1.Effect.Action(GameManager.Instance.Players[0],card);
                  GameManager.Instance.Players[0].RefreshPoints();
                  GameObject grave=GameObject.Find("Graveyard Player1");
                    if(grave.transform.childCount!=0){
                     Destroy(grave.transform.GetChild(0).gameObject);
                     DeleteCard.transform.GetChild(0).gameObject.transform.SetParent(grave.transform,false);
                  } else{
                    DeleteCard.transform.GetChild(0).gameObject.transform.SetParent(grave.transform,false);
                  }
                  }
                  
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
               } else  if(GameManager.Instance.State== GameManager.GameState.Player2Turn && !GameManager.Instance.Pass[0]){
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
               } else     if(GameManager.Instance.State== GameManager.GameState.Player1Turn && GameManager.Instance.Pass[1]){
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
               } else     if(GameManager.Instance.State== GameManager.GameState.Player2Turn && GameManager.Instance.Pass[0]){
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
               }
          }
       

     
}
