using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class OpacityButton : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _opacity;

    private Image _image;

    public Image Image => _image;

    public event Action<float> Clicked;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnClicked()
    {
        Clicked?.Invoke(_opacity);
    }
}
