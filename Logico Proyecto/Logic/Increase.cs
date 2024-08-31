namespace Logic;

public class Increase : Card
{
    public override string Name{get;}

    public override string Faccion {get;}

    public override Effects Effect{get;}

    public override Boards.Rows Rows{get;set;}
    public override Players Owner { get ; set ; }

    public Increase(string name, string faccion,  Effects effects,Players owner)
    {
        Name=name;
        Faccion=faccion;
        Effect=effects;
        Owner = owner;
        Rows =0;
         
    }
}