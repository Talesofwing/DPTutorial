//
// 所有非靜態的函數或變量都是屬於"對象"，而非"類"
// 因此，想引用非靜態的函數或變量時，必須先有"對象"
//

// 外部類
public class OuterClass {
    private static int m_ID;
    private string m_Name;

    private static int GetID () {
        return m_ID;
    }

    public static void Display () {
        // output something
    }
    
    private string GetName () {
        return m_Name;
    }
    
    private static void OuterClassTestMethod () {
        // 需要把InnerClass寫出來才能調用內部類中的靜態方法
        // 只能訪問public的函數與變量
        InnerClass.InnerClassTestMethod ();
        InnerClass.m_Age = 1;
        
        // 只能在外部類中使用
        InnerClass2 a = new InnerClass2();
    }

    private void OuterClassTestMethod2 () {
        // 不能訪問private的函數與變量
        // InnerClass.InnerClassTestMethod2 ();
        // InnerClass.m_Desc = "123";
    }

    // 不能返回InnerClass2
    // public static InnerClass2 GetInnerClass2 () {
    //     return new InnerClass2 ();
    // }
    
    // 內部類
    public class InnerClass {
        private static string m_Desc;
        public static int m_Age;
            
        // 因為內部類定義於外部類中，相當於是外部類的東西
        // 因此可以直接引用外部類的東西
        public static void InnerClassTestMethod () {
            m_ID = GetID ();

            Display ();

            // 需要"實例對象"才能訪問m_Name
            // m_Name = "123";
            // string name = GetName ();
        }

        private static void InnerClassTestMethod2 () { }

        public void InnerClassTestMethod3 () { }
    }

    private class InnerClass2 {
        
    }
    
}
