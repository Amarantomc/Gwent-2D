namespace Logic;
 using System;
 using System.Runtime;

public class Players{
   
   public Decks Deck{get;}

   public Boards Board{get;} 

   public List<Card> Hand{ get;}

   public int Points{get; set;}

   public int Rounds{get;set;}

    

    

    



   public Players(Decks Decks, Boards boards)
   {
    Deck=Decks;
    Board=boards;
    Hand=new List<Card>();
    Points=0;
    Rounds=0;
   
     for(int i=0; i<10; i++){
        int randomNum=GetRandomNum(Deck.Length-1);
       Hand.Add(Deck.GetCard(randomNum));
       Deck.Remove(randomNum);
       
       
       
     } 
    
   }  

    public static int GetRandomNum(int MaxValue){
      CustomRandom random=new CustomRandom(123);
     return random.Next(MaxValue);

   } 

    
   
    

    public void InsertCardInHand(){
      
      int randomNum=GetRandomNum(Deck.Length-1);
      Card card=Deck.GetCard(randomNum);
      Hand.Add(card);
      Deck.Remove(randomNum);
      
      
    } 

    public void DeleteCardInHand(Card card) => Hand.Remove(card);

    public void RefreshPoints(){
     
     int newPoints=0;

     for(int i=0;i<Board.Length-2;i++){
        
        Boards.Rows rows= (Boards.Rows)i;
        
         foreach (Card card in Board[rows])
      {
         if(card is UnitsCard units){
          newPoints+=units.Power;
         }
      }
     } 
     Points=newPoints+30;
     
     
    }


}

 