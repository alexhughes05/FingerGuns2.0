using UnityEngine;
using System.Collections;

public class MaterialModifier : MonoBehaviour
{
    //components
    private SkinnedMeshRenderer _mr;

    //private
    private Material matDefault;

    //properties
    public bool ExecuteIFrames { get; set; }

    private void Awake()
    {
        _mr = GetComponentInChildren<SkinnedMeshRenderer>();
        if (_mr == null)
            Debug.LogError("MaterialSwapper component was unable to find a SkinnedMeshRenderer on gameObject: " + gameObject.name);
        matDefault = _mr.material;
    }

    public void SwapMaterialOnce(Material newMaterial)
    {
        _mr.material = newMaterial;
    }

    public void SwapMaterialForDuration(Material newMaterial, float swapDuration)
    {
        _mr.material = newMaterial;
        Invoke(nameof(ResetMaterial), swapDuration);
    }

    private void ResetMaterial()
    {
        _mr.material = matDefault;
    }

    public IEnumerator ToggleMaterialForDuration(string nameId, float toggleDuration)
    {
        _mr.material.SetInt(nameId, 1);
        yield return new WaitForSeconds(toggleDuration);
        _mr.material.SetInt(nameId, 0);
    }
}
