using MyLib;
using ShapeControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;


namespace WinFormZZ
{
    public partial class Form1 : Form
    {
        private GeometricFigure currentFigure;
        private UserControl currentControl;
        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
        }
        private void InitializeComboBox()
        {
            cmbFigureType.Items.AddRange(new string[] { "Круг", "Прямоугольник", "Треугольник", "Квадрат" });
            cmbFigureType.SelectedIndex = 0;
        }

        private void cmbFigureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowFigureControl(cmbFigureType.SelectedItem.ToString());
        }

        private void ShowFigureControl(string figureType)
        {
            // Удаляем текущий контрол, если он есть
            if (currentControl != null)
            {
                pnlParameters.Controls.Remove(currentControl);
                currentControl.Dispose();
            }

            // Создаем и добавляем новый контрол в зависимости от выбранной фигуры
            switch (figureType)
            {
                case "Круг":
                    currentControl = new CircleControl();
                    break;
                case "Прямоугольник":
                    currentControl = new RectangleControl();
                    break;
                case "Треугольник":
                    currentControl = new TriangleControl();
                    break;
                case "Квадрат":
                    currentControl = new SquareControl();
                    break;
            }

            // Добавляем новый контрол на панель
            pnlParameters.Controls.Add(currentControl);
            currentControl.Dock = DockStyle.Fill;
        }
        private GeometricFigure CreateFigure()
        {
            switch (cmbFigureType.SelectedItem.ToString())
            {
                case "Круг":
                    var circleControl = (CircleControl)currentControl;
                    return new Circle(circleControl.Radius);
                case "Прямоугольник":
                    var rectControl = (RectangleControl)currentControl;
                    return new RectangleZ(rectControl.Width, rectControl.Height);
                case "Треугольник":
                    var triangleControl = (TriangleControl)currentControl;
                    // Проверка на существование треугольника
                    double a = triangleControl.SideA;
                    double b = triangleControl.SideB;
                    double c = triangleControl.SideC;
                    if (a + b <= c || a + c <= b || b + c <= a)
                        throw new ArgumentException("Треугольник с такими сторонами не существует");
                    return new Triangle1X(a, b, c);
                case "Квадрат":
                    var squareControl = (SquareControl)currentControl;
                    return new Square(squareControl.Side);
                default:
                    throw new ArgumentException("Неизвестный тип фигуры");
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                currentFigure = CreateFigure();

                // Получаем информацию о расчетах из самой фигуры
                rtxtArea.Text = currentFigure.GetAreaInfo();
                rtxtPerimeter.Text = currentFigure.GetPerimeterInfo();

                // Активируем кнопку сохранения
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentFigure == null)
            {
                MessageBox.Show("Сначала выполните расчет!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string savePath = "geometric_calculations.txt";
                string content = $"Фигура: {currentFigure.Name}\n" +
                                $"Формула площади: {currentFigure.AreaFormula}\n" +
                                $"Формула периметра: {currentFigure.PerimeterFormula}\n" +
                                $"Площадь: {rtxtArea.Text}\n" +
                                $"Периметр: {rtxtPerimeter.Text}\n";


                FileManager.SaveToFile(content, savePath);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static class FileManager
        {
            public static void SaveToFile(string content, string defaultFileName)
            {
                try
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                        saveFileDialog.FilterIndex = 1;
                        saveFileDialog.RestoreDirectory = true;
                        saveFileDialog.FileName = "geometric_calculations";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.AppendAllText(saveFileDialog.FileName, content + Environment.NewLine + Environment.NewLine);
                            MessageBox.Show($"Результаты успешно сохранены в файл! Файл сохранен:\n{saveFileDialog.FileName}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
