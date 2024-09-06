
using System;
using System.Collections.Generic;
using Gwent;

public class DotExpression : Expressions
{
    public override Tokens.TokenType Type => Tokens.TokenType.DotExpression;

    public Expressions Left { get; }
    public Tokens Dot { get; }
    public Expressions Right { get; }

    public DotExpression(Expressions left, Tokens dot, Expressions right)
    {
        Left = left;
        Dot = dot;
        Right = right;
    }

    public override bool CheckSemantic()
    {
        throw new NotImplementedException();
    }

    public override object Evaluate(Scope scope)
    {   
        if(Dot.Type== Tokens.TokenType.OpenBracket)
        {
           List<Card> left1=(List<Card>)Left.Evaluate(scope);
           if(Right is not null && Right.Evaluate(scope) is double x)
           {
             return left1[(int)x];
           }
           throw new Exception("Invalid Operation in Indexer  ");

        }
        var left=Left.Evaluate(scope);
         var right=Right as FunctionExpression;
         if(Left is VarExpression var && var.Var.Text=="context") left="context";
         return right!.Evaluate(scope,left);
       
         
    }
}