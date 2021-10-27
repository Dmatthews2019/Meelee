using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Spawner = new SpawnEnemy();
    }
    SpawnEnemy Spawner;
}
