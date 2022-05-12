using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sun"))
        {
            PlantLogic.Instance.SumSun();
            Destroy(collision.gameObject);
        }
    }

}
