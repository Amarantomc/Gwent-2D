namespace Logic;

public class WeatherCard: Card 
{     
    public override string Name{get;}

    public override string Faccion {get;}

    public override Effects Effect{get;}

    public override Boards.Rows Rows{get;set;}

    public WeatherCard (string name, string faccion, Effects effect)
     {
        Name=name;
        Faccion=faccion;
        Effect=effect;
        Rows=0;
         
        
     }
}