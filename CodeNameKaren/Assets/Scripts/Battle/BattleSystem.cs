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
    [SerializeField] AudioSource Win1;
    [SerializeField] AudioSource BattleMusic;

    [SerializeField] BattleDialogBox DialogBox;

    BattleState state;
    int currentAction;
    int currentMove;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupBattle());
        BattleMusic.Play();
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

    IEnumerator PerformPlayerMove()
    {
        state = BattleState.Busy;
        var move = PlayerUnit.Character.Moves[currentMove];
        yield return DialogBox.TypeDialog(PlayerUnit.Character.Base.Name + " Used " + move.Base.name);

        yield return new WaitForSeconds(1f);

        bool isfainted = EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);
        yield return EnemyHud.UpdateHP();

        if(isfainted) //change this to make fainted dialog change
        {
            if (EnemyUnit.Character.Base.Name == "Girl Scout")
            {
                yield return DialogBox.TypeDialog(EnemyUnit.Character.Base.Name + " was punted by Karen");
                BattleMusic.Stop();
                Win1.Play();
            }
            else
            {
                yield return DialogBox.TypeDialog(EnemyUnit.Character.Base.Name + " quit their job");
            }

        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMove()
    {
        state = BattleState.EnemyMove;

        var move = EnemyUnit.Character.GetRandomMove();

		yield return DialogBox.TypeDialog(EnemyUnit.Character.Base.Name + " Used " + move.Base.name);

		yield return new WaitForSeconds(1f);

		bool isfainted = PlayerUnit.Character.TakeDamage(move, EnemyUnit.Character);
        yield return playerHud.UpdateHP();

		if (isfainted) //change this to make fainted dialog change
		{
			if (EnemyUnit.Character.Base.Name == "Girl Scout")
			{
				yield return DialogBox.TypeDialog("The police were called on Karen");
			}
			else
			{
				yield return DialogBox.TypeDialog("Karen fainted from her temper tantrum");
			}

		}
		else
		{
            PlayerAction();
		}
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
            if (currentMove < PlayerUnit.Character.Moves.Count - 1)
            {
                ++currentMove;
            }

        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0)
            {
                --currentMove;
            }
        }

		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			if (currentMove < PlayerUnit.Character.Moves.Count - 2)
			{
                currentMove += 2;
			}

		}

		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (currentMove > 1)
			{
				currentMove -= 2;
			}
		}

        DialogBox.UpdateMoveSelection(currentMove, PlayerUnit.Character.Moves[currentMove]);

        if(Input.GetKeyDown(KeyCode.Z))
        {
            DialogBox.EnableMoveSelector(false);
            DialogBox.EnableDialogText(true);
            SoundEffect.Play();
            StartCoroutine(PerformPlayerMove());
        }
	}
}
