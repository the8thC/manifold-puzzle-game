using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataTextLoader : MonoBehaviour {
    Button[] buttons;
    TextMeshProUGUI[] textMeshes;
    TextMeshProUGUI text0;
    TextMeshProUGUI text1;
    TextMeshProUGUI text2;

    public Button button0;
    public Button button1;
    public Button button2;
    public SaveLoadScript saverLoader;

    void Start() {
        buttons = new Button[] { button0, button1, button2 };
    }

    void OnEnable() {
        InitTextMeshes();
        LoadTextData(0);
        LoadTextData(1);
        LoadTextData(2);
    }

    void InitTextMeshes() {
        if(text0 == null)
            text0 = button0.GetComponentInChildren<TextMeshProUGUI>();
        if(text1 == null)
            text1 = button1.GetComponentInChildren<TextMeshProUGUI>();
        if(text2 == null)
            text2 = button2.GetComponentInChildren<TextMeshProUGUI>();
        if(textMeshes == null)
            textMeshes = new TextMeshProUGUI[] { text0, text1, text2 };
    }

    public void LoadTextData(int index) {
        string text;
        if(saverLoader.LoadSaveData("Save" + index, out text))
            textMeshes[index].text = text;
    }
}
