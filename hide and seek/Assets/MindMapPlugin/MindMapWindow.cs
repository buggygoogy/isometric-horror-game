using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class MindMapWindow : EditorWindow
{
    List<string> boxTitle = new List<string>();
    List<Vector2> boxPos = new List<Vector2>();
    List<Vector2> boxSize = new List<Vector2>();
    List<Color> boxColor = new List<Color>();

    List<Vector2> lineStartAndEnd = new List<Vector2>();

    int numOfBox = 0;
    int numOfLine;
    float w = 50;
    float h = 50;
    string enterTitle;

    Color color = Color.Lerp(Color.white, Color.black, 0.5f);

    bool isCreatingLine = false;

    bool showBox = false;
    bool isSelectBox = false;
    int listCount = 0;
    int selectedBox;
    string showBoxText = "Show all Boxes";

    private void Awake()
    {
        boxTitle.Insert(0, "Enter Title Here");
        boxPos.Insert(0, new Vector2(0, 200));
        boxSize.Insert(0, new Vector2(50, 50));
        boxColor.Insert(0, color);

        lineStartAndEnd.Insert(0, new Vector2(0, 0));

        numOfLine = 0;

        GUI.color = Color.white;
    }

    [MenuItem("Window/Mind Map")]
    public static void openWindow()
    {
        GetWindow<MindMapWindow>("Mind Map");
    }

    void OnGUI()
    {
        GUILayout.Label("Settings", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Save", GUILayout.Width(250), GUILayout.Height(25)))
        {
            SaveData();
        }

        if (GUILayout.Button("Load", GUILayout.Width(250), GUILayout.Height(25)))
        {
            ReadData();
        }
        EditorGUILayout.EndHorizontal();

        SaveAndChangeTheDataOfBox();

        CreateAndDeleteBox();

        GenerateBox();

        GenerateLine();

        DeleteAllLine();

        ListOutAllTheBox();
    }

    void SaveAndChangeTheDataOfBox()
    {
        if (isSelectBox)
        {
            //Save and Change data
            boxTitle[selectedBox] = EditorGUILayout.TextField("Title", boxTitle[selectedBox], GUILayout.Width(500));

            //Change Size
            w = EditorGUILayout.Slider("Width", boxSize[selectedBox].x, 50, 200, GUILayout.Width(500));
            h = EditorGUILayout.Slider("Higth", boxSize[selectedBox].y, 50, 200, GUILayout.Width(500));

            //Change Color
            color = EditorGUILayout.ColorField("Color", boxColor[selectedBox], GUILayout.Width(200));

            //Save Size and Color
            boxSize[selectedBox] = new Vector2(w, h);
            boxColor[selectedBox] = color;

            Repaint();
        }
        else
        {
            //Change data
            enterTitle = EditorGUILayout.TextField("Title", boxTitle[numOfBox], GUILayout.Width(500));

            //Change Size
            w = EditorGUILayout.Slider("Width", w, 50, 200, GUILayout.Width(500));
            h = EditorGUILayout.Slider("Higth", h, 50, 200, GUILayout.Width(500));

            //Change Color
            color = EditorGUILayout.ColorField("Color", color, GUILayout.Width(200));

            //Save All Data
            boxTitle.Insert(numOfBox, enterTitle);
            boxPos.Insert(numOfBox, new Vector2(200, 200));
            boxSize.Insert(numOfBox, new Vector2(w, h));
            boxColor.Insert(numOfBox, color);
        }
    }

    void CreateAndDeleteBox()
    {
        EditorGUILayout.BeginHorizontal();

        //The "+" button
        if (GUILayout.Button("Create Box", GUILayout.Width(250), GUILayout.Height(25)))
        {
            numOfBox++;

            selectedBox = numOfBox - 1;
            isSelectBox = true;

            GUI.FocusControl(null);
        }

        //The "-" button
        if (GUILayout.Button("Delete Box", GUILayout.Width(250), GUILayout.Height(25)) && numOfBox > 0)
        {
            numOfBox--;
            listCount--;

            if (isSelectBox)
            {
                boxTitle.RemoveAt(selectedBox);
                boxPos.RemoveAt(selectedBox);
                boxSize.RemoveAt(selectedBox);
                boxColor.RemoveAt(selectedBox);

                DeleteLine();

                isSelectBox = false;
            }
        }

        EditorGUILayout.EndHorizontal();

        if (isSelectBox)
        {
            ShowButtonWhenSelectedBox();
        }
    }

    void ShowButtonWhenSelectedBox()
    {
        EditorGUILayout.BeginHorizontal();

        //Deselect Button
        if (GUILayout.Button("Deselect Box", GUILayout.Width(250), GUILayout.Height(25)))
        {
            isSelectBox = false;
        }

        //Set the selected box to the start of the line that is creating
        if (GUILayout.Button("Create Line", GUILayout.Width(250), GUILayout.Height(25)))
        {
            lineStartAndEnd.Insert(numOfLine, new Vector2(selectedBox, 0));
            isCreatingLine = true;
        }

        EditorGUILayout.EndHorizontal();
    }

    void GenerateBox()
    {
        for (int i = 0; i < numOfBox; i++)
        {
            GUI.backgroundColor = boxColor[i];
            GUI.Box(new Rect(boxPos[i], boxSize[i]), boxTitle[i]);

            SelectBox(i);
            DragBox(i);
        }
    }

    void SelectBox(int selectedBox_Num)
    {
        if (Event.current.type == EventType.MouseDown)
        {
            if (new Rect(boxPos[selectedBox_Num], boxSize[selectedBox_Num]).Contains(Event.current.mousePosition))
            {
                selectedBox = selectedBox_Num;
                isSelectBox = true;

                GUI.FocusControl(null);

                Repaint();

                //Set the selected box to the end of the line that is creating
                if (isCreatingLine)
                {
                    float temp = lineStartAndEnd[numOfLine].x;
                    lineStartAndEnd.Insert(numOfLine, new Vector2(temp, selectedBox_Num));
                    isCreatingLine = false;
                    numOfLine++;
                }
            }
            return;
        }
    }

    void DragBox(int selectedBox_Num)
    {
        if (Event.current.type == EventType.MouseDrag && new Rect(boxPos[selectedBox_Num], boxSize[selectedBox_Num]).Contains(Event.current.mousePosition))
        {
            boxPos[selectedBox] += Event.current.delta;
            Repaint();
        }
    }

    void GenerateLine()
    {
        if (isCreatingLine)
        {
            int lineStart = (int)lineStartAndEnd[numOfLine].x;

            float x_LineStart = boxPos[lineStart].x + (boxSize[lineStart].x / 2);
            float y_LineStart = boxPos[lineStart].y + (boxSize[lineStart].y / 2);

            float x_LineEnd = Event.current.mousePosition.x;
            float y_LineEnd = Event.current.mousePosition.y;

            Handles.DrawLine(new Vector3(x_LineStart, y_LineStart), new Vector3(x_LineEnd, y_LineEnd));
        }

        for(int i = 0; i < numOfLine; i++)
        {
            int lineStart = (int)lineStartAndEnd[i].x;
            int lineEnd = (int)lineStartAndEnd[i].y;

            float x_LineStart = boxPos[lineStart].x + (boxSize[lineStart].x / 2);
            float y_LineStart = boxPos[lineStart].y + (boxSize[lineStart].y / 2);

            float x_LineEnd = boxPos[lineEnd].x + (boxSize[lineEnd].x / 2);
            float y_LineEnd = boxPos[lineEnd].y + (boxSize[lineEnd].y / 2);

            Handles.DrawLine(new Vector3(x_LineStart, y_LineStart), new Vector3(x_LineEnd, y_LineEnd));
        }
    }

    void DeleteLine()
    {
        //Remove line from list
        for (int i = 0; i < numOfLine; i++)
        {
            if (lineStartAndEnd[i].x == selectedBox || lineStartAndEnd[i].y == selectedBox)
            {
                lineStartAndEnd.RemoveAt(i);
                numOfLine--;
                i--;
            }
        }

        //Correct the line data
        for (int i = 0; i < numOfLine; i++)
        {
            if (lineStartAndEnd[i].x > selectedBox)
            {
                float tempX = lineStartAndEnd[i].x - 1;
                float tempY = lineStartAndEnd[i].y;

                lineStartAndEnd[i] = new Vector2(tempX, tempY);
            }

            if (lineStartAndEnd[i].y > selectedBox)
            {
                float tempX = lineStartAndEnd[i].x;
                float tempY = lineStartAndEnd[i].y - 1;

                lineStartAndEnd[i] = new Vector2(tempX, tempY);
            }
        }
    }

    void DeleteAllLine()
    {
        GUI.backgroundColor = Color.white;

        if (GUILayout.Button("Delete All Lines", GUILayout.Width(503), GUILayout.Height(25)))
        {
            if (numOfLine > 0)
            {
                lineStartAndEnd.Clear();
                numOfLine = 0;
            }
        }
    }

    void ListOutAllTheBox()
    {
        GUI.backgroundColor = Color.white;
        
        showBox = EditorGUILayout.Foldout(showBox, showBoxText);

        if (showBox)
        {
            showBoxText = "Hide all Box";

            for (listCount = 0; listCount < numOfBox; listCount++)
            {
                GUI.backgroundColor = boxColor[listCount];
                if (GUILayout.Button(boxTitle[listCount], GUILayout.Width(150)))
                {
                    selectedBox = listCount;
                    isSelectBox = true;
                }
            }
        }
        else
        {
            showBoxText = "Show all Boxes";
        }
    }

    void SaveData()
    {
        string path = Application.dataPath + "/MindMapPlugin";
        string name = "/MindMapData.txt";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        StreamWriter file = File.CreateText(path + name);

        file.WriteLine(numOfBox);
        file.WriteLine(numOfLine);

        for (int i = 0; i < numOfBox; i++)
        {
            file.WriteLine(boxTitle[i]);
        }

        for (int i = 0; i < numOfBox; i++)
        {
            file.WriteLine(boxPos[i].x);
            file.WriteLine(boxPos[i].y);
        }

        for (int i = 0; i < numOfBox; i++)
        {
            file.WriteLine(boxSize[i].x);
            file.WriteLine(boxSize[i].y);
        }

        for (int i = 0; i < numOfBox; i++)
        {
            file.WriteLine(boxColor[i].r);
            file.WriteLine(boxColor[i].g);
            file.WriteLine(boxColor[i].b);
            file.WriteLine(boxColor[i].a);
        }

        for (int i = 0; i < numOfLine; i++)
        {
            file.WriteLine(lineStartAndEnd[i].x);
            file.WriteLine(lineStartAndEnd[i].y);
        }

        file.Close();
    }

    void ReadData()
    {
        string path = Application.dataPath + "/MindMapPlugin";
        string name = "/MindMapData.txt";

        StreamReader file = File.OpenText(path + name);

        numOfBox = Int32.Parse(file.ReadLine());
        numOfLine = Int32.Parse(file.ReadLine());

        for (int i = 0; i < numOfBox; i++)
        {
            boxTitle.Insert(i, file.ReadLine());
        }

        for (int i = 0; i < numOfBox; i++)
        {
            float readX = float.Parse(file.ReadLine());
            float readY = float.Parse(file.ReadLine());

            boxPos.Insert(i, new Vector2(readX, readY));
        }

        for (int i = 0; i < numOfBox; i++)
        {
            float readX = float.Parse(file.ReadLine());
            float readY = float.Parse(file.ReadLine());

            boxSize.Insert(i, new Vector2(readX, readY));
        }

        for (int i = 0; i < numOfBox; i++)
        {
            float readR = float.Parse(file.ReadLine());
            float readG = float.Parse(file.ReadLine());
            float readB = float.Parse(file.ReadLine());
            float readA = float.Parse(file.ReadLine());

            boxColor.Insert(i, new Color(readR, readG, readB, readA));
        }

        for (int i = 0; i < numOfLine; i++)
        {
            float readX = float.Parse(file.ReadLine());
            float readY = float.Parse(file.ReadLine());

            lineStartAndEnd.Insert(i, new Vector2(readX, readY));
        }

        file.Close();
    }
}
