using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
[RequireComponent(typeof(ARTrackedImageManager))]

public class ImageScript : MonoBehaviour
{
    [SerializeField] private GameObject placeablePrefab;
    private ARTrackedImageManager trackedImageManager;
    private GameObject spawnedObject;

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        GameObject newPrefab = Instantiate(placeablePrefab, Vector3.zero, Quaternion.identity);
        spawnedObject = newPrefab;
    }

    private void OnEnable() { trackedImageManager.trackedImagesChanged += ImageChanged; }

    private void OnDisable() { trackedImageManager.trackedImagesChanged -= ImageChanged; }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            GameObject prefab = spawnedObject;
            Vector3 position = trackedImage.transform.position;
            prefab.transform.position = position;
            prefab.transform.rotation = trackedImage.transform.rotation;
            prefab.SetActive(true);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            GameObject prefab = spawnedObject;
            Vector3 position = trackedImage.transform.position;
            prefab.transform.position = position;
            prefab.transform.rotation = trackedImage.transform.rotation;
            prefab.SetActive(true);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            spawnedObject.SetActive(false);
        }
    }

}