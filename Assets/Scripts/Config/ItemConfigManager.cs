using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

[Serializable]
public class ItemConfig
{
    public int id;
}

[CreateAssetMenu(menuName = "ItemConfigManager")]
public class ItemConfigManager : ScriptableObject
{
    [SerializeField]
    public ItemConfig[] configs;

    private Dictionary<int, int> __itemConfigIdMap;

    public void Init()
    {
        __itemConfigIdMap = new Dictionary<int, int>();

        int i, length = configs != null ? configs.Length : 0;
        for (i = 0; i < length; ++i)
            __itemConfigIdMap.Add(configs[i].id, i);
    }

    public int GetConfigIndexById(int id)
    {
        return __itemConfigIdMap[id];
    }

    public ItemConfig GetConfigById(int id)
    {
        return configs[GetConfigIndexById(id)];
    }
}