using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Character
{
	public CharacterClass Base { get; set; }
	public int level { get; set; }
	public int HP { get; set; }

	public List<Move> Moves { get; set; }
	
	public Character(CharacterClass pBase, int pLevel)
	{
		Base = pBase;
		level = pLevel;
		HP = MaxHP;

		Moves = new List<Move>();
		foreach (var move in Base.GetLearnableMoves()) 
		{ 
			if(move.getLevel() <= level)
			{
				Moves.Add(new Move(move.getMoveBase()));
			}

			if (Moves.Count >= 4)
				break;
		}
	}

	public int Attack
	{
		get { return Mathf.FloorToInt(Base.getAttack() * level / 100f) + 5; }
	}

	public int Defense
	{
		get { return Mathf.FloorToInt(Base.getDefense() * level / 100f) + 5; }
	}

	public int SpAttack
	{
		get { return Mathf.FloorToInt(Base.getSpAttack() * level / 100f) + 5; }
	}

	public int SpDefense
	{
		get { return Mathf.FloorToInt(Base.getSPDefense() * level / 100f) + 5; }
	}

	public int Speed
	{
		get { return Mathf.FloorToInt(Base.getSpeed() * level / 100f) + 5; }
	}

	public int MaxHP
	{
		get { return Mathf.FloorToInt(Base.getMaxHP() * level / 100f) + 5; }
	}
}
