using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    private float minXRange;
    private float maxXRange;

    private float minZRange = 1.5f;
    private float maxZRange = 1.8f;

    private float arrangeX;
    private float arrangeZ;

    public void SpawnPeople(string tag, Vector3 pos, Quaternion rot, int count)
    {
        if (count == 1)
        {
            minXRange = 0f;
            maxXRange = 0.3f;
        }
        else if (count == 2)
        {
            minXRange = -0.3f;
            maxXRange = 0.3f;
        }
        else if (count == 3)
        {
            minXRange = -0.4f;
            maxXRange = 0.4f;
        }
        else if (count == 4)
        {
            minXRange = -0.6f;
            maxXRange = 0.6f;
        }
        
        if (tag.Equals("Enemy"))
        {
            minXRange = -1.5f;
            maxXRange = 1.5f;
            pos.y += 0.3f;
            pos.z -= 0.3f;
            minZRange = -0.4f;
            maxZRange = -2.75f;
            
            ObjectPooler.Instance.SpawnFromPool("GiantEnemy", pos, rot);
            pos.z += 0.3f;
        }

        for (int i = 0; i < count; i++)
        {
            var currentPos = pos;
            arrangeX = Random.Range(minXRange, maxXRange);
            arrangeZ = Random.Range(minZRange, maxZRange);
            currentPos.x += arrangeX;
            currentPos.z += arrangeZ;
            ObjectPooler.Instance.SpawnFromPool(tag, currentPos, rot);
        }

        minZRange = 1.5f;
        maxZRange = 1.8f;
    }
}