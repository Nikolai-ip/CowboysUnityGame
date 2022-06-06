using UnityEngine;

public class InstantiateCowboys : MonoBehaviour
{
    [SerializeField] private GameObject _rifleMenGhostPrefab;
    [SerializeField] private GameObject _rifleMentPrefab;
    [SerializeField] private Camera _camera;
    private GameObject _rifleMan;
    [SerializeField] private float dx = 0.5f;
    [SerializeField] private float dy = 0.5f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _colorOnMouseEnter;
    public bool _isInstanting = false;
    [SerializeField] private Cells[] cells;

    private void Start()
    {
        //  _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        _spriteRenderer.color = _colorOnMouseEnter;
    }

    private void OnMouseExit()
    {
        _spriteRenderer.color = Color.white;
    }

    public void OnMouseDown()
    {
        if (!_isInstanting)
        {
            _rifleMan = Instantiate(_rifleMenGhostPrefab);
            _isInstanting = true;
        }
    }

    private void Update()
    {
        if (_rifleMan != null && _isInstanting)
        {
            Vector3 vector3 = _camera.ScreenToWorldPoint(Input.mousePosition);
            vector3.x += dx;
            vector3.y += dy;
            vector3.z = 0;
            _rifleMan.transform.position = vector3;
        }
        if (_isInstanting && Input.GetMouseButtonDown(1))
        {
            foreach (var cell in cells)
            {
                if (cell.isCell && !cell.isBusy)
                {
                    cell.isBusy = true;
                    float dx = 0.486f;
                    float dy = 0.6303f;
                    Instantiate(_rifleMentPrefab, new Vector2(cell.transform.position.x + dx, cell.transform.position.y + dy), cell.transform.rotation);
                    Destroy(_rifleMan);
                    _isInstanting = false;
                }
            }
        }
    }
}