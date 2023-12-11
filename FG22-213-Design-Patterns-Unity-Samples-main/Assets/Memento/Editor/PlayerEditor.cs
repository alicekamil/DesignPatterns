using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Memento.Editor
{
    [CustomEditor(typeof(Player))]
    public class PlayerEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            return base.CreateInspectorGUI();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("IncHealth"))
            {
                Undo.RecordObject(this.target, "Increase Health on Player");
                (this.target as Player).health++;
                EditorUtility.SetDirty(this.target);
            }
        }
    }
}