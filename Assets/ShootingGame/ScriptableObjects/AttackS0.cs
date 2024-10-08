using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackS0", menuName = "TopDownController/attacks/Default",order=0)]
public class AttackS0 : ScriptableObject
{
    [Header("Attack")]
    public float size;
    public float delay;
    public float power;
    public float speed;
    public LayerMask target;

    [Header("Knock Back Info")]
    public bool isOnKnockBack;
    public float knockbackPower;
    public float knockbackTime;
}



