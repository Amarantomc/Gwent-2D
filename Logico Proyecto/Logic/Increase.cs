namespace Logic;

public class Increase : Card
{
    public override string Name{get;}

    public override string Faccion {get;}

    public override Effects Effect{get;}

    public override Boards.Rows Rows{get;set;}


    public Increase(string name, string faccion,  Effects effects)
    {
        Name=name;
        Faccion=faccion;
        Effect=effects;
        Rows=0;
         
    }
}