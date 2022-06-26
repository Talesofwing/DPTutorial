public class UseInnerClass {

    public UseInnerClass () {
        
    }

    private void TestMethod () {
        // 可以通過OuterClass來獲取InnerClass的信息
        // 但是獲取不了private的InnerClass2的信息
        OuterClass.InnerClass innerClass = new OuterClass.InnerClass ();
        innerClass.InnerClassTestMethod3 ();
    }

}
