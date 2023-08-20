using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI NameText;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] HPBar hPBar;

    Character _character;
    public void setData(Character character)
    {
        _character = character;

        NameText.text = character.Base.Name;
        LevelText.text = "Lvl " + character.level;
        hPBar.setHP((float)character.HP / character.MaxHP);
    }
    public IEnumerator UpdateHP()
    {
        yield return hPBar.SetHPSmooth((float)_character.HP / _character.MaxHP);
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
