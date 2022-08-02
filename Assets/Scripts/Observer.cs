using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameEnding gameEnding;
    private bool _isPlayerInRange;

    private void OnTriggerEnter(Collider other) {
        if(other.transform == player) 
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform == player) 
        {
            _isPlayerInRange = false;
        }
    }

    private void Update() {
        if(_isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
