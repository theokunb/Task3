using System;
using UnityEngine;

public class OpacityButtonContainer : MonoBehaviour
{
    [SerializeField] private OpacityButton[] _opacityButton;

    public event Action<float> OpacityChanged;

    private void OnEnable()
    {
        foreach (var button in _opacityButton)
        {
            button.Clicked += OnSelected;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _opacityButton)
        {
            button.Clicked -= OnSelected;
        }
    }

    public void OnClicked(GameObject currentButton)
    {
        foreach (var button in _opacityButton)
        {
            if (button.gameObject == currentButton.gameObject)
            {
                button.Image.color = Color.white;
            }
            else
            {
                button.Image.color = new Color(1, 1, 1, 0);
            }
        }
    }

    private void OnSelected(float opacity)
    {
        OpacityChanged?.Invoke(opacity);
    }
}
