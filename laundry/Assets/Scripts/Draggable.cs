using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType {COLORED, WHITE, BLUE, RED, YELLOW, GREEN}
public enum ArticleType { PILE, SHIRT, SWEATER, TANKTOP, PANTS, UNDERWEAR, SOCKS}

public class Draggable : MonoBehaviour
{

    bool dontDestroy;

    public ArticleType article;
    public ColorType color;
    
    bool holding;
    Vector3 mousePosition;
    Vector3 startPos;
    Vector3 offset;
    new BoxCollider2D collider;
    //Vector2 colliderSize;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
        //colliderSize = collider.size;
    }

    private void OnMouseDown()
    {
        if (!holding)
        {
            Press();
        }
    }

    public void Press()
    {
        startPos = transform.position;
        //collider.size = new Vector2(0.001f, 0.001f);
        holding = true;
        offset = mousePosition - transform.position;
    }

    private void OnMouseUp()
    {
        if (holding)
        {
            Unpress();
        }
    }

    public bool Unpress()
    {
        bool b = CheckCollision();

        //collider.size = colliderSize;
        holding = false;

        if (!dontDestroy)
        {
            Destroy(gameObject);
        }

        return b;
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

    bool CheckCollision()
    {
        //absolute brute code

        Droppable[] droppables = FindObjectsOfType<Droppable>();
        
        foreach (Droppable droppable in droppables)
        {
            //if colliding with mouse
            if (droppable.gameObject.GetComponent<BoxCollider2D>().OverlapPoint(mousePosition))
            {
                if (droppable.CheckItem())
                {
                    droppable.OnDrop();
                    return true;
                }
            }
        }

        return false;
    }
}
