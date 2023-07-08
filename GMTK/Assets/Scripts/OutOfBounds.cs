using System;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        if (Math.Abs(position.x) > 10 || Math.Abs(position.y) > 5)
        {
            Destroy(gameObject);
        }
    }
}
