using System.Collections;
using UnityEngine;

public class Prefab_Egg : MonoBehaviour
{
    public GameObject prefabEgg;
    private GameObject createdEgg;

    private Vector2 randomPosition;
    private float minX = -2f;
    private float maxX = 2f;
    private float fixedY = 5f;
    void Start()
    {
        StartCoroutine(PrefabEgg());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator PrefabEgg()
    {
        while (true)
        {
            float randomX = Random.Range(minX, maxX);
            Vector2 randomPos = new Vector2(randomX,fixedY);

            createdEgg = Instantiate(prefabEgg, randomPos, Quaternion.identity);

            yield return new WaitForSeconds(1f);
        }
    }
}
