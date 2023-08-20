using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit PlayerUnit;
    [SerializeField] BattleUnit EnemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud EnemyHud;
    // Start is called before the first frame update
    void Start()
    {
        SetupBattle();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetupBattle()
    {
        PlayerUnit.SetUp();
        playerHud.setData(PlayerUnit.Character);
        EnemyUnit.SetUp();
        EnemyHud.setData(EnemyUnit.Character);
    }
}
