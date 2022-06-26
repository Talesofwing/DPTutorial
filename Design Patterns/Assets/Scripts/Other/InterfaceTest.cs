

public interface A {
    void TestMethod ();
}

public interface B : A {
    // 覆蓋掉A中的TestMethod了
    new int TestMethod ();
}

public class InterfaceTest : B {
    
    void A.TestMethod () {
        
    }

    public int TestMethod () {
        return 0;
    }
    
}