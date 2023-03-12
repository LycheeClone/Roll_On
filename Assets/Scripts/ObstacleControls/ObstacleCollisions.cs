using System;
using UnityEngine;

namespace ObstacleControls
{
    public class ObstacleCollisions : MonoBehaviour
    {
        private void Update()
        {
        }


        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                MeshRenderer obstacleColor = GetComponent<MeshRenderer>();
                obstacleColor.material.color = Color.red;
                print("Çarptın");
            }
        }
    }
}