using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Takeable : MonoBehaviour
{
    // Start is called before the first frame update
    public Draggable draggable;

    public void OnMouseDown()
    {
        if (IsAvailable())
            OnTake();
    }

    public void OnMouseUp()
    {
        OnDrop();
    }

    public abstract bool IsAvailable();

    public abstract void OnTake();

    public abstract bool OnDrop();
}
