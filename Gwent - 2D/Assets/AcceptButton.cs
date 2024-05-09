using System.Collections;
using System.Collections.Generic;
using Logic;
using UnityEngine;

public class AcceptButton : MonoBehaviour
{

   public GameObject HandCards;

   public GameObject SelectedCards;
   private  GameObject hand;

  public void Onclick(){
        
        if(GameManager.Instance.State== GameManager.GameState.InitialPlayer1){
             hand=GameObject.Find("Hand Player1");
             if(SelectedCards.transform.childCount!=0){
             foreach (Transform child in SelectedCards.transform)
             {
                Card card=child.gameObject.GetComponent<data>().card;
                CardsManager.Instance.RemoveCard(child.gameObject,GameManager.Instance.State);
                GameManager.Instance.Players[0].Deck.Insert(card);
                GameManager.Instance.Players[0].DeleteCardInHand(card);
                Destroy(child.gameObject);
                GameManager.Instance.Players[0].InsertCardInHand();
                for(int i=0;i<CardsManager.Instance.prefabs.Length;i++){
                     if(CardsManager.Instance.prefabs[i].name==GameManager.Instance.Players[0].Hand[GameManager.Instance.Players[0].Hand.Count-1].Name ){
                         CardsManager.Instance.cardsPlayer1.Add(CardsManager.Instance.prefabs[i]);
                          
                         CardsManager.Instance.cardsPlayer1[ CardsManager.Instance.cardsPlayer1.Count-1] .GetComponent<data>().card=GameManager.Instance.Players[0].Hand[GameManager.Instance.Players[0].Hand.Count-1];
                         CardsManager.Instance.cardsPlayer1[ CardsManager.Instance.cardsPlayer1.Count-1] .GetComponent<data>().player=GameManager.Instance.Players[0];
                         break;
                     }
                }
             }  

               

              
        }   while(HandCards.transform.childCount!=0){
                   HandCards.transform.GetChild(0).gameObject.transform.SetParent(hand.transform,false);
               }
             
           GameManager.Instance.updateState(GameManager.GameState.Player1Turn);
        } else  if(GameManager.Instance.State== GameManager.GameState.InitialPlayer2){
             hand=GameObject.Find("Hand Player2");
             if(SelectedCards.transform.childCount!=0){
             foreach (Transform child in SelectedCards.transform)
             {
                Card card=child.gameObject.GetComponent<data>().card;
                CardsManager.Instance.RemoveCard(child.gameObject,GameManager.Instance.State);

                GameManager.Instance.Players[1].Deck.Insert(card);
                GameManager.Instance.Players[1].DeleteCardInHand(card);
                Destroy(child.gameObject);
                GameManager.Instance.Players[1].InsertCardInHand();
                for(int i=0;i<CardsManager.Instance.prefabs.Length;i++){
                     if(CardsManager.Instance.prefabs[i].name==GameManager.Instance.Players[1].Hand[GameManager.Instance.Players[1].Hand.Count-1].Name ){
                         CardsManager.Instance.cardsPlayer2.Add(CardsManager.Instance.prefabs[i]);
                          
                         CardsManager.Instance.cardsPlayer2[CardsManager.Instance.cardsPlayer2.Count-1].GetComponent<data>().card=GameManager.Instance.Players[1].Hand[GameManager.Instance.Players[1].Hand.Count-1];
                         CardsManager.Instance.cardsPlayer2[CardsManager.Instance.cardsPlayer2.Count-1] .GetComponent<data>().player=GameManager.Instance.Players[1];

                         break;
                     }
                }
             }
              
        }     while(HandCards.transform.childCount!=0){
                   HandCards.transform.GetChild(0).gameObject.transform.SetParent(hand.transform,false);
               }
        
            GameManager.Instance.updateState(GameManager.GameState.Player2Turn);
        }  
        
        
        InicialCards.Instance.gameObject.SetActive(false);
       

   }
}
