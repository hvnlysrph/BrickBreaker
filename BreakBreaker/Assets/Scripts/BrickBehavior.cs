using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        if(collision.gameObject.tag == "ball")
        {
            GameManager.instance.bricksInPlay--;
            Destroy(gameObject);
        }
    }
}
