using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PanelMover : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _hidePlace;
    [SerializeField] private float _moveSpeed;

    private bool _isShow = true;
    private Vector3 _startPoint;
    private CancellationTokenSource _cancellationTokenSource;

    private void OnDisable()
    {
        _cancellationTokenSource?.Cancel();
    }

    private void Start()
    {
        _startPoint = _target.transform.position;
    }

    public async void OnShowHide()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource = new CancellationTokenSource();

        if (_isShow == true)
        {
            await MoveAsync(_hidePlace.transform.position, _cancellationTokenSource.Token);
            _isShow = false;
        }
        else
        {
            await MoveAsync(_startPoint, _cancellationTokenSource.Token);
            _isShow = true;
        }
    }

    private async Task MoveAsync(Vector3 targetPositioon, CancellationToken token)
    {
        while(_target.transform.position.ToString() != targetPositioon.ToString())
        {
            if (token.IsCancellationRequested)
            {
                break;
            }

            _target.transform.position = Vector3.MoveTowards(_target.transform.position, targetPositioon, _moveSpeed * Time.deltaTime);
            await Task.Yield();
        }
    }
}
