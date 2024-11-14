using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class game : MonoBehaviour
{
    public Transform prefab;
    public KeyCode createkey = KeyCode.C;
    public KeyCode newGameKey = KeyCode.N;
    public KeyCode saveKey = KeyCode.S;

    List<Transform> objects;
    string savePath;

    void Awake()
    {
        objects = new List<Transform> ();
        savePath = Path.Combine(Application.persistentDataPath, "saveFile");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(createkey))
        {
            //Instantiate(prefab);
            CreateObject();
        }
        else if (Input.GetKeyDown(newGameKey))
        {
            BeginNewGame();
        }
        else if (Input.GetKey(saveKey))
        {
            Save();
        }
    }

    void CreateObject ()
    {
        Transform t = Instantiate(prefab);
        t.localPosition = Random.insideUnitSphere * 5f;
        t.localRotation = Random.rotation;
        t.localScale = Vector3.one * Random.Range(0.1f, 1f);
        objects.Add(t);
    }

    void BeginNewGame() 
    {
        for (int i = 0; i < objects.Count; i++)
        {
            Destroy(objects[i].gameObject);
        }
        objects.Clear();
    }

    // Save and read data

    void Save()
    {
        using (var writer = new BinaryWriter(File.Open(savePath, FileMode.Create)) )
        {
            writer.Write(objects.Count);
        }
  
    }
}
