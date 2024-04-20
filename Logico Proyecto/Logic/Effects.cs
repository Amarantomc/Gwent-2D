namespace Logic;
public abstract class Effects{
    public abstract void Action(Players player);
    public abstract void Action(Players player1,Card card);
    public abstract void Action(Players player1,Players player2,Card card);
    public abstract Boards.Rows Action2(Players player);    


   

    

} 
 

public class Steal:Effects{

    
    public Steal()
    {
        
    }
    
    public override void Action(Players player)
    {    
       if(player.Hand.Count<10){
         int index=Players.GetRandomNum(player.Deck.Length-1);
         player.Hand.Add(player.Deck.GetCard(index));
      
        }
         

    }

     

    

   

    public override void Action(Players player1, Players player2, Card card)
    {
         
    }

    public override void Action(Players player1, Card card)
    {
        
    }

    public override Boards.Rows Action2(Players player)
    {
         return 0;
    }
}

public class BossEffect : Effects
{
    public override void Action(Players player)
    {
        for(int i=0;i<player.Board.Length-2;i++){
            Boards.Rows rows= (Boards.Rows)i;
             foreach (var card in player.Board[rows])
             {
                 if(card is UnitsCard units &&(units.Atack== UnitsCard.AtackType.R ||units.Atack== UnitsCard.AtackType.MR||units.Atack== UnitsCard.AtackType.RS||units.Atack== UnitsCard.AtackType.MRS) ){
                     units.Power++;

                 }
             }
             
        }
    }

    public override void Action(Players player1, Players player2, Card card)
    {
         
    }

    public override void Action(Players player1, Card card)
    {
        
    }

    public override Boards.Rows Action2(Players player)
    {
         return 0;
    }
}
public class DeleteWeather: Effects
{
    public DeleteWeather()
    {
    }
    

    


   
        

    public override void Action(Players player)
    {
         
    }

    public override void Action(Players player1, Players player2, Card card)
    { 
         int increase=0;
         if(card.Effect is SetWeather2) increase=2;
         if(card.Effect is SetWeather4) increase=4;
          
          foreach (Card card1 in player1.Board[card.Rows])
          {
             if(card1 is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){
                 unitsCard.Power+=increase;
             }
          } 

             foreach (Card card1 in player2.Board[card.Rows])
          {
             if(card1 is UnitsCard unitsCard &&unitsCard.Type== UnitsCard.UnitType.Silver){
                 unitsCard.Power+=increase;
             }
          }
         
    }

    public override void Action(Players player1, Card card)
    {
         
    }

    public override Boards.Rows Action2(Players player)
    {
         return 0;
    }
}

public class DeleteMorePowerCard : Effects

{   
    public override void Action(Players player)
    {
        
    UnitsCard maxPower=new UnitsCard("test","test",0,UnitsCard.AtackType.M ,UnitsCard.UnitType.Silver,null);
       Boards.Rows maxRow=Boards.Rows.M;
        
        for(int i=0;i<player.Board.Length;i++){
           
            Boards.Rows row= (Boards.Rows)i;
          
           foreach(Card card in player.Board[row]){
            if(card is UnitsCard unitsCard){
                if(maxPower.Power<unitsCard.Power){
               maxPower=unitsCard;
               maxRow=row;
              }
                }
            }
        
        } 

        player.Board.DeleteBoardCard(maxRow,maxPower);  
    }

    public override void Action(Players player1, Players player2, Card card)
    {
         
    }

    public override void Action(Players player1, Card card)
    {
        
    }

    public override Boards.Rows Action2(Players player)
    {
         return 0;
    }
}

public class DeleteLessPowerCard : Effects

{
    public override void Action(Players player)
    {
         UnitsCard minPower=new UnitsCard("test","test",100,UnitsCard.AtackType.M ,UnitsCard.UnitType.Silver,null);
       Boards.Rows minRow=Boards.Rows.M;
        
        for(int i=0;i<player.Board.Length;i++){
           
            Boards.Rows row= (Boards.Rows)i;
          
           foreach(Card card in player.Board[row]){
            if(card is UnitsCard unitsCard){
                if(minPower.Power>unitsCard.Power){
               minPower=unitsCard;
               minRow=row;
              }
                }
            }
        
        } 

        player.Board.DeleteBoardCard(minRow,minPower);
    }

    public override void Action(Players player1, Card card)
    {
        
    }

    public override void Action(Players player1, Players player2, Card card)
    {
         
    }

    public override Boards.Rows Action2(Players player)
    {
        return 0;
    }
}

public class DeleteCardInGame : Effects
{
   
     public override void Action(Players player, Card card)
    {
         
    }

    
    

    public override void Action(Players player)
    {
         int randomRow= Players.GetRandomNum(2);
         Boards.Rows row=(Boards.Rows)randomRow;
         int randomCard=Players.GetRandomNum( player.Board[row].Count);
         Card card= player.Board.GetBoardCard(row,randomCard);
         if(card is not WeatherCard && card is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){
            player.Board.DeleteBoardCard(row,card);
         } else Action(player);
    }

    public override void Action(Players player1, Players player2, Card card)
    {
         
    }

    public override Boards.Rows Action2(Players player)
    {
         return 0;
    }
}

public class IncreaseRow2 : Effects
{
  
    public override void Action(Players player, Card card)
    {
          int increase=2;
         foreach (Card card1 in player.Board[card.Rows])
         {  
             if(card1 is UnitsCard units&& units.Type== UnitsCard.UnitType.Silver){
                 units.Power+=increase;
                
             }
         }
    }
  
    public override void Action(Players player)
    {
         
    }

    public override void Action(Players player1, Players player2, Card card)
    {
        
    }

    public override Boards.Rows Action2(Players player)
    {
        return 0;
    }
}

public class IncreaseRow4 : Effects
{
   
      public override void Action(Players player, Card card)
    {
        int increase=4;
         foreach (Card card1 in player.Board[card.Rows])
         {  
             if(card1 is UnitsCard units&& units.Type== UnitsCard.UnitType.Silver){
                 units.Power+=increase;
                
             }
         }
        
       
    }
   
    public override void Action(Players player)
    {
         
    }

    public override void Action(Players player1, Players player2, Card card)
    {
         
    }

    public override Boards.Rows Action2(Players player)
    {
        return 0;
    }
}

public class SetLure : Effects
{
    public override void Action(Players player)
    {
        
    }

     

    public override void Action(Players player, Card card)
    {  
       Boards.Rows rows=card.Rows;
       UnitsCard minPower=new UnitsCard("test","test",100,UnitsCard.AtackType.M ,UnitsCard.UnitType.Silver,null); 
       foreach (Card card1 in player.Board[rows])
       {
         if(card1 is UnitsCard unitsCard && unitsCard.Power<minPower.Power){
            minPower=unitsCard;
         }
       }
       player.Hand.Add(minPower);
       player.Board.DeleteBoardCard(minPower.Rows,minPower);

    }

    public override void Action(Players player1, Players player2, Card card)
    {
         
    }

    public override Boards.Rows Action2(Players player)
    {
        return 0;
    }
}

public class SetWeather2 : Effects

{
    
      public override void Action(Players player, Card card)
    {
       
    }


    
    
    
    public override void Action(Players player)
    {
        
        
    }

    public override void Action(Players player1, Players player2, Card card)
    {
        int weather=2;

        foreach(Card card1 in player1.Board[card.Rows]){
            if(card1 is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){
                unitsCard.Power-=weather;
            }
        } 
         foreach(Card card1 in player2.Board[card.Rows]){
            if(card1 is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){
                unitsCard.Power-=weather;
            }
        }
        
    }

    public override Boards.Rows Action2(Players player)
    {
        return 0;
    }
}

public class SetWeather4 : Effects
{


     public override void Action(Players player, Card card)
    {
         
    }


    public override void Action(Players player)
    {
        
        
    }

    public override void Action(Players player1, Players player2, Card card)
    {
        int weather=4;

        foreach(Card card1 in player1.Board[card.Rows]){
            if(card1 is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){
                unitsCard.Power-=weather;
            }
        }
          foreach(Card card1 in player2.Board[card.Rows]){
            if(card1 is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){
                unitsCard.Power-=weather;
            }
        }
    }

    public override Boards.Rows Action2(Players player)
    {
        return 0;
    }
}

public class CleanRow : Effects
{
    public override void Action(Players player)
    {   
        
    }

    public override void Action(Players player, Card card)
    {
        
        
    }

    public override void Action(Players player1, Players player2, Card card)
    {
         
    }

    public override Boards.Rows Action2(Players player)
    {
          Boards.Rows lessRows=0;
        int less=int.MaxValue;
        for(int i=0;i<player.Board.Length-2;i++){
            Boards.Rows rows= (Boards.Rows)i;
           
            int count=player.Board[rows].Count;
           
            if(count<less){
                less=count;
                lessRows=rows;
            }
        } 

        foreach (Card card in player.Board[lessRows])
        {
            player.Board.DeleteBoardCard(lessRows,card);
        }
        return lessRows;
    }
}

public class PlusOne : Effects
{
    public override void Action(Players player)
    {
        
    }

    public override void Action(Players player1, Card card)
    {
        int increase=0;
        Boards.Rows rows= card.Rows;
        foreach (Card card1 in player1.Board[rows])
        {
            if(card1 is UnitsCard) increase++;
        }
         if(card is UnitsCard unitsCard) unitsCard.Power+=increase;
    }

    public override void Action(Players player1, Players player2, Card card)
    {
        
    }

    public override Boards.Rows Action2(Players player)
    {
        return 0;
    }
}

public class BossEffect2 : Effects
{
    public override void Action(Players player)
    {
           for(int i=0;i<player.Board.Length-2;i++){
            Boards.Rows rows= (Boards.Rows)i;
             foreach (var card in player.Board[rows])
             {
                 if(card is UnitsCard units &&(units.Atack== UnitsCard.AtackType.S ||units.Atack== UnitsCard.AtackType.MS||units.Atack== UnitsCard.AtackType.RS||units.Atack== UnitsCard.AtackType.MRS) ){
                     units.Power++;

                 }
             }
             
        }
    }

    public override void Action(Players player1, Card card)
    {
        
    }

    public override void Action(Players player1, Players player2, Card card)
    {
         
    }

    public override Boards.Rows Action2(Players player)
    {
         return 0;
    }
}

public class NoEffect : Effects
{
    public override void Action(Players player)
    {
        
    }

    public override void Action(Players player1, Card card)
    {
        
    }

    public override void Action(Players player1, Players player2, Card card)
    {
        
    }

    public override Boards.Rows Action2(Players player)
    {
        return 0;
    }
}