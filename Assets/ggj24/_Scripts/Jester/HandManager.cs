using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandManager : MonoBehaviour
{
    [SerializeField] MouseFollow _leftHand, _rightHand;
    private MouseFollow _currentHand;

    // Start is called before the first frame update
    void Start()
    {
        _currentHand = (Input.mousePosition.x >= Mathf.Epsilon) ? _rightHand : _leftHand;
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mousePos.x >= Mathf.Epsilon && _currentHand == _leftHand)
        {
            SwitchHands();
        }

        if(mousePos.x < Mathf.Epsilon && _currentHand == _rightHand)
        {
            SwitchHands();
        }

    }

    private void SwitchHands()
    {
        _currentHand.enabled = false;
        _currentHand.transform.DOMove(_currentHand.StartPosition, 1f).SetAutoKill(false);

        _currentHand = (_currentHand == _leftHand) ? _rightHand : _leftHand;

        DOTween.Kill(_currentHand.transform);
        _currentHand.enabled = true;
        // Debug.Log("hand swicthed to:" + _currentHand.name);
    }
}
