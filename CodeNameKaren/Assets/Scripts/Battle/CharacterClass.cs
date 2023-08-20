using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characters", menuName = "Characters/Create new Character")]
public class CharacterClass : ScriptableObject
{
    //:)
    [SerializeField] public string Name;
    [SerializeField] string Description;

    //[TextArea]
    [SerializeField] public Sprite BattleImage;
    [SerializeField] public Sprite AttackImage;

    //stats
    [SerializeField] int maxHP;
    [SerializeField] int Attack;
    [SerializeField] int Defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int Speed;

    [SerializeField] CharacterType type1;
    [SerializeField] CharacterType type2;

    public enum CharacterType
    {
        None,
        Karen,
        Confusion,
        Understanding,
        Nonsense,
        Physical
    }

    public string getDescription()
    {
        return Description;
    }


    public string getName()
    {
        return name;
    }

    public CharacterType getCharacterType1()
    {
        return type1;
    }

    public CharacterType getCharacterType2()
    {
        return type2;
    }

    public int getMaxHP()
    {
        return maxHP;
    }

    public int getAttack()
    {
        return Attack;
    }

    public int getDefense()
    {
        return Defense;
    }

    public int getSpAttack()
    {
        return spAttack;
    }

    public int getSPDefense()
    {
        return spDefense;
    }

    public int getSpeed()
    {
        return Speed;
    }

    public List<LearnableMoves> GetLearnableMoves()
    {
        return learnableMoves;
    }

    [System.Serializable]
    public class LearnableMoves
    {
        [SerializeField] MoveBase moveBase;
        [SerializeField] int level;

        public MoveBase getMoveBase()
        {
            return moveBase;
        }

		public int getLevel()
		{
			return level;
		}
	}

    [SerializeField] List<LearnableMoves> learnableMoves;
}
