using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Move", menuName ="Character/Create New Move")]
public class MoveBase : ScriptableObject
{
	[SerializeField] string Name;

	[SerializeField] string Description;

	[SerializeField] public CharacterClass.CharacterType Type; //need to fix later maybe
	[SerializeField] public int Power;
	[SerializeField] int Accuracy;
	[SerializeField] public int PP;


}
