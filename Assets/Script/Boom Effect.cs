using UnityEngine;

public class BoomEffect : MonoBehaviour
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
