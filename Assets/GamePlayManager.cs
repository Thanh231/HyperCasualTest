using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public KeyCodeController hotKey;
    float timer;
    public List<KeyCode> keyCodes;
    public float spawnX;
    void Start()
    {
        //InvokeRepeating("SpawnHotKey" ,0, 5f);
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 3f;
            SpawnHotKey();
        }
    }
    public void SpawnHotKey()
    {
        int index = Random.Range(0, keyCodes.Count);
        Vector2 pos = new Vector2(Random.Range(-spawnX, spawnX), transform.position.y);
        KeyCodeController key = Instantiate(hotKey, pos,Quaternion.identity);
        key.SetUpKeyCode(keyCodes[index]);
    }
}
