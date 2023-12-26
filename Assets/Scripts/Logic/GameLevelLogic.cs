using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class GameLevelLogic : MonoBehaviour
{
    public static Action<int> conditionTriggerApplyChanged;

    public class ConditionNode
    {
        public int configIndex;
        public bool isApply;
    }

    public int bindLevelId;

    public ConditionNode[] conditionNodes
    {
        private set;
        get;
    }

    public List<int> currentItems
    {
        private set;
        get;
    }

    public LevelConfig levelConfig
    {
        private set;
        get;
    }

    private void Awake()
    {
        currentItems = new List<int>();
    }

    public void Init(GameRoot rootLogic)
    {
        currentItems.Clear();

        levelConfig = rootLogic.conditionConfigManager.GetLevelConfigById(bindLevelId);
        int i, length = levelConfig.nodes != null ? levelConfig.nodes.Length : 0;
        conditionNodes = new ConditionNode[length];
        for (i=0; i<length; ++i)
        {
            var nodeConfig = levelConfig.nodes[i];
            var node = new ConditionNode();
            node.isApply = false;
            node.configIndex = i;
            conditionNodes[i] = node;
        }

        var triggers = FindObjectsOfType<ConditionTrigger>();
        length = triggers.Length;
        for(i=0; i<length; ++i)
        {
            triggers[i].InitItem(levelConfig);
        }
    }

    public void ApplyTrigger(int index)
    {
        var conditionNode = conditionNodes[index];
        var nodeConfig = levelConfig.nodes[ conditionNode.configIndex ];
        int i, length = nodeConfig.preItemNodes != null ? nodeConfig.preItemNodes.Length : 0;
        for(i=0; i<length; ++i)
        {
            var needItemId = nodeConfig.preItemNodes[i];
            if(!currentItems.Contains(needItemId))
                return;
        }

        conditionTriggerApplyChanged?.Invoke(index);
    }
}