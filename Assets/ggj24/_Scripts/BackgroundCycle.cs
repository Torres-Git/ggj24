using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundCycle : MonoBehaviour
{
    [SerializeField] Vector3 _rotationAxis = Vector3.up;  // Set the axis you want to rotate around
     [SerializeField] float _cycleDuration = 60; 

    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(_rotationAxis * 360f,_cycleDuration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Incremental)
            .SetEase(Ease.Linear).OnStepComplete(()=> Debug.Log("Day Completed!"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
