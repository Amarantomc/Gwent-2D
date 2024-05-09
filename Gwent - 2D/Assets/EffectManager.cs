using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;
using Unity.VisualScripting;

public class EffectManager : MonoBehaviour
{     
     private static GameManager game;
     public static EffectManager Instance;
     public  GameObject PanelForDelete;

     public GameObject Lure;

     public GameObject Increase;

     public GameObject Weather;
     public Card AuxCard;

     public bool [] ActiveWeatherPlayer1=new bool[3];
     public bool [] ActiveWeatherPlayer2=new bool[3];
     public bool [] ActiveIncreasePlayer1=new bool[3];
     public bool [] ActiveIncreasePlayer2=new bool[3];



 
     

     void Start(){
        game=GameManager.Instance;
        Instance=this;
         
         
     } 
 

      public void EffectActivation(Card card, Players player1, Players player2 ){
        AuxCard=card;
        
        if(card.Effect is SetLure && GameManager.Instance.State!= GameManager.GameState.InitialPlayer1 && GameManager.Instance.State!= GameManager.GameState.InitialPlayer2){
           Lure.SetActive(true);
           LurePanel.Instance.CardLoad();
          
           
        } else if(card.Effect is SetIncrease && GameManager.Instance.State!= GameManager.GameState.InitialPlayer1 && GameManager.Instance.State!= GameManager.GameState.InitialPlayer2){
           Increase.SetActive(true);
           IncreasePanel.Instance.SetCards();
        } else if(card.Effect is SetWeather && GameManager.Instance.State!= GameManager.GameState.InitialPlayer1 && GameManager.Instance.State!= GameManager.GameState.InitialPlayer2 ){
            Weather.SetActive(true);
            WeatherPanel.Instance.SetCards();
        }
            
      //   if(card.Effect is DeleteMorePowerCard ||card.Effect is DeleteLessPowerCard ){
      //       card.Effect.Action(player2);
      //       Card card1=player2.Board[Boards.Rows.Graveyard][player2.Board[Boards.Rows.Graveyard].Count-1];
      //          if(game.State== GameManager.GameState.Player1Turn){
      //         GameObject row= GameObject.Find(card1.Rows.ToString()+" Player2");
      //       GameObject destroy=row.transform.Find(card1.Name+"(Clone)").gameObject;
      //       GameObject graveyard= GameObject.Find("Graveyard Player2");
      //       destroy.transform.SetParent(graveyard.transform,false);
      //     }
          
          
      //      else if(game.State== GameManager.GameState.Player2Turn){
      //          GameObject row= GameObject.Find(card1.Rows.ToString()+" Player1");
      //       GameObject destroy=row.transform.Find(card1.Name+"(Clone)").gameObject;
      //       GameObject graveyard= GameObject.Find("Graveyard Player1");
      //       destroy.transform.SetParent(graveyard.transform,false);
      //     }

            
      //       } 

         else if(card.Effect is DeleteCardInGame && GameManager.Instance.State!= GameManager.GameState.InitialPlayer1 && GameManager.Instance.State!= GameManager.GameState.InitialPlayer2 ){
         
         PanelForDelete.gameObject.SetActive(true);
         DeletePanel.Instance.SetCards();
         
         

         
         // Instance.StartCoroutine(Instance.Wait());

         
          //   card.Effect.Action(player2);
          //   Card card1=player2.Board[Boards.Rows.Graveyard][player2.Board[Boards.Rows.Graveyard].Count-1];
          //     if(State== GameState.Player1Turn){
          //        GameObject row= GameObject.Find(card1.Rows.ToString()+" Player2");
          //       GameObject destroy=row.transform.Find(card1.Name+"(Clone)").gameObject;
          //       GameObject graveyard= GameObject.Find("Graveyard Player2");
          //        destroy.transform.SetParent(graveyard.transform,false);
          // }
            
            
          //  else if(State== GameState.Player2Turn){
          //   GameObject row= GameObject.Find(card1.Rows.ToString()+" Player1");
          //   GameObject destroy=row.transform.Find(card1.Name+"(Clone)").gameObject;
          //   GameObject graveyard= GameObject.Find("Graveyard Player1");
          //   destroy.transform.SetParent(graveyard.transform,false);
          // } 
                 

                 
      //        StartCoroutine(WaitForClick((clickedObject) => {
      //       // Aquí puedes hacer algo con clickedObject
      //       Debug.Log("Se hizo clic en " + clickedObject.name);
             
             

      //       // Aquí puedes poner el código que quieres que se ejecute después de que se haga clic en un objeto
      //   }));
        
         //   if(card1.GetComponent<data>().card!=null){
         //        if(card1.GetComponent<data>().card is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){
         //          GameObject graveyard= GameObject.Find("Graveyard Player1");
         //          card1.transform.SetParent(graveyard.transform,false);
         //          clickedCard=null;
                
         //        } else EffectActivation(card,player1,player2);
             
         //    } else EffectActivation(card,player1,player2);


         }

         //  else  if(card.Effect is Steal){
         //        //Devuelve una carta
         //        card.Effect.Action(player1);
         //        if(game.State== GameManager.GameState.Player1Turn){
         //           GameObject hand= GameObject.Find("Hand Player1");
         //           if(hand.transform.childCount<10){
         //              foreach (GameObject card1 in CardsManager.Instance.cardsPlayer1)
         //              {
         //                if(card1.name== player1.Hand[player1.Hand.Count-1].Name){
         //                  GameObject card2=Instantiate(card1,new Vector3(0,0,0),Quaternion.identity);
         //                   card2.transform.SetParent(hand. transform,false);
         //                   card2.GetComponent<data>().card=player1.Hand[player1.Hand.Count-1];
         //                   card2.GetComponent<data>().player=player1;
         //                   CardsManager.Instance.cardsPlayer1.Add(card2);
         //                  }
         //              }
         //           }
         //        }    else if(game.State== GameManager.GameState.Player2Turn){
         //           GameObject hand= GameObject.Find("Hand Player2");
         //           if(hand.transform.childCount<10){
         //              foreach (GameObject card1 in CardsManager.Instance.cardsPlayer1)
         //              {
         //                if(card1.name== player1.Hand[player1.Hand.Count-1].Name){
         //                  GameObject card2=Instantiate(card1,new Vector3(0,0,0),Quaternion.identity);
         //                   card2.transform.SetParent(hand. transform,false);
         //                   card2.GetComponent<data>().card=player1.Hand[player1.Hand.Count-1];
         //                   card2.GetComponent<data>().player=player1;
         //                   CardsManager.Instance.cardsPlayer2.Add(card2);
         //                  }
         //              }
         //           }
         //        } 
            
         //    }  else if(card.Effect is DeleteWeather){
         //       card.Effect.Action(player1,player2,card);
         //    } 
         //    else if(card.Effect is PlusOne){
         //      card.Effect.Action(player1,card);
         //    }
         //     else if(card.Effect is IncreaseRow2 || card.Effect is IncreaseRow4){
         //      card.Effect.Action(player1,card);
         //     } 
         //     else if(card.Effect is SetWeather2 || card.Effect is SetWeather4){
         //      card.Effect.Action(player1,player2,card);
         //     }
         //     else if(card.Effect is CleanRow){
         //       Boards.Rows row= card.Effect.Action2(player2);
         //       if(game.State==GameManager.GameState.Player1Turn){
         //         GameObject row2= GameObject.Find(row.ToString()+" Player2");
         //         GameObject graveyard= GameObject.Find("Graveyard Player2");
         //          foreach (GameObject card1 in row2.transform )
         //          {
         //             card1.transform.SetParent(graveyard.transform,false);
         //          }
         //       } else  if(game.State==GameManager.GameState.Player2Turn){
         //         GameObject row2= GameObject.Find(row.ToString()+" Player1");
         //         GameObject graveyard= GameObject.Find("Graveyard Player1");
         //          foreach (GameObject card1 in row2.transform )
         //          {
         //             card1.transform.SetParent(graveyard.transform,false);
         //          }
         //       }
               
         //     }
     
            
 


          

    }
      
      public void CheckWeather(Card card){
         GameObject weatherRow;
         Card weatherCard;
          if(card.Rows== Boards.Rows.M){
              if(ActiveWeatherPlayer1[0]){
               weatherRow=GameObject.Find("W1 Player1");
               weatherCard=weatherRow.transform.GetChild(0).gameObject.GetComponent<data>().card;
               weatherCard.Effect.Action(GameManager.Instance.Players[0],GameManager.Instance.Players[1], weatherCard);
              }  

              if(ActiveWeatherPlayer2[0]){
                weatherRow=GameObject.Find("W1 Player2");
               weatherCard=weatherRow.transform.GetChild(0).gameObject.GetComponent<data>().card;
               weatherCard.Effect.Action(GameManager.Instance.Players[0],GameManager.Instance.Players[1], weatherCard);
              }
              
      } else if(card.Rows== Boards.Rows.R){
             if(ActiveWeatherPlayer1[1]){
               weatherRow=GameObject.Find("W2 Player1");
               weatherCard=weatherRow.transform.GetChild(0).gameObject.GetComponent<data>().card;
               weatherCard.Effect.Action(GameManager.Instance.Players[0],GameManager.Instance.Players[1], weatherCard);
              }  

              if(ActiveWeatherPlayer2[1]){
                weatherRow=GameObject.Find("W2 Player2");
               weatherCard=weatherRow.transform.GetChild(0).gameObject.GetComponent<data>().card;
               weatherCard.Effect.Action(GameManager.Instance.Players[0],GameManager.Instance.Players[1], weatherCard);
              }
      } else if(card.Rows== Boards.Rows.S){
            if(ActiveWeatherPlayer1[2]){
               weatherRow=GameObject.Find("W3 Player1");
               weatherCard=weatherRow.transform.GetChild(0).gameObject.GetComponent<data>().card;
               weatherCard.Effect.Action(GameManager.Instance.Players[0],GameManager.Instance.Players[1], weatherCard);
              }  

              if(ActiveWeatherPlayer2[2]){
                weatherRow=GameObject.Find("W3 Player2");
               weatherCard=weatherRow.transform.GetChild(0).gameObject.GetComponent<data>().card;
               weatherCard.Effect.Action(GameManager.Instance.Players[0],GameManager.Instance.Players[1], weatherCard);
              }
      }
      } 

      public void CheckIncrease(Card card){
          GameObject increaseRow;
          Card increaseCard;
           if(GameManager.Instance.State== GameManager.GameState.Player1Turn){
               if(card.Rows== Boards.Rows.M && ActiveIncreasePlayer1[0]){
                 increaseRow=GameObject.Find("M Player1");
                 for(int i=0;i<increaseRow.transform.childCount;i++){
                     if(increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card is Increase){
                        increaseCard=increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card;
                        increaseCard.Effect.Action(GameManager.Instance.Players[0],increaseCard);
                     }
                 }
               } else   if(card.Rows== Boards.Rows.R && ActiveIncreasePlayer1[1]){
                 increaseRow=GameObject.Find("R Player1");
                 for(int i=0;i<increaseRow.transform.childCount;i++){
                     if(increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card is Increase){
                        increaseCard=increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card;
                        increaseCard.Effect.Action(GameManager.Instance.Players[0],increaseCard);
                     }
                 }
               } else   if(card.Rows== Boards.Rows.S && ActiveIncreasePlayer1[2]){
                 increaseRow=GameObject.Find("S Player1");
                 for(int i=0;i<increaseRow.transform.childCount;i++){
                     if(increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card is Increase){
                        increaseCard=increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card;
                        increaseCard.Effect.Action(GameManager.Instance.Players[0],increaseCard);
                     }
                 }
               }
                 
           } else   if(GameManager.Instance.State== GameManager.GameState.Player2Turn){
               if(card.Rows== Boards.Rows.M && ActiveIncreasePlayer2[0]){
                 increaseRow=GameObject.Find("M Player2");
                 for(int i=0;i<increaseRow.transform.childCount;i++){
                     if(increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card is Increase){
                        increaseCard=increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card;
                        increaseCard.Effect.Action(GameManager.Instance.Players[0],increaseCard);
                     }
                 }
               } else   if(card.Rows== Boards.Rows.R && ActiveIncreasePlayer2[1]){
                 increaseRow=GameObject.Find("R Player2");
                 for(int i=0;i<increaseRow.transform.childCount;i++){
                     if(increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card is Increase){
                        increaseCard=increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card;
                        increaseCard.Effect.Action(GameManager.Instance.Players[0],increaseCard);
                     }
                 }
               } else   if(card.Rows== Boards.Rows.S && ActiveIncreasePlayer2[2]){
                 increaseRow=GameObject.Find("S Player2");
                 for(int i=0;i<increaseRow.transform.childCount;i++){
                     if(increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card is Increase){
                        increaseCard=increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card;
                        increaseCard.Effect.Action(GameManager.Instance.Players[0],increaseCard);
                     }
                 }
               }
                 
           }
      }

}
