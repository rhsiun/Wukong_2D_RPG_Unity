﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        yield return (battleDialogue.TypeDialog($"{enemyUnit.getBattleMonster()._base.name} appeared, defeat him to get into the cave!"));
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
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

    IEnumerator PerformPlayerMove() {
        state = BattleState.Busy;
        var move = battleUnit.battleMonster._moves[currentMove];
        yield return battleDialogue.TypeDialog($"{battleUnit.battleMonster._base.getName()} used {move._Base.name}");

        yield return new WaitForSeconds(1f);

        bool isDefeated = enemyUnit.battleMonster.TakeDamage(move, battleUnit.battleMonster);
        //Debug.Log("current enemy hp: " + enemyUnit.battleMonster.currentHP);
        enemyHud.UpdateHP();
        if(isDefeated) {
            yield return battleDialogue.TypeDialog($"{enemyUnit.battleMonster._base.getName()} is defeated!");

            yield return new WaitForSeconds(1f);

            if(enemyUnit._base.name.Equals("Boss")){
                SceneManager.LoadScene(6);
            }
            if(enemyUnit._base.name.Equals("The Guardian")){
                SceneManager.LoadScene(4);
            }
            
        }
        else {
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMove() {
        state = BattleState.EnemyMove;

        var move = enemyUnit.battleMonster.GetRandomMove();
        yield return battleDialogue.TypeDialog($"{enemyUnit.battleMonster._base.getName()} used {move._Base.name}");

        yield return new WaitForSeconds(1f);

        bool isDefeated = battleUnit.battleMonster.TakeDamage(move, enemyUnit.battleMonster);
        //Debug.Log("current player hp: " + battleUnit.battleMonster.currentHP);
        battleHud.UpdateHP();
        if(isDefeated) {
            yield return battleDialogue.TypeDialog("You are defeated! Start over!");

            yield return new WaitForSeconds(1f);

            if(enemyUnit._base.name.Equals("Boss")){
                SceneManager.LoadScene(5);
            }
            if(enemyUnit._base.name.Equals("The Guardian")){
                SceneManager.LoadScene(2);
            }
        }
        else {
            PlayerAction();
        }
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
         if(Input.GetKeyDown(KeyCode.S))
        {
            if(currentMove<battleUnit.getBattleMonster().getMoves().Count-1)
            {
                currentMove++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if(currentMove>0)
            {
                currentMove--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if(currentMove<battleUnit.getBattleMonster().getMoves().Count-2)
            {
                currentMove +=2;
            }
        }
           else if (Input.GetKeyDown(KeyCode.A))
        {
            if(currentMove>1)
            {
                currentMove -=2;
            }
        }

        battleDialogue.UpdateMoveSelection(currentMove,battleUnit.getBattleMonster().getMoves()[currentMove]);

        if(Input.GetKeyDown(KeyCode.Space)) {
            battleDialogue.EnableMoveSelector(false);
            battleDialogue.EnableDialogText(true);
            StartCoroutine(PerformPlayerMove());
        }
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
                StartCoroutine(RunDialogue());
            }
        }
    }
    IEnumerator RunDialogue() {
        Debug.Log("hi");

        yield return battleDialogue.TypeDialog("Do Not Run! Defeat him to get to your friend!");

        yield return new WaitForSeconds(1f);

        PlayerAction();
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