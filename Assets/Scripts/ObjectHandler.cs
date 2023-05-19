using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshRenderer))]
public class ObjectHandler : MonoBehaviour
{
    [SerializeField] private Image _image;

    private MeshRenderer _renderer;
    private List<Material> _materials = new List<Material>();

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.GetMaterials(_materials);
    }

    public void SetOpacity(float opacity)
    {
        foreach (var mat in _materials)
        {
            Color currentColor = mat.color;
            currentColor.a = opacity;
            mat.color = currentColor;
        }
    }

    public void SetSelection(bool status)
    {
        _image.enabled = status;
    }
}
