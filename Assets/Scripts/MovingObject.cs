using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.State != GameManager.GameState.Game)
        {
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = new Vector2(GameController.instance.moveSpeed, 0);
            return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.gameOver == true)
        {
            rigidbody.velocity = Vector2.zero;
        }
    }
}
