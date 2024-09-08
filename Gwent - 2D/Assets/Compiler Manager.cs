using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;
using System.Linq;

public static class CompilerManager
{
    public static Players Player1=GameManager.Instance.Players[0];

    public static Players Player2=GameManager.Instance.Players[1];

    
    public static Players GetPlayer()
    {
        if(GameManager.Instance.State== GameManager.GameState.Player2Turn)
       {
         Player1=GameManager.Instance.Players[1];
         Player2=GameManager.Instance.Players[0];
       }
       else {
         Player1=GameManager.Instance.Players[0];
         Player2=GameManager.Instance.Players[1];
       }
       return Player1;
    }
   
   public static Players GetPlayer(int player)
   {
      if(player==1) return Player1;

      if(player==2) return Player2;
      throw new System.Exception("Invalid ID for Player");
   }

   public static int GetTriggerPlayer()
   {
      if(GameManager.Instance.State== GameManager.GameState.Player1Turn) return 1;
      return 2;
   }
    public static (List<GameObject> objects, List<Card> cards) GetSource(string source)
    {
       if(GameManager.Instance.State== GameManager.GameState.Player2Turn)
       {
         Player1=GameManager.Instance.Players[1];
         Player2=GameManager.Instance.Players[0];
       }
       else {
         Player1=GameManager.Instance.Players[0];
         Player2=GameManager.Instance.Players[1];
       }
        switch (source)
        {  
            case "hand":
            {
                List<Card> result=Player1.Hand;
                List<GameObject> objects=CardsManager.Instance.cardsPlayer1;
                return (objects,result);
            }
            case "otherHand":
            {
               List<Card> result=Player2.Hand;
               List<GameObject> objects=CardsManager.Instance.cardsPlayer2;
               if(GameManager.Instance.State== GameManager.GameState.Player2Turn)
               {
                  objects=CardsManager.Instance.cardsPlayer1;
               }
                 return (objects,result); 
            }
            case "deck":
            {
                List<Card> result=Player1.Deck.GetDeck();
                return(null!,result);
            }
            case "otherDeck":
            {
                List<Card> result=Player2.Deck.GetDeck();
                return(null!,result);
            }
             case "field":
            {
              List<Card> result=Player1.Board.GetValues().ToList();
              List<GameObject>objects=new List<GameObject>();
              var M=GameObject.Find("M Player1");
              var R=GameObject.Find("R Player1");
              var S=GameObject.Find("S Player1");
              if(GameManager.Instance.State== GameManager.GameState.Player2Turn)
              {
                M=GameObject.Find("M Player2");
                R=GameObject.Find("R Player2");
                S=GameObject.Find("S Player2");
              }
              
               for(int i=0;i<M.transform.childCount;i++)
               {
                  objects.Add(M.transform.GetChild(i).gameObject);
               }
               for(int i=0;i<R.transform.childCount;i++)
               {
                  objects.Add(R.transform.GetChild(i).gameObject);
               }
               for(int i=0;i<S.transform.childCount;i++)
               {
                  objects.Add(S.transform.GetChild(i).gameObject);
               }
               return (objects,result);
            }
             case "otherField":
             {
               List<Card> result=Player2.Board.GetValues().ToList();
              List<GameObject>objects=new List<GameObject>();
              var M=GameObject.Find("M Player1");
              var R=GameObject.Find("R Player1");
              var S=GameObject.Find("S Player1");
              if(GameManager.Instance.State== GameManager.GameState.Player1Turn)
              {
                M=GameObject.Find("M Player2");
                R=GameObject.Find("R Player2");
                S=GameObject.Find("S Player2");
              }
              
               for(int i=0;i<M.transform.childCount;i++)
               {
                  objects.Add(M.transform.GetChild(i).gameObject);
               }
               for(int i=0;i<R.transform.childCount;i++)
               {
                  objects.Add(R.transform.GetChild(i).gameObject);
               }
               for(int i=0;i<S.transform.childCount;i++)
               {
                  objects.Add(S.transform.GetChild(i).gameObject);
               }
               return (objects,result);
             }

               case "M":
               {
                  List<Card> result=new List<Card>();
                  foreach (var item in Player1.Board[Boards.Rows.M])
                  {
                     if(item is UnitsCard unitsCard && !unitsCard.IncreaseAfected &&  unitsCard.Type== UnitsCard.UnitType.Silver)
                     { 
                        result.Add(item);
                     }
                  }
                  List<GameObject> objects=new List<GameObject>();
                 
                return(objects,result);

               }

               case "R":
               {
                   List<Card> result=new List<Card>();
                  foreach (var item in Player1.Board[Boards.Rows.R])
                  {
                     if(item is UnitsCard unitsCard && !unitsCard.IncreaseAfected &&  unitsCard.Type== UnitsCard.UnitType.Silver)
                     { 
                        result.Add(item);
                     }
                  }
                  List<GameObject> objects=new List<GameObject>();
                   
                return(objects,result);

               }

               case "S":
               {
                   List<Card> result=new List<Card>();
                  foreach (var item in Player1.Board[Boards.Rows.S])
                  {
                     if(item is UnitsCard unitsCard &&  !unitsCard.IncreaseAfected && unitsCard.Type== UnitsCard.UnitType.Silver)
                     { 
                        result.Add(item);
                     }
                  }
                  List<GameObject> objects=new List<GameObject>();
                   
                return(objects,result);

               }

               case "MW":
               {
                   List<Card> result=new List<Card>();
                  foreach (var item in Player1.Board[Boards.Rows.M])
                  {
                     if(item is UnitsCard unitsCard && !unitsCard.WeatherAfected && unitsCard.Type== UnitsCard.UnitType.Silver)
                     { 
                        result.Add(item);
                     }
                  }
                   foreach (var item in Player2.Board[Boards.Rows.M])
                  {
                     if(item is UnitsCard unitsCard && !unitsCard.WeatherAfected && unitsCard.Type== UnitsCard.UnitType.Silver)
                     { 
                        result.Add(item);
                     }
                  }
                  List<GameObject> objects=new List<GameObject>();
                  
                  return(objects,result);

               }

                 case "RW":
               {
                    List<Card> result=new List<Card>();
                  foreach (var item in Player1.Board[Boards.Rows.R])
                  {
                     if(item is UnitsCard unitsCard && !unitsCard.WeatherAfected && unitsCard.Type== UnitsCard.UnitType.Silver)
                     { 
                        result.Add(item);
                     }
                  }
                   foreach (var item in Player2.Board[Boards.Rows.R])
                  {
                     if(item is UnitsCard unitsCard && !unitsCard.WeatherAfected && unitsCard.Type== UnitsCard.UnitType.Silver)
                     { 
                        result.Add(item);
                     }
                  }
                  List<GameObject> objects=new List<GameObject>();
                  
                  return(objects,result);

               }

                 case "SW":
               {
                    List<Card> result=new List<Card>();
                  foreach (var item in Player1.Board[Boards.Rows.S])
                  {
                     if(item is UnitsCard unitsCard && !unitsCard.WeatherAfected && unitsCard.Type== UnitsCard.UnitType.Silver)
                     { 
                        result.Add(item);
                     }
                  }
                   foreach (var item in Player2.Board[Boards.Rows.S])
                  {
                     if(item is UnitsCard unitsCard && !unitsCard.WeatherAfected && unitsCard.Type== UnitsCard.UnitType.Silver)
                     { 
                        result.Add(item);
                     }
                  }
                  List<GameObject> objects=new List<GameObject>();
                  
                  return(objects,result);

               }
            
            default:
            { //board
              List<Card> result=Player1.Board.GetValues().ToList().Concat(Player2.Board.GetValues().ToList()).ToList();
              List<GameObject>objects=new List<GameObject>();
              var M=GameObject.Find("M Player1");
              var R=GameObject.Find("R Player1");
              var S=GameObject.Find("S Player1");
              var M2=GameObject.Find("M Player2");
              var R2=GameObject.Find("R Player2");
              var S2=GameObject.Find("S Player2");
              
               for(int i=0;i<M.transform.childCount;i++)
               {
                  objects.Add(M.transform.GetChild(i).gameObject);
               }
               for(int i=0;i<R.transform.childCount;i++)
               {
                  objects.Add(R.transform.GetChild(i).gameObject);
               }
               for(int i=0;i<S.transform.childCount;i++)
               {
                  objects.Add(S.transform.GetChild(i).gameObject);
               }
               
               
               for(int i=0;i<M2.transform.childCount;i++)
               {
                  objects.Add(M2.transform.GetChild(i).gameObject);
               }
               for(int i=0;i<R2.transform.childCount;i++)
               {
                  objects.Add(R2.transform.GetChild(i).gameObject);
               }
               for(int i=0;i<S2.transform.childCount;i++)
               {
                  objects.Add(S2.transform.GetChild(i).gameObject);
               }
               return (objects,result);
            } 
        }
        
    }

    public static void ApplyVisual( List<GameObject> objects, string source)
    {
        if(source== "board" || source=="field" || source=="otherField")
        {
           if(source=="board")
           {
              foreach (var item in objects)
           {
              bool find=false;
              foreach (var card in GetPlayer(1).Board.GetValues())
              {
                 if(card.Name==item.gameObject.GetComponent<data>().card.Name)
                 {
                   find=true;
                   break;
                 }
              }

              if(!find) Object.Destroy(item);
           }

               foreach (var item in objects)
           {
              bool find=false;
              foreach (var card in GetPlayer(2).Board.GetValues())
              {
                 if(card.Name==item.gameObject.GetComponent<data>().card.Name)
                 {
                   find=true;
                   break;
                 }
              }

              if(!find) Object.Destroy(item);
           }
           } 
           
           else if(source=="field")
           {
               
               foreach (var item in objects)
           {
              bool find=false;
              foreach (var card in GetPlayer().Board.GetValues())
              {
                 if(card.Name==item.gameObject.GetComponent<data>().card.Name)
                 {
                   find=true;
                   break;
                 }
              }

              if(!find) Object.Destroy(item);
           }
           } 
             else if(source=="otherField")
             {
                
                foreach (var item in objects)
            {
              bool find=false;
              foreach (var card in GetPlayer(2).Board.GetValues())
              {
                 if(card.Name==item.gameObject.GetComponent<data>().card.Name)
                 {
                   find=true;
                   break;
                 }
              }

              if(!find) Object.Destroy(item);
           }
             }
           
           
        }
        return;
    }
}
