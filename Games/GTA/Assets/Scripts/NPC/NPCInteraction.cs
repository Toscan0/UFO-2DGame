using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] voiceLine;
    public int lineNumber;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(NPCVoiceover());
        }
    }

    IEnumerator NPCVoiceover()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        lineNumber = Random.Range(0, 3);
        audioSource.clip = voiceLine[lineNumber];
        audioSource.Play();

        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
