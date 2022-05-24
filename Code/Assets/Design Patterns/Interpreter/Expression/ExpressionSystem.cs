using UnityEngine;

public static class ExpressionSystem {

    public static string GetResult (TextContext context) {
        string result = "";
        
        IExpression expression = null;
        ExpressionFactory factory = new ExpressionFactory ();
        while (context.Context.Length > 0) {
            string key = context.Context.Substring (0, 1);
            if (key == "<") {
                key = context.Context.Substring (1, context.Context.IndexOf ('>') - 1);
                context.Context = context.Context.Substring (key.Length + 2);
            } else {
                context.Context = context.Context.Substring (key.Length);
            }
            
            expression = factory.CreateExpression (key);
            result += expression.Interpret (key);
        }

        return result;
    }
    
}
