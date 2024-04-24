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
            
            GameObject card=Instantiate(CardsManager.Instance.prefabs[i],new Vector3(0,0,0),Quaternion.identity);
            card.transform.SetParent(HandPlayer. transform,false);
            card.GetComponent<data>().card=player.Hand[player.Hand.Count-1];
            card.GetComponent<data>().player=player;
            
             if(GameManager.Instance.State== GameManager.GameState.Player1Turn){
             CardsManager.Instance.cardsPlayer1.Add(card);
        } else if(GameManager.Instance.State== GameManager.GameState.Player2Turn){
          CardsManager.Instance.cardsPlayer2.Add(card);
        }
            break;
            
        }
      }
      }  
} 

  
}
