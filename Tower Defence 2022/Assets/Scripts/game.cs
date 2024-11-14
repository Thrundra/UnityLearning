using UnityEngine;

public class game : MonoBehaviour
{
    public Transform prefab;
    public KeyCode createkey = KeyCode.C;
    public KeyCode newGameKey = KeyCode.N;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(createkey))
        {
            //Instantiate(prefab);
            CreateObject();
        }
        else if(Input.GetKeyDown(newGameKey))
        {
            BeginNewGame();
        }
    }

    void CreateObject ()
    {
        Transform t = Instantiate(prefab);
        t.localPosition = Random.insideUnitSphere * 5f;
        t.localRotation = Random.rotation;
        t.localScale = Vector3.one * Random.Range(0.1f, 1f);
    }

    void BeginNewGame() { }
}
