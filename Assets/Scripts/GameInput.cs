using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    public event EventHandler OnPauseAction;
    public static GameInput Instance { get; private set; }

    // Start is called before the first frame update
    public InputSystem inputSystem;

    //evento che si attiva quando premo il tasto
    public event EventHandler OnLeftClickEvent;


    private void Awake()
    {
        Instance = this;
        this.inputSystem = new InputSystem();


        this.inputSystem.UI.Enable();
        this.inputSystem.Player.Enable();

        this.inputSystem.Player.Pause.performed += Pause_Performed;
    }

    private void Pause_Performed(InputAction.CallbackContext context)
    {

        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }


    void Start()
    {
      

    }


    // Update is called once per frame
    void Update()
    {
        var mousePosition = this.inputSystem.UI.Point.ReadValue<Vector2>();
 

        if (this.inputSystem.UI.LeftClick.IsPressed())

        {
         //   Debug.Log("Tengo premuto left");
        }

        if (this.inputSystem.UI.LeftClick.WasPressedThisFrame())

        {
            OnLeftClickEvent?.Invoke(this, EventArgs.Empty);
           // Debug.Log("premo left");
        }


        if (this.inputSystem.UI.RightClick.WasPressedThisFrame())

        {
          //  Debug.Log("premo right");
        }
    }
}
