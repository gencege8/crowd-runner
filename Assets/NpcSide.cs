using UnityEngine;

public class NpcSide : MonoBehaviour
{
    public UnitData unitData;
    public int currentHp;

    private void Start()
    {
        currentHp = unitData.hp;
    }
}
