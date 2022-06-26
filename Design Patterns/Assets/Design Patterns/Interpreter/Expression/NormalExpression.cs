using System.Linq;

public class NormalExpression : IExpression {
    public override string Interpret (string context) {
        return context;
    }

}