using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Editor_System : MonoBehaviour {

    public GameObject editor_object;
    public GameObject editor_UI;
    public GameObject[] prefabsList;
    public GameObject[] button;
    [HideInInspector]
    public Boolean paused = false;
    [HideInInspector]
    public int pageNumber = 0;
    [HideInInspector]
    public List<GameObject> edited_Objects;
    private int maxPageNumber = 0;
    private GameObject instantFocus;
    private GameObject focus;
    private Vector3 wp2;

    // Use this for initialization
    void Start() {
        maxPageNumber = prefabsList.Length / button.Length;
        if ((prefabsList.Length / button.Length) % button.Length != 0)
            maxPageNumber++;

        SetBtnOnEditor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = !paused;
            editor_UI.SetActive(paused);
        }
        wp2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        try
        {
            instantFocus.transform.position = LatticeMove();
        }
        catch (System.Exception)
        {

        }
    }

    public void SetBtnOnEditor () {
        for (int i = 0; i < button.Length; i++) {
            try {
                button[i].SetActive(true);
                button[i].GetComponent<Editor_ObjectBtn>().ChangeSourceObject(prefabsList[i + pageNumber * button.Length]);
            } catch {
                button[i].SetActive(false);
            }
        }
    }

    public void ChangeFocus(GameObject other) {
        focus = other;
        editor_object.GetComponent<SpriteRenderer>().sprite = focus.GetComponent<SpriteRenderer>().sprite;
        if(instantFocus == null)
            instantFocus = Instantiate(editor_object, LatticeMove(), Quaternion.identity);
        else
            instantFocus.GetComponent<SpriteRenderer>().sprite = focus.GetComponent<SpriteRenderer>().sprite;
    }

    public GameObject GetFocus() { return focus; }

    public void ChangPage(bool isPlus) {
        if (isPlus)
        {
            pageNumber++;
        }
        else
        {
            pageNumber--;
        }

        if (maxPageNumber < pageNumber) pageNumber = maxPageNumber;
        if (pageNumber < 0) pageNumber = 0;

        SetBtnOnEditor();
    }

    Vector3 LatticeMove() {
        wp2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(Mathf.RoundToInt(wp2.x), Mathf.RoundToInt(wp2.y), 0);


    }
}
