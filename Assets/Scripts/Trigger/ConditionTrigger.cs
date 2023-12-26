using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public abstract class ConditionTrigger : MonoBehaviour
{
    public int conditionIndex;

    private TriggerAction __action;
    private LevelConfig __levelConfig;
    private GameLevelLogic.ConditionNode __bindNode;

    public bool bindApply
    {
        get
        {
            return __bindNode.isApply;
        }
    }
    
    public void InitItem(LevelConfig levelConfig)
    {
        if (__action == null)
            __action = gameObject.GetComponent<TriggerAction>();

        __levelConfig = levelConfig;
        __bindNode = GameRoot.s_Instance.currentLevelLogic.conditionNodes[conditionIndex];

        if (!bindApply)
            GameLevelLogic.conditionTriggerApplyChanged += __OnApplyChanged;

        __OnInit();
    }

    protected virtual void __OnInit()
    {

    }

    void __OnApplyChanged(int index)
    {
        if(index == conditionIndex)
        {
            if (__action != null)
                __action.OnEnterToActionState();

            GameLevelLogic.conditionTriggerApplyChanged -= __OnApplyChanged;
        }
    }

    protected virtual void OnDisable()
    {
        GameLevelLogic.conditionTriggerApplyChanged -= __OnApplyChanged;
    }

    protected void RequestCondition()
    {
        if (bindApply)
            return;

        GameRoot.s_Instance.currentLevelLogic.ApplyTrigger(conditionIndex);

        if (__action != null)
            __action.OnApplyAction();
    }
}