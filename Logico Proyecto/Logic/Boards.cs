
namespace Logic;
 public class Boards{
    
     Dictionary<Rows,List<Card>> board;
      public List<Card> this[Rows rows]
    {
        get
        {
            if (board.ContainsKey(rows))
            {
                return board[rows];
            }
           return null;
        }
    }
      
   public enum Rows{
        M, R, S, Graveyard, Heroe,Weather 
    } 
    

    public Boards()
    {
        board= new Dictionary<Rows, List<Card>>
        {
            { Rows.M, new List<Card>() },
            { Rows.R, new List<Card>() },
            { Rows.S, new List<Card>() },
            { Rows.Graveyard, new List<Card>() },
            { Rows.Heroe, new List<Card>() }
            
        };
      

        
         

    } 
       
       public  bool CheckRow(Card card, Rows row){
           
           if(card is BossCard){
            return true;
           }
           else if(card is WeatherCard){
              if(!board[row].Contains(card)) return true;
           } 
           else  if(card is Increase){
              if(!board[row].Contains(card)) return true;
           }
          else if(card is UnitsCard units){
             if(units.Atack== UnitsCard.AtackType.MRS) return true;
              else if(row== Rows.M){
            if(units.Atack==UnitsCard.AtackType.M || units.Atack==UnitsCard.AtackType.MR||units.Atack==UnitsCard.AtackType.MS) return true;
           } 

           else if(row == Rows.R){
            if(units.Atack== UnitsCard.AtackType.R||units.Atack== UnitsCard.AtackType.MR||units.Atack== UnitsCard.AtackType.RS) return true;
           } 

            else if(row == Rows.S){
            if(units.Atack== UnitsCard.AtackType.S||units.Atack== UnitsCard.AtackType.MS||units.Atack== UnitsCard.AtackType.RS) return true;
           }
           }         
            return false;
       }   
 
    
    
     public Card GetBoardCard(Rows row,int index)=> board[row][index];
    
    
    public void SetCard(Card card, Rows row){
       if(CheckRow(card,row)){
        board[row].Add(card);
        
       }
        
          
    
    }
    

    public int Length => board.Count;
     

    public void DeleteBoardCard(Rows row, Card card)
    {
         board[Rows.Graveyard].Add(card);
         board[row].Remove(card);
    } 

    public bool ContainsCard(Rows row ,Card card){
        if(board[row].Contains(card)) return true;
        else return false;
    } 
    
    
     
} 
