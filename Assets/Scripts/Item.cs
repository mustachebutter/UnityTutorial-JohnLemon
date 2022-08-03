using UnityEngine;

public class Item : MonoBehaviour 
{
    [SerializeField] private ItemSO itemData;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {

            ICollectable collectablePlayer = other.gameObject.GetComponent<ICollectable>();
            collectablePlayer.Collect(itemData);
            Destroy(gameObject);
        }
    }
}