using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour, ICollectable
{
    [SerializeField]
    GameObject visual;

    [SerializeField]
    AudioSource coinsAudioSource;

    [SerializeField]
    Collider coll;

    public int coinsValue;

    public void OnCollected()
    {
        StartCoroutine(CollectCorout());
    }

    IEnumerator CollectCorout()
    {
        coll.enabled = false;
        coinsAudioSource.Play();
        visual.SetActive(false);
        yield return null;

        ScoreCoin.instance.score += coinsValue;

        while (coinsAudioSource.isPlaying)
        {
            yield return null;
        }
       Destroy(gameObject);
    }

}
