using System.Collections.Generic;
using UnityEngine;

public interface ILocalizationFactory {
    Dictionary<int, string> Create ();
    Dictionary<int, Sprite> CreateSprites ();
    string GetName ();
}