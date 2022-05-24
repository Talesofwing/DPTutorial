using UnityEngine;

public class CharacterNormalState : ICharacterState {
    
    public void Attack () {
        Debug.Log ("Character Normal Attack");
    }

    public int TakeDamage (int damage) {
        // 傷害減免30%
        return damage;
    }

    public CharacterState GetStateType () {
        return CharacterState.Normal;
    }

    public override string ToString () {
        return "Normal";
    }
    
}
