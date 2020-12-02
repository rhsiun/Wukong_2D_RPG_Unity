using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public BattleUnit battleUnit;
    public BattleHud battleHud;
    public BattleUnit enemyUnit;
    public BattleHud enemyHud;
    public BattleDialogue battleDialogue;
 
    public BattleState state;
    public int currentAction;
    public int currentMove;

    public void Start()
    {
        StartCoroutine(setUp());
    }

    //Use own code coroutine
    public IEnumerator setUp()
    {
        battleUnit.setUpMonster();
        enemyUnit.setUpMonster();
        battleHud.setUpHud(battleUnit.getBattleMonster());
        enemyHud.setUpHud(enemyUnit.getBattleMonster());

        
        //To do: Use own code for coroutine
        //  StartCoroutine(battleDialogue.TypeDialog($"A wild {battleUnit.getBattleMonster()._base.name} appeared"));
        yield return (battleDialogue.TypeDialog($"{enemyUnit.getBattleMonster()._base.name} appeared, defeat him to get into the cave!"));
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    void PlayerAction()
    {
        Debug.Log("playeractionclicked");
        state = BattleState.PlayerAction;
        Debug.Log(state);
        StartCoroutine(battleDialogue.TypeDialog("Choose an action"));
        battleDialogue.EnableActionSelector(true);

    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        battleDialogue.EnableActionSelector(false);
        battleDialogue.EnableDialogText(false);
        battleDialogue.EnableMoveSelector(true);
        battleDialogue.SetMoveNames(battleUnit.getBattleMonster().getMoves());

    }

    void Update()
    {

        if(state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }
    void HandleMoveSelection()
    {
         if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(currentMove<battleUnit.getBattleMonster().getMoves().Count-1)
            {
                currentMove++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(currentMove>0)
            {
                currentMove--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentMove<battleUnit.getBattleMonster().getMoves().Count-2)
            {
                currentMove +=2;
            }
        }
           else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentMove>1)
            {
                currentMove -=2;
            }
        }

        battleDialogue.UpdateMoveSelection(currentMove,battleUnit.getBattleMonster().getMoves()[currentMove]);
    }
    void HandleActionSelection()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(currentAction<1)
            {
                currentAction++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if(currentAction>0)
            {
                currentAction--;
            }
        }

        battleDialogue.UpdateActionSelection(currentAction);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentAction == 0)
            {
                //Fight
                PlayerMove();
            }
            else if (currentAction == 1)
            {
                //Run

            }
        }
    }
}

public enum BattleState
{
    Start,
    PlayerAction,
    PlayerMove,
    EnemyMove,
    Busy
}