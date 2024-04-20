namespace Logic;
public class BossCard : Card
{
    public override string Name {get;}

    public override string Faccion {get;}

    public override Effects Effect{get;}

    public override Boards.Rows Rows{get;set;}


    public int Power{get;}

    public BossCard(string name, string faccion, int power, Effects effect)
    {
        Name=name;
        Faccion=faccion;
        Effect=effect;
        Power=power;
        Rows=Boards.Rows.Heroe;
        
    }
}