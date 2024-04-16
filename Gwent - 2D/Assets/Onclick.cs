using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Logic;
using Unity.VisualScripting;
using System.Runtime;
using System;
using UnityEditor.VersionControl;
using UnityEditor.SearchService;
using Microsoft.SqlServer.Server;

public class OnClick : MonoBehaviour
{
      
      public GameObject HandPlayer1;
      public GameObject HandPlayer2;


      private Players player1; 
      private Players player2; 
      GameObject[] prefabs;
      private GameObject [] cardsPlayer1;
      private GameObject [] cardsPlayer2;
       


        

    

     

    // Start is called before the first frame update
    void Start()
    {   
        // prefabs= Resources.LoadAll<GameObject>("Prefabs");
        // GameManager.Instance.updateState(GameManager.GameState.Start);
        //  player1=GameManager.Instance.Players[0];
        //  player2=GameManager.Instance.Players[1];
        //  //Cargo todas las cartas en los respectivos arrays de jugadores
        //  for(int i=0;i<player1.Hand.Count;i++){
        //    for(int j=0;j<prefabs.Length;j++){
             
        //      if( player1.Hand[i].Name==prefabs[j].name||player2.Hand[i].Name==prefabs[j].name ){
        //        if(player1.Hand[i].Name==prefabs[j].name){
        //          cardsPlayer1[i]=prefabs[j];
        //          cardsPlayer1[i].GetComponent<data>().card=player1.Hand[i];
        //          cardsPlayer1[i].GetComponent<data>().player=player1;

        //        }
        //        if(player2.Hand[i].Name==prefabs[j].name){
        //          cardsPlayer2[i]=prefabs[j];
        //          cardsPlayer2[i].GetComponent<data>().card=player2.Hand[i];
        //          cardsPlayer2[i].GetComponent<data>().player=player2;
        //        }
        //        break;
        //    }
        //  } 
        //  } 
         //Falta cambiar vizualisacion de cartas
       
   

       
         
          //  for(int i=0;i<player1.Hand.Count;i++){
          //      for(int j=0;j<prefabs.Length;j++){
                     
          //   if(GameManager.Instance.State==GameManager.GameState.Player1Turn) {
          //         if(player1.Hand[i].Name==prefabs[j].name){
          //          GameObject card=Instantiate(prefabs[j],new Vector3(0,0,0),Quaternion.identity);
          //          card.transform.SetParent(HandPlayer1.transform,false);
          //          card.GetComponent<data>().card=player1.Hand[i];
          //          cardsPlayer1[i]=card;
                   
          //          break;
          //        } 
          //            }
                
          //      }
          //  }
        
      //   } 



        
    }

    // Update is called once per frame
    void Update()
    { 
      //  GameManager.StateChanged+=ChangeCards;
      //  GameManager.StateChanged-=ChangeCards;
        
    }

    private void ChangeCards(GameManager.GameState state)
    {    Debug.Log("Cambio estado");
         if(state== GameManager.GameState.Player1Turn){
             foreach (GameObject card in cardsPlayer1 )
             {
                card.transform.SetParent(HandPlayer1.transform,false);
             }

              for(int i=0;i<HandPlayer2.transform.childCount;i++){
                 
                 Destroy(HandPlayer2.transform.GetChild(i));
                GameObject cardBack = Resources.Load<GameObject>("Prefabs/" + "CardBack");
                cardBack.transform.SetParent(HandPlayer2.transform,false);
                
                 
              }
         } 

          if(state== GameManager.GameState.player2Turn){
             foreach (GameObject card in cardsPlayer2)
             {
              card.transform.SetParent(HandPlayer2.transform,false);
             }

             for(int i=0;i<HandPlayer1.transform.childCount;i++){
              Destroy(HandPlayer1.transform.GetChild(i));
                GameObject cardBack = Resources.Load<GameObject>("Prefabs/" + "CardBack");
                cardBack.transform.SetParent(HandPlayer1.transform,false);
             }
          }
    }

    public void Onclick()
    { 
        if(HandPlayer1. transform.childCount<10 &&GameManager.Instance.State== GameManager.GameState.Player1Turn) {
         player1.InsertCardInHand();
      for(int i=0;i<prefabs.Length;i++){
        if(prefabs[i].name==player1.Hand[player1.Hand.Count-1].Name){
           
            GameObject card=Instantiate(prefabs[i],new Vector3(0,0,0),Quaternion.identity);
            card.transform.SetParent(HandPlayer1. transform,false);
            card.GetComponent<data>().card=player1.Hand[player1.Hand.Count-1];
            card.GetComponent<data>().player=player1;
            break;
            
        }
      }
      } else if(HandPlayer2.transform.childCount<10 && GameManager.Instance.State== GameManager.GameState.player2Turn){
        player2.InsertCardInHand();
         for(int i=0;i<prefabs.Length;i++){
             if(prefabs[i].name==player2.Hand[player2.Hand.Count-1].Name){
           
            GameObject card=Instantiate(prefabs[i],new Vector3(0,0,0),Quaternion.identity);
            card.transform.SetParent(HandPlayer2. transform,false);
            card.GetComponent<data>().card=player2.Hand[player2.Hand.Count-1];
            card.GetComponent<data>().player=player2;
            break;
            
        }
         }
      }
} 

  
}
