using UnityEngine;

public class MunitionManagement : MonoBehaviour
{
    [SerializeField]
    public GameObject YellowMunPrefab;

    [SerializeField]
    public GameObject RedMunPrefab;

    [SerializeField]
    public GameObject BlueMunPrefab;

    private GameObject _currentMunType;
    private float _shootCooldown;

    private bool _canShoot = true;
    private float _timer = 0;

    private static MunitionManagement _instance;
    public static MunitionManagement Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        SetYellowMun();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_canShoot)
        {
            _timer += Time.deltaTime;
            if (_timer >= _shootCooldown)
            {
                _canShoot = true;
            }
        }
    }

    public void Fire()
    {
        if (_canShoot)
        {
            _canShoot = false;
            Instantiate(_currentMunType, ShipManagement.Instance.transform.position, ShipManagement.Instance.transform.rotation);
            _timer = 0f;
        }
    }

    public void SetYellowMun()
    {
        _currentMunType = YellowMunPrefab;
        _shootCooldown = 0.2f;
        _canShoot = true;
        _timer = 0f;
    }

    public void SetRedMun()
    {
        _currentMunType = RedMunPrefab;
        _shootCooldown = 0.2f;
        _canShoot = true;
        _timer = 0f;
        // Set parameters for red munitions.
    }

    public void SetBluewMun()
    {
        _currentMunType = BlueMunPrefab;
        _shootCooldown = 1.2f;
        _canShoot = true;
        _timer = 0f;
    }
}