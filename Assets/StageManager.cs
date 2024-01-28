using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] Transform _mainCurtain, _leftCurtain, _rightCurtain, _castle;
    [SerializeField] BackgroundCycle _nightDayCycle, _cloudCycle;

    // Start is called before the first frame update
    void Start()
    {
        _mainCurtain.DOMoveY(-20, 1f).SetEase(Ease.InElastic).SetAutoKill(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
