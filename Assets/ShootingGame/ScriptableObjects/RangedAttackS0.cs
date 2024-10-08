using UnityEngine;

[CreateAssetMenu(fileName = "RangeAttackS0",menuName = "TopDownController/attacks/Ranged",order =1)]
public class RangedAttackS0 : AttackS0
{
    [Header("Ranged Attack Info")]
    public string bulletnameTag;
    public float duration;
    public float spread;
    public int numberOfProjectilesPerShot;
    public float multipleProjectilesAngle;
    public Color projectileColor;

}



