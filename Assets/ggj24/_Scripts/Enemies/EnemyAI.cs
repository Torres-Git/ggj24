using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour, IEnemy
{
    private Peasant _peasantData;
    private SpriteRenderer _enemySprite;
    private float _health;
    private float _halfHealth;
    private Vector3 _startPosition;

    private bool _isAvailable = true;
    public bool IsAvailable { get => _isAvailable;  }


    // Start is called before the first frame update
    private void Start()
    {
        _enemySprite = GetComponent<SpriteRenderer>();
        _startPosition = transform.position;
    }

    public void Init(Peasant peasantData)
    {
        _isAvailable = false;
        
        DOTween.Complete(transform);
        transform.position =_startPosition;
        _peasantData = peasantData;

        _enemySprite.sprite = _peasantData.Infected;
        _health = _peasantData.MaxHealth;
        _halfHealth = _health * .5f;

        transform.DOMoveX(-transform.position.x, _peasantData.WalkDuration).SetEase(Ease.Linear);
    }

    public void Tickle()
    {
        _health -= _peasantData.DamageTaken;

        if(_health <= _halfHealth)
        {
            _enemySprite.sprite = _peasantData.HalfCured;
        }
        if(_health <= 0f)
        {
            _enemySprite.sprite = _peasantData.Cured;
        }

        transform.DOBlendableLocalMoveBy(new Vector3(0f, _peasantData.JumpForce, 0f), _peasantData.JumpDuration).SetEase(Ease.OutQuint).OnComplete
        (
            ()=>
        transform.DOBlendableLocalMoveBy(new Vector3(0f, -_peasantData.JumpForce, 0f), _peasantData.FallDuration).SetEase(Ease.InSine)

        );
    }

    private void Clean()
    {
        Debug.Log("Im ready bro");
        DOTween.Complete(transform);

        _isAvailable = true;
        transform.position = _startPosition;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Castle")
        {
            // ScoreManager.GivePoints
            Clean();
        }    
    }

    
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Bounds")
        {
            Clean();
        }    
    }


}
public interface IEnemy
{
    void Tickle();
}
