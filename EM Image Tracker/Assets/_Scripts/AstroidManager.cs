using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidManager : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void StartDisableCooldown()
    {
        audioSource.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        StartCoroutine(DisableCooldown());
    }

    private IEnumerator DisableCooldown()
    {
        yield return new WaitForSeconds(2);

        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
