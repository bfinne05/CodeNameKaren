using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] CharacterClass Base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;
    // Start is called before the first frame update

    public Character Character { get; set; }

    public void SetUp()
    {
        Character = new Character(Base, level);
        if(isPlayerUnit)
        {
            GetComponent<Image>().sprite = Character.Base.BattleImage; //front sprite
        }
        else
        {
            GetComponent<Image>().sprite=Character.Base.AttackImage; //back sprite?
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
