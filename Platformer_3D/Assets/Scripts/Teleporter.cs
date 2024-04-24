using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (transform.tag == "TPTODungeon")
        {
            other.transform.position = new Vector3(-116f, 78f, 132f);
            return;
        }

        if (transform.tag == "TPToCastle")
        {
            other.transform.position = new Vector3(-203f, 21f, 138f);
            return;
        }
        if (transform.tag == "TPToCastleTP")
        {
            other.transform.position = new Vector3(-198f, 21f, 71f);
            return;
        }

    }
}
