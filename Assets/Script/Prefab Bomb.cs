using UnityEngine;
using System.Collections;

public class Prefab_Bomb: MonoBehaviour
{
    public GameObject prefabBomb;
    private GameObject createdBomb;

    private Vector2 randomPosition;
    private float minX = -2f;
    private float maxX = 2f;
    private float fixedY = 5f;
    void Start()
    {
        StartCoroutine(PrefabBomb());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator PrefabBomb()
    {
        while (true)
        {
            float randomX = Random.Range(minX, maxX);
            Vector2 randomPos = new Vector2(randomX, fixedY);

            createdBomb = Instantiate(prefabBomb, randomPos, Quaternion.identity);

            yield return new WaitForSeconds(1.7f);
        }
    }
}
