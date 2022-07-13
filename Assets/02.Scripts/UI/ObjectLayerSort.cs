using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectLayerSort : MonoBehaviour
{
    [SerializeField]
    private int playerSortingLayer;

    private TilemapRenderer map;

    private void Awake()
    {
        map = GetComponent<TilemapRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("UpTrigger"))
        {
            map.sortingOrder = playerSortingLayer - 1;
        }
        if (collision.CompareTag("DownTrigger"))
        {
            map.sortingOrder = playerSortingLayer + 1;
        }
    }
}
