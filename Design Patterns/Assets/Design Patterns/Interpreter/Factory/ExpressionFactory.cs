public class ExpressionFactory {

    public IExpression CreateExpression (string key) {

        switch (key) {
            case "D":
                return new DateExpression ();
            case "ATK":
                return new AtkExpression ();
            default:
                return new NormalExpression ();
        }
    }

}
