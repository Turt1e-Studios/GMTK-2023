using System;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    // https://math.stackexchange.com/questions/13261/how-to-get-a-reflection-vector
    // THIS FKING WORKS LETS GOOOOOOOO
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Shield"))
        {
            Vector2 d = gameObject.GetComponent<MoveForward>().Velocity;
            Vector2 n = col.transform.up; // the respective normal vector
            gameObject.GetComponent<MoveForward>().Velocity = d - 2 * n.normalized * (Vector2.Dot(d, n));
        }
    }
}
