using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropoble : MonoBehaviour
{

    public int objId;
    private MeshRenderer meshRenderer;
    public Material basic;
    public Material green;
    public Material red;

    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Draggable")
        {
            if (objId == other.GetComponent<Dragable>().objId)
            {
                meshRenderer.material = green;
            }
            else
                meshRenderer.material = red;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        meshRenderer.material = basic;
    }
}
