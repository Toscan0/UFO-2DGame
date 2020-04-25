using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Die()
    {
        StartCoroutine(MakePlayerDead(0.5f));
       
    }

    public void Respawn()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    private IEnumerator MakePlayerDead(float waitTime)
    {
        animator.SetTrigger("Dead");
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(waitTime);

        GetComponent<SpriteRenderer>().enabled = false;
    }
}
