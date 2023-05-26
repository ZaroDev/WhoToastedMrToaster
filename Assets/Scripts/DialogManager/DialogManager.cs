using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

namespace WhoToastedMrToaster.DialogManager
{
    public class NodeOption
    {
        public string text;
        public Node node;
        public Action callback;
    }

    public class Node
    {
        public string Title;
        public string Dialogue;

        public List<NodeOption> Options = new List<NodeOption>();
    }

    public class DialogManager
    {
        List<Node> m_Nodes = new List<Node>();
        Node m_ActiveNode = null;

        public void SetStartingNode(int index)
        {
            if (index < 0 || index >= m_Nodes.Count) return;

            m_ActiveNode = m_Nodes[index];
        }

        public Node CreateNode()
        {
            Node node = new Node();

            m_Nodes.Add(node);

            return node;
        }

        public Node SelectedOption(int option)
        {
            if (m_ActiveNode == null) return null;
            if (option < 0 || option >= m_ActiveNode.Options.Count) return null;

            m_ActiveNode.Options[option].callback();
            m_ActiveNode = m_ActiveNode.Options[option].node;

            return m_ActiveNode;
        }

        public Node getActiveNode()
        {
            return m_ActiveNode;
        }
    }
}
