using UnityEngine;

public class OrbitingEnemy : MonoBehaviour
{

    public Transform player;

    public Transform target;

    [SerializeField] private float radius = 5f;
    [SerializeField] private float baseSpeedMultiplier = 5f;
    private float degreesPerSecond = 45f;

    private float currentAngle;

    private void Update()
    {
        OrbitTarget();
        FaceTarget();
        CalculateSpeed();
    }

    // Orbit about the set target at a defined radius
    private void OrbitTarget()
    {
        //add our desired turn speed to our current angle to continusly rotate
        currentAngle += degreesPerSecond * Time.deltaTime;

        //convert current angle from degrees to radians
        float radians = currentAngle * Mathf.Deg2Rad;

        // calculate the relevant xy coordinates on a circle
        float offsetX = Mathf.Cos(radians) * radius;
        float offsetY = Mathf.Sin(radians) * radius;

        //set our current position to spot on circle
        transform.position = target.position + new Vector3(offsetX, offsetY, 0f);
    }

    //snap Y axis to point towards target
    private void FaceTarget()
    {
        //calcuate direction from current here to our target
        Vector3 directionToTarget = player.position - transform.position;

        //derive angle to target through the direction vector
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        //snap rotation to face our target
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }

    //set speed to distnace * multipler
    private void CalculateSpeed()
    {
        //claculate distance without taking the square root in the magnitude
        var distanceSquared = (player.position - transform.position).sqrMagnitude;

        //set our speed to our square magnitude and mutltiplt with movement modifier
        degreesPerSecond = distanceSquared * baseSpeedMultiplier;
    }
}
