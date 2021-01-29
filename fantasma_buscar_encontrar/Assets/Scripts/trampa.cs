using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
