using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Peasant", menuName = "ScriptableObjects/PeasantScriptableObject", order = 1)]
public class PeasantScriptableObject : ScriptableObject
{
    public bool spawnLeft;
    public float walkSpeed; 
    public float jumpForce;
    public float maxHealth;
    public float damageTaken;
    public float jumpDuration;
    public Sprite infected;
    public Sprite halfCured;
    public Sprite cured;
}
