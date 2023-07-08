using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed;

    // Or should have used Set private get or something
    public Vector2 Velocity
    {
        set => _velocity = value;
        get => _velocity;
    }
    private Vector2 _velocity;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_velocity.normalized * (speed * Time.deltaTime));
    }
}
