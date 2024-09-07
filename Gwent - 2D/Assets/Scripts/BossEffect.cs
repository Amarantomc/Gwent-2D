using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEffect : MonoBehaviour
{
     public GameObject Text;

     public void Onclick(){

         
        
        if(GameManager.Instance.State== GameManager.GameState.Player1Turn){
            gameObject.GetComponent<data>().card=GameManager.Instance.Players[0].Board.GetBoardCard(Boards.Rows.Heroe,0);
            var card=gameObject.GetComponent<data>().card;
            if(card.Effect is CompilerEffects) EffectManager.Instance.EffectActivation(card,GameManager.Instance.Players[0],GameManager.Instance.Players[1]);
            else {
                card.Effect.Action(GameManager.Instance.Players[0]);
                Text.SetActive(true);
                StartCoroutine(Wait());
                }
                gameObject.GetComponent<Button>().enabled=false;
                GameManager.Instance.BossActivation[0]=true;
            
        } else if(GameManager.Instance.State == GameManager.GameState.Player2Turn){
            gameObject.GetComponent<data>().card=GameManager.Instance.Players[1].Board.GetBoardCard(Boards.Rows.Heroe,0);
            var card=gameObject.GetComponent<data>().card;

            if(card.Effect is CompilerEffects) EffectManager.Instance.EffectActivation(card,GameManager.Instance.Players[1],GameManager.Instance.Players[0]);
            
            else{
                card.Effect.Action(GameManager.Instance.Players[1]);
                Text.SetActive(true);
                StartCoroutine(Wait());
            }

            
            gameObject.GetComponent<Button>().enabled=false;
            GameManager.Instance.BossActivation[1]=true;

            

        }
         IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
         Text.SetActive(false);
    }
        
     }
}
