using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenPointsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> regenPoints;

    void Start()
    {
        regenPoints.AddRange(GameObject.FindGameObjectsWithTag("RegenPoints"));
    }

    float myUpdate = 0;

    void Update()
    {

        foreach (var point in regenPoints)
        {
            point.SetActive(
                (point.GetComponent<ReGenPoint>().AlivePoints > 0)
                );
            if (!point.activeSelf && Time.time > myUpdate + 10)
            {
                point.GetComponent<ReGenPoint>().AlivePoints = 100;
                myUpdate = Time.time;
            }

        }
    }
}
