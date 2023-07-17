using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;

    public bool IsFacingRight;

    public Collider2D bossCollider;

    public Rigidbody2D rb;

    public Animator anim;

    public GameObject bossHealthBar;

    private void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        IsFacingRight = false;
        bossHealthBar.SetActive(false);
    }

    private void Update()
    {
        OnTriggerEnter2D(bossCollider);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            anim.SetBool("IsFightStarted", true);
            bossCollider.enabled = false;
            bossHealthBar.SetActive(true);
        }
    }

    

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(player != null){
            
            if (transform.position.x > player.position.x && IsFacingRight)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                IsFacingRight = false;
            }
            else if (transform.position.x < player.position.x && !IsFacingRight)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                IsFacingRight = true;
            }
        }
    }
   

}
