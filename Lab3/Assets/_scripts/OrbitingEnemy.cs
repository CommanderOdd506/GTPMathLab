using UnityEngine;

public class OrbitingEnemy : MonoBehaviour
{

    public Transform player;

    public Transform target;

    [SerializeField] private float radius = 5f;
    [SerializeField] private float degreesPerSecond = 45f;

    private float currentAngle;   // in degrees

    private void Update()
    {
        currentAngle += degreesPerSecond * Time.deltaTime;

        float radians = currentAngle * Mathf.Deg2Rad;

        // A point on a circle in the XZ plane
        float offsetX = Mathf.Cos(radians) * radius;
        float offsetY = Mathf.Sin(radians) * radius;

        transform.position = target.position + new Vector3(offsetX, offsetY, 0f);

        FaceTarget();
    }

    private void FaceTarget()
    {
        Vector3 directionToTarget = player.position - transform.position;
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
