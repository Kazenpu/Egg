using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Egg : MonoBehaviour
{
    public GameObject splash;
    private Player player;
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (player != null)
            {
                player.MissCount();
            }
            Vector3 spawnPosition = transform.position;
            Destroy(gameObject);
            Splash(spawnPosition);
        }
    }

    void Splash(Vector3 position)
    {
            Instantiate(splash, position, Quaternion.identity);
    }
}
