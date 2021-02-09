using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 init_pos;
    void Start()
    {
        init_pos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = init_pos;
    }
}
