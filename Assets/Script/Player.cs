using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public TextMeshProUGUI heartText;
    private int heart = 5;
    public TextMeshProUGUI finalScoreLoseText;
    public TextMeshProUGUI finalScoreWinText;
    private int finalScore;
    public TextMeshProUGUI missCountText;
    private int missCount = 6;
    public TextMeshProUGUI missTotalWinText;
    public TextMeshProUGUI missTotalLoseText;
    private int missTotal = -1;

    public GameObject winCanvas;
    public GameObject gameOverCanvas;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 move;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        winCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        Score();
        Heart();
        MissCount();
    }
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        move.Normalize();

        if (move.x > 0)
        {
            Flip(false);
        }
        else if (move.x < 0)
        {
            Flip(true);
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = move * speed;
    }
    void Flip(bool facingLeft)
    {
        Vector2 newScale = transform.localScale;
        newScale.x = facingLeft ? -1 : 1; //toan tu 3 ngoi
        transform.localScale = newScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            Destroy(collision.gameObject);
            score += 10;

            Score();
            
            if (score == 100)
            {
                Win();
            }
        }
        if (collision.gameObject.CompareTag("Bomb"))
        {
            animator.SetTrigger("Is Hurt");
            if (score > 0)
            {
                score -= 10;
            }
            heart -= 1;

            Score();
            Heart();

            if (heart == 0)
            {
                GameOver();
            }
        }
        if (collision.gameObject.CompareTag("Border"))
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
    void Score()
    {
        scoreText.text = "" + score.ToString();
        finalScore = score;
    }
    void Heart()
    {
        heartText.text = "x " + heart.ToString();
    }
    void Win()
    {
        winCanvas.SetActive(true);
        finalScoreWinText.text = "Final Score: " + finalScore.ToString();
        missTotalWinText.text = "Missed: " + missTotal.ToString();
        Time.timeScale = 0;
    }
    void GameOver()
    {
        gameOverCanvas.SetActive(true);
        finalScoreLoseText.text = "Final Score: " + finalScore.ToString();
        missTotalLoseText.text = "Missed: " + missTotal.ToString();
        Time.timeScale = 0;
    }
    public void MissCount()
    {
        missCount -= 1;
        missTotal += 1;

        if (missCount == 0)
        {
            GameOver();
        }
        UpdateMissCount();
    }

    void UpdateMissCount()
    {
        missCountText.text = "Miss: " + missCount.ToString();
    }
}
