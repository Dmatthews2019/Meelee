using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPrefabs : MonoBehaviour
{
    public static AttackPrefabs _instance;
    public GameObject ProjectilePrefab;

    public static AttackPrefabs Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AttackPrefabs>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
