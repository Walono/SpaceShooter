using UnityEngine;

public class ShipManagement : MonoBehaviour
{
    private static ShipManagement _instance;
    public static ShipManagement Instance { get { return _instance; } }

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
}