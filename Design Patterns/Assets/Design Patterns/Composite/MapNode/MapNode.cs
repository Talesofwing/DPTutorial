using System;
using System.Collections.Generic;

public abstract class MapNode {
    public abstract void AddChild (MapNode node);
    public abstract void RemoveChild (MapNode node);
    public abstract void Display ();

#region Iterator & Composite

    public abstract IEnumerator<MapNode> CreateIterator ();

#endregion

}