using Logic;

public class Increase : Card
{
    public override string Name{get;}

    public override string Faccion {get;}

    public override Effects Effect{get;set;}

    public override Boards.Rows Rows{get;set;}
    public override int Owner { get ; set ; }

    public Increase(string name, string faccion,  Effects effects,int owner)
    {
        Name=name;
        Faccion=faccion;
        Effect=effects;
        Owner = owner;
        Rows =0;
         
    }
}