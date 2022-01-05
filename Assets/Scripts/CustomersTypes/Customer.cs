using UnityEngine;


[SelectionBase]
public class Customer : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera _mainCam;

    private Vector3 _startPos;

    [SerializeField] private Transform _DragObject;

    public ProgressDisplayer _progressDisplayer;


    [HideInInspector] public int RightArm, LeftArm, RightShoulder, LeftShoulder, Chest, Belly, RightLeg, LeftLeg, RightLowerLeg, LeftLowerLeg;
    private int[] _bodyParts = new int[10];

    private Renderer[] _allRenderers;
    public GymEquipment _gymEquipment;

    [SerializeField] private GymEquipment _previousEquipment;

    [SerializeField] private float _speed;
    [SerializeField] private float _colorTransparency;

    [SerializeField] private bool _isOverWaitingRoom = false;

    private bool _isFinished = false;
    private bool _isDragging = false;

    private void Awake()
    {
        _mainCam = Camera.main;
        _allRenderers = GetComponentsInChildren<Renderer>();
    }

    private void Start()
    {
        SetupCustomerStats();
        SetPartsToArray();
        _progressDisplayer.SetSelectedCustomerProgress(this);
    }

    public void SetPartsToArray()
    {
        _bodyParts[0] = RightArm;
        _bodyParts[1] = LeftArm;
        _bodyParts[2] = RightShoulder;
        _bodyParts[3] = LeftShoulder;
        _bodyParts[4] = Chest;
        _bodyParts[5] = Belly;
        _bodyParts[6] = RightLeg;
        _bodyParts[7] = LeftLeg;
        _bodyParts[8] = RightLowerLeg;
        _bodyParts[9] = LeftLowerLeg;

    }

    private void OnMouseDown()
    {
        CameraMovement.IsDragging = true;
        CustomerManager.Instance.DisableStats(_progressDisplayer);

        _startPos = transform.position;
        _dragOffset = transform.position - GetMousePos();

        _progressDisplayer.SetSelectedCustomerProgress(this);
    }

    private void OnMouseDrag()
    {

        if (!_isDragging)
        {
            _DragObject.position = Vector3.MoveTowards(_DragObject.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
            float distance = Vector3.Distance(_DragObject.position, _startPos);
            if (distance > 1f)
            {
                _isDragging = true;
                SetColorTransparency(_colorTransparency);
                SetCustomerToEquipment();
                _progressDisplayer.HideProgressPanal();
                return;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
        }
    }

    private void SetCustomerToEquipment()
    {
        _previousEquipment = _gymEquipment;

        if (_gymEquipment)
        {
            _gymEquipment.SetCustomer(null);
            return;
        }

        WaitingRoom.Instance.CheckTheSameCustomerIsQueue(this);
    }


    private void OnMouseUp()
    {
        _isDragging = false;
        CameraMovement.IsDragging = false;
        SetColorTransparency(1);

        SetupCustomer();
    }
    private void SetupCustomer()
    {
        if (_isOverWaitingRoom)
        {
            WaitingRoom.Instance.AddCustomerToQueue(this);
            _progressDisplayer.OpenProgressPanal();
            _gymEquipment = null;
            _previousEquipment = null;
        }
        if (_gymEquipment)
        {
            Customer currentCustomerInSelectedEquipment = _gymEquipment.Customer;
            if (currentCustomerInSelectedEquipment == this) return;
            

            if (currentCustomerInSelectedEquipment)
            {
                if (_gymEquipment.Customer)
                {
                    if (!_previousEquipment)
                    {
                        WaitingRoom.Instance.AddCustomerToQueue(_gymEquipment.Customer);
                        _gymEquipment.Customer._progressDisplayer.OpenProgressPanal();
                        _gymEquipment.SetCustomer(this);
                        return;
                    }
                    _previousEquipment.SetCustomer(_gymEquipment.Customer);
                }
                _gymEquipment.SetCustomer(this);
                return;
            }
            _gymEquipment.SetCustomer(this);
        }
        else
        {
            if (_previousEquipment)
            {
                _previousEquipment.SetCustomer(this);
                return;
            }
            WaitingRoom.Instance.AddCustomerToQueue(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GymEquipment gymEquipment = collision.GetComponent<GymEquipment>();

        if (gymEquipment)
        {
            transform.localScale = new Vector2(1.1f, 1.1f);
            _gymEquipment = gymEquipment;
        }

        WaitingRoom waitingRoom = collision.GetComponent<WaitingRoom>();
        if (waitingRoom)
        {
            _isOverWaitingRoom = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(1f, 1f);
        WaitingRoom waitingRoom = collision.GetComponent<WaitingRoom>();
        if (waitingRoom)
        {
            _isOverWaitingRoom = false;
        }

        GymEquipment gymEquipment = collision.GetComponent<GymEquipment>();
        if (_gymEquipment != gymEquipment) return;

        _gymEquipment = null;
    }

    private void SetColorTransparency(float value)
    {
        for (int i = 0; i < _allRenderers.Length; i++)
        {
            _allRenderers[i].material.color = new Color(1f, 1f, 1f, value);
        }
    }

    private Vector3 GetMousePos()
    {
        Vector3 mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    public void CheckForFinish()
    {
        if (IsReachedGoal() && !_isFinished)
        {
            _isFinished = true;
            Done();
        }
    }

    private bool IsReachedGoal()
    {
        bool result = false;
        for (int i = 0; i < _bodyParts.Length; i++)
        {
            if (_bodyParts[i] < 100)
            {
                result = false;
                break;
            }
            result = true;
        }
        return result;
    }

    private void Done()
    {
        ScoreManager.Instance.UpdateScore(100);
        _gymEquipment.Customer = null;
        _gymEquipment = null;
        _previousEquipment = null;

        gameObject.SetActive(false);
    }


    public virtual void SetupCustomerStats()
    {

    }
}
