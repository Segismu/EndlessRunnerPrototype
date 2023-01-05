using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField] float limitPos;

    void Start()
    {
        startPos = transform.position;
        limitPos = GetComponent<BoxCollider>().size.x / 2;
    }


    void Update()
    {
        if (transform.position.x < startPos.x - limitPos)
        {
            transform.position = startPos;
        }
    }
}
