using UnityEngine;

public class SpawnFood : MonoBehaviour
{

    public GameObject foodObj;
    public Transform spawnLoc;

    public void SpawnFoods()
    {
        Instantiate(foodObj, spawnLoc.position, Quaternion.identity);
    }


}
