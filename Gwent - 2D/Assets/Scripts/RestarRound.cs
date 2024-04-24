using System.Collections;
using System.Collections.Generic;
using Logic;
using UnityEngine;

public class RestarRound : MonoBehaviour
{
    // Start is called before the first frame update
     public void Onclick(){
   
      GameManager.GameState state=GameManager.Instance.State;
      Players winplayer=GameManager.Instance.currentWinnerPlayer;
        GameObject board=GameObject.Find("Board");
       foreach (Transform child in board.transform)
      {   
          if(child.gameObject!=GameObject.Find("Heroe Player1") &&child.gameObject!=GameObject.Find("Heroe Player2")){
            for(int i=0;i<child.transform.childCount;i++){
           Destroy(child.GetChild(i).gameObject);
         }
          }
         
      }   
            if(state== GameManager.GameState.Player1Turn){
                if(winplayer== GameManager.Instance.Players[0]) GameManager.Instance.RotatePlayer1();
            } else if(state== GameManager.GameState.Player2Turn){
                if(winplayer== GameManager.Instance.Players[1]) GameManager.Instance.RotatePlayer2();
            } 
           
            
            GameManager.Instance.RoundWiner.SetActive(false);
           CardsManager.Instance.GameStar();
     }
}
