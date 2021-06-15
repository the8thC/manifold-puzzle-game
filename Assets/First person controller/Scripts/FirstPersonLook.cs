using UnityEngine;

public class FirstPersonLook : MonoBehaviour {
    [SerializeField]
    Transform character;
    [SerializeField]
    AudioListener audioListener;
    Vector2 currentMouseLook;
    Vector2 appliedMouseDelta;
    //bool isUnpaused = true;
    
    public float sensitivity = 1;
    public float smoothing = 2;

    public PauseMenu pauseMenu;


    // void Reset() {
    //     character = GetComponentInParent<FirstPersonMovement>().transform;
    //     audioListener = GetComponent<AudioListener>();
    // }

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        currentMouseLook.x = character.localEulerAngles.y;
        currentMouseLook.y = -transform.localEulerAngles.x;
    }

    void Update() {
        if (pauseMenu.IsGamePaused)
        {
            audioListener.enabled = false;
            return;
            // if(pauseMenu.IsGamePaused) {
            //     Pause();
            //     return;
            // } else if(!pauseMenu.IsGamePaused)
            //     Unpause();
            
            // pauseMenu.PauseHasChanged = false;
        }
        else
            audioListener.enabled = true;


        // Get smooth mouse look.
        //character.localRotation(out float angleX, out Vector3 axis);
        //currentMouseLook.x = angleX * axis.y;
        currentMouseLook.x = character.localEulerAngles.y;
        currentMouseLook.y = -transform.localEulerAngles.x;
        //transform.localRotation.ToAngleAxis(out float angleY, out Vector3 axis2);
        //currentMouseLook.y = Mathf.Clamp(angleY, -90, 90);

        Vector2 smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * sensitivity * smoothing);
        appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
        currentMouseLook += appliedMouseDelta;
        //currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90, 90);

        // Rotate camera and controller.
        transform.localRotation = Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);
    }

    // void OnDestroy()
    // {
    //     Cursor.lockState = CursorLockMode.None;
    // }

    void Pause() {
        audioListener.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
    void Unpause() {
        audioListener.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
