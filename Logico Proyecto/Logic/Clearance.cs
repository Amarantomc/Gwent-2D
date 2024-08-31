namespace Logic;

public class Clearance : Card
{
    public override string Name{get;}

    public override string Faccion {get;}

    public override Effects Effect{get;}

    public override Boards.Rows Rows{get;set;}
    public override Players Owner { get ; set ; }

    public Clearance(string name, string faccion, Effects effect,Players owner)
    {
        Name=name;
        Faccion=faccion;
        Effect=effect;
        Owner = owner;
        Rows =0;
    }
}