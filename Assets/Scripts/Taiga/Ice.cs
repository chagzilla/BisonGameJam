using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {


            if (collision.gameObject.TryGetComponent(out Player player))
            {
                player.movementType = MovementType.SLIDING;
                if (collision.gameObject.TryGetComponent(out Rigidbody2D rb2D))
                {
                    rb2D.velocity = player.dir.normalized * player.topDownSpeed;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.TryGetComponent(out Rigidbody2D rb2D))
            {
                rb2D.velocity = Vector2.zero;
            }

            if (collision.gameObject.TryGetComponent(out Player player))
            {
                player.movementType = MovementType.TOPDOWN;
            }

        }
    }
}
