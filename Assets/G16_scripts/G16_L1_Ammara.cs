using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class G16_L1_Ammara : MonoBehaviour
{
    string c_state = "q0", direction, c_txt;
    public Text statusText, cStateText, LabelText;
    public Camera mycam;
    public Button okbtn, backBtn;
    Ray ray;
    RaycastHit hit;
    string inp;
    public TMP_InputField inpField;
    GameObject cubeChild;
    string txt;
    public AudioSource tin;
    public GameObject btnobj, inpfieldobj, preCube;
    // Start is called before the first frame update
    void Start()
    {
        okbtn.onClick.AddListener(genBoxes);
        backBtn.onClick.AddListener(reset);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            test();
            tin.Play();
        }
    }

    public void genBoxes()
    {
        inp = inpField.text;
        int j = 0;
        string pattren = @"^([abc]+)$";
        Match m = Regex.Match(inpField.text, pattren);
        if (m.Success)
        {
            btnobj.SetActive(false);
            inpfieldobj.SetActive(false);
            inp = "$$" + inpField.text + "$$";
            char[] chrinp = inp.ToCharArray();
            for (int i = 0; i < inp.Length; i++)
            {

                GameObject cube; // GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube = Instantiate(preCube);
                cube.transform.position = new Vector3(j, 0, 0);
                cube.GetComponent<Renderer>().material.color = Color.green;
                GameObject obj = new GameObject();
                obj.transform.parent = cube.transform;
                GameObject child = cube.transform.GetChild(0).gameObject;
                child.AddComponent<TextMeshPro>();
                child.GetComponent<TextMeshPro>().fontSize = 10;
                child.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.Center;
                child.GetComponent<TextMeshPro>().text = chrinp[i].ToString();
                child.transform.Rotate(90, 0, 0);
                Vector3 pos = child.transform.localPosition;
                pos.x = 0;
                pos.y = 0.65f;
                pos.z = 0;
                child.transform.localPosition = pos;
                j = j + 2;
            }
        }


    }
    void move(string s)
    {
        if (s == "R")
        {
            Vector3 vec = mycam.transform.position;
            vec.x = vec.x + 2;
            mycam.transform.position = vec;
        }
        else if (s == "L")
        {
            Vector3 vec = mycam.transform.position;
            vec.x = vec.x - 2;
            mycam.transform.position = vec;
        }
    }
    void test()
    {
        ray = mycam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit))
        {
            cubeChild = hit.transform.GetChild(0).gameObject;
            txt = cubeChild.GetComponent<TextMeshPro>().text;
            print("Print");
        }
        switch (c_state)
        {
            case "q0":
                {

                    if (txt == "a")
                    {
                        c_state = "q1";
                        cStateText.text = "q1";
                        cubeChild.GetComponent<TextMeshPro>().text = "x";
                        direction = "R";
                        move(direction);
                        print("R");

                    }
                    else if (txt == "y")
                    {
                        c_state = "q3";
                        cStateText.text = "q3";
                        cubeChild.GetComponent<TextMeshPro>().text = "y";
                        direction = "R";
                        move(direction);
                    }
                    else
                    {
                        statusText.text = "String is rejected";
                    }
                    break;
                }
            case "q1":
                {
                    if (txt == "a")
                    {

                        c_state = "q1";
                        cStateText.text = "q1";
                        cubeChild.GetComponent<TextMeshPro>().text = "a";
                        direction = "R";
                        move(direction);

                    }
                    else if (txt == "b")
                    {
                        c_state = "q2";
                        cStateText.text = "q2";
                        cubeChild.GetComponent<TextMeshPro>().text = "y";
                        direction = "L";
                        move(direction);
                    }
                    else if (txt == "y")
                    {
                        c_state = "q1";
                        cStateText.text = "q1";
                        cubeChild.GetComponent<TextMeshPro>().text = "y";
                        direction = "R";
                        move(direction);
                    }
                    else
                    {
                        statusText.text = "String is rejected";
                    }

                    break;
                }
            case "q2":
                {
                    if (txt == "y")
                    {
                        c_state = "q2";
                        cStateText.text = "q2";
                        cubeChild.GetComponent<TextMeshPro>().text = "y";
                        direction = "L";
                        move(direction);

                    }
                    else if (txt == "a")
                    {
                        c_state = "q2";
                        cStateText.text = "q2";
                        cubeChild.GetComponent<TextMeshPro>().text = "a";
                        direction = "L";
                        move(direction);
                    }
                    else if (txt == "x")
                    {
                        c_state = "q0";
                        cStateText.text = "q0";
                        cubeChild.GetComponent<TextMeshPro>().text = "x";
                        direction = "R";
                        move(direction);
                    }

                    else
                    {
                        statusText.text = "String is rejected";
                    }

                    break;
                }
            case "q3":
                {
                    if (txt == "y")
                    {
                        c_state = "q3";
                        cStateText.text = "q3";
                        cubeChild.GetComponent<TextMeshPro>().text = "y";
                        direction = "R";
                        move(direction);

                    }
                    else if (txt == "c")
                    {
                        c_state = "q4";
                        cStateText.text = "q4";
                        cubeChild.GetComponent<TextMeshPro>().text = "c";
                        direction = "L";
                        move(direction);
                    }
                    else
                    {
                        statusText.text = "String is rejected";
                    }

                    break;
                }
            case "q4":
                {
                    if (txt == "y")
                    {
                        c_state = "q4";
                        cStateText.text = "q4";
                        cubeChild.GetComponent<TextMeshPro>().text = "y";
                        direction = "L";
                        move(direction);

                    }
                    else if (txt == "x")
                    {
                        c_state = "q5";
                        cStateText.text = "q5";
                        cubeChild.GetComponent<TextMeshPro>().text = "x";
                        direction = "R";
                        move(direction);
                    }
                    else
                    {
                        statusText.text = "String is rejected";
                    }

                    break;
                }
            case "q5":
                {
                    if (txt == "y")
                    {
                        c_state = "q6";
                        cStateText.text = "q6";
                        cubeChild.GetComponent<TextMeshPro>().text = "#";
                        direction = "R";
                        move(direction);

                    }
                    else if (txt == "z")
                    {
                        c_state = "q8";
                        cStateText.text = "q8";
                        cubeChild.GetComponent<TextMeshPro>().text = "z";
                        direction = "S";
                        move(direction);
                    }
                    else
                    {
                        statusText.text = "String is rejected";
                    }

                    break;
                }
            case "q6":
                {
                    if (txt == "z")
                    {
                        c_state = "q6";
                        cStateText.text = "q6";
                        cubeChild.GetComponent<TextMeshPro>().text = "z";
                        direction = "R";
                        move(direction);
                    }
                    else if (txt == "y")
                    {
                        c_state = "q6";
                        cStateText.text = "q6";
                        cubeChild.GetComponent<TextMeshPro>().text = "y";
                        direction = "R";
                        move(direction);
                    }
                    else if (txt == "c")
                    {
                        c_state = "q7";
                        cStateText.text = "q7";
                        cubeChild.GetComponent<TextMeshPro>().text = "z";
                        direction = "L";
                        move(direction);
                    }
                    else
                    {
                        statusText.text = "String is rejected";
                    }

                    break;
                }
            case "q7":
                {
                    if (txt == "y")
                    {
                        c_state = "q7";
                        cStateText.text = "q7";
                        cubeChild.GetComponent<TextMeshPro>().text = "y";
                        direction = "L";
                        move(direction);

                    }
                    else if (txt == "z")
                    {
                        c_state = "q7";
                        cStateText.text = "q7";
                        cubeChild.GetComponent<TextMeshPro>().text = "z";
                        direction = "L";
                        move(direction);
                    }
                    else if (txt == "#")
                    {
                        c_state = "q5";
                        cStateText.text = "q5";
                        cubeChild.GetComponent<TextMeshPro>().text = "#";
                        direction = "R";
                        move(direction);
                    }
                    else
                    {
                        statusText.text = "String is rejected";
                    }
                    break;
                }
            case "q8":
                {
                    if (txt == "z")
                    {
                        c_state = "q8";
                        cStateText.text = "q8";
                        cubeChild.GetComponent<TextMeshPro>().text = "z";
                        direction = "S";
                        move(direction);

                        statusText.text = "String is Accepted";
                    }
                    else
                    {
                        statusText.text = "String is rejected";
                    }
                }
                break;

        }

    }
    public void BackButtonCode(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void reset()
    {
        SceneManager.LoadScene("Scene2");
    }
}

