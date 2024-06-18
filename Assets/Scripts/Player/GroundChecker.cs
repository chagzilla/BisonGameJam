using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            GetComponentInParent<Player>().isTouchingGround = true;
            GetComponentInParent<Player>().canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            GetComponentInParent<Player>().isTouchingGround = false;
        }
    }
}
