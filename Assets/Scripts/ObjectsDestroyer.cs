using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDestroyer : MonoBehaviour
{
    private BoxCollider boxCollider;
    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
