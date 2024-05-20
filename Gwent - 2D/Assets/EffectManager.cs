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
            
        if((card.Effect is DeleteMorePowerCard ||card.Effect is DeleteLessPowerCard) && GameManager.Instance.State!= GameManager.GameState.InitialPlayer1 && GameManager.Instance.State!= GameManager.GameState.InitialPlayer2  ){
           Card card1= card.Effect.Action(player2);
           if(card1!=null){
              Card card2=player2.Board[Boards.Rows.Graveyard][player2.Board[Boards.Rows.Graveyard].Count-1];
               if(game.State== GameManager.GameState.Player1Turn){
              GameObject row= GameObject.Find(card2.Rows.ToString()+" Player2");
            GameObject destroy=row.transform.Find(card2.Name+"(Clone)").gameObject;
            GameObject graveyard= GameObject.Find("Graveyard Player2");
             if(graveyard.transform.childCount!=0){
                Destroy(graveyard.transform.GetChild(0).gameObject);
                destroy.transform.SetParent(graveyard.transform,false);
             } else
            destroy.transform.SetParent(graveyard.transform,false);
          }
          
          
           else if(game.State== GameManager.GameState.Player2Turn){
               GameObject row= GameObject.Find(card2.Rows.ToString()+" Player1");
            GameObject destroy=row.transform.Find(card2.Name+"(Clone)").gameObject;
            GameObject graveyard= GameObject.Find("Graveyard Player1");
             if(graveyard.transform.childCount!=0){
                Destroy(graveyard.transform.GetChild(0).gameObject);
                destroy.transform.SetParent(graveyard.transform,false);
             } else
            destroy.transform.SetParent(graveyard.transform,false);
          }
           }
            

            
            } 

         else if(card.Effect is DeleteCardInGame && GameManager.Instance.State!= GameManager.GameState.InitialPlayer1 && GameManager.Instance.State!= GameManager.GameState.InitialPlayer2 ){
         
         PanelForDelete.gameObject.SetActive(true);
         DeletePanel.Instance.SetCards();
        }

          else  if(card.Effect is Steal){
                 Card card3=card.Effect.Action(player1);
                 if(card3!=null){
                     if(game.State== GameManager.GameState.Player1Turn){
                   GameObject hand= GameObject.Find("Hand Player1");
                   if(hand.transform.childCount<10){
                      foreach (GameObject card1 in CardsManager.Instance.prefabs)
                      {
                        if(card1.name== card3.Name){
                           
                           card1.GetComponent<data>().card=card3;
                           card1.GetComponent<data>().player=player1;
                           CardsManager.Instance.cardsPlayer1.Add(card1);
                           break;
                          }
                      }
                   }
                }    else if(game.State== GameManager.GameState.Player2Turn){
                   GameObject hand= GameObject.Find("Hand Player2");
                   if(hand.transform.childCount<10){
                      foreach (GameObject card1 in CardsManager.Instance.prefabs)
                      {
                        if(card1.name== card3.Name){
                           
                           card1.GetComponent<data>().card=card3;
                           card1.GetComponent<data>().player=player1;
                           CardsManager.Instance.cardsPlayer2.Add(card1);
                           break;
                          }
                      }
                   }
                } 
                 }
               
            
            }  else if(card.Effect is DeleteWeather && GameManager.Instance.State!= GameManager.GameState.InitialPlayer1 && GameManager.Instance.State!= GameManager.GameState.InitialPlayer2){
                Boards.Rows row=card.Rows;
                GameObject weather =GameObject.Find("W1 Player1");
                if(row == Boards.Rows.M){
                   if(GameObject.Find("W1 Player1").transform.childCount!=0){
                     weather=GameObject.Find("W1 Player1").transform.GetChild(0).gameObject;
                     ActiveWeatherPlayer1[0]=false;
                   } else if(GameObject.Find("W1 Player2").transform.childCount!=0){
                     weather=GameObject.Find("W1 Player2").transform.GetChild(0).gameObject;
                     ActiveWeatherPlayer2[0]=false;
                   } else weather=null!;
                }   
                else if(row == Boards.Rows.R){
                   if(GameObject.Find("W2 Player1").transform.childCount!=0){
                     weather=GameObject.Find("W2 Player1").transform.GetChild(0).gameObject;
                      ActiveWeatherPlayer1[1]=false;
                   } else if(GameObject.Find("W2 Player2").transform.childCount!=0){
                     weather=GameObject.Find("W2 Player2").transform.GetChild(0).gameObject;
                     ActiveWeatherPlayer2[1]=false;
                   } else weather=null!;
                } else if(row == Boards.Rows.S){
                   if(GameObject.Find("W3 Player1").transform.childCount!=0){
                     weather=GameObject.Find("W3 Player1").transform.GetChild(0).gameObject;
                      ActiveWeatherPlayer1[2]=false;
                   } else if(GameObject.Find("W3 Player2").transform.childCount!=0){
                     weather=GameObject.Find("W3 Player2").transform.GetChild(0).gameObject;
                     ActiveWeatherPlayer2[2]=false;
                   } else weather=null!;
                } 
                  if(weather!=null){
                       GameObject graveyard;
                       if(player1.Board.ContainsCard(weather.GetComponent<data>().card.Rows,weather.GetComponent<data>().card)){
                           player1.Board.DeleteBoardCard(weather.GetComponent<data>().card.Rows,weather.GetComponent<data>().card);
                           graveyard=GameObject.Find("Graveyard Player1"); 
                           if(graveyard.transform.childCount!=0){
                               Destroy(graveyard.transform.GetChild(0).gameObject);
                               weather.transform.SetParent(graveyard.transform,false);
                           } else weather.transform.SetParent(graveyard.transform,false);
                       } else if(player2.Board.ContainsCard(weather.GetComponent<data>().card.Rows,weather.GetComponent<data>().card)){
                           player2.Board.DeleteBoardCard(weather.GetComponent<data>().card.Rows,weather.GetComponent<data>().card);
                           graveyard=GameObject.Find("Graveyard Player2"); 
                           if(graveyard.transform.childCount!=0){
                               Destroy(graveyard.transform.GetChild(0).gameObject);
                               weather.transform.SetParent(graveyard.transform,false);
                           } else weather.transform.SetParent(graveyard.transform,false);
                       } 
                          card.Effect.Action(player1,player2,weather.GetComponent<data>().card);

                  }


            } 
            else if(card.Effect is PlusOne  && GameManager.Instance.State!= GameManager.GameState.InitialPlayer1 && GameManager.Instance.State!= GameManager.GameState.InitialPlayer2){
              card.Effect.Action(player1,card);
            }
             else if(card.Effect is IncreaseRow2 || card.Effect is IncreaseRow4){
              card.Effect.Action(player1,card);
             } 
             else if(card.Effect is SetWeather2 || card.Effect is SetWeather4){
              card.Effect.Action(player1,player2,card);
             } 
               else if(card.Effect is Average  && GameManager.Instance.State!= GameManager.GameState.InitialPlayer1 && GameManager.Instance.State!= GameManager.GameState.InitialPlayer2){
                   card.Effect.Action(player1);
               }
                else if(card.Effect is IncreasePower  && GameManager.Instance.State!= GameManager.GameState.InitialPlayer1 && GameManager.Instance.State!= GameManager.GameState.InitialPlayer2){
                   card.Effect.Action(player1,card);
                }
      
             else if(card.Effect is CleanRow  && GameManager.Instance.State!= GameManager.GameState.InitialPlayer1 && GameManager.Instance.State!= GameManager.GameState.InitialPlayer2 ){
               Boards.Rows row= card.Effect.Action2(player2);
               if(game.State==GameManager.GameState.Player1Turn){
                 GameObject row2= GameObject.Find(row.ToString()+" Player2");
                 GameObject graveyard= GameObject.Find("Graveyard Player2");
                  foreach (Transform card1 in row2.transform )
                  {
                     if(graveyard.transform.childCount==0){
                     card1.gameObject.transform.SetParent(graveyard.transform,false);
                     } else{
                       Destroy( graveyard.transform.GetChild(0).gameObject);
                       card1.gameObject.transform.SetParent(graveyard.transform,false);
                     }
                     
                  }
               } else  if(game.State==GameManager.GameState.Player2Turn){
                 GameObject row2= GameObject.Find(row.ToString()+" Player1");
                 GameObject graveyard= GameObject.Find("Graveyard Player1");
                  foreach (Transform card1 in row2.transform )
                  {
                        if(graveyard.transform.childCount==0){
                     card1.gameObject.transform.SetParent(graveyard.transform,false);
                     } else{
                       Destroy( graveyard.transform.GetChild(0).gameObject);
                       card1.gameObject.transform.SetParent(graveyard.transform,false);
                     }
                  }
               }
               
             }
     
             player1.RefreshPoints();
             player2.RefreshPoints();
 


          

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
                        increaseCard.Effect.Action(GameManager.Instance.Players[1],increaseCard);
                     }
                 }
               } else   if(card.Rows== Boards.Rows.R && ActiveIncreasePlayer2[1]){
                 increaseRow=GameObject.Find("R Player2");
                 for(int i=0;i<increaseRow.transform.childCount;i++){
                     if(increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card is Increase){
                        increaseCard=increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card;
                        increaseCard.Effect.Action(GameManager.Instance.Players[1],increaseCard);
                     }
                 }
               } else   if(card.Rows== Boards.Rows.S && ActiveIncreasePlayer2[2]){
                 increaseRow=GameObject.Find("S Player2");
                 for(int i=0;i<increaseRow.transform.childCount;i++){
                     if(increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card is Increase){
                        increaseCard=increaseRow.transform.GetChild(i).gameObject.GetComponent<data>().card;
                        increaseCard.Effect.Action(GameManager.Instance.Players[1],increaseCard);
                     }
                 }
               }
                 
           }
      }

}
