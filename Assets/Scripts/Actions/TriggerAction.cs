using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class TriggerAction : MonoBehaviour
{
    public abstract void OnApplyAction();

    public abstract void OnEnterToActionState();
}