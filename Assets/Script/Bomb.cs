using UnityEngine;
using UnityEngine.Rendering;

public class Bomb : MonoBehaviour
{
    public GameObject boomEffect;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Vector3 spawnPosition = transform.position;
            Destroy(gameObject);
            Splash(spawnPosition);
        }
    }

    void Splash(Vector3 position)
    {
        Instantiate(boomEffect, position, Quaternion.identity);
    }
}
