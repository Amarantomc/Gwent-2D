using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;
using System.Linq;
using System;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{   
   

   public static GameManager Instance;

   public GameState State; 

   public static event Action<GameState> StateChanged;

   public Players [] Players=new Players[2];
    
   public bool [] Pass=new bool[2];

   public int [] Wins=new int[2];

    public int Rounds=0; 

     public enum GameState{
      Start,
      Player1Turn,

      player2Turn,
      DecideWin

    }
    
    public GameObject canvas;



    
    void Awake(){
      Instance=this;
       
         
        
    }  
   


    public void updateState(GameState state){
      State=state;
      StateChanged?.Invoke(state);
       
       switch (state)
       { 
         case GameState.Start:
         GameStart();
         break;
         case GameState.Player1Turn:
         break;
         case GameState.player2Turn:
         Debug.Log("Cambiando");
       //Esta solucion para rotar pincha
         GameObject test=GameObject.Find("Board");
         foreach (Transform child in test.transform)
{
    child.transform.rotation = Quaternion.Euler(180, 0, 0);
}
         
         test.transform.rotation=Quaternion.Euler(180,0,0);
         
            
            

         break;
         case GameState.DecideWin:
         break;
         
         default: break;
       } 
          
      
 
    }

 
     
    void GameStart(){
            
      GameBase run=new GameBase();
       Players[0]=run.player1;
       Players[1]=run.player2;
       updateState(GameState.Player1Turn);
        
         
    } 

    public static void PlayCard(Card card){
         if(Instance.State==GameState.Player1Turn){
            Instance.Players[0].Board.SetCard(card,card.Rows);
            Instance.updateState(GameState.player2Turn);
         } else{
          Instance.Players[1].Board.SetCard(card,card.Rows);
            Instance.updateState(GameState.Player1Turn);

         }
    }

    void EffectActivation(Card card, Players player1, Players player2){
        
          if(card.Effect is DeleteMorePowerCard ||card.Effect is DeleteLessPowerCard ){
            card.Effect.Action(player2);
            Card card1=player2.Board[Boards.Rows.Graveyard][player2.Board[Boards.Rows.Graveyard].Count-1];
             GameObject row= GameObject.Find(card1.Rows.ToString());
            GameObject destroy=row.transform.Find(card1.Name+"(Clone)").gameObject;
            Destroy(destroy);
            } 

            if(card.Effect is DeleteCardInGame ){
              //Accion para seleccionar la carta
              GameObject cardSelected= GameObject.Find("EjemploCarta");//ejemplo
               card.Effect.Action(player2,cardSelected.GetComponent<data>().card);
               Destroy(cardSelected);
             
            }

    }

   


   
}
