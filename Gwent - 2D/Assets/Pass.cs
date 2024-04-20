using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : MonoBehaviour
{
    public void PassTurn(){
        GameManager.GameState state=GameManager.Instance.State;
        if(state== GameManager.GameState.Player1Turn){
            GameManager.Instance.Pass[0]=true;
            if(!GameManager.Instance.Pass[1]) GameManager.Instance.RotatePlayer2();

            GameManager.Instance.updateState(GameManager.GameState.Player2Turn);
        } else if(state == GameManager.GameState.Player2Turn){
            GameManager.Instance.Pass[1]=true;
            if(!GameManager.Instance.Pass[0]) GameManager.Instance.RotatePlayer1();

            GameManager.Instance.updateState(GameManager.GameState.Player1Turn);
        }
    }
}
