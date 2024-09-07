
using System;
using System.Collections.Generic;
using System.Linq;
using Gwent;
using Logic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using Random = System.Random;

public class FunctionExpression : Expressions
{
    public override Tokens.TokenType Type => Tokens.TokenType.FunctionExpression;

    public Tokens.TokenType FunctionType { get; }
    public Expressions Param { get; }

    public FunctionExpression( Tokens.TokenType functionType, Expressions param)
    {
        FunctionType = functionType;
        Param = param;
    }

    public FunctionExpression( Tokens.TokenType functionType)
    {
        FunctionType = functionType;
    }

    public override bool CheckSemantic()
    {
        throw new NotImplementedException();
    }

    public override object Evaluate(Scope scope)
    {
         return true;
    }

    public object Evaluate(Scope scope, object value)
    {
        if(value is Card card)
        {
            if(FunctionType== Tokens.TokenType.PowerKeyword && card is UnitsCard unitsCard) return(double) unitsCard.Power;
            else if(FunctionType== Tokens.TokenType.NameKeyword ) return card.Name;
            else if(FunctionType== Tokens.TokenType.FactionKeyword ) return card.Faccion;
            else if(FunctionType== Tokens.TokenType.RangeKeyword )
            {
              if(card is UnitsCard units) return units.Type.ToString();
              if(card is WeatherCard) return "Clima";
              if(card is Increase) return "Aumento";
              if(card is BossCard) return "Lider";
            }
            else if(FunctionType== Tokens.TokenType.OwnerKeyword) return (double)card.Owner;
        
        } else if(value is List<Card> cards)
        {
            if(FunctionType== Tokens.TokenType.PopKeyword)
            {
                Card card1=cards[0];
                 cards.RemoveAt(0);
                 return card1;
            }
            else if( FunctionType== Tokens.TokenType.PushKeyword)
            {
                if(Param is not null &&Param.Evaluate(scope) is Card card1)
                {
                    cards.Add(card1);
                    cards.Reverse();
                    return card1;
                } else throw new Exception("Invalid Expression in Push Function");
            }
            else if( FunctionType== Tokens.TokenType.SendBottomKeyword)
            {
              if(Param is not null &&Param.Evaluate(scope) is Card card1)
                {
                    cards.Add(card1);
                    return card1;
                } else throw new Exception("Invalid Expression in SendBottom Function");
            }
             else if(FunctionType == Tokens.TokenType.RemoveKeyword)
             { 
                if(Param is not null &&Param.Evaluate(scope) is Card card1)
                {
                   cards.Remove(card1);
                  return card1;
                } else throw new Exception("Invalid Expression in Remove Function");
             }
              else if( FunctionType== Tokens.TokenType.FindKeyword)
              {
                 if(Param is not null && Param is LambdaExpression lambda)
                 {
                    List<Card> aux= new List<Card>();
                    foreach (var card1 in cards)
                    {
                         
                        if(lambda.Evaluate(scope) is Predicate<Card> predicate && predicate.Invoke(card1)) aux.Add(card1);
                    }
                    return aux;
                 }
                  else throw new Exception("Invalid Expression in Find Expression");
              }
               else if(FunctionType == Tokens.TokenType.ShuffleKeyword)
               {
                   Random rnd = new Random();
                   int n = cards.Count;

                   for (int i = n - 1; i > 0; i--)
                  {
                  int j = rnd.Next(0, i + 1);
             
                   Card temp = cards[i];
                  cards[i] = cards[j];
                      cards[j] = temp;
                 }
                  return cards;
               }
               else if(FunctionType== Tokens.TokenType.AddKeyword)
               {
                    if(Param is null || Param.Evaluate(scope) is not Card) throw new Exception("Missing Card to Add");
                    Card card1=Param.Evaluate(scope) as Card;
                    cards.Add(card1);
                    return card1;
                    
               }
        } else if( value is "context")
        {    
            if(FunctionType== Tokens.TokenType.BoardKeyword)
            {
                if(Param is not null && Param.Evaluate(scope)is double x)
                {
                    int exp=(int)x;
                    return CompilerManager.GetPlayer(1).Board.GetValues().Concat(CompilerManager.GetPlayer(2).Board.GetValues()).ToList()[exp];
                } else if(Param is not null && Param.Evaluate(scope) is not double) throw new Exception($"Invalid Expression Inside [] {Param.Evaluate(scope)}");
                
             return CompilerManager.GetPlayer(1).Board.GetValues().Concat(CompilerManager.GetPlayer(2).Board.GetValues()).ToList();

            } 
            if(FunctionType== Tokens.TokenType.HandKeyword)
            {
                if(Param is not null && Param.Evaluate(scope) is double x)
                {
                    int exp=(int)x;
                    return CompilerManager.GetPlayer().Hand[exp];
                } else if(Param is not null && Param.Evaluate(scope) is not double) throw new Exception($"Invalid Expression Inside [] {Param.Evaluate(scope)}");
                return CompilerManager.GetPlayer().Hand;
            }
             
            if(FunctionType== Tokens.TokenType.DeckKeyword) 
            {
                 if(Param is not null && Param.Evaluate(scope) is double x)
                {
                    int exp=(int)x;
                    return   CompilerManager.GetPlayer().Deck.GetDeck()[exp];
                } else if(Param is not null && Param.Evaluate(scope) is not double) throw new Exception($"Invalid Expression Inside [] {Param.Evaluate(scope)}");
                 return CompilerManager.GetPlayer().Deck.GetDeck();
            }
            
            if(FunctionType== Tokens.TokenType.GraveyardKeyword) 
            {
                 if(Param is not null && Param.Evaluate(scope) is double x)
                {
                    int exp=(int)x;
                    return CompilerManager.GetPlayer().Board[ Boards.Rows.Graveyard][exp];
                } else if(Param is not null && Param.Evaluate(scope) is not double) throw new Exception($"Invalid Expression Inside [] {Param.Evaluate(scope)}");
                 return CompilerManager.GetPlayer().Board[ Boards.Rows.Graveyard];
            }
             
            if( FunctionType== Tokens.TokenType.FieldKeyword) 
            {
               if(Param is not null && Param.Evaluate(scope) is double x)
                {
                    int exp=(int)x;
                    return CompilerManager.GetPlayer().Board.GetValues()[exp];
                } else if(Param is not null && Param.Evaluate(scope) is not double) throw new Exception($"Invalid Expression Inside [] {Param.Evaluate(scope)}");
                 return CompilerManager.GetPlayer().Board.GetValues();   
            }
            
            if(FunctionType== Tokens.TokenType.HandOfPlayerKeyword || FunctionType== Tokens.TokenType.DeckOfPlayerKeyword
            || FunctionType== Tokens.TokenType.FieldOfPlayerKeyword|| FunctionType== Tokens.TokenType.GraveyardOfPlayerKeyword)
            {
               if(Param is not null  && Param.Evaluate(scope) is double a)
                {
                    Players playerParam= CompilerManager.GetPlayer((int)a);
                    if( FunctionType== Tokens.TokenType.HandOfPlayerKeyword) return playerParam.Hand;
                    if( FunctionType== Tokens.TokenType.DeckOfPlayerKeyword) return playerParam.Deck.GetDeck();
                    if( FunctionType== Tokens.TokenType.FieldOfPlayerKeyword) return playerParam.Board.GetValues();
                    if( FunctionType== Tokens.TokenType.GraveyardOfPlayerKeyword) return playerParam.Board[ Boards.Rows.Graveyard];


                } else throw new Exception("Invalid Expression in Dot Expression"); 
            }
            if(FunctionType== Tokens.TokenType.TriggerPlayerKeyword) return (double)CompilerManager.GetTriggerPlayer();

        }
        return true;
    }
}