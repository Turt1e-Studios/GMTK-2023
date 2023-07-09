using System;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public float SpeedMultiplier { get; set; }
    [SerializeField] private float speed;
    private GameObject objectFollowing;
    
    // Start is called before the first frame update
    void Start()
    {
        objectFollowing = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((objectFollowing.transform.position - transform.position).normalized * (speed * SpeedMultiplier * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }
}
