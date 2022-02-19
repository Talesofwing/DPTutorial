using System.Collections.Generic;
using UnityEngine;

public interface ILocalizationFactory {
    public Dictionary<int, string> Create ();
    public Dictionary<int, Sprite> CreateSprites ();
}