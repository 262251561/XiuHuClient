using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class ConditionNodeConfig
{
    public int[] preItemNodes; //需要的物品ID数组

    public int afaterItem; //得到的物品ID
}

[Serializable]
public class LevelConfig
{
    public int id;

    public ConditionNodeConfig[] nodes;
}

[CreateAssetMenu(menuName = "ConditionLevelConfigManager")]
public class ConditionLevelManager : ScriptableObject
{
    [SerializeField]
    public LevelConfig[] configs;

    private Dictionary<int, int> __levelConfigIdMap;

    public void Init()
    {
        __levelConfigIdMap = new Dictionary<int, int>();

        int i, length = configs != null ? configs.Length : 0;
        for (i = 0; i < length; ++i)
            __levelConfigIdMap.Add( configs[i].id, i );
    }

    public int GetLevelConfigIndexById(int id)
    {
        return __levelConfigIdMap[id];
    }

    public LevelConfig GetLevelConfigById(int id)
    {
        return configs[ GetLevelConfigIndexById(id) ];
    }
}