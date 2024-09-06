
using System;
using System.Collections.Generic;
using System.Linq;
using Gwent;
using Logic;

public class LambdaExpression : Expressions
{
    public override Tokens.TokenType Type => Tokens.TokenType.LambdaExpression;

    public List<VarExpression> Variables { get; }
    public Tokens Do { get; }
    public Statement Body { get; }

    public Tokens.TokenType Delegate{get;}

    private Scope  scope{get;set;}

    public LambdaExpression( Tokens Do, Statement body, Tokens.TokenType Delegate, params VarExpression[] variables)
    {   
        Variables=new List<VarExpression>();
        foreach (var item in variables)
        {
           Variables.Add(item); 
        }
        this.Do = Do;
        Body=body;
        this.Delegate=Delegate;
    }

    public override bool CheckSemantic()
    {
       return true;
    }
    public bool DelegateCheckSemantic(Scope internalScope)
    {
         foreach (var item in Variables)
         {
            FindVar(internalScope,item.Var.Value.ToString()!);
         }
         
         
         return true;
         
    }

    private bool FindVar(Scope internalScope, string name)
    { 
        if (internalScope is null) return true; 
            
             if (internalScope!.Variables.Exists(x=> x.Var.Value.ToString()== name))
            {
                throw new Exception($"Variable {name} was defined already");
            }
            return FindVar(internalScope.Parent!,name);
    }

    public override object Evaluate(Scope scope)
    {    // Devuelve un Action o un Predicate
         this.scope=scope;
          foreach (var item in Variables )
            {
                scope.Variables.Add(item);
            }
         if(Delegate == Tokens.TokenType.ActionKeyword)
         {
           

            Action<List<Card>> action=Evaluate;
            

            return action;
         }
         if(Delegate == Tokens.TokenType.PredicateKeyword)
         {  
            
            
            Predicate<Card> predicate=Evaluate;
            
            return predicate;
         }
         throw new Exception("Invalid Operation");
    }

    public bool Evaluate(Card card)
    {
       Variables[0].Value=card;
       return (bool)Body.Expressions.First().Evaluate(scope!);
    }
    public void Evaluate(List<Card> cards)
    {
        Variables[0].Value=cards;
        Body.Evaluate(scope!);
    }
}