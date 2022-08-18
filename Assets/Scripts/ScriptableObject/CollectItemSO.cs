using UnityEngine;

[CreateAssetMenu(fileName = "CollectItem", menuName = "UnityTutorial-JohnLemon/CollectItem", order = 0)]
public class CollectItemSO : ItemSO 
{
    [SerializeField] private ECollectItemType itemType;
    [SerializeField] private Color materialColor;
    public float maxValuePerOrb;
    [HideInInspector] public float valuePerOrb;

    public ECollectItemType ItemType { get { return itemType; } }
    public Color MaterialColor { get { return materialColor; } }
}
