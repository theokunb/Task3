using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MyToggle : MonoBehaviour
{
    [SerializeField] private Image[] _targetImages;
    [SerializeField] private Color _targetColor;

    private Toggle _toggle;
    private Color[] _defaultColor;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _defaultColor = new Color[_targetImages.Length];

        for(int i = 0; i < _targetImages.Length; i++)
        {
            _defaultColor[i] = _targetImages[i].color;
        }

        ChangeColor();
    }

    public void ChangeColor()
    {
        for(int i=0; i < _targetImages.Length;i++)
        {
            _targetImages[i].color = _toggle.isOn ? _targetColor : _defaultColor[i];
        }
    }
}
