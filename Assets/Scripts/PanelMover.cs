using System.Threading.Tasks;
using UnityEngine;

public class PanelMover : MonoBehaviour
{
    [SerializeField] private Animator _target;

    private bool _isShow = true;

    public void OnShowHide()
    {
        if(_isShow == true)
        {
            _target.SetTrigger(AnimationsController.Params.Hide);
            _isShow = false;
        }
        else
        {
            _target.SetTrigger(AnimationsController.Params.Show);
            _isShow = true;
        }
    }
}
