using System;
using Gwent;

public class WhileExpression : Expressions
{
    public override Tokens.TokenType Type => Tokens.TokenType.WhileExpression;

    
    public Expressions BoolExpression { get; }
    
    public Statement Body { get; }

    

    public WhileExpression( Expressions boolExpression,Statement body)
    {
         
        BoolExpression = boolExpression;
         
        Body = body;
    } 

    

    public override bool CheckSemantic()
    {
          return true;
       
    }

    public override object Evaluate(Scope scope)
    {
         Scope scopeStatment=scope.CreateChild();
          
             while (BoolExpression.Evaluate(scope) is bool condition && condition)
             {
                Body.Evaluate(scopeStatment);
             }
         
            if(BoolExpression.Evaluate(scope) is not bool) throw new Exception("Missing or Invalid Expression for While Condition");
         
         return null!;
         
    }
}
