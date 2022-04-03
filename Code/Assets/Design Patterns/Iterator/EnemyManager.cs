using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Q. 為甚麼要用C#提供的接口?
/// A. 統一，只要是C#程序員就會知道IEnumerable的使用方法。並且能被foreach使用。
/// </summary>
public class EnemyManager : IEnumerable<Enemy> {
    private List<Enemy> m_Enemies;

#region Singleton

    private static Lazy<EnemyManager> m_Instance = new Lazy<EnemyManager> (() => new EnemyManager ());

    public static EnemyManager Instance {
        get { return m_Instance.Value; }
    }

    private EnemyManager () {
        m_Enemies = new List<Enemy> ();
    }

#endregion

#region C#提供的迭代器

    // 在C#2.0後，加入了yield return關鍵字取代IEnumerator，所以可以不用自己寫IEnumerator
    // C#有提供泛型和非泛型的迭代器
    // 在其它語言中可能叫Iterator (迭代器), Enumerator (枚舉器)

    IEnumerator IEnumerable.GetEnumerator () {
        for (int index = 0; index < Count; index++) {
            yield return m_Enemies[index];
        }
    }

    public IEnumerator<Enemy> GetEnumerator () {
        // for (int index = 0; index < Count; index++) {
        //     yield return m_Enemies[index];
        // }
        return new EnemyEnumerator (m_Enemies);
    }

#endregion

#region 其它方法

    /// <summary>
    /// C# 語法糖
    /// </summary>
    
    public Enemy this [int index] {
        get { return m_Enemies[index]; }
    }

    public Enemy this [string name] {
        get { return m_Enemies[0]; }
    }
    
    public void AddEnemy (Enemy enemy) {
        if (!m_Enemies.Contains (enemy))
            m_Enemies.Add (enemy);
    }

    public void RemoveEnemy (Enemy enemy) {
        m_Enemies.Remove (enemy);
    }
    
    public int Count {
        get { return m_Enemies.Count; }
    }
    
#endregion

}

/// <summary>
/// EnemyManager的迭代器
/// </summary>
public class EnemyEnumerator : IEnumerator<Enemy> {
    private List<Enemy> m_Enemies;
    public int Position { get; private set; }

    public EnemyEnumerator (List<Enemy> enemies) {
        Position = -1;
        m_Enemies = enemies;
    }

    ~EnemyEnumerator () {
        Dispose ();
    }
    
    public Enemy Current {
        get {
            if (Position == -1 || Position == m_Enemies.Count) {
                throw new InvalidOperationException ();
            }
            return m_Enemies[this.Position];
        }
    }

    object IEnumerator.Current {
        get {
            return Current;
        }
    }

    public bool MoveNext () {
        return ++Position < m_Enemies.Count;
    }

    public void Reset () {
        Position = -1;
    }

    public void Dispose () {
        // 傳址參數
        // m_Enemies.Clear();
        m_Enemies = null;
    }
  
}
