using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public Players Player1;
    public Players Player2;

    public List<Card> CompilerCardsPlayer1;
    public List<Card> CompilerCardsPlayer2;
    void Awake()
    {
       Instance=this;
       DontDestroyOnLoad(gameObject);
       CompilerCardsPlayer1=new List<Card>();
       CompilerCardsPlayer2=new List<Card>();
    }

    void Start()
    {
         GameBase game=new GameBase();
         Player1=game.player1;
         Player2=game.player2;
         
    }

    public void StartGame()
    {
       GameBase game=new GameBase();
         Player1=game.player1;
         Player2=game.player2;
      foreach (var item in CompilerCardsPlayer1)
      {
        Player1.Deck.Insert(item);
      }
      foreach (var item in CompilerCardsPlayer2)
      {
        Player2.Deck.Insert(item);
      }
    }

}
