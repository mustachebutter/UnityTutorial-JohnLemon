using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "UnityTutorial-JohnLemon/Item", order = 0)]
public class ItemSO : ScriptableObject 
{
    [SerializeField] private string _name = "Item Name";
    [SerializeField] private string _description = "Item Description";
}