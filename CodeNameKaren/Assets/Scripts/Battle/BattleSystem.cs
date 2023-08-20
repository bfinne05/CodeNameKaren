using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState 
{
    Start,
    PlayerAction,
    PlayerMove,
    EnemyMove,
    Busy
}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit PlayerUnit;
    [SerializeField] BattleUnit EnemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud EnemyHud;

    [SerializeField] AudioSource SoundEffect;

    [SerializeField] BattleDialogBox DialogBox;

    BattleState state;
    int currentAction;
    int currentMove;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupBattle());
    }


    // Update is called once per frame
    private void Update()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }
    public IEnumerator SetupBattle()
    {
        PlayerUnit.SetUp();
        playerHud.setData(PlayerUnit.Character);
        EnemyUnit.SetUp();
        EnemyHud.setData(EnemyUnit.Character);

        DialogBox.SetMoveNames(PlayerUnit.Character.Moves);

        yield return StartCoroutine(DialogBox.TypeDialog("You Challenged " + EnemyUnit.Character.Base.Name));
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(DialogBox.TypeDialog("Choose an action"));
        DialogBox.EnableActionSelector(true);
    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        DialogBox.EnableActionSelector(false);
        DialogBox.EnableDialogText(false);
        DialogBox.EnableMoveSelector(true);
    }

    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
            {
                currentAction = currentAction + 1;
                Debug.Log(currentAction);
            }

        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
            {
                Debug.Log(currentAction);
                currentAction = currentAction - 1;
            }
        }

        DialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentAction == 0)
            {
                //fight
                PlayerMove();
                SoundEffect.Play();
            }
            else if (currentAction == 1)
            {
                //defend or burn turn
                SoundEffect.Play();
            }
        }
    }

    void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < PlayerUnit.Character.Moves.Count)
            {
                currentMove++;
            }

        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentAction > 0)
            {
                currentMove--;
            }
        }

		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			if (currentAction < PlayerUnit.Character.Moves.Count)
			{
                currentMove += 2;
			}

		}

		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (currentMove > 1)
			{
				currentMove -=2;
			}
		}

        DialogBox.UpdateMoveSelection(currentMove, PlayerUnit.Character.Moves[currentMove]);
	}
}
