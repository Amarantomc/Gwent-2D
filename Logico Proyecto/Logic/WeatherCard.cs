using Logic;

public class WeatherCard: Card 
{     
    public override string Name{get;}

    public override string Faccion {get;}

    public override Effects Effect{get;set;}

    public override Boards.Rows Rows{get;set;}
    public override int Owner {  get;set; }

    public WeatherCard (string name, string faccion, Effects effect,int owner)
     {
        Name=name;
        Faccion=faccion;
        Effect=effect;
        Owner = owner;
        Rows =0;
         
        
     }
}