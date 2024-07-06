using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform WayPoint1;
    public Transform WayPoint2;
    public float Speed = 5f;
    private Transform _currentTarget;
    public Renderer CarRenderer;

    void Start()
    {
        _currentTarget = WayPoint1;
        if (CarRenderer == null)
        {
            Debug.LogError("Car does not have a Renderer component.");
        }
    }

    void Update()
    {
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _currentTarget.position) < 0.1f)
        {
            ChangeColor();

            _currentTarget = _currentTarget == WayPoint1 ? WayPoint2 : WayPoint1;

            Vector3 direction = (_currentTarget.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    void ChangeColor()
    {
        CarRenderer.materials[1].color = new Color(Random.value, Random.value, Random.value);
    }
}
