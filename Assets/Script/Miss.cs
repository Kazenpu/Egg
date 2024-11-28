using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Miss : MonoBehaviour
{
    private int miss = 5;
    public TextMeshProUGUI missText;
    public GameObject gameOverCanvas;

    void Start()
    {
        gameOverCanvas.SetActive(false);
        Missed();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            miss -= 1;
            Missed();

            if (miss == 0)
            {
                GameOver();
            }
        }
    }
    void Missed()
    {
        missText.text = "Miss: " + miss.ToString();
    }
    void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
