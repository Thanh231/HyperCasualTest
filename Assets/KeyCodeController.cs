using TMPro;
using UnityEngine;

public class KeyCodeController : MonoBehaviour
{
    public float velocity = 0.02f;
    private KeyCode key;
    public TextMeshProUGUI textKey;

    public void SetUpKeyCode(KeyCode _keyCode)
    {
        key = _keyCode;
        textKey.text = key.ToString();
    }
    void Update()
    {
        transform.position -= new Vector3(0, velocity);

        if (Input.GetKeyDown(key))
        {
            PlayerManager.instance.player.SetRotate((Vector2)transform.position);
            Destroy(gameObject);
        }
    }
}
