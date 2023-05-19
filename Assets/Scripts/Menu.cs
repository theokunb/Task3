using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Toggle _showHideAllToggle;
    [SerializeField] private Toggle _checkAllToggle;
    [SerializeField] private ItemTemplate _template;
    [SerializeField] private ItemsObserver _observer;
    [SerializeField] private OpacityButtonContainer _opacityButtons;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _opacityButtons.OpacityChanged += OnOpacityChanged;
        _spawner.Spawned += OnSpawned;
    }

    private void OnDisable()
    {
        _opacityButtons.OpacityChanged -= OnOpacityChanged;
        _spawner.Spawned -= OnSpawned;
    }

    private void Start()
    {
        CheckAll();
        ShowOrHideSelectedItems();
    }

    public void CheckAll()
    {
        _observer.SetItemsStatus(_checkAllToggle.isOn);
    }

    public void ShowOrHideSelectedItems()
    {
        foreach(var element in _observer.GetSelected())
        {
            element.PerformHideButton(_showHideAllToggle.isOn);
        }
    }

    private void OnOpacityChanged(float opacity)
    {
        var a = _observer.GetSelected().ToList();
        foreach (var element in _observer.GetSelected())
        {
            element.SetOpacity(opacity);
        }
    }

    private void OnSpawned(ObjectHandler obj)
    {
        var item = Instantiate(_template, _observer.transform);
        item.SetObject(obj);
    }
}
