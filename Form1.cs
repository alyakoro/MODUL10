using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПР10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nomer, data_start, data_end, summ;

            nakladna nak = new nakladna();
            summ = "";
            nomer = textBox1.Text;
            data_start = monthCalendar1.SelectionStart.ToLongDateString();
            data_end = monthCalendar1.SelectionEnd.ToLongDateString();


            if (radioButton1.Checked) summ = radioButton1.Text;
            else if (radioButton2.Checked) summ = radioButton2.Text;
            else if (radioButton3.Checked) summ = radioButton3.Text;
     
            nak.Data(nomer,
                     data_start,
                     data_end,
                     summ);
            nak.Info();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0')&&(e.KeyChar <= '9')) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }
    }
    class nakladna
    {
        public string nom = "???"; //Номер сотрудника
        public string data_start; //Дата начала отпуска
        public string data_end; //Дата конца отпуска
        public string summ = "???";//Сумма зарплаты

        //Проверка значений и вывод ошибок
        public void Data(string nom, string data_start, string data_end, string summ)
        {
            if (nom != "") this.nom = nom;
            else MessageBox.Show("Введите номер сотрудника!","Ошибка");
            if ((data_start != "")||(data_end != ""))
            {
                this.data_start = data_start; this.data_end = data_end;
            }
            else MessageBox.Show("Введите дату!", "Ошибка");
            if (summ != "") this.summ = summ;
            else MessageBox.Show("Выберите зарплату!", "Ошибка");
        }

        public void Info()
        {
            string caption = "Информация о накладной";
            string message = "";
            message = "Сотрудник номер: " + nom + "\nБерет отпуск с: " + data_start +
                " по: " + data_end + "\nC зарплатой: " + summ + " руб / месяц";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message,caption, buttons);
        }
    }
}
