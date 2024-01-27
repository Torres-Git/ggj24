using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Peasant_", menuName = "Waves/PeasantData")]
public class Peasant : DescriptionBasedSO
{
    [SerializeField] string _name ="Socrates"; // JULIO DO IT

    [SerializeField] float _sickLevel; // JULIO DO IT
    [SerializeField] float _rizzLevel; // JULIO

    [SerializeField] Sprite _appearance;
    
    public float SickLevel { get => _sickLevel; }
    public float RizzLevel { get => _rizzLevel; }
    public string Name { get => _name;  }
}

