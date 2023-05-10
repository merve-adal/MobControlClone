using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    [SerializeField] private Transform sideMovementRoot;
    private float _spawnInterval => SettingsManager.GameSettings.spawnIntervalForPlayer;
    private float spawnInterval;
    [SerializeField] private int numberOfPlayerThrown = 0;
    private int numberOfPlayerThrownForSpawnGiant => SettingsManager.GameSettings.numberOfPlayerThrownForSpawnGiant;

    private void Awake()
    {
        spawnInterval = _spawnInterval;
    }

    private void Update()
    {
        InputCheck();
    }

    private void InputCheck()
    {
        if (Input.GetMouseButton(0))
        {
            //here is for little blue ones
            spawnInterval -= Time.deltaTime;
            if (spawnInterval <= Time.deltaTime)
            {
                var localPos = sideMovementRoot.position;
                var rotation = sideMovementRoot.transform.rotation;
                GameManager.Instance.SpawnRequest("Player", localPos, rotation, 1);

                spawnInterval = _spawnInterval;
                numberOfPlayerThrown++;

                GameManager.Instance.SetCurrentThrownPctOnBar(numberOfPlayerThrown);
            }
        }
        else
        {
            spawnInterval = _spawnInterval;
            //here is for big yellow one if i can add -->i added :D
            if (numberOfPlayerThrown >= numberOfPlayerThrownForSpawnGiant)
            {
                var localPos = sideMovementRoot.position;
                var rotation = sideMovementRoot.transform.rotation;
                GameManager.Instance.SpawnRequest("GiantPlayer", localPos, rotation, 1);

                numberOfPlayerThrown = 0;
                GameManager.Instance.SetCurrentThrownPctOnBar((float) numberOfPlayerThrown);
            }
        }
    }
}