using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ImageScript : MonoBehaviour

{
    [SerializeField] ARTrackedImageManager m_TrackedImageManager;
    [SerializeField] GameObject m_PrefabToInstantiate;
    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;
    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;
    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var removedImage in eventArgs.removed)
        {
            Destroy(removedImage.gameObject);
            gameObject.SetActive(false);
            if (m_PrefabToInstantiate != null)
            {
                Destroy(m_PrefabToInstantiate);
            }
        }
    }
}