using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CollectItemSO))]
public class EditorCollectItemSO : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        CollectItemSO item = target as CollectItemSO;
        item.valuePerOrb = EditorGUILayout.Slider("Value Per Orb", item.valuePerOrb, 0.0f, item.maxValuePerOrb);
    }
}