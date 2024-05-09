using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;

public class Cancel : MonoBehaviour
{   

    public GameObject Panel;

    public GameObject AllCards;
    public void Onclick(){
        ReturnCardsToPosition();
        Panel.SetActive(false);
    }

     private void ReturnCardsToPosition(){
               GameObject MRow;
               GameObject RRow;
               GameObject SRow;
               
            if(GameManager.Instance.State== GameManager.GameState.Player1Turn){
                MRow=GameObject.Find("M Player1");
                RRow=GameObject.Find("R Player1");
                SRow=GameObject.Find("S Player1");

                foreach (Transform card in AllCards.transform )
                {
                     if(card.GetComponent<data>().card.Rows== Boards.Rows.M){
                        card.transform.SetParent(MRow.transform,false);
                     } else if(card.GetComponent<data>().card.Rows== Boards.Rows.R){
                         card.transform.SetParent(RRow.transform,false);
                     } else if(card.GetComponent<data>().card.Rows== Boards.Rows.S){
                         card.transform.SetParent(SRow.transform,false);
                     }
                }
               } else  if(GameManager.Instance.State== GameManager.GameState.Player2Turn){
                MRow=GameObject.Find("M Player2");
                RRow=GameObject.Find("R Player2");
                SRow=GameObject.Find("S Player2");

                foreach (Transform card in AllCards.transform )
                {
                     if(card.GetComponent<data>().card.Rows== Boards.Rows.M){
                        card.transform.SetParent(MRow.transform,false);
                     } else if(card.GetComponent<data>().card.Rows== Boards.Rows.R){
                         card.transform.SetParent(RRow.transform,false);
                     } else if(card.GetComponent<data>().card.Rows== Boards.Rows.S){
                         card.transform.SetParent(SRow.transform,false);
                     }
                }
               }
          }
}
