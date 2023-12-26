using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ConditionSimpleClickTrigger : ConditionTrigger, IPointerClickHandler
{
    private bool __isClickEnable;

    protected override void __OnInit()
    {
        __isClickEnable = !bindApply;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(__isClickEnable)
            RequestCondition();
    }
}