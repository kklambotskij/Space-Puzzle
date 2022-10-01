using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

    public class FieldBlokuDoku : MonoBehaviour
    {
        [SerializeField] GameObject fieldCell;
        [SerializeField] GameObject gridField;
        [SerializeField] GameObject gridFigurs;
        [SerializeField] DataBase dataProvider;
        [SerializeField] RectTransform dragFigureTransform;

        List<FieldCell> fieldCells = new List<FieldCell>();
        List<FigureCell> figuresCells = new List<FigureCell>();
        
        FigureCell currentFigure;
        int maxFieldCells = 64;
        int dragCellId = -1;
        int countMove = 0;

        // Start is called before the first frame update
        void Start()
        {
            CreateField();
            CreateFigures();            
        }

        // Update is called once per frame
        void Update()
        {
            UpdateDragFigure();
        }
        private void CreateField()
        {
            for (int i = 0; i < maxFieldCells; i++)

            {
                GameObject viewObj = Instantiate(fieldCell, gridField.transform) as GameObject;
                viewObj.name = i.ToString();
                RectTransform rect = viewObj.GetComponent<RectTransform>();//находим поле дл¤ нашего обьекта и его позицию и размер
                rect.localPosition = new Vector3(0, 0, 0);//задаем позицию
                rect.localScale = new Vector3(1, 1, 1);//задаем маштаб
                viewObj.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

                FieldCell newCell = new FieldCell();//создание экземпл¤ра ¤чейки
                newCell.view = viewObj;//приравниваем его gameObject к ¤чейки из юнити
                fieldCells.Add(newCell);//добавл¤ем ¤чейку в список            
            }
        }

        private void CreateFigures()
        {
            for (int i = 0; i < 3; i++)
            {
                var id = 1;
                //var id = Random.Range(3, dataProvider.figursCells.Count);

                GameObject viewObj = Instantiate(dataProvider.figursCells[id].figure, gridFigurs.transform) as GameObject;
                viewObj.name = i.ToString();
                RectTransform rect = viewObj.GetComponent<RectTransform>();//находим поле дл¤ нашего обьекта и его позицию и размер
                rect.localPosition = new Vector3(0, 0, 0);//задаем позицию
                rect.localScale = new Vector3(1, 1, 1);//задаем маштаб
                viewObj.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

                FigureCell newCell = new FigureCell();//создание экземпл¤ра ¤чейки
                newCell.figure = viewObj;//приравниваем его gameObject к ¤чейки из юнити
                newCell.figure.transform.localScale = new Vector3(1, 1, 1);
                figuresCells.Add(newCell);//добавл¤ем ¤чейку в список
                UpdateFigursCells(i, dataProvider.figursCells[id]);

            }
        }

        private void UpdateDragFigure()
        {
            Vector3 pos = Input.mousePosition + dataProvider.mouseDragOffset;
            pos.z = gridField.GetComponent<RectTransform>().position.z;
            dragFigureTransform.transform.position = Camera.main.ScreenToWorldPoint(pos);
        }
        public void UpdateFigursCells(int id, FigursCell item)
        {
            figuresCells[id].id = item.id;
            figuresCells[id].figure.GetComponent<Image>().sprite = item.img;//Random.Range(0, figurs.Count)
            Debug.Log("UpdateFigursCells: " + dragCellId);
        }

        public void SelectObject(GameObject selectObject)
        {
            if (dragCellId == -1)
            {
                dragCellId = int.Parse(selectObject.name);//преобразовываем им¤ обьекта в число и приравниваем его к переменной
                currentFigure = CopyFigureCells(figuresCells[dragCellId]);//копируем ¤чейку на которую нажали и приравниваем ее к ¤чейки инвентар¤

                if (currentFigure.id > 0)
                {
                    dragFigureTransform.gameObject.SetActive(true);//включаем видимость перетаскиваемого обьекта
                    dragFigureTransform.GetComponent<Image>().sprite = dataProvider.figursCells[currentFigure.id].img;//приравниваем картинку перетаскиваемого обьекта к ¤чейки на которую нажали                
                    UpdateFigursCells(dragCellId, dataProvider.figursCells[0]);//добавл¤ем ¤чейку в слот на который нажали, с первой картинкой и первым id 
                }
                else
                {
                    Debug.Log("currentID = 0");
                    dragCellId = -1;//возвращаем начальное значение
                }
            }
            else
            {
                Vector3 moving = dragFigureTransform.transform.position;
                FindAndDrop(moving, currentFigure.id, dragCellId);


                dragCellId = -1;
                dragFigureTransform.gameObject.SetActive(false);

                countMove += 1;
                Debug.Log($"countMove + {countMove}");
            }
        }

        private FigureCell CopyFigureCells(FigureCell old)
        {
            FigureCell New = new FigureCell();

            New.id = old.id;//приравниваем новый id к старому
            New.figure = old.figure;//приравниваем новый обьект к старому        

            return New;//возвращаем знаечение New
        }

        private void FindAndDrop(Vector3 moving, int figureId, int figureNumber)
        {
            Debug.Log($"{nameof(FindAndDrop)} - moving : {moving}");

            List<FieldCell> parts = FindCellsForFigure(moving, figureId);

            bool canDrop = CanDrop(parts);

            if (canDrop == true)
            {
                for (int i = 0; i < parts.Count; i++)
                {
                    PutFigurePart(parts[i]);
                    Debug.Log($"{nameof(FindAndDrop)} - parts[{i}].id: {parts[i].view.name}");
                }

            }
            else
            {
                UpdateFigursCells(figureNumber, dataProvider.figursCells[figureId]);
            }
        }

        private List<FieldCell> FindCellsForFigure(Vector3 moving, int figursId)
        {
            List<FieldCell> parts = new List<FieldCell>();

            var width = fieldCells[1].view.transform.position.x - fieldCells[0].view.transform.position.x;
            var height = fieldCells[0].view.transform.position.y - fieldCells[8].view.transform.position.y;

            var coefX = width / 0.7f - 0.05f;
            var coefY = height / 0.7f - 0.05f;

            for (int i = 0; i < dataProvider.figursCells[figursId].vertex.Count; i++)
            {
                var v0 = dataProvider.figursCells[figursId].vertex[i];

                var cell = FindFigurePart(moving + new Vector3(-0.175f, 0.175f, 0) - new Vector3(v0.x * coefX, v0.y * coefY, 0));
                parts.Add(cell);
            }

            return parts;
        }

        private FieldCell FindFigurePart(Vector3 moving)
        {
            FieldCell cell = null;
            Vector3 minPos = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);//создание минимальной позиции до элемента            

            for (int i = 0; i < fieldCells.Count; i++)
            {
                Vector3 cellsI = fieldCells[i].view.transform.position;

                if (Vector3.Distance(cellsI, moving) < Vector3.Distance(moving, minPos))
                {
                    minPos = cellsI;
                    cell = fieldCells[i];
                }
            }
            return cell;
        }

        private static bool CanDrop(List<FieldCell> parts)
        {
            var canDrop = true;

            for (int i = 0; i < parts.Count; i++)
            {
                if (parts[i].check == true)
                {
                    canDrop = false;
                    break;
                }
            }

            for (int i = 0; i < parts.Count; i++)
            {
                for (int j = 0; j < parts.Count; j++)
                {
                    if (j != i)
                    {
                        if (parts[i].view.name == parts[j].view.name)
                        {
                            canDrop = false;
                            break;
                        }
                    }
                }
            }

            return canDrop;
        }

        private void PutFigurePart(FieldCell cell)
        {
            FieldCell box = fieldCells[int.Parse(cell.view.name)];
            box.check = true;
            box.view.GetComponent<Image>().sprite = dataProvider.figursCells[1].img;
        }
        
    }

    [Serializable]
    public class FieldCell
    {
        public int id = 0;
        public GameObject view;
        public bool check = false;        
    }

    [Serializable]
    class FigureCell
    {
        public GameObject figure;
        public int id;//номер фигуры от 3
    }
