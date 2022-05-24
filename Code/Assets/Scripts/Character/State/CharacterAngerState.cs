using UnityEngine;

public class CharacterAngerState : ICharacterState {
    
    public void Attack () {
        // 攻擊力提升1.5倍
        Debug.Log ("Character Anger Attack");
    }

    public int TakeDamage (int damage) {
        // 傷害減免30%
        return (int)Mathf.Round (damage * 0.7f);
    }
    
    public CharacterState GetStateType () {
        return CharacterState.Anger;
    }
    
    public override string ToString () {
        return "Anger";
    }
    
}
