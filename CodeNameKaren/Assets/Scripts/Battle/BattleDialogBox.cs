using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] int lettersPerSecond;
    [SerializeField] TextMeshProUGUI DialogText;
    [SerializeField] Color highlightedColor;

    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<TextMeshProUGUI> actionTexts;
    [SerializeField] List<TextMeshProUGUI> moveTexts;

    [SerializeField] TextMeshProUGUI PPText;
    [SerializeField] TextMeshProUGUI typeText;


    // Start is called before the first frame update

    public void SetDialog(string dialog)
    {
        DialogText.text = dialog;
    }

    public IEnumerator TypeDialog(string dialog)
    {
        DialogText.text = "";
        foreach(var letter in dialog.ToCharArray())
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }

    public void EnableDialogText(bool enabled)
    {
        DialogText.enabled = enabled;
    }

	public void EnableActionSelector(bool enabled)
	{
		actionSelector.SetActive(enabled);
	}

	public void EnableMoveSelector(bool enabled)
	{
		moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
	}

    public void UpdateActionSelection(int selectedAction)
    {
        for(int i = 0; i < actionTexts.Count; i++)
        {
            if(i == selectedAction)
            {
                actionTexts[i].color = highlightedColor;
            }
            else
            {
				actionTexts[i].color = Color.black;
			}
        }
    }

    public void UpdateMoveSelection(int selectedMove, Move move)
    {
		for (int i = 0; i < moveTexts.Count; i++)
		{
			if (i == selectedMove)
			{
				moveTexts[i].color = highlightedColor;
			}
			else
			{
				moveTexts[i].color = Color.black;
			}
		}
        PPText.text = "PP " + move.PP + "/" + move.Base.PP;
        typeText.text = move.Base.Type.ToString();
	}

    public void SetMoveNames(List<Move> moves)
    {
        for (int i = 0; i < moveTexts.Count; i++)
        {
            if(i < moves.Count)
            {
                moveTexts[i].text = moves[i].Base.name;
            }
            else
            {
                moveTexts[i].text = "-";
            }
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
