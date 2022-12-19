using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundColider;
    private float groundHorizantalLenght;
    // Start is called before the first frame update
    void Start()
    {
        groundColider = GetComponent<BoxCollider2D>();
        groundHorizantalLenght = groundColider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -groundHorizantalLenght)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizantalLenght * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
