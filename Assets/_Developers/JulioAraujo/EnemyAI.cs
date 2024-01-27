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



    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        enemyRenderer = GetComponent<SpriteRenderer>();
        enemySprite.sprite = peasant.infected;
        health = peasant.maxHealth;
        halfHealth = health/2f;
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
            transform.DOBlendableLocalMoveBy(new Vector3(0f, -peasant.weight, 0f), peasant.fallSpeed); 
            

            //rb.AddForce(Vector2.up * peasant.floatSpeed);
            //transform.position += Vector3.up * Time.deltaTime * floatSpeed;
        }
        else
        {
        }

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
