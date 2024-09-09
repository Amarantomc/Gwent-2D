using Logic;

public  class  UnitsCard : Card
{

public override string Name{get;}

public override string Faccion{get;} 

public override Effects Effect{get;set;}

public override Boards.Rows Rows{get;set;}

public override int Power{get;set;}


public AtackType Atack{get;} 

public UnitType Type{get;}
    public override int Owner { get ; set ; }

    public bool WeatherAfected;

public bool IncreaseAfected;


    public enum AtackType{
    M, R, S, MR, MS, RS, MRS
   } 

public enum UnitType{
    Gold, Silver
}
    
   public UnitsCard(string name, string faccion,int power, AtackType atack, UnitType type, Effects effect,int owner)
    {
        Name=name;
        Faccion=faccion;
        Power=power;
        Effect=effect;
        Owner = owner;
        Atack =atack;
        Type=type;
        Rows=0;
        WeatherAfected=false;
        IncreaseAfected=false;
        }
  
}