using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    bool holding;
    Vector3 mousePosition;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        holding = true;
        offset = mousePosition - transform.position;
    }

    private void OnMouseUp()
    {
        holding = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        if (holding)
            Hold();
    }

    void Hold()
    {

        Vector3 deltaMouse = mousePosition; // + offset;
        
        //remember delta, move to mouse, reapply delta

        // Doesn't consider resolution so not viable unless accounting for screen size
        //deltaMouse.x = Input.GetAxisRaw("Mouse X");
        //deltaMouse.y = Input.GetAxisRaw("Mouse Y");

        //Sensitivity
        transform.position = deltaMouse;
    }
}
