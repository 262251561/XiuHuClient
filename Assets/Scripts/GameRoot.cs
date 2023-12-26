using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class GameRoot : MonoBehaviour
{
    public static GameRoot s_Instance;

    public ConditionLevelManager conditionConfigManager
    {
        private set;
        get;
    }

    public ItemConfigManager itemConfigManager
    {
        private set;
        get;
    }

    public GameObject rootUI;

    public GameLevelLogic currentLevelLogic;

    IEnumerator Start()
    {
        var itemTable = Resources.Load<ItemConfigManager>("ItemTables");
        itemTable.Init();
        itemConfigManager = itemTable;

        var conditionTable = Resources.Load<ConditionLevelManager>("ConditionTables");
        conditionTable.Init();
        conditionConfigManager = conditionTable;

        yield return null;

        currentLevelLogic.Init(this);

        yield return null;

        s_Instance = this;

        yield return __ApplyGame();
    }

    IEnumerator __ApplyGame()
    {
        yield return new WaitForSeconds(2.0f);
        rootUI.transform.GetChild(0).gameObject.SetActive(false);
    }
}
