
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Gwent;

public class PostActionExpression : Expressions
{
    public override Tokens.TokenType Type => Tokens.TokenType.PostActionExpression;

    public Expressions Name { get; }

    public SelectorExpression Selector{get; set;}

    public PostActionExpression  Child{get;}

    public List<AssignmentExpression> Param{get;}
    private Scope scope{get;set;}
    

     
    public PostActionExpression(Expressions name, SelectorExpression selector)
    {
        Name = name;
        Selector = selector;
         
    }

    public PostActionExpression(Expressions name, SelectorExpression selector, PostActionExpression child)
    {
        Name = name;
        Selector = selector;
        Child = child;
    }
    public PostActionExpression(Expressions name, SelectorExpression selector, PostActionExpression child, List<AssignmentExpression> param)
    {
        Name = name;
        Selector = selector;
        Child = child;
        Param=new List<AssignmentExpression>();
        Copy(Param,param);
    }

    public override bool CheckSemantic()
    {
         if(Name is null || Name.Evaluate(scope!) is not string) throw new Exception("Invalid or Missing Name Expression");
         if(Selector is not null) Selector.Evaluate(scope!);
         if(Child is not null) Child.Evaluate(scope!);
         return true;
    }

    public bool CheckSemantic(Scope scope)
    {
       if(Name is null || Name.Evaluate(scope!) is not string) throw new Exception("Invalid or Missing Name Expression");
         if(Selector is not null) Selector.CheckSemantic(scope!);
         if(Child is not null) Child.CheckSemantic(scope!);
         return true;  
    }

    public override object Evaluate(Scope scope)
    {
          
         
         return 0;
    }

    public object Evaluate(Scope scope, SelectorExpression parent)
    {
         this.scope=scope;
        if (Selector is not null && Selector.Source.Evaluate(scope!) is string source && source == "parent")
        {
            Selector.Source = parent.Source;
        }
        SelectorExpression selector;
        if (Selector is not null) selector = Selector;
        else selector = parent;
        return GetEffect(this,selector,new List<(EffectExpression,SelectorExpression)>());

    }

    private List<(EffectExpression,SelectorExpression)> GetEffect(PostActionExpression postActionExpression, SelectorExpression parent, List<(EffectExpression, SelectorExpression)> list)
    {
       var effect=Context.Effects.Find(x=> x.Name.Evaluate(scope!).Equals(postActionExpression.Name.Evaluate(scope!) ));
       if(effect is null) throw new Exception($"Effect {postActionExpression.Name.Evaluate(scope!)} does not exist");
       if(effect.Params is not null)
       {
          foreach (VarExpression item in effect.Params.ParamsStatement.Expressions)
            {
              string varName=item.Var.Text;
              if(Param.Exists(x=>varName==x.Identifier.Var.Text))
              {
                AssignmentExpression param=Param.Find(x=>varName==x.Identifier.Var.Text)!;
                scope.Variables.Add(item);
                if(item.DataType is null)
                {
                    item.Value=param.Right;
                     
                } else if(item.DataType is not null)
                {   
                    
                    var right=param.Right.Evaluate(scope!);
                    if(item.DataType== Tokens.TokenType.NumberKeyword && right is double) item.Value=right;
                    else if(item.DataType== Tokens.TokenType.BoolKeyword && right is bool) item.Value=right;
                    else if(item.DataType== Tokens.TokenType.StringKeyword && right is string) item.Value=right;
                    else throw new Exception($" Cannot convert from {right.GetType()} to {item.DataType}");

                        
                     
                }
              } else throw new Exception($"Missing Param {varName}");
            }
       }
       list.Add((effect,parent)); 
       if(postActionExpression.Child is not null) return GetEffect(postActionExpression.Child,parent,list);
       return list;
    }
}