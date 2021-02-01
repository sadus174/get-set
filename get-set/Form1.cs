using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace get_set
{
    public partial class Form1 : Form
    {
        //Счётчик количества экземпляров класса
        int i = 0;
        //Объявляем коллекции экземпляров классов
        List<Patient> pat;

        class Patient
        {
            //Поля класса
            public string fio;
            public string dr;
            public string palata;
            //Поле класса закрытом модификатором доступа
            private string data_vipis;
            //Свойство класса
            public string Data_Vipis
            {
                set
                {
                    if (value == "")
                    {
                        MessageBox.Show("Поле заполненно некоректно");
                    }
                    else
                    {
                        data_vipis = value;
                    }
                }
                get { return data_vipis; }
            }

            // Конструкторы класса, принимающие значения  переменных из TextBox
            public Patient(string fn, string ln, string a) { fio = fn; dr = ln; palata = a; data_vipis = "Неопределена"; }
            public Patient(string fn, string ln, string a, string dt_v) { fio = fn; dr = ln; palata = a; data_vipis = ""; data_vipis = dt_v; }

            //Метод класса для вывода информации в listbox
            public void GetInfo(ListBox listbox1)
            {
                listbox1.Items.Add($"ФИО: {fio} Дата рождения {dr} Палата {palata} Дата выписки {data_vipis}");
            }

            //Метод класса для выписки пациентов
            public void Vipis(string new_dt)
            {
                this.Data_Vipis = new_dt;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        //Добавление пациента
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //Используя конструктор, вводим данные из textbox в поля экземплярра класса         
            pat.Add(new Patient(textBox1.Text, textBox2.Text, textBox3.Text));
            //Метод вывода добавленного экземпляра класса в ListBox
            pat[i].GetInfo(listBox1);
            //Увеличиваем счётчик на единицу, что бы использовать данную переменную как индекс массива экземпляра классов.
            i++;
        }

        //Обычный метод вывода всех экземпляров класса
        public void GetAllList(ListBox listBox1)
        {
            listBox1.Items.Clear();

            for (int p = 0; p < pat.Count; p++)
            {
                pat[p].GetInfo(listBox1);
            }
        }

        //Вывод списка
        private void button2_Click(object sender, EventArgs e)
        {
            GetAllList(listBox1);
        }

        //Выписка пациентов
        private void button3_Click(object sender, EventArgs e)
        {
            //Jпределяем индекс строки выделенного элемента
            int id_select = listBox1.SelectedIndex;
            //Выводим его
            toolStripStatusLabel1.Text  = $"Индекс выделенной строки: {id_select}";
            //Вызываем метод класса, который меняет поле "Дата выписки" подставляя в него значение из текстбокса
            pat[id_select].Vipis(textBox4.Text);
            //Очищаем листбокс
            listBox1.Items.Clear();
            //Вызываем метод его заполнения
            GetAllList(listBox1);
        }

        //Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            //Инициализируем коллекцию экземпляров класса
            pat = new List<Patient>();
            // Получаем количество слов и букв за слово.
            int num_letters = 7;
            // Создаем массив букв, которые мы будем использовать.
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            // Создаем генератор случайных чисел.
            Random rand = new Random();
            for (int y = 0; y <= rand.Next(7, 15); y++)
            {
                // Сделайте ФИО.
                string word = "";
                for (int j = 1; j <= num_letters; j++)
                {
                    // Выбор случайного числа от 0 до 25
                    // для выбора буквы из массива букв.
                    int letter_num = rand.Next(0, letters.Length - 1);
                    // Добавить письмо.
                    word += letters[letter_num];
                }
                // Сделайте ДР.
                string word1 = "";
                for (int j = 1; j <= num_letters; j++)
                {
                    // Выбор случайного числа от 0 до 25
                    // для выбора буквы из массива букв.
                    int letter_num = rand.Next(0, letters.Length - 1);
                    // Добавить письмо.
                    word1 += letters[letter_num];
                }
                // Сделайте палату.
                string word2 = rand.Next(10, 99).ToString();
                for (int j = 1; j <= 1; j++)
                {
                    // Выбор случайного числа от 0 до 25
                    // для выбора буквы из массива букв.
                    int letter_num = rand.Next(0, letters.Length - 1);
                    // Добавить письмо.
                    word2 += letters[letter_num];
                }
                //Используя конструктор, вводим данные из textbox в поля экземплярра класса         
                pat.Add(new Patient(word, word1, word2));
                //Метод вывода добавленного экземпляра класса в ListBox
                pat[i].GetInfo(listBox1);
                //Увеличиваем счётчик на единицу, что бы использовать данную переменную как индекс массива экземпляра классов.
                i++;
            }
        }
    }
}
