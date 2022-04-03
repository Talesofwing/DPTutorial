using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateCaretaker {
    // 先進後出，所以選用Stack
    private Stack<PlayerStateMemento> m_Mementos = new Stack<PlayerStateMemento> ();

    public void AddMemento (PlayerStateMemento memento) {
        m_Mementos.Push (memento);
    }

    public PlayerStateMemento PopMemento () {
        return m_Mementos.Pop ();
    }

    public bool HasMemento () {
        return m_Mementos.Count > 0;
    }
    
}
