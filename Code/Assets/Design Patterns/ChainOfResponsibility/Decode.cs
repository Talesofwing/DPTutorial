using UnityEngine;

public abstract class IDecode {
    protected IDecode m_Next;

    public IDecode () {
        m_Next = null;
    }
    
    public IDecode (IDecode next) {
        m_Next = next;
    }
    
    public abstract bool Decode (string code);
}

public class DecodeA : IDecode {
    
    public DecodeA () { }
    public DecodeA (IDecode next) : base (next) { }
    
    public override bool Decode (string code) {
        if (code.Length <= 5) {
            Debug.Log ("DecodeA: " + code);
            return true;
        } else {
            if (m_Next != null) {
                return m_Next.Decode (code);
            } else {
                Debug.Log ("不存在能解碼的解碼器。");
                return false;
            }
        }
    }
    
}

public class DecodeB : IDecode {
    
    public DecodeB () { }
    public DecodeB (IDecode next) : base (next) { }
    
    public override bool Decode (string code) {
        if (code.Length <= 10) {
            Debug.Log ("DecodeB: " + code);
            return true;
        } else {
            if (m_Next != null) {
                return m_Next.Decode (code);
            } else {
                Debug.Log ("不存在能解碼的解碼器。");
                return false;
            }
        }
    }
    
}

public class DecodeC : IDecode {

    public DecodeC () { }
    public DecodeC (IDecode next) : base (next) { }

    public override bool Decode (string code) {
        if (code.Length <= 15) {
            Debug.Log ("DecodeC: " + code);
            return true;
        } else {
            if (m_Next != null) {
                return m_Next.Decode (code);
            } else {
                Debug.Log ("不存在能解碼的解碼器。");
                return false;
            }
        }
    }
    
}
