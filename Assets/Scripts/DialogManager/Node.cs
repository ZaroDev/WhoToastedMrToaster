using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
namespace WhoToastedMrToaster.DialogManager
{
    public class Node
    {
        string Name;
        string Dialogue;

        List<Node> Nodes = new List<Node>();
        List<Action> Callbacks = new List<Action>();
    }
}
