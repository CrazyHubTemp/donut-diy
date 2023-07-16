using Game.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Game.Editors 
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(DragMovementAlong), true)]
    public class DragMovementAlongEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        }
    }
}

