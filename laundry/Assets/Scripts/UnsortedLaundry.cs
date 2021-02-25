using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnsortedLaundry : Takeable
{
    public override bool IsAvailable()
    {
        return true;
    }

    public override void OnTake()
    {
        //Generate clothes
        Transform t = GameObject.FindWithTag("Clothes").transform;

        GameObject clone = t.GetChild(Random.Range(0, t.childCount)).gameObject;
        clone = Instantiate(clone, GameObject.FindWithTag("Draggables").transform);
        draggable = clone.GetComponent<Draggable>();
        draggable.Press();
    }

    public override bool OnDrop()
    {
        return draggable.Unpress();
    }
}
