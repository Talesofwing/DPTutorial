public class Vocaloid {
    
    public void Sing () {
        // 其它方法
        
        OnSing ();
        
        // 其它方法
    }
    protected virtual void OnSing () {}

    public void TestMethod (int i) {
        if (i > 50) {
            // do something
        } else {
            // throw exception
        }
    }
    
}

// 子類中，不要覆蓋掉Vocaloid的Sing方法，可以覆寫OnSing ()方法，這樣一來，整個Vocaloid的邏輯並不會受到影響
// 子類中，可以擴展自己的方法 HighSing (), LowSing ()


public class Miku : Vocaloid {

    protected override void OnSing () {
        base.OnSing ();
        
        // do something
    }

    public void HighSing () {
        
    }
    
    public new void TestMethod (int i) {
        if (i > 100) {
            // do something
        } else {
            // throw exception
        }
    }
    
}

public class Luka : Vocaloid {
 
    protected override void OnSing () {
        base.OnSing ();
        
    }

    public void LowSing () {
        
    }
    
}