using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_VFX : MonoBehaviour
{
    ParticleSystem partSystem;
    MeshRenderer mesh;
   
    
    void Start()
    {
        partSystem = GetComponent<ParticleSystem>();
        mesh = GetComponentInParent<MeshRenderer>();
        SetMesh();
    }

    private void SetMesh()
    {
        var PartSysShape = partSystem.shape;
        PartSysShape.meshRenderer = mesh;
    }

}
