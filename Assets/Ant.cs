using UnityEngine;

public class Ant : MonoBehaviour
{
    Rigidbody2D rd;
    private Vector2 randomPos;
    public float maxDis;
    public float smothSpeed;
    public float speed;
    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        randomPos = rd.position;

        Vector2 temp = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
        Vector2 dir = temp - randomPos;

        dir.Normalize();
        randomPos = dir * maxDis;
    }

    void Update()
    {      
        if (Vector2.Distance(transform.position,randomPos) < 0.1f)
        {
            Vector2 temp = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
            Vector2 dir = temp - randomPos;
            dir.Normalize();
            randomPos = dir * maxDis;
        }
        transform.position = Vector2.MoveTowards(transform.position, randomPos, speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        Vector2 test = randomPos - (Vector2)transform.position;
        float angle = Mathf.Atan2(test.y, test.x) * Mathf.Rad2Deg - 90f;
        float currentRotation = rd.rotation;
        float smooth = Mathf.LerpAngle(currentRotation, angle, smothSpeed * Time.deltaTime);
        rd.rotation = smooth;
    }
}
