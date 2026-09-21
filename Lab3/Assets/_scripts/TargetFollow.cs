using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    public GameObject target;
    public float speed;

    //lerp current position towards our target position
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.transform.position.x, speed * Time.deltaTime), 0, 0);
    }
}
