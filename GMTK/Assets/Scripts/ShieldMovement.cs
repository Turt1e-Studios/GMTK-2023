using System;
using UnityEngine;

public class ShieldMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject character;
    [SerializeField] private float radius;
    private Vector3 _charPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Shield will always point towards the character but also be the same relative position as the cursor
    void Update()
    {
        // Have to use SCREENTOWORLDPOINT for WORLD position, not screen position.
        _charPosition = character.transform.position;
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        // Figured all this out after doing some trig equation solving with my dad
        // the "zero" is where the charPosition is
        float deltaX = mousePos.x - _charPosition.x;
        float deltaY = mousePos.y - _charPosition.y;
        float slope = deltaY / deltaX;

        if (deltaX < 0)
        {
            slope *= -1;
        }

        float changeX = (float) Math.Sqrt(Math.Pow(radius, 2) / (Math.Pow(slope, 2) + 1));
        float changeY = slope * changeX;
        
        if (deltaX < 0)
        {
            changeX *= -1;
        }

        transform.position = _charPosition + new Vector3(changeX, changeY, 0);
        
        // Point towards char
        transform.up = transform.position - character.transform.position; 
    }
}
