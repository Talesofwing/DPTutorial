using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TWFactory : ILocalizationFactory {

    public Dictionary<int, string> Create () {
        Dictionary<int, string> npcNames = new Dictionary<int, string> ();
        
        // Load data.
        npcNames[1] = "熊";
        npcNames[2] = "零君";
        npcNames[3] = "田中";
        npcNames[4] = "煒";
        
        return npcNames;
    }

    public Dictionary<int, Sprite> CreateSprites () {
        return null;
    }
    
}
