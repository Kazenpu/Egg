using UnityEngine;

public class Splash : MonoBehaviour
{
    public float timeDestroy;
    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
