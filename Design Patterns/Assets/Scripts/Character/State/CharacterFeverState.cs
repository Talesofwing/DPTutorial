using UnityEngine;

public class CharacterFeverState : ICharacterState {
    
    public void Attack () {
        // 攻擊力提升2倍
        Debug.Log ("Character Fever Attack");
    }

    public int TakeDamage (int damage) {
        // 傷害減免50%
        return (int)Mathf.Round (damage * 0.5f);
    }
    
    public CharacterState GetStateType () {
        return CharacterState.Fever;
    }
    
    public override string ToString () {
        return "Fever";
    }
    
}
