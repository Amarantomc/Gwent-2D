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

            
            default:
            {
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
}
