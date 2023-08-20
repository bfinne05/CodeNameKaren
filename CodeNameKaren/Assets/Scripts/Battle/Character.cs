using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Character
{
	CharacterClass _base;
	int level;
	public int HP { get; set; }

	public List<Move> Moves { get; set; }
	
	public Character(CharacterClass pBase, int pLevel)
	{
		_base = pBase;
		level = pLevel;
		HP = _base.getMaxHP();

		Moves = new List<Move>();
		foreach (var move in _base.GetLearnableMoves()) 
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
		get { return Mathf.FloorToInt(_base.getAttack() * level / 100f) + 5; }
	}

	public int Defense
	{
		get { return Mathf.FloorToInt(_base.getDefense() * level / 100f) + 5; }
	}

	public int SpAttack
	{
		get { return Mathf.FloorToInt(_base.getSpAttack() * level / 100f) + 5; }
	}

	public int SpDefense
	{
		get { return Mathf.FloorToInt(_base.getSPDefense() * level / 100f) + 5; }
	}

	public int Speed
	{
		get { return Mathf.FloorToInt(_base.getSpeed() * level / 100f) + 5; }
	}

	public int MaxHP
	{
		get { return Mathf.FloorToInt(_base.getMaxHP() * level / 100f) + 5; }
	}
}
