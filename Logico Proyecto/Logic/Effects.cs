namespace Logic;
public abstract class Effects{
    public abstract Card Action(Players player);
    public abstract void Action(Players player1,Card card);
    public abstract void Action(Players player1,Players player2,Card card);
    public abstract Boards.Rows Action2(Players player);



   

    

} 
 

public class Steal:Effects{

    
    public Steal()
    {
        
    }
    
    public override Card Action(Players player)
    {    
       if(player.Hand.Count<10){
         int index=Players.GetRandomNum(player.Deck.Length-1);
         Card card=player.Deck.GetCard(index);
         player.Hand.Add(player.Deck.GetCard(index));
         return card;
      
        }
        return null!;
         

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

    public BossEffect(){

    }
    
    public override Card Action(Players player)
    {
        for(int i=0;i<player.Board.Length-2;i++){
            Boards.Rows rows= (Boards.Rows)i;
             foreach (var card in player.Board[rows])
             {
                 if(card is UnitsCard units && (units.Type == UnitsCard.UnitType.Silver)&&(units.Atack== UnitsCard.AtackType.R ||units.Atack== UnitsCard.AtackType.MR||units.Atack== UnitsCard.AtackType.RS||units.Atack== UnitsCard.AtackType.MRS) ){
                     units.Power++;

                 }
             }
             
        }
        return null!;
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
    

    


   
        

    public override Card Action(Players player)
    {
         return null!;
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

    public DeleteMorePowerCard(){

    }  
    public override Card Action(Players player)
    {
        
    UnitsCard maxPower=new UnitsCard("test","test",0,UnitsCard.AtackType.M ,UnitsCard.UnitType.Silver,new NoEffect());
       Boards.Rows maxRow=Boards.Rows.M;
       bool find=false;
        
        for(int i=0;i<player.Board.Length-2;i++){
           
            Boards.Rows row= (Boards.Rows)i;
          
           foreach(Card card in player.Board[row]){
            if(card is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){
                if(maxPower.Power<unitsCard.Power){
               maxPower=unitsCard;
               maxRow=row;
               find=true;
              }
                }
            }
        
        } 
                if(find){
                  player.Board.DeleteBoardCard(maxRow,maxPower);
                  return maxPower;
                } else return null!;
          
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

    public DeleteLessPowerCard()
    {
        
    }
    public override Card Action(Players player)
    {
         UnitsCard minPower=new UnitsCard("test","test",100,UnitsCard.AtackType.M ,UnitsCard.UnitType.Silver,new NoEffect());
       Boards.Rows minRow=Boards.Rows.M;
       bool find=false;
        
        for(int i=0;i<player.Board.Length-2;i++){
           
            Boards.Rows row= (Boards.Rows)i;
          
           foreach(Card card in player.Board[row]){
            if(card is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){
                if(minPower.Power>unitsCard.Power){
               minPower=unitsCard;
               minRow=row;
               find=true;
              }
                }
            }
        
        }   
              if(find){
                player.Board.DeleteBoardCard(minRow,minPower);
                return minPower;
              }else return null!;

       
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
     public DeleteCardInGame(){

     }
     public override void Action(Players player, Card card)
    {
         player.Board.DeleteBoardCard(card.Rows,card);
    }

    
    

    public override Card Action(Players player)
    {
          return null!; 

          
         
        
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
    
     public IncreaseRow2(){

     }
    public override void Action(Players player, Card card)
    {
          int increase=2;
         foreach (Card card1 in player.Board[card.Rows])
         {  
             if(card1 is UnitsCard units&& !units.IncreaseAfected && units.Type== UnitsCard.UnitType.Silver){
                 units.Power+=increase;
                 units.IncreaseAfected=true;
                
             }
         }
    }
  
    public override Card Action(Players player)
    {
         return null!;
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
      
      public IncreaseRow4(){

      }
      public override void Action(Players player, Card card)
    {
        int increase=4;
         foreach (Card card1 in player.Board[card.Rows])
         {  
             if(card1 is UnitsCard units&& !units.IncreaseAfected && units.Type== UnitsCard.UnitType.Silver){
                 units.Power+=increase;
                 units.IncreaseAfected=true;
                
             }
         }
        
       
    }
   
    public override Card Action(Players player)
    {
         return null!;
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

    public SetLure(){

    }
    public override Card Action(Players player)
    {
        return null!;
    }

     

    public override void Action(Players player, Card card)
    {  
        player.Hand.Add(card);

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
      public SetWeather2(){

      }
    
      public override void Action(Players player, Card card)
    {
       
    }


    
    
    
    public override Card Action(Players player)
    {
        return null!;
        
    }

    public override void Action(Players player1, Players player2, Card card)
    {
        int weather=2;

        foreach(Card card1 in player1.Board[card.Rows]){
            if(card1 is UnitsCard unitsCard && !unitsCard.WeatherAfected &&  unitsCard.Type== UnitsCard.UnitType.Silver){
                unitsCard.Power-=weather;
                unitsCard.WeatherAfected=true;
            }
        } 
         foreach(Card card1 in player2.Board[card.Rows]){
            if(card1 is UnitsCard unitsCard && !unitsCard.WeatherAfected && unitsCard.Type== UnitsCard.UnitType.Silver){
                unitsCard.Power-=weather;
                unitsCard.WeatherAfected=true;
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
     public SetWeather4(){
        
      }

     public override void Action(Players player, Card card)
    {
         
    }


    public override Card Action(Players player)
    {
        
        return null!;
    }

    public override void Action(Players player1, Players player2, Card card)
    {
        int weather=4;

        foreach(Card card1 in player1.Board[card.Rows]){
            if(card1 is UnitsCard unitsCard && !unitsCard.WeatherAfected && unitsCard.Type== UnitsCard.UnitType.Silver){
                unitsCard.Power-=weather;
                unitsCard.WeatherAfected=true;
            }
        }
          foreach(Card card1 in player2.Board[card.Rows]){
            if(card1 is UnitsCard unitsCard && !unitsCard.WeatherAfected && unitsCard.Type== UnitsCard.UnitType.Silver){
                unitsCard.Power-=weather;
                unitsCard.WeatherAfected=true;
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

    public CleanRow(){
        
      }
    public override Card Action(Players player)
    {   
        return null!;
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
        int less=400;
        int count=0;
        for(int i=0;i<player.Board.Length-2;i++){
            Boards.Rows rows= (Boards.Rows)i;
            count=0;
              foreach (Card card in player.Board[rows])
              {
                 if(card is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){
                    count++;
                 }
              }
           
            if(count<less && count!=0){
                less=count;
                lessRows=rows;
            }
        } 
         
         for(int i=0;i<player.Board[lessRows].Count;i++){
              if(player.Board[lessRows][i]is UnitsCard unitsCard && unitsCard.Type== UnitsCard.UnitType.Silver){
            player.Board.DeleteBoardCard(lessRows,player.Board[lessRows][i]);
              }
         }
        
        return lessRows;
    }
}

public class PlusOne : Effects
{   

    public PlusOne(){
        
      }
    public override Card Action(Players player)
    {
       return null!; 
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

    public BossEffect2(){
        
      }
    public override Card Action(Players player)
    {
           for(int i=0;i<player.Board.Length-2;i++){
            Boards.Rows rows= (Boards.Rows)i;
             foreach (var card in player.Board[rows])
             {
                 if(card is UnitsCard units && (units.Type== UnitsCard.UnitType.Silver)&& (units.Atack== UnitsCard.AtackType.S ||units.Atack== UnitsCard.AtackType.MS||units.Atack== UnitsCard.AtackType.RS||units.Atack== UnitsCard.AtackType.MRS) ){
                     units.Power++;

                 }
             }
             
        } 
        return null!;
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

    public NoEffect(){
        
      }
    public override Card Action(Players player)
    {
        return null!;
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

public class SetIncrease : Effects
{   

    public SetIncrease(){
        
      }
    public override Card Action(Players player)
    {
         return null!;
    }

    public override void Action(Players player1, Card card)
    {
           card.Effect.Action(player1,card);
        player1.Board.SetCard(card,card.Rows);
        player1.DeleteCardInHand(card); 
    }

    public override void Action(Players player1, Players player2, Card card)
    {
         
    }

    public override Boards.Rows Action2(Players player)
    {
         return 0;
    }
}

public class SetWeather : Effects
{    

    public SetWeather(){
        
      }
    public override Card Action(Players player)
    {
         return null!;
    }

    public override void Action(Players player1, Card card)
    {
           
    }

    public override void Action(Players player1, Players player2, Card card)
    {
          card.Effect.Action(player1,player2,card);
        player1.Board.SetCard(card,card.Rows);
        player1.DeleteCardInHand(card);
    }

    public override Boards.Rows Action2(Players player)
    {
         return 0;
    }
}

public class IncreasePower : Effects
{   

    public IncreasePower(){
        
      }
    public override Card Action(Players player)
    {
        return null!; 
    }

    public override void Action(Players player1, Card card)
    {    
        int power=0;
         for(int i=0;i<player1.Board.Length-2;i++){
             Boards.Rows row= (Boards.Rows)i;

             foreach (Card item in player1.Board[row])
             {
                 if(item.Name==card.Name){
                    power++;
                 }
             }
         } 

             if(card is UnitsCard unitsCard && power!=0) unitsCard.Power*=power;
    }

    public override void Action(Players player1, Players player2, Card card)
    {
         
    }

    public override Boards.Rows Action2(Players player)
    {
         return 0;
    }
}

public class Average : Effects
{   

    public Average(){
        
      }
    public override Card Action(Players player)
    {
         int power=0;
         int countCards=0;
         int average=0;
         
         for(int i=0;i<player.Board.Length-2;i++){
             Boards.Rows row= (Boards.Rows)i;

             foreach (Card item in player.Board[row])
             {
                 if(item is UnitsCard unitsCard){
                    power+=unitsCard.Power;
                    countCards++;
                 }
             }
         } 
         average=power/countCards; 
          for(int i=0;i<player.Board.Length-2;i++){
             Boards.Rows row= (Boards.Rows)i;

             foreach (Card item in player.Board[row])
             {
                 if(item is UnitsCard unitsCard){
                     unitsCard.Power=average;
                 }
             }
         } 
         return null!;  
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