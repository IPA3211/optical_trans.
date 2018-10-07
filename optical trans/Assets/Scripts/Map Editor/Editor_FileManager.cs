using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Editor_FileManager : MonoBehaviour {

    string Path_FileName = ("C:\\Intel\\UserMap");
    public GameObject collector;
    public GameObject content;
    public GameObject CanvasLoad;
    public GameObject CanvasSave;
    public GameObject loadButton;
    public GameObject Drawer;
    public GameObject fileNameCollecter;
    public string fileName;

    private GameObject tmp;
    private Editor_ImageChanger[] edi_Imag;
    private Transform[] tranChildren;
    private SerializedUnit[] unit;


    // Use this for initialization
    public void OnOffSave() {
        CanvasSave.SetActive(!CanvasSave.activeSelf);
    }
    
    public void GetFileName() {
        fileName = fileNameCollecter.GetComponent<Text>().text;
        Save();
    }

    public void Save() {
        try
        {
            tranChildren = collector.GetComponentsInChildren<Transform>(); // not only children also parent
            edi_Imag = collector.GetComponentsInChildren<Editor_ImageChanger>();

            unit = new SerializedUnit[tranChildren.Length -1];// not only children also parent

            for (int i = 0; i < tranChildren.Length - 1; i++) {
                Debug.Log(i + " : " + tranChildren[i + 1]);// not only children also parent
                unit[i] = new SerializedUnit(tranChildren[i + 1], edi_Imag[i].sourceObject);
                Debug.Log(unit[i]);
            }
        }
        catch {
            Debug.Log("Get Data Error");
        }

        DirectoryInfo di = new DirectoryInfo(Path_FileName);
        if (di.Exists == false)
        {
            di.Create();
        }

        Stream ws = new FileStream(Path_FileName + "\\" + fileName + ".dat", FileMode.Create);
        BinaryFormatter serializer = new BinaryFormatter();

        serializer.Serialize(ws, unit);
        ws.Close();

        Debug.Log("Save Finished");
        CanvasSave.SetActive(false);
    }

    public void Load() {
        CanvasLoad.SetActive(true);
        DirectoryInfo dirctotyInfo = new DirectoryInfo(Path_FileName);
        FileInfo[] childDirctotyInfo;

        childDirctotyInfo = dirctotyInfo.GetFiles();
        Debug.Log(childDirctotyInfo.Length);

        for (int i = 0; i < childDirctotyInfo.Length; i++) {
            GameObject a = Instantiate(loadButton, content.transform);
            a.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -30 *i, 0);
            string path = childDirctotyInfo[i].FullName;
            a.GetComponent<Button>().onClick.AddListener(() => LoadFile(path));
            a.GetComponentInChildren<Text>().text = childDirctotyInfo[i].Name;
        }
    }

    public void LoadFile(string path) {
        ClearCollector();

        Stream rs = new FileStream(path, FileMode.Open);
        BinaryFormatter deserializer = new BinaryFormatter();

        SerializedUnit[] nc2;
        nc2 = (SerializedUnit[])deserializer.Deserialize(rs);
        rs.Close();

        for(int i = 0; i < nc2.Length; i++)
            Debug.Log(nc2[i]);

        Editor_System editorSystem = gameObject.GetComponent<Editor_System>();
        for (int i = 0; i < nc2.Length; i++)
        {
            for (int j = 0; j < editorSystem.prefabsList.Length; j++)
            {
                if (editorSystem.prefabsList[j].name.Equals(nc2[i].gameObject))
                {
                    tmp = editorSystem.prefabsList[j];
                    break;
                }
            }
            Drawer.GetComponent<Editor_ImageChanger>().sourceObject = tmp;
            GameObject ObjTmp = Instantiate(Drawer, new Vector3(nc2[i].x, nc2[i].y, nc2[i].z), Quaternion.identity);
            ObjTmp.transform.parent = collector.transform;
        }
        Transform[] a = content.GetComponentsInChildren<Transform>();
        for (int i = 0; i < a.Length - 1; i++)
            Destroy(a[i+1].gameObject);
        CanvasLoad.SetActive(false);
    }

    void ClearCollector() {
        tranChildren = collector.GetComponentsInChildren<Transform>();// not only children also parent

        for (int i = 0; i < tranChildren.Length - 1; i++) {
            Destroy(tranChildren[i + 1].gameObject);
        }
    }
}

[System.Serializable]
class SerializedUnit {
    public float x, y, z;
    public string gameObject;

    public SerializedUnit(Transform transform, GameObject gameObject) {
        this.x = transform.position.x;
        this.y = transform.position.y;
        this.z = transform.position.z;
        this.gameObject = gameObject.name;
    }

    override public string ToString() {

        return "(" +x + ", " + y + "," + z +")" + " " + gameObject;
    }
}
