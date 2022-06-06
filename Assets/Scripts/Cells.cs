using UnityEngine;

public class Cells : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer _sp;

    [SerializeField] private InstantiateCowboys _InterfaceCell;
    [SerializeField] private Color _Color;
    public bool isCell = false;
    public bool isBusy = false;

    private void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        if (_InterfaceCell._isInstanting)
        {
            _sp.color = _Color;
            isCell = true;
        }
    }

    private void OnMouseExit()
    {
        _sp.color = Color.white;
        isCell = false;
    }
}