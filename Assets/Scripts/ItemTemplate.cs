using UnityEngine;
using UnityEngine.UI;

public class ItemTemplate : MonoBehaviour
{
    [SerializeField] private Toggle _selectToggle;
    [SerializeField] private Toggle _hideToggle;

    private ObjectHandler _object;

    public bool IsSelected => _selectToggle.isOn;

    public void SetObject(ObjectHandler objectHandler)
    {
        _object = objectHandler;
        Select(_selectToggle.isOn);
        PerformHideButton(_hideToggle.isOn);
    }

    public void Select(bool status)
    {
        _selectToggle.isOn = status;
        _object.SetSelection(status);
    }

    public void PerformHideButton(bool status)
    {
        _hideToggle.isOn = status;
        SetOpacity(_hideToggle.isOn ? 1 : 0);
    }

    public void SetOpacity(float opacity)
    {
        _object.SetOpacity(opacity);
    }

    public void OnSelectClicked()
    {
        Select(_selectToggle.isOn);
    }

    public void OnShowHideClicked()
    {
        PerformHideButton(_hideToggle.isOn);
    }
}
