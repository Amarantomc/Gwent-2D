namespace Logic;

public  class  UnitsCard : Card
{

public override string Name{get;}

public override string Faccion{get;} 

public override Effects Effect{get;}

public override Boards.Rows Rows{get;set;}

public int Power{get;set;}

public AtackType Atack{get;} 

public UnitType Type{get;}


    public enum AtackType{
    M, R, S, MR, MS, RS, MRS
   } 

public enum UnitType{
    Gold, Silver
}
    
   public UnitsCard(string name, string faccion,int power, AtackType atack, UnitType type, Effects effect)
    {
        Name=name;
        Faccion=faccion;
        Power=power;
        Effect=effect;
        Atack=atack;
        Type=type;
        Rows=0;
        }
  
}