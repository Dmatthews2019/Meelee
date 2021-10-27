using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicScenes : MonoBehaviour
{

    public Collider[] colliders;
    public GameObject[] SceneMarkers;
    public LayerMask layer;
    public List<string> insideScenes;

    public bool checkIsInside;
    // Start is called before the first frame update
    void Start()
    {
        SceneMarkers = GameObject.FindGameObjectsWithTag("sceneMarker");
        SceneManager.LoadSceneAsync("Home", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {

        DynamicSceneLoad();
    }

    void DynamicSceneLoad() 
    {

        int countLoaded = SceneManager.sceneCount;
        Scene[] loadedScenes = new Scene[countLoaded];

        for (int i = 0; i < countLoaded; i++)
        {
                loadedScenes[i] = SceneManager.GetSceneAt(i);
        }
        ClearMultipleScenes(loadedScenes);

        checkIsInside = insideScenes.Contains(SceneManager.GetActiveScene().name);
        foreach (var Light in GameObject.FindGameObjectsWithTag("Light"))
        {
            Light.GetComponent<Light>().enabled = !checkIsInside;
        }
        
        if (insideScenes.Contains(SceneManager.GetActiveScene().name)) return;

        colliders = Physics.OverlapSphere(transform.position, 300, layer.value);
        foreach (var collider in colliders)
        {
            if (!loadedScenes.Contains(SceneManager.GetSceneByName(collider.gameObject.name)))
            {
                Debug.Log(collider.gameObject.name);
                SceneManager.LoadSceneAsync(collider.gameObject.name, LoadSceneMode.Additive);
            }
        }
        foreach (var sceneMarker in SceneMarkers)
        {
            if (!colliders.Contains(sceneMarker.GetComponent<Collider>()) && loadedScenes.Contains(SceneManager.GetSceneByName(sceneMarker.name)))
            {
                SceneManager.UnloadSceneAsync(sceneMarker.name);
            }
        }
    }

    void ClearMultipleScenes(Scene[] scenes) 
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            for (int x = i + 1; x < scenes.Length; x++)
            {
                if (scenes[i].name == scenes[x].name)
                {
                    //Debug.Log(scenes[x].name + "marked as duplicate");
                    SceneManager.UnloadSceneAsync(scenes[x]);
                }
            }
        }
    }


}
