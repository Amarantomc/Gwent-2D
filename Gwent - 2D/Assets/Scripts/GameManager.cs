using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Logic;

using System.Linq;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{   
   

   public static GameManager Instance;

   public GameState State; 

  

   public Players [] Players=new Players[2];
    
   public bool [] Pass=new bool[2];

   public int [] Wins=new int[2];

   public bool [] BossActivation=new bool[2];

    public int Rounds=0;
    GameObject deck1Button;
    GameObject deck2Button;

    GameObject boss1Button;
    GameObject boss2Button;

    public GameObject RoundWiner;

    public GameObject GameWiner;

     

    public Players currentWinnerPlayer;


     public enum GameState{
      Start,

      InitialPlayer1,

      InitialPlayer2,
      Player1Turn,

      Player2Turn,
      DecideRoundWinner,
      DecideWin

    }
    
    public GameObject canvas;

    public GameObject InitialTurn;
    public bool initialPlayer1;

    public bool initialPlayer2; 
 
    void Awake(){
      Instance=this;
      initialPlayer1=true;
      initialPlayer2=true;
      deck1Button=GameObject.Find("Deck Player1");
      deck2Button= GameObject.Find("Deck Player2");
      boss1Button=GameObject.Find("CJ");
      boss2Button=GameObject.Find("Joel Miller");
      currentWinnerPlayer=new Players(new Decks(new WeatherCard("test","test", new NoEffect()),new WeatherCard("test","test", new NoEffect())),new Boards());

      
       
         
        
    } 

    
   


    public void updateState(GameState state){
      State=state;
   
      
       
       switch (state)
       { 
         case GameState.Start:
         GameStart();
         break;

         case GameState.InitialPlayer1:
          
         CardsManager.Instance.ChangeCard(state);
         initialPlayer1=false;
         InitialTurn.SetActive(true);
         InicialCards.Instance.SetCards();
         break;

         case GameState.InitialPlayer2:
          
         CardsManager.Instance.ChangeCard(state);
         initialPlayer2=false;
         InitialTurn.SetActive(true);
         InicialCards.Instance.SetCards();
         break;
        
         case GameState.Player1Turn:
         if(CheckPass()){
          Players players= DecideRoundWinner();
          if(Wins.Contains(2)){
            updateState(GameState.DecideWin);
            break;
          } 
          ShowRoundWinner(players);
          break;
         } 
          CardsManager.Instance.ChangeCard(state);
         updateDeckButton(state);
           
         break;
       
         case GameState.Player2Turn:
        if(CheckPass()){
           Players players= DecideRoundWinner();
          if(Wins.Contains(2)) {
             updateState(GameState.DecideWin);
             break;
          }
          ShowRoundWinner(players);
          break;
        }
         CardsManager.Instance.ChangeCard(state);
         updateDeckButton(state);
         
           

         break;
      
         
         case GameState.DecideWin:
         Players player=DecideWinner();
         ShowWinner(player);
         
         
         break;
         
         default: break;
       } 
          
      
 
    }

 
     
    void GameStart(){
       
      Pass=new bool[2];
      BossActivation=new bool[2];
      
       GameBase run=new GameBase();
       Players[0]=run.player1;
       Players[1]=run.player2;
       Players[0].Points+=30;
       Players[1].Points+=30;
       initialPlayer1=true;
       initialPlayer2=true;
       
       
        
         
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
            
            
            
            CardsManager.Instance.RemoveCard(card, GameState.Player1Turn);
            EffectManager.Instance.CheckIncrease(card1);
            EffectManager.Instance.CheckWeather(card1);
 
          EffectManager.Instance.EffectActivation(card1,Instance.Players[0],Instance.Players[1]);
        // Instance.Players[0].RefreshPoints();
     
    
     if(!Instance.Pass[1]){
            Instance.RotatePlayer2();
            if(Instance.initialPlayer2) Instance.updateState(GameState.InitialPlayer2);
            else Instance.updateState(GameState.Player2Turn);
            
          }
          
       }  else{
          Instance.Players[1].Board.SetCard(card1,card1.Rows);
          Instance.Players[1].DeleteCardInHand(card1);
          

 
          CardsManager.Instance.RemoveCard(card, GameState.Player2Turn);
          EffectManager.Instance.CheckIncrease(card1);
            EffectManager.Instance.CheckWeather(card1);
             EffectManager.Instance.EffectActivation(card1,Instance.Players[1],Instance.Players[0]);  

         // Instance.Players[1].RefreshPoints();
     
     if(!Instance.Pass[0]){
            Instance.RotatePlayer1();
            if(Instance.initialPlayer1) Instance.updateState(GameState.InitialPlayer1);
           else Instance.updateState(GameState.Player1Turn);
            
          }
  



         

         }
    }  
       void updateDeckButton(GameState state){
          if(state== GameState.Player1Turn){
             deck1Button.GetComponent<Button>().enabled=true;
             deck2Button.GetComponent<Button>().enabled=false; 
             boss2Button.GetComponent<Button>().enabled=false;
             if(!BossActivation[0]) boss1Button.GetComponent<Button>().enabled=true;
             
             
          } else if( state== GameState.Player2Turn){
            deck1Button.GetComponent<Button>().enabled=false;
             deck2Button.GetComponent<Button>().enabled=true;
             boss1Button.GetComponent<Button>().enabled=false;
             if(!BossActivation[1])boss2Button.GetComponent<Button>().enabled=true;
              
             
          }
       }
     
       bool CheckPass(){
          if(Pass.Contains(false)) return false;
          return true;
       } 
        
        Players DecideRoundWinner(){
          Rounds++;
           if(Players[0].Points>=Players[1].Points){
             Wins[0]++;
             
             currentWinnerPlayer=Players[0];
             
             return Players[0];
           } else if(Players[0].Points<Players[1].Points){
             Wins[1]++;
             
             currentWinnerPlayer=Players[1];

             return Players[1];
           }
           return Players[0];
        } 

        void ShowRoundWinner(Players players){
         
         RoundWiner.SetActive(true);
         string text="";
         if(players==Players[0]) text="Player1";
         else text="Player2";
         RoundWiner.transform.GetComponentInChildren<TMP_Text>().text=text;
         
      } 

        Players DecideWinner(){
           int index=0;
           if(Wins[0]==2) index=0;
           if(Wins[1]==2) index=1;
           return Players[index];
        }  

        void ShowWinner(Players players){
          GameWiner.SetActive(true);
          string text="";
         if(players==Players[0]) text="Player1";
         else text="Player2";
          
          GameWiner.transform.GetComponentInChildren<TMP_Text>().text=text;
           
          

        }

         


      

     

 
   

   


   
}
