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
      
      public GameObject HandPlayer;
      Players player;

      public static OnClick Instance;


      void Awake(){
        Instance=this;
      }

       
        public void Onclick()
    {   
        if(GameManager.Instance.State== GameManager.GameState.Player1Turn){
          player= GameManager.Instance.Players[0];
        } else if(GameManager.Instance.State== GameManager.GameState.Player2Turn){
          player= GameManager.Instance.Players[1];
        }
        if(HandPlayer.transform.childCount<10 ) {
         player.InsertCardInHand();
      for(int i=0;i<CardsManager.Instance.prefabs.Length;i++){
        if(CardsManager.Instance.prefabs[i].name==player.Hand[player.Hand.Count-1].Name){
              if(GameManager.Instance.State== GameManager.GameState.Player1Turn){
             CardsManager.Instance.cardsPlayer1.Add(CardsManager.Instance.prefabs[i]);
             CardsManager.Instance.cardsPlayer1[CardsManager.Instance.cardsPlayer1.Count-1].GetComponent<data>().card=player.Hand[player.Hand.Count-1];
             CardsManager.Instance.cardsPlayer1[CardsManager.Instance.cardsPlayer1.Count-1].GetComponent<data>().player=player;
             GameObject card=Instantiate(CardsManager.Instance.prefabs[i],new Vector3(0,0,0),Quaternion.identity);
             card.GetComponent<data>().card=player.Hand[player.Hand.Count-1];
             card.GetComponent<data>().player=player;
            card.transform.SetParent(HandPlayer. transform,false);

        }  else if(GameManager.Instance.State== GameManager.GameState.Player2Turn){
           CardsManager.Instance.cardsPlayer2.Add(CardsManager.Instance.prefabs[i]);
             CardsManager.Instance.cardsPlayer2[CardsManager.Instance.cardsPlayer2.Count-1].GetComponent<data>().card=player.Hand[player.Hand.Count-1];
             CardsManager.Instance.cardsPlayer2[CardsManager.Instance.cardsPlayer2.Count-1].GetComponent<data>().player=player;
             GameObject card=Instantiate(CardsManager.Instance.prefabs[i],new Vector3(0,0,0),Quaternion.identity);
             card.GetComponent<data>().card=player.Hand[player.Hand.Count-1];
             card.GetComponent<data>().player=player;
            card.transform.SetParent(HandPlayer. transform,false);
        }
             
            
         
            break;
            
        }
      }
      }  
}  

 

  
}
