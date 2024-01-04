using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject line;
    public List<Sprite> ballSprites;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public CircleCollider2D col;
    public BallCreation ballCreation;
    private bool hasCreatedNewBall = false;
    public float scaleCoefficient = 0.02f;
    public ScoreManager scoreManager; // Make sure this line is at the top of your script
    public MenuScript menuScript;

    public enum BallSize
    {
        ExtraSmall,
        Small,
        Tiny,
        Miniature,
        Normal,
        Large,
        ExtraLarge,
        Huge,
        Gigantic,
        Enormous
    }

    public BallSize ballSize = BallSize.ExtraSmall;
    public float base_size = 0.3f;

    public void Start()
    {
        ballCreation = GameObject.FindGameObjectWithTag("BallManager").GetComponent<BallCreation>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        menuScript = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<MenuScript>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !collision.gameObject.GetComponent<BallScript>().hasCreatedNewBall)
        {
            BallSize otherSize = collision.gameObject.GetComponent<BallScript>().ballSize;

            if (ballSize == otherSize)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                CreateBiggerBall(collision.gameObject.transform);
                hasCreatedNewBall = true;

            }
        }
    }

    public void DropBall()
    {
        rb.velocity = Vector2.zero;
    }

    void CreateBiggerBall(Transform otherBall)
    {
        if (ballSize == BallSize.Enormous)
        {
            menuScript.EndGame();
            return;
        }
        BallSize newSize = GetNextSize(ballSize);
        Vector3 newPosition = Vector3.Lerp(transform.position, otherBall.position, 0.5f);
        newPosition += new Vector3(0, 0.2f);

        // Add points based on the size of merging balls
        int points = (int)newSize * 50 + 100; // You can adjust this logic based on your scoring system

        // Call the ScoreManager to add points
        if (scoreManager != null)
        {
            scoreManager.AddScore(points);
        }

        


        ballCreation.CreateBall(newPosition, newSize);
    }

    public void SetSize(BallSize newSize)
    {
        ballSize = newSize;
        float newScale = base_size + (int)newSize * scaleCoefficient;
        transform.localScale = new Vector3(newScale, newScale, 1f);
        spriteRenderer.sprite = ballSprites[(int)newSize];
    }

    BallSize GetNextSize(BallSize currentSize)
    {
        // Logic to determine the next size
        switch (currentSize)
        {
            case BallSize.ExtraSmall:
                return BallSize.Small;
            case BallSize.Small:
                return BallSize.Tiny;
            case BallSize.Tiny:
                return BallSize.Miniature;
            case BallSize.Miniature:
                return BallSize.Normal;
            case BallSize.Normal:
                return BallSize.Large;
            case BallSize.Large:
                return BallSize.ExtraLarge;
            case BallSize.ExtraLarge:
                return BallSize.Huge;
            case BallSize.Huge:
                return BallSize.Gigantic;
            case BallSize.Gigantic:
                return BallSize.Enormous;
            default:
                return currentSize;
        }
    }
}
