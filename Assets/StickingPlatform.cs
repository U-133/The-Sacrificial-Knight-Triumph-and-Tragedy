using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickingPlatform : MonoBehaviour
{
    public Collider2D platformColl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (platformColl.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (platformColl.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}