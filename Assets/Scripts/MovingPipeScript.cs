
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovingPipeScript : MonoBehaviour
{

    public float frequency;
    public float amplitude;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = Random.Range(- Mathf.PI, Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, (float) Mathf.Sin(Time.time * frequency + offset) * amplitude, transform.position.z);
    }
}
