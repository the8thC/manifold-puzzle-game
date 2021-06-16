using UnityEngine;

public class FirstPersonLook : MonoBehaviour {
    [SerializeField]
    Transform character;
    [SerializeField]
    AudioListener audioListener;
    Vector2 currentMouseLook;
    Vector2 appliedMouseDelta;
    
    public float sensitivity = 1;
    public float smoothing = 2;

    public PauseMenu pauseMenu;

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
        }
        else
            audioListener.enabled = true;


        currentMouseLook.x = character.localEulerAngles.y;
        currentMouseLook.y = -transform.localEulerAngles.x;

        // Get smooth mouse look.
        Vector2 smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * sensitivity * smoothing);
        appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
        currentMouseLook += appliedMouseDelta;

        // Rotate camera and controller.
        transform.localRotation = Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);
    }

    void Pause() {
        audioListener.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
    void Unpause() {
        audioListener.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
