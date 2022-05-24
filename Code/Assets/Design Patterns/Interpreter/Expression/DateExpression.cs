using System;

public class DateExpression : IExpression {

    public override string Interpret (string context) {
        return DateTime.Now.ToShortDateString ();
    }
    
}