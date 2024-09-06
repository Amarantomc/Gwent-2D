
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Gwent;
using Logic;
using Microsoft.Win32.SafeHandles;

public class CardExpression : Expressions
{
    public override Tokens.TokenType Type =>  Tokens.TokenType.CardExpression;

    public Expressions Name { get; }
    public Expressions TypeCard { get; }
    public Expressions Faction { get; }
    public Expressions Power { get; }
    public List<Expressions> Range { get; }
    public OnActivationExpression OnActivation { get; }

    private Scope scope{get;set;}

    private string [] types={"Oro","Plata","Lider","Aumento","Clima"};
    

    public CardExpression( Expressions name, Expressions type, Expressions faction, Expressions power, List<Expressions> range, OnActivationExpression onActivation)
    {
        Name = name;
        TypeCard = type;
        Faction = faction;
        Power = power;
        OnActivation = onActivation;
        Range=new List<Expressions>();
        Copy(Range,range);
        
    }

    public override bool CheckSemantic()
    {
        
        if(Name is null || Name.Evaluate(scope!) is not string) throw new Exception("Name does not exist");
        if(TypeCard is null || !types.Contains(TypeCard.Evaluate(scope!))) throw new Exception("Type does not exist");

        if(TypeCard.Evaluate(scope!) is string type)
        { 
            
            if(type== "Oro"|| type=="Plata")
            {
               if(Faction is null || Faction.Evaluate(scope!) is not string) throw new Exception("Faction does not exist");
               if(Power is null || Power.Evaluate(scope!) is not double x || x<=0) throw new Exception("Power does not exist");
               if(Range.Count>3 || !Range.Any() ) throw new Exception("Params Overload or Missing");
               RangeMethod(Range);
            }
            else if(type=="Clima"|| type=="Aumento")
            {    
                if(Power is not null)
                {
                if( Power!.Evaluate(scope!) is not double x || x!=0) throw new Exception("This Card cannot have Power");
                
                }
                if(Range.Any() ) throw new Exception("This Card cannot have Range");
                
            }
            else if(type=="Lider")
            {
              if(Power is null || Power.Evaluate(scope!) is not double x || x<=0) throw new Exception("Power does not exist");
              if(Range.Any()) throw new Exception("Lider do not have Range");

            } else throw new Exception($"Invalid Card Type {type}");
        } 
          OnActivation.CheckSemantic(scope!);
          return true;

          

        
    }

    private bool [] RangeMethod(List<Expressions> expressions)
    {
         bool[] result = new bool[3];
            foreach(Expressions expression in expressions) 
            {   
                string range=(expression.Evaluate(scope!) is string y) ? y: throw new Exception("Range must be a String Type");

            switch (range)
            {
                case "Melee":
                {
                    if(!result[0])
                    {
                        result[0]=true;
                        continue;
                    }
                    throw new Exception("Semantic Error only can be one Melee");

                }
                     
                case "Ranged":
                 
                 if(!result[1])
                    {
                        result[1]=true;
                        continue;
                    }
                    throw new Exception("Semantic Error only can be one Ranged");

                case "Siege":
                 
                 if(!result[2])
                    {
                        result[2]=true;
                        continue;
                    }
                    throw new Exception("Semantic Error only can be one Siege");


                default:
                throw new Exception($"Unexpected Token {range}, Expected 'Melee', 'Ranged' o 'Siege' "); 
                    
            }

            
                
            }

            return result;
    }

    public override object Evaluate(Scope scope)
    {
         this.scope=scope;
         CheckSemantic();
         Card card=null!;
         UnitsCard.AtackType ranged=0;

         string name=(string)Name.Evaluate(scope);
         string type=(string)TypeCard.Evaluate(scope);
         string faction=(string)Faction.Evaluate(scope);
         double power;
         bool [] range;

          if(type== "Oro" || type=="Plata")
         {
            power=(double)Power.Evaluate(scope);
            range=RangeMethod(Range);
            UnitsCard.UnitType unitType=(type=="Oro")? UnitsCard.UnitType.Gold: UnitsCard.UnitType.Silver; 
            string auxRange="";
            if(range[0]) auxRange+="M";
            if(range[1]) auxRange+="R";
            if(range[2]) auxRange+="S";
            for(int i=0;i<=6;i++)
            { 
                UnitsCard.AtackType atack=(UnitsCard.AtackType)i;
                if(auxRange==atack.ToString()) 

                {
                    ranged=atack;
                    break;
                }
            }

            card=new UnitsCard(name,faction,(int)power,ranged,unitType,new NoEffect(),0);
              
         } 
         else if(type=="Clima"|| type=="Aumento")
         {
            if(type=="Clima") card=new WeatherCard(name,faction,new NoEffect(),0);
            else card=new Increase(name,faction,new NoEffect(),0);
            

         } else if(type=="Lider")
         {  
            power=(double)Power.Evaluate(scope);
            card=new BossCard(name,faction,(int)power,new NoEffect(),0);
         }
         
       

List<(EffectExpression,SelectorExpression)> aux=(List<(EffectExpression,SelectorExpression)>)OnActivation.Evaluate(scope);
         List<(string,Action<List<Card>>,string,bool,Predicate<Card>)> result= new List<(string,Action<List<Card>>,string, bool, Predicate<Card>)>();
         
         foreach (var item in aux)
         {  
             
            (string,bool,Predicate<Card>) selector=(item.Item2 is not null)? ((string, bool, Predicate<Card>))item.Item2.Evaluate(scope):(null,false,null);
             (string,Action<List<Card>>) effect = ( (string,Action<List<Card>>)) item.Item1.Evaluate(scope);
           
            result.Add((effect.Item1,effect.Item2 ,selector.Item1,selector.Item2,selector.Item3));
         }

         if(card is WeatherCard || card is Increase)
         {
            if(result.Count>1|| result.Count==0) throw new Exception($"{card} only can have one Effect");
            if(result[0].Item3 is not null) throw new Exception($"{card} cannot have Selector Expression");
             

         }
                card.Effect=new CompilerEffects(result);
               return card;
         

          
    }
}