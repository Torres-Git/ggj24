using UnityEngine;

[CreateAssetMenu(fileName = "Peasant_", menuName = "Waves/PeasantData")]
public class Peasant : DescriptionBasedSO
{
    [SerializeField] string _peasantName ="Socrates";
    [SerializeField]  float _walkDuration;
    [SerializeField]  float _jumpForce;
    [SerializeField]  float _maxHealth;
    [SerializeField]  float _damageTaken;
    [SerializeField]  float _jumpDuration;
    [SerializeField]  float _fallDuration;
    [SerializeField]  Sprite _infected, _halfCured, _cured;

    public string Name { get => _peasantName;  }
    public float WalkDuration { get => _walkDuration; }
    public float JumpForce { get => _jumpForce;  }
    public float MaxHealth { get => _maxHealth;  }
    public float DamageTaken { get => _damageTaken;  }
    public float JumpDuration { get => _jumpDuration;  }
    public float FallDuration { get => _fallDuration;  }
    public Sprite Infected { get => _infected; }
    public Sprite HalfCured { get => _halfCured; }
    public Sprite Cured { get => _cured;  }

}

