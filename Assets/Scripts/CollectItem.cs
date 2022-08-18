using UnityEngine;

public class CollectItem : MonoBehaviour 
{
    [SerializeField] private CollectItemSO itemData;
    private Renderer _renderer;
    
    private void Start() {
        _renderer = GetComponent<Renderer>();
        if(_renderer && itemData)
        {
            _renderer.material.color = itemData.MaterialColor;
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {

            ICollectable collectablePlayer = other.gameObject.GetComponent<ICollectable>();
            collectablePlayer.Collect(itemData);

            IStatChange changableStats = other.gameObject.GetComponent<IStatChange>();
            changableStats.ChangeStatOnCollectItem(itemData.ItemType, itemData.valuePerOrb);
            Destroy(gameObject);
        }
    }
}