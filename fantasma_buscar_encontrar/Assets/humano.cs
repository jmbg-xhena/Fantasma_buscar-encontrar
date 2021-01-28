using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humano : MonoBehaviour
{
    public GameObject rama;

    // Start is called before the first frame update
    void Start()
    {
        rama.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("trampa")) {
            Destroy(collision.gameObject);
        }
    }
}
