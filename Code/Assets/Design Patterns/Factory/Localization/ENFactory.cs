using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENFactory : ILocalizationFactory {

    public Dictionary<int, string> Create () {
        Dictionary<int, string> npcNames = new Dictionary<int, string> ();
        
        // Load data.
        npcNames[1] = "Kuma";
        npcNames[2] = "ZeRo";
        npcNames[3] = "tanaka";
        npcNames[4] = "wei";
        
        return npcNames;
    }
    
    public Dictionary<int, Sprite> CreateSprites () {
        return null;
    }
    
}
