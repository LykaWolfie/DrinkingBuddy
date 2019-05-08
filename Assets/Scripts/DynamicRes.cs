using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicRes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.projectionMatrix = Matrix4x4.Ortho(-640f * 0.625f, 640f * 0.625f, -640f, 640f, 0.3f, 1000f);
    }

    private void Update() {
        if (StartGame.Practice()) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                StartGame.ChangeToGameScene(0);
            }
        }
    }
}
