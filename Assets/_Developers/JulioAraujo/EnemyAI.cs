using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private PeasantScriptableObject peasant;
    private SpriteRenderer enemySprite;
    private SpriteRenderer enemyRenderer;
    private Rigidbody2D rb;
    private float health;
    private float halfHealth;
    [SerializeField] private bool reachedCastle = false;
    [SerializeField] private bool isClicked = false;
    private int direction;
    private float groundPosition;
    [SerializeField] Transform xAxis;
    [SerializeField] Transform yAxis;



    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        enemyRenderer = GetComponent<SpriteRenderer>();
        enemySprite.sprite = peasant.infected;
        health = peasant.maxHealth;
        halfHealth = health/2f;
        //if (peasant.spawnLeft)
        //{
        //    direction = 1;
        //}
        //else
        //{
        //    direction = -1;
        //}
        groundPosition = transform.position.y;
        transform.DOMoveX(-transform.position.x, peasant.walkSpeed).SetEase(Ease.OutExpo);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
            health -= peasant.damageTaken;
        }
        else
        {
            isClicked = false;
        }

        if(health <= halfHealth)
        {
            enemySprite.sprite = peasant.halfCured;
        }
        if(health <= 0f)
        {
            enemySprite.sprite = peasant.cured;
        }

        if (isClicked)
        {
            //rb.gravityScale = 0f;

            transform.DOBlendableLocalMoveBy(new Vector3(0f, peasant.jumpForce, 0f), peasant.jumpDuration);
            //yAxis.DOJump(new Vector3(transform.position.x, groundPosition, transform.position.z), peasant.jumpForce, 1, peasant.jumpDuration);
            
            //rb.AddForce(Vector2.up * peasant.floatSpeed);
            //transform.position += Vector3.up * Time.deltaTime * floatSpeed;
        }
            //else
            //{
            //    rb.gravityScale = 1f;
            //}

        if (isClicked && !enemyRenderer.isVisible)
        {
            Debug.Log("Im dead bro");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Castle")
        {
            reachedCastle = true;
        }
    }
}
