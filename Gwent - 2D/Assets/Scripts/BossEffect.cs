using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEffect : MonoBehaviour
{
     public GameObject Text;

     public void Onclick(){
        Text.SetActive(true);
        StartCoroutine(Wait());
        if(GameManager.Instance.State== GameManager.GameState.Player1Turn){
            gameObject.GetComponent<data>().card=GameManager.Instance.Players[0].Board.GetBoardCard(Logic.Boards.Rows.Heroe,0);
            gameObject.GetComponent<data>().card.Effect.Action(GameManager.Instance.Players[0]);
            gameObject.GetComponent<Button>().enabled=false;
        } else if(GameManager.Instance.State == GameManager.GameState.Player2Turn){
            gameObject.GetComponent<data>().card=GameManager.Instance.Players[1].Board.GetBoardCard(Logic.Boards.Rows.Heroe,0);
            gameObject.GetComponent<data>().card.Effect.Action(GameManager.Instance.Players[1]);
            gameObject.GetComponent<Button>().enabled=false;
            

        }
         IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
         Text.SetActive(false);
    }
        
     }
}
