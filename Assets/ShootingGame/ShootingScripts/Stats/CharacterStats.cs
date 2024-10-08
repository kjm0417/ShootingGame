using UnityEngine;

public enum StatsChangeType
{
    Add, //0
    Multiple,//1
    Override //2
}

//데이터 폴더처럼 사용할 수 있게 만들어주는 Attribute
[System.Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType; //스텟 변화
    [Range(1, 100)] public int maxHealth; //어떤 체력
    [Range(1,20f)] public float speed; //어떤 스피드
    public AttackS0 attackS0; //어떤 무기
}