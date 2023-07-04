using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using NameListApp;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Registering_Work
{
    public partial class Form2 : Form
    {
        public string formName;
        private AddableValues All;
        public AddableValues Data { get; set; }
        public delegate void MyFunctionDelegate();
        public MyFunctionDelegate CallMyFunction;
        public Action<AddableValues> CallMyActionFunction { get; set; }

        public Form2(string labelText)
        {
            InitializeComponent();
            All = JsonSerializer.Deserialize<AddableValues>(labelText);

            textBox1.Text = All.Name;
            textBox2.Text = All.Address;
            textBox3.Text = All.Phonenumber;
            textBox4.Text = All.Email;
            textBox5.Text = All.Workflow;
        }
        private void CallMyFunctionFromForm2(AddableValues Data)
        {
            if (CallMyFunction != null)
            {
                CallMyFunction.Invoke();
            }
            if (CallMyActionFunction != null)
            {
                CallMyActionFunction.Invoke(Data);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            All.Name = textBox1.Text;
            All.Address = textBox2.Text;
            All.Phonenumber = textBox3.Text;
            All.Email = textBox4.Text;
            All.Workflow = textBox5.Text;
            Data = All; // Assign the data to the Data property
            CallMyFunctionFromForm2(Data);
            this.Close(); // Close Form2
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
