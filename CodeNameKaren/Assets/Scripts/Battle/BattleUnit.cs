using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] CharacterClass Base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;
    // Start is called before the first frame update

    public Character Character { get; set; }

    Image image;
    Vector3 originalPos;
    Color originalColor;
	private void Awake()
	{
		image = GetComponent<Image>();
        originalPos = image.transform.localPosition;
        originalColor = image.color;
	}

	public void SetUp()
    {
        Character = new Character(Base, level);
        if(isPlayerUnit)
        {
            image.sprite = Character.Base.BattleImage; //front sprite
        }
        else
        {
            image.sprite=Character.Base.AttackImage; //back sprite?
        }
        PlayerEnterAnimation();
    }


    public void PlayerEnterAnimation()
    { 
        if(isPlayerUnit)
        {
            image.transform.localPosition = new Vector3(-500f, originalPos.y, originalPos.z);
        }
        else
        {
            image.transform.localPosition = new Vector3(500f, originalPos.y, originalPos.z);
        }

        image.transform.DOLocalMoveX(originalPos.x, 1f);
    }

    public void PlayAttackAnimation()
    {
        var sequence = DOTween.Sequence();
        if(isPlayerUnit)
        {
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x + 50f, 0.25f));
        }
        else
        {
			sequence.Append(image.transform.DOLocalMoveX(originalPos.x - 50f, 0.25f));
		}

        sequence.Append(image.transform.DOLocalMoveX(originalPos.x, 0.25f));
    }

    public void PlayHitAnimation()
    {
        var Sequence = DOTween.Sequence();
        Sequence.Append(image.DOColor(Color.grey, 0.1f));
        Sequence.Append(image.DOColor(originalColor, 0.1f));
    }

    public void PlayFaintAnimation() //use this to create animation of girl scout getting punted by karen add to original pos
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.transform.DOLocalMoveY(originalPos.y - 150f, 0.5f));
        sequence.Join(image.DOFade(0f, 0.5f));
    }

	public void PlayPuntAnimation()
	{
		var sequence = DOTween.Sequence();
		sequence.Append(image.transform.DOLocalMoveY(originalPos.y + 150f, 0.5f));
		sequence.Join(image.DOFade(0f, 0.5f));
	}
}
