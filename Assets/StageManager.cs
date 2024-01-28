using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] Transform _mainCurtain, _leftCurtain, _rightCurtain, _castle;
    [SerializeField] Transform _spears;
    [SerializeField] BackgroundCycle _nightDayCycle, _cloudCycle;
    
   // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Stage is Laoded");
        OutCurtain();
        GameManager.Instance.StartSequence(this);
    }

    public void InCurtain()
    {
        DOTween.Complete(_mainCurtain);
        _mainCurtain.gameObject.SetActive(true);
        _mainCurtain.DOMoveY(0, 3f).SetEase(Ease.InSine).SetAutoKill(true);
    }


    public void OutCurtain()
    {
        DOTween.Complete(_mainCurtain);
        _mainCurtain.gameObject.SetActive(true);
        _mainCurtain.DOMoveY(11, 3f).SetEase(Ease.InSine).SetAutoKill(true);
    }


    public void BounceCastle()
    {
        DOTween.Complete(_castle);
        _castle.DOPunchScale(Vector3.left * .3f, 1f).SetAutoKill(true);
    }

    public void AddSpears()
    {
        DOTween.Complete(_spears);
        _spears.gameObject.SetActive(true);
        _spears.rotation.SetEulerAngles(Vector3.zero);
        _spears.DOScale(Vector3.one, 1f);

    }
    public void RemoveSpears()
    {
        DOTween.Complete(_spears);
        _spears.DOPunchScale(Vector3.left * 1.5f, 1f).OnComplete(()=>_spears.gameObject.SetActive(false));
    }
}
