using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ConstractorManager : MonoBehaviour
{

    private ARTrackedImageManager aRTrackedImageManager;

    public GameObject[] objectsToManage;
    // Start is called before the first frame update
    void Start()
    {
        aRTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }
    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(var trackedImage in args.added)
        {
            Transform curPos = trackedImage.gameObject.transform;
           foreach(GameObject obj in objectsToManage)
            {
                if (obj.name == trackedImage.referenceImage.name)
                {
                    UpdatePosition(trackedImage, obj);
                }
                
            }
        }
    }
    public void UpdatePosition(ARTrackedImage trackedImage, GameObject obj)
    {
        obj.transform.position = trackedImage.gameObject.transform.position;
        obj.transform.rotation = trackedImage.gameObject.transform.rotation;
    }
}
