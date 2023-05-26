using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WhoToastedMrToaster.DialogManager
{
    public class DialogManagerWindow : EditorWindow
    {

        [MenuItem("Window/Dialog Manager")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(DialogManagerWindow));
        }

        private void OnGUI()
        {
            GUILayout.Label("Dialog manager");
        }
    }
}