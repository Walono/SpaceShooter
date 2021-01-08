using UnityEngine;

public enum EBoxType
{
    yellowBox = 0,
    redBox = 1,
    blueBox = 2
}

public class MunitionBoxManager : MonoBehaviour
{
    [SerializeField]
    private MunitionManagement _munManager;

    [SerializeField]
    private BoxCollider _shipCollider;

    [SerializeField]
    private Material[] _boxMaterial;

    private EBoxType nextBox;
    private float _boxTimer = 7f;
    private float _spawnTime;
    private bool _canSpawn = true;

    private GameObject _currentCube = null;
    private BoxCollider _cubeCollider;

    private void Start()
    {
        nextBox = EBoxType.redBox;
        _spawnTime = Time.time + _boxTimer;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_canSpawn && Time.time > _spawnTime)
        {
            _canSpawn = false;
            CreateACube(_boxMaterial[(int)nextBox], nextBox);
            nextBox = (EBoxType)(((int)nextBox + 1) % _boxMaterial.Length);
        }
    }

    private void CreateACube(Material colorMat, EBoxType boxType)
    {
        _currentCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _currentCube.transform.localScale = new Vector3(1f, 1f, 1f);
        _cubeCollider = _currentCube.AddComponent<BoxCollider>();
        _cubeCollider.size = new Vector3(1.2f, 1.2f, 1.2f);
        _cubeCollider.isTrigger = true;
        _currentCube.GetComponent<Renderer>().material = colorMat;
        MunitionBoxLife boxLife = _currentCube.AddComponent<MunitionBoxLife>();
        boxLife.BoxType = boxType;
        boxLife.ShipObject = _shipCollider.gameObject;
        boxLife.MunBoxManager = this;
    }

    public void BoxUsed()
    {
        _canSpawn = true;
        _spawnTime = Time.time + _boxTimer;
    }
}