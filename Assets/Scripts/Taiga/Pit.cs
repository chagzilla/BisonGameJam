using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Transform>().position = Checkpoints.Instance.checkpoints[Checkpoints.Instance.currentpoint];
            if (collision.gameObject.TryGetComponent(out Rigidbody2D rb2D))
            {
                rb2D.velocity = Vector2.zero;
            }
        }
    }
}
