using UnityEngine;
using Random = UnityEngine.Random;

// "Character" refers to the object that the shield is moving around that the player cannot control.
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float timePerDirectionChange;
    [SerializeField] private float speed;
    [SerializeField] private bool goesTowardsCenter;

    public Vector2 Direction => _direction;
    private Vector2 _direction;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(ChangeDirection), 0, timePerDirectionChange);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * _direction);
    }

    // Ensure the character is on the screen.
    void LateUpdate()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint (transform.position);
        viewPos.x = Mathf.Clamp01 (viewPos.x);
        viewPos.y = Mathf.Clamp01 (viewPos.y);
        transform.position = Camera.main.ViewportToWorldPoint (viewPos);
    }

    void ChangeDirection()
    {
        if (goesTowardsCenter)
        {
            _direction = (new Vector3(Random.Range(-5f, 5f), Random.Range(-2.5f, 2.5f), 0) - transform.position).normalized;
        }
        else
        {
            _direction = Random.insideUnitCircle.normalized;
        }
    }
}
