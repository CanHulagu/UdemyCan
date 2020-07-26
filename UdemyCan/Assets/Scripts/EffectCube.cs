using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(0.6f, 1.2f);
        Destroy(gameObject, x);
    }

}
