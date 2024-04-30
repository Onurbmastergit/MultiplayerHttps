using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0 , 50* Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }
}
