using UnityEngine;

public class UseInterpreter : MonoBehaviour {

    private void Start () {
        TextContext context = new TextContext ("日期:<D>，攻擊力:<ATK>");
        Debug.Log (context.Context);
        
        string result = ExpressionSystem.GetResult (context);
        Debug.Log (result);
    }
    
}
