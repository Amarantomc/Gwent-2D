
using System;
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
        var left=Left.Evaluate(scope);
         var right=Right as FunctionExpression;
         return right!.Evaluate(scope,left);
       
         
    }
}