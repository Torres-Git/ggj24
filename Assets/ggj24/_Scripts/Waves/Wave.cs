using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Waves/Wave")]
public class Wave : DescriptionBasedSO
{
    [Header("Rest")]
    [SerializeField] float _restDurationBeforeWave = 10f;
    [SerializeField] float _extraDurationWindow = 2f;
    
    [Header("Config")]
    [SerializeField] List<Peasant> _peasants;
    [SerializeField]float _duration;

    public float RestDurationBeforeWave { get => _restDurationBeforeWave;  }
    public List<Peasant> Peasants { get => _peasants;  }
    public float Duration { get => _duration;  }
}


