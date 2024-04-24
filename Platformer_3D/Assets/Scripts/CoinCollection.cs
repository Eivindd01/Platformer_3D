using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class CoinCollection : MonoBehaviour
{
    public GameObject[] coinsToInstantiate;

    [SerializeField]
    public List<Transform> listPos;

    private void Start()
    {
       SpawnCoins();
    }

    void SpawnCoins() 
    { 
        foreach(var pos in listPos)
        {
            int n = Random.Range(0, coinsToInstantiate.Length);
            Instantiate(coinsToInstantiate[n], pos.position, coinsToInstantiate[n].transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ICollectable iCollectable = other.gameObject.GetComponent<ICollectable>();

        if (iCollectable == null) 
        {
            return;
        }
        iCollectable.OnCollected();

       /* coinAudioDestination.PlayOneShot(coinAudioSource);

        if (other.transform.tag == "Coin_Penta")
        {
            coin++;
            coinText.text = "Coins: " + coin.ToString();
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Coin_Diamondo")
        {
            coin += 2;
            coinText.text = "Coins: " + coin.ToString();
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Coin_Diamondo5side")
        {
            coin += 3;
            coinText.text = "Coins: " + coin.ToString();
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Coin_SoftStar")
        {
            coin += 5;
            coinText.text = "Coins: " + coin.ToString();
            Destroy(other.gameObject);
        }*/
    }
}
