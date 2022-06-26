public enum CharacterState {
    Normal,
    Anger,
    Fever
}

public interface ICharacterState {
    void Attack ();
    int TakeDamage (int damage);
    CharacterState GetStateType ();
}
