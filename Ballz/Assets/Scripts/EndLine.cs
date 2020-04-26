using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLine : MonoBehaviour
{
    private BallLaucher ballLaucher;

    private void Awake()
    {
        ballLaucher = FindObjectOfType<BallLaucher>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball")){
            ballLaucher.ReturnBall();
            collision.collider.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
