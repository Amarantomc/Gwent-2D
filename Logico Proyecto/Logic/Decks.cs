using System.Xml.Schema;

namespace Logic;

public class Decks{

   private List<Card> deck;
   public int Length =>deck.Count;


   public Decks(params  Card[] cards)
   {
      deck= new List<Card>();
      for(int i=0;i<cards.Length;i++){
         deck.Add(cards[i]);
      }
   } 

   public void Insert(Card card){
      deck.Add(card);
   } 
    
   public Card GetCard(int index){
       if(deck.Count>0){
         return deck[index];
       } 
       return null!;
       
   }
   
   

   public void Remove(int index)=>deck.RemoveAt(index);


}