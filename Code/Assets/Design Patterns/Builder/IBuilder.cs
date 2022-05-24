using UnityEngine;

public interface IBuilder {
    void CreateBody ();
    void CreateWeapon ();
    T GetResult<T> ();
}
