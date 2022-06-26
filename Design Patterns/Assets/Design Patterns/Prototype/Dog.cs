using System;
using UnityEngine;

public class Ear : ICloneable {
    public string Test = "";

    public Ear () {
        // Debug.Log ("Ear constructor.");
    }

    public object Clone () {
        return this.MemberwiseClone ();
    }
    
    public override string ToString () {
        return Test;
    }
}

/// <summary>
/// 可以實現C#的ICloneable
/// 也可以自己實現自己的方法
/// </summary>
public class Dog : ICloneable {
    
    public string Name {
        get;
        set;
    }

    public int Age {
        get;
        set;
    }

    public Ear[] Ears {
        get;
        set;
    }

    public Dog () {
        // Debug.Log ("Dog constructor");

        Ears = new Ear[] {new Ear (), new Ear ()};
        
        // 模擬很複雜的初始化
        // for (int i = 0; i < 100000; i++) { }
    }

#region ICloneable Implementation

    /// <summary>
    /// Deep Clone
    /// </summary>
    /// <returns></returns>
    public object Clone () {
        Dog other = this.ShallowClone ();
        int count = this.Ears.Length;
        other.Ears = new Ear[this.Ears.Length];
        // 要注意不要只Clone數組
        // 而應該將數組內部的元素改變
        // other.Ears = this.Ears.Clone () as Ear[];
        for (int i = 0; i < count; i++) {
            other.Ears[i] = this.Ears[i].Clone () as Ear;
        }
        
        return other;
    }

#endregion

#region My clone methods.

    public Dog ShallowClone () {
        return this.MemberwiseClone () as Dog;
    }

    public Dog DeepClone () {
        return Clone () as Dog;
    }
    
#endregion

    public override string ToString () {
        return "Name: " + Name + ", Age: " + Age + ", Ear[0]: " + Ears[0] + ", Ear[1]: " + Ears[1];
    }
}
