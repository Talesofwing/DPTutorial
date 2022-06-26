using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPFactory : ILocalizationFactory {

    public Dictionary<int, string> Create () {
        Dictionary<int, string> npcNames = new Dictionary<int, string> ();
        
        // Load data.
        npcNames[1] = "クマ";
        npcNames[2] = "ゼロ";
        npcNames[3] = "田中";
        npcNames[4] = "イ";
        
        return npcNames;
    }
    
    public Dictionary<int, Sprite> CreateSprites () {
        return null;
    }
    
    public string GetName () {
        return "クマ";
    }
    
}
