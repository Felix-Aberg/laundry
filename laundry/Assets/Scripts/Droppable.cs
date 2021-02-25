using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Droppable : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject spawn;

    public abstract bool CheckItem();

    public abstract void OnDrop();
}
