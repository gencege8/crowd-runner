using System.Collections;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public BossSide boss;
    public CrowdManager crowd;
    public GameManager game;
    public float tickRate;
    
    public void StartBattle()
    {
        StartCoroutine(BattleTick());
    }
    IEnumerator BattleTick()
    {
        while (crowd.crowdCount > 0 && boss.hp > 0)
        {
            int totalDamage = crowd.GetTotalDamage();
            int bossDamage = boss.damage;
            boss.hp -= totalDamage;
            crowd.KillNpc(bossDamage);
            yield return new WaitForSeconds(tickRate);
        }
        if(crowd.crowdCount == 0)
        {
            game.EndGame(false);
        }
        else if (boss.hp <= 0)
        {
            game.EndGame(true);
        }
        
    }

}
