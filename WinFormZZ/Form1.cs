using MyLib;
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

        /*private string GetFigureParameters()
        {
            switch (currentFigure)
            {
                case Circle circle:
                    return $"Радиус: {circle.Radius}";
                case RectangleZ rect:
                    return $"Ширина: {rect.Width}, Высота: {rect.Height}";
                case Triangle1X triangle:
                    return $"Стороны: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}";
                case Square square:
                    return $"Сторона: {square.Side}";
                default:
                    return "Неизвестные параметры";
            }
        }*/

        private void cmbFigureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Показываем/скрываем TextBox'ы в зависимости от выбранной фигуры
            lblParam1.Text = "Радиус:";
            txtParam1.Visible = true;
            txtParam2.Visible = false;
            txtParam3.Visible = false;
            lblParam2.Visible = false;
            lblParam3.Visible = false;

            switch (cmbFigureType.SelectedItem.ToString())
            {
                case "Круг":
                    lblParam1.Text = "Радиус:";
                    txtParam1.Clear();
                    break;
                case "Прямоугольник":
                    lblParam1.Text = "Ширина:";
                    lblParam2.Text = "Высота:";
                    txtParam2.Visible = true;
                    txtParam1.Clear();
                    txtParam2.Clear();
                    lblParam2.Visible = true;
                    break;
                case "Треугольник":

                    lblParam1.Text = "Сторона A:";
                    lblParam2.Text = "Сторона B:";
                    lblParam3.Text = "Сторона C:";
                    txtParam2.Visible = true;
                    txtParam1.Clear();
                    txtParam2.Clear();
                    txtParam3.Clear();
                    txtParam3.Visible = true;
                    lblParam2.Visible = true;
                    lblParam3.Visible = true;
                    break;
                case "Квадрат":
                    lblParam1.Text = "Сторона:";
                    txtParam1.Clear();
                    break;
            }

        }
        private GeometricFigure CreateFigure()
        {
            double p1, p2 = 0, p3 = 0;
            if (!double.TryParse(txtParam1.Text, out p1) || p1 <= 0)
                throw new ArgumentException("Некорректное значение параметра 1");

            switch (cmbFigureType.SelectedItem.ToString())
            {
                case "Круг":
                    return new Circle(p1);
                case "Прямоугольник":
                    if (!double.TryParse(txtParam2.Text, out p2) || p2 <= 0)
                        throw new ArgumentException("Некорректное значение параметра 2");
                    return new RectangleZ(p1, p2);
                case "Треугольник":
                    if (!double.TryParse(txtParam2.Text, out p2) || p2 <= 0)
                        throw new ArgumentException("Некорректное значение параметра 2");
                    if (!double.TryParse(txtParam3.Text, out p3) || p3 <= 0)
                        throw new ArgumentException("Некорректное значение параметра 3");
                    // Проверка на существование треугольника
                    if (p1 + p2 <= p3 || p1 + p3 <= p2 || p2 + p3 <= p1)
                        throw new ArgumentException("Треугольник с такими сторонами не существует");
                    return new Triangle1X(p1, p2, p3);
                case "Квадрат":
                    return new Square(p1);
                default:
                    throw new ArgumentException("Неизвестный тип фигуры");
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                currentFigure = CreateFigure();
                double area = currentFigure.CalculateArea();
                double perimeter = currentFigure.CalculatePerimeter();
                string formulaArea = "";
                string formulaPerimeter = "";

                switch (cmbFigureType.SelectedItem.ToString())
                {
                    case "Круг":
                        formulaArea = $"Площадь круга = π * r^2\nПлощадь круга = π * {txtParam1.Text}^2 = {area:F2}";
                        formulaPerimeter = $"Периметр круга = 2 * π * r\nПериметр круга = 2 * π * {txtParam1.Text} = {perimeter:F2}";
                        break;
                    case "Прямоугольник":
                        formulaArea = $"Площадь прямоугольника = ширина * высота\nПлощадь прямоугольника = {txtParam1.Text} * {txtParam2.Text} = {area:F2}";
                        formulaPerimeter = $"Периметр прямоугольника = 2 * (ширина + высота)\nПериметр прямоугольника = 2 * ({txtParam1.Text} + {txtParam2.Text}) = {perimeter:F2}";
                        break;

                    case "Треугольник":

                        double a = double.Parse(txtParam1.Text);
                        double b = double.Parse(txtParam2.Text);
                        double c = double.Parse(txtParam3.Text);
                        double p = (a + b + c) / 2.0;

                        formulaArea += $"Площадь треугольника (по формуле Герона) = √(p * (p - a) * (p - b) * (p - c))\nПолупериметр p = ({txtParam1.Text} + {txtParam2.Text} + {txtParam3.Text}) / 2 = {p:F2}\n" +
                            $"Площадь треугольника = √({p:F2} * ({p:F2} - {txtParam1.Text}) * ({p:F2} - {txtParam2.Text}) * ({p:F2} - {txtParam3.Text})) = {area:F2}"; 
                        formulaPerimeter = $"Периметр треугольника = a + b + c\nПериметр треугольника = {txtParam1.Text} + {txtParam2.Text} + {txtParam3.Text} = {perimeter:F2}";
                        break;
                    case "Квадрат":
                        formulaArea = $"Площадь квадрата = сторона^2\nПлощадь квадрата = {txtParam1.Text}^2 = {area:F2}";
                        formulaPerimeter = $"Периметр квадрата = 4 * сторона\nПериметр квадрата = 4 * {txtParam1.Text} = {perimeter:F2}";
                        break;
                    default:
                        formulaArea = "Площадь не может быть вычислена.";
                        formulaPerimeter = "Периметр не может быть вычислен.";
                        break;
                }

                rtxtArea.Text = formulaArea;
                rtxtPerimeter.Text = formulaPerimeter;
                
                

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
    }
    }
