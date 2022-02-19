using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KRFactory : ILocalizationFactory {

    public Dictionary<int, string> Create () {
        Dictionary<int, string> npcNames = new Dictionary<int, string> ();
        
        // Load data.
        npcNames[1] = "1";
        npcNames[2] = "2";
        npcNames[3] = "3";
        npcNames[4] = "4";
        
        return npcNames;
    }
    
    public Dictionary<int, Sprite> CreateSprites () {
        return null;
    }

}
