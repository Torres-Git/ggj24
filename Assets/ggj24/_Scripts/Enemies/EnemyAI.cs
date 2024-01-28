using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour, IEnemy
{
    private Peasant _peasantData;
    [SerializeField] SpriteRenderer _enemySprite;
    private float _hitPoints;
    private Vector3 _startPosition;
    private Vector3 _startScale;

    private bool _isAvailable = true;
    public bool IsAvailable { get => _isAvailable;  }
    public SpriteRenderer EnemySprite { get => _enemySprite; set => _enemySprite = value; }


    // Start is called before the first frame update
    private void Start()
    {
        _enemySprite = GetComponent<SpriteRenderer>();
        _startPosition = transform.position;
        _startScale = transform.localScale;
    }

    public void Init(Peasant peasantData)
    {
        _isAvailable = false;
        
        DOTween.Complete(transform);
        transform.position =_startPosition;
        _peasantData = peasantData;

        _enemySprite.sprite = _peasantData.Infected;
        _hitPoints = _peasantData.MaxHealth;

        transform.DOMoveX(-transform.position.x, _peasantData.WalkDuration).SetEase(Ease.Linear);
    }

    public void Tickle()
    {
        _hitPoints -= _peasantData.DamageTaken;

        if(_hitPoints <= 0f)
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
        transform.localScale = _startScale;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Castle")
        {
            if(_hitPoints <= 0)
            {
                var doorPos = FindChildWithTag(other.gameObject,"Door").transform.position;

                transform.DOMove(doorPos,.7f);
                transform.DOScale(_startScale *.4f ,.7f).OnComplete(()=> Clean());
                // ScoreManager.GivePoints???
            }
            else
            {
                var doorPos = FindChildWithTag(other.gameObject,"Door").transform.position;

                transform.DOMove(doorPos,.7f).SetAutoKill(true);
                transform.DOPunchRotation(Vector3.forward * 45, .3f);
                transform.DOScale(_startScale *.4f ,.7f).OnComplete(()=> Clean());
                GameManager.Instance.DamageCastle(1); // JULIO DO IT
                // ScoreManager.GivePoints???
            }


        }    
    }

    
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Bounds")
        {
            Clean();
        }    
    }


    private GameObject FindChildWithTag(GameObject parent, string tag) 
    {
        GameObject child = null;
 
       foreach(Transform transform in parent.transform) {
          if(transform.CompareTag(tag)) {
             child = transform.gameObject;
            break;
        }
   }
 
   return child;
}

}
public interface IEnemy
{
    void Tickle();
}
