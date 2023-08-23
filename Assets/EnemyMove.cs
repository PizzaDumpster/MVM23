using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float interpolator;
    [SerializeField] bool movingTwardB;
    [SerializeField] bool movingTwardA;
    [SerializeField] float step = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        movingTwardB = true;
        movingTwardA = false;
        transform.position = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (interpolator <= 1 && !movingTwardA && movingTwardB)
        {
            movingTwardB = true;
            movingTwardA = false;
            interpolator += step;
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, step);
            if (transform.position == pointB.position)
            {
                movingTwardB = false;
                movingTwardA = true;
                interpolator -= step;
            }
        }
        if (interpolator >= 0 && !movingTwardB && movingTwardA)
        {
            movingTwardB = false;
            movingTwardA = true;
            interpolator -= step;
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, step);
            if (transform.position == pointA.position)
            {
                movingTwardB = true;
                movingTwardA = false;
                interpolator += step;
            }
        }
        if (interpolator > 1)
            interpolator = 1;
        if (interpolator < 0) 
            interpolator = 0;




    }
}
