using System;
using UnityEngine;

// 參考來源: https://cloud.tencent.com/developer/article/1574428

/// <summary>
/// 方法1. 餓漢式
/// 這種方式較常用，但容易產生垃圾對象
/// 優點: 沒有加鎖操作，所以執行效率高
/// 缺點: 類加載時就初始化實例對象，浪費內存
/// 可以在"一定"且"即時"會用到實例對象中的類中使用。
/// </summary>
public class Singleton {
    private static Singleton m_Instance = new Singleton ();

    public static Singleton GetInstance () {
        return m_Instance;
    }

    private Singleton () {
        Debug.Log ("單例((餓漢式)被創建了!");
    }
}

/// <summary>
/// 方法2. 懶漢式
/// 具備Lazy Loading的特性，能夠在多線程中很好地工作，但是效果較低
/// 優點: 在第一次調用才初始化，避免內存浪費
/// 缺點: 在單線程中沒有問題，但多綿程中有可能會出現同時創建多個實例的問題 (可用double check解決)
/// </summary>
public class Singleton2 {
    private static Singleton2 m_Instance;

    public static Singleton2 Instance {
        get {
            // 多線程問題
            if (null == m_Instance) {
                m_Instance = new Singleton2 ();
            }

            return m_Instance;
        }
    }

    private Singleton2 () {
        Debug.Log ("單例(懶漢式)被創建了!");
    }
}

/// <summary>
/// 方法3. double check
/// 具備lazy loading和並解決了多線程中的重複創建對象的問題。
/// </summary>
public class Singleton3 {
    private static Singleton3 m_Instance;
    private static readonly object m_Lock = new object ();

    public static Singleton3 Instance {
        get {
            // double check
            if (null == m_Instance) {
                lock (m_Lock) {
                    if (null == m_Instance) {
                        m_Instance = new Singleton3 ();
                    }
                }
            }
            return m_Instance;
        }
    }
    
    private Singleton3 () {
        Debug.Log ("單例(double check)被創建了!");
    }
}

/// <summary>
/// 方法4. 靜態內部類
/// 這種方法不需要加鎖，在效率上和內存使用上都比較好
/// 克服了方法1中的浪費內存問題，同時也解決了方法2中的線程問題
/// 並且，因為沒有加鎖解鎖操作，效率也更高。
/// </summary>
public class Singleton4 {

    private static class SingletonStaticInner {
        /// <summary>
        /// 當一個類有靜態構造函數時，它的靜態成員變量不會被BeforeFieldInit修飾
        /// 就會確保在被引用的時候才會實例化，而不是程序啟動的時候實例化
        /// 簡單地來說，就是確保SingletonStaticInner是在被訪問時才初始化
        /// </summary>
        static SingletonStaticInner () { }
        // BeforeFieldInit :　如果一個類沒有靜態構造函數，它就會被標記為BeforeFieldInit。
        // 即說明這個類的初始化工作有可能早於，晚於或就在這個類的靜態屬性被訪問時完成。

        // static的變量會先被自動初始化
        internal static Singleton4 SingletonStatic = new Singleton4 ();
        // internal: 只能在同一個程序集中被訪問
        // 程序集: dll、exe程序集
    }

    private Singleton4 () {
        Debug.Log ("單例(靜態內部類)被創建了!");
    }

    public static Singleton4 GetInstance () {
        return SingletonStaticInner.SingletonStatic;
    }

    public void Display () {
        Debug.Log ("單例(靜態內部類)!");
    }
    
}

/// <summary>
/// 方法5. Lazy
/// 需要.NetFramework 4+
/// </summary>
public class Singleton5 {
    private static Lazy<Singleton5> m_Instance = new Lazy<Singleton5> (()=> new Singleton5 ());
    
    private Singleton5 () {
        Debug.Log ("單例(Lazy)!");
    }
    
    public static Singleton5 GetInstance () {
        return m_Instance.Value;
    }
}