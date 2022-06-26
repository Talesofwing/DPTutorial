using System;
using System.Collections;
using System.Collections.Generic;

public class NULLIterator : IEnumerator<MapNode> {

    public bool MoveNext () {
        return false;
    }

    public MapNode Current {
        get { return null; }
    }

    object IEnumerator.Current {
        get { return Current; }
    }

    public void Reset () {
        throw new NotSupportedException ();
    }

    public void Dispose () {
        throw new NotSupportedException ();
    }
    
}