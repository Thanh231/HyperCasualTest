using UnityEngine;

public class PlayerPrevent : MonoBehaviour
{
    private Rigidbody2D rd;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }
    public void SetRotate(Vector2 dis)
    {
        Vector2 temp = dis - (Vector2)transform.position;
        temp.Normalize();
        float angle = Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg - 90f;

        rd.rotation = angle;
    }
}
