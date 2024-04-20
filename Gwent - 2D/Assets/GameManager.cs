using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;

using System.Linq;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
   

   public static GameManager Instance;

   public GameState State; 

   public static event Action<GameState> StateChanged;

   public Players [] Players=new Players[2];
    
   public bool [] Pass=new bool[2];

   public int [] Wins=new int[2];

    public int Rounds=0;
    GameObject deck1Button;
    GameObject deck2Button;


     public enum GameState{
      Start,
      Player1Turn,

      Player2Turn,
      DecideRoundWinner,
      DecideWin

    }
    
    public GameObject canvas;



    
    void Awake(){
      Instance=this;
      deck1Button=GameObject.Find("Deck Player1");
      deck2Button= GameObject.Find("Deck Player2");
       
         
        
    }  
   


    public void updateState(GameState state){
      State=state;
   
      
       
       switch (state)
       { 
         case GameState.Start:
         GameStart();
         break;
         case GameState.Player1Turn:
         CardsManager.Instance.ChangeCard(state);
         updateDeckButton(state);
         if(CheckPass()) updateState(GameState.DecideRoundWinner);
          
         break;
         case GameState.Player2Turn:
         
       CardsManager.Instance.ChangeCard(state);
       updateDeckButton(state);
       if(CheckPass()) updateState(GameState.DecideRoundWinner);
         
            
            

         break;
         case GameState.DecideRoundWinner:
          DecideRoundWinner();
          if(Wins.Contains(2)) updateState(GameState.DecideWin);
          break;
         case GameState.DecideWin:
         Players player=DecideWinner();
         
         break;
         
         default: break;
       } 
          
      
 
    }

 
     
    void GameStart(){
            
      GameBase run=new GameBase();
       Players[0]=run.player1;
       Players[1]=run.player2;
       
        
         
    }  

     public void RotatePlayer2(){
       
     GameObject board=GameObject.Find("Board");
     foreach (Transform child in board.transform)
{
    child.transform.rotation = Quaternion.Euler(180, 0, 0);
}
         
    board.transform.rotation=Quaternion.Euler(180,0,0);

     } 
          public void RotatePlayer1(){
            
      
     GameObject board=GameObject.Find("Board");
     foreach (Transform child in board.transform)
{
    child.transform.rotation = Quaternion.Euler(-180, 0, 0);
}
         
   board.transform.rotation=Quaternion.Euler(0,0,0);

     }

    public static void PlayCard(GameObject card){
         Card card1=card.GetComponent<data>().card;
           
         
         if(Instance.State==GameState.Player1Turn){
            Instance.Players[0].Board.SetCard(card1,card1.Rows);
            Instance.Players[0].DeleteCardInHand(card1);
            Instance.Players[0].RefreshPoints();
            
            CardsManager.Instance.RemoveCard(card, GameState.Player1Turn);
            if(!Instance.Pass[1]){
              Instance.RotatePlayer2();
            Instance.updateState(GameState.Player2Turn);
             
            }
         } else{
          Instance.Players[1].Board.SetCard(card1,card1.Rows);
          Instance.Players[1].DeleteCardInHand(card1);
          Instance.Players[1].RefreshPoints();
 
          CardsManager.Instance.RemoveCard(card, GameState.Player2Turn);
          if(!Instance.Pass[0]){
            Instance.RotatePlayer1();
            Instance.updateState(GameState.Player1Turn);
            
          }

         }
    }  
       void updateDeckButton(GameState state){
          if(state== GameState.Player1Turn){
             deck1Button.GetComponent<Button>().interactable=true;
             deck2Button.GetComponent<Button>().interactable=false; 
          } else if( state== GameState.Player2Turn){
            deck1Button.GetComponent<Button>().interactable=false;
             deck2Button.GetComponent<Button>().interactable=true;
          }
       }
     
       bool CheckPass(){
          if(Pass.Contains(false)) return false;
          return true;
       } 
        
        void DecideRoundWinner(){
          Rounds++;
           if(Players[0].Points>Players[1].Points){
             Wins[0]++;
           } else if(Players[0].Points<Players[1].Points){
             Wins[1]++;
           }
        }

        Players DecideWinner(){
           int index=0;
           if(Wins[0]==2) index=0;
           if(Wins[1]==2) index=1;
           return Players[index];
        }
    void EffectActivation(Card card, Players player1, Players player2){
          
          if(card.Effect is DeleteMorePowerCard ||card.Effect is DeleteLessPowerCard ){
            card.Effect.Action(player2);
            Card card1=player2.Board[Boards.Rows.Graveyard][player2.Board[Boards.Rows.Graveyard].Count-1];
               if(State== GameState.Player1Turn){
              GameObject row= GameObject.Find(card1.Rows.ToString()+" Player2");
            GameObject destroy=row.transform.Find(card1.Name+"(Clone)").gameObject;
            GameObject graveyard= GameObject.Find("Graveyard Player2");
            destroy.transform.SetParent(graveyard.transform,false);
          }
          
          
           else if(State== GameState.Player2Turn){
               GameObject row= GameObject.Find(card1.Rows.ToString()+" Player1");
            GameObject destroy=row.transform.Find(card1.Name+"(Clone)").gameObject;
            GameObject graveyard= GameObject.Find("Graveyard Player1");
            destroy.transform.SetParent(graveyard.transform,false);
          }

            
            } 

          if(card.Effect is DeleteCardInGame ){
            card.Effect.Action(player2);
            Card card1=player2.Board[Boards.Rows.Graveyard][player2.Board[Boards.Rows.Graveyard].Count-1];
              if(State== GameState.Player1Turn){
                 GameObject row= GameObject.Find(card1.Rows.ToString()+" Player2");
                GameObject destroy=row.transform.Find(card1.Name+"(Clone)").gameObject;
                GameObject graveyard= GameObject.Find("Graveyard Player2");
                 destroy.transform.SetParent(graveyard.transform,false);
          }
            
            
           else if(State== GameState.Player2Turn){
            GameObject row= GameObject.Find(card1.Rows.ToString()+" Player1");
            GameObject destroy=row.transform.Find(card1.Name+"(Clone)").gameObject;
            GameObject graveyard= GameObject.Find("Graveyard Player1");
            destroy.transform.SetParent(graveyard.transform,false);
          }
               
             
            } 

            if(card.Effect is Steal){
               card.Effect.Action(player1);
                if(State== GameState.Player1Turn){
                   GameObject hand= GameObject.Find("Hand Player1");
                   if(hand.transform.childCount<10){
                      foreach (GameObject card1 in CardsManager.Instance.cardsPlayer1)
                      {
                        if(card1.name== player1.Hand[player1.Hand.Count-1].Name){
                          GameObject card2=Instantiate(card1,new Vector3(0,0,0),Quaternion.identity);
                           card2.transform.SetParent(hand. transform,false);
                           card2.GetComponent<data>().card=player1.Hand[player1.Hand.Count-1];
                           card2.GetComponent<data>().player=player1;
                           CardsManager.Instance.cardsPlayer1.Add(card2);
                          }
                      }
                   }
                }    else if(State== GameState.Player2Turn){
                   GameObject hand= GameObject.Find("Hand Player2");
                   if(hand.transform.childCount<10){
                      foreach (GameObject card1 in CardsManager.Instance.cardsPlayer1)
                      {
                        if(card1.name== player1.Hand[player1.Hand.Count-1].Name){
                          GameObject card2=Instantiate(card1,new Vector3(0,0,0),Quaternion.identity);
                           card2.transform.SetParent(hand. transform,false);
                           card2.GetComponent<data>().card=player1.Hand[player1.Hand.Count-1];
                           card2.GetComponent<data>().player=player1;
                           CardsManager.Instance.cardsPlayer2.Add(card2);
                          }
                      }
                   }
                } 
            
            }  else if(card.Effect is DeleteWeather){
               card.Effect.Action(player1,player2,card);
            } 
            else if(card.Effect is PlusOne){
              card.Effect.Action(player1,card);
            }
             else if(card.Effect is IncreaseRow2 || card.Effect is IncreaseRow4){
              card.Effect.Action(player1,card);
             } 
             else if(card.Effect is SetWeather2 || card.Effect is SetWeather4){
              card.Effect.Action(player1,player2,card);
             }
             else if(card.Effect is CleanRow){
               Boards.Rows row= card.Effect.Action2(player2);
               if(State== GameState.Player1Turn){
                 GameObject row2= GameObject.Find(row.ToString()+" Player2");
                 GameObject graveyard= GameObject.Find("Graveyard Player2");
                  foreach (GameObject card1 in row2.transform )
                  {
                     card1.transform.SetParent(graveyard.transform,false);
                  }
               } else  if(State== GameState.Player2Turn){
                 GameObject row2= GameObject.Find(row.ToString()+" Player1");
                 GameObject graveyard= GameObject.Find("Graveyard Player1");
                  foreach (GameObject card1 in row2.transform )
                  {
                     card1.transform.SetParent(graveyard.transform,false);
                  }
               }
               
             }

    }

   


   
}
