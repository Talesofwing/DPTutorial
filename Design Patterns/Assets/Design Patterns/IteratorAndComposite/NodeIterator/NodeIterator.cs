using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeIterator : IEnumerator<MapNode> {
    Stack m_Stack = new Stack ();
    
    public NodeIterator (IEnumerator<MapNode> iterator) {
        m_Stack.Push (iterator);
    }

    public bool MoveNext () {
        if (m_Stack.Count <= 0) {
            return false;
        } else {
            // 因為m_Stack是成員變量
            // 內部的計數會保留
            IEnumerator<MapNode> iterator = (IEnumerator<MapNode>)m_Stack.Peek ();

            if (!iterator.MoveNext ()) {
                m_Stack.Pop ();

                return MoveNext ();
            } else {
                return true;
            }
        }
    }

    public MapNode Current {
        get {
            IEnumerator<MapNode> iterator = (IEnumerator<MapNode>)m_Stack.Peek ();
            MapNode node = iterator.Current;
            // 這裏的判斷可有可無
            // 因為在節點中也有NULLIterator可用
            if (node is LayerNode) {
                m_Stack.Push (node.CreateIterator ());
            }

            return node;
        }
    }

    object IEnumerator.Current {
        get {
            return Current;
        }
    }

    public void Reset () {
        throw new NotSupportedException ();
    }

    public void Dispose () {
        throw new NotSupportedException ();
    }
    
}
