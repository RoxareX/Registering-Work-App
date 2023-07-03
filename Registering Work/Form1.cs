using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace NameListApp
{
    public class AddableValues
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string Workflow { get; set; }
        public int Id { get; set; }

    }
    public class listJson
    {
        public AddableValues All { get; set; }
    }
    public partial class Form1 : Form
    {
        private List<listJson> list;
        private Panel nameListPanel;
        //
        private Panel addNamePanel;
        //
        private TextBox nameTextBox;
        private TextBox addressTextBox;
        private TextBox phonenumberTextBox;
        private TextBox emailTextBox;
        private TextBox workflowTextBox;
        //
        private Button addButton;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Initialize the list of names
            list = new List<listJson>();
            var addableValues = new AddableValues
            {
                Name = "mark",
                Address = "home",
                Phonenumber = "123",
                Email = "mark",
                Workflow = "coding"
            };
            var listjson = new listJson
            {
                All = addableValues
            };

            list.Add(listjson);
            string jsonString = JsonSerializer.Serialize(addableValues);

            // Set up the main form
            Size = new Size(800, 600);

            // Set up the Name List panel
            nameListPanel = new Panel();
            nameListPanel.Dock = DockStyle.Fill;
            Controls.Add(nameListPanel);

            //
            // Set up the Add Name panel
            addNamePanel = new Panel();
            addNamePanel.Dock = DockStyle.Fill;
            addNamePanel.Visible = false;
            Controls.Add(addNamePanel);

            // Create the TextBox for entering parts
            nameTextBox = new TextBox();
            nameTextBox.Location = new Point(100, 50);
            nameTextBox.Size = new Size(200, 20);
            addNamePanel.Controls.Add(nameTextBox);
            // Create the TextBox for entering address
            addressTextBox = new TextBox();
            addressTextBox.Location = new Point(100, 100);
            addressTextBox.Size = new Size(200, 20);
            addNamePanel.Controls.Add(addressTextBox);
            // Create the TextBox for entering phonenumber
            phonenumberTextBox = new TextBox();
            phonenumberTextBox.Location = new Point(100, 150);
            phonenumberTextBox.Size = new Size(200, 20);
            addNamePanel.Controls.Add(phonenumberTextBox);
            // Create the TextBox for entering email
            emailTextBox = new TextBox();
            emailTextBox.Location = new Point(100, 200);
            emailTextBox.Size = new Size(200, 20);
            addNamePanel.Controls.Add(emailTextBox);
            // Create the TextBox for entering workflow
            workflowTextBox = new TextBox();
            workflowTextBox.Location = new Point(100, 250);
            workflowTextBox.Size = new Size(200, 20);
            addNamePanel.Controls.Add(workflowTextBox);
            //
            //

            // Create the Add button
            addButton = new Button();
            addButton.Text = "Add";
            addButton.Location = new Point(225, 300);
            addButton.Click += AddButton_Click;
            addNamePanel.Controls.Add(addButton);

            // Create the Back button
            Button backButton = new Button();
            backButton.Text = "Back";
            backButton.Location = new Point(100, 300);
            backButton.Click += BackButton_Click;
            addNamePanel.Controls.Add(backButton);

            // Populate the Name List panel with clickable labels
            int y = 50;
            foreach (var parts in list)
            {
                Label nameLabel = new Label();
                nameLabel.Text = parts.All.Name;
                nameLabel.Name = JsonSerializer.Serialize(parts.All);
                nameLabel.Location = new Point(100, y);
                nameLabel.ForeColor = Color.Blue;
                nameLabel.Cursor = Cursors.Hand;
                nameLabel.Click += NameLabel_Click;
                nameListPanel.Controls.Add(nameLabel);

                y += 30;
            }

            // Add a button to switch to the Add Name panel
            Button addNameButton = new Button();
            addNameButton.Text = "Add Name";
            addNameButton.Location = new Point(150, 200);
            addNameButton.Click += AddNameButton_Click;
            nameListPanel.Controls.Add(addNameButton);
        }

        private EventHandler SendRest(AddableValues rest)
        {
            var name = rest.Name;
            var address = rest.Address;
            var phonenumber = rest.Phonenumber;
            var email = rest.Email;
            var workflow = rest.Workflow;

            MessageBox.Show($"You clicked on {name}");
            throw new NotImplementedException();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            nameListPanel.Visible = true;
            addNamePanel.Visible = false;
            nameTextBox.Text = string.Empty;
            addressTextBox.Text = string.Empty;
            phonenumberTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            workflowTextBox.Text = string.Empty;
        }

        private void NameLabel_Click(object sender, EventArgs e)
        {
            Label nameLabel = (Label)sender;
            MessageBox.Show($"You clicked on {nameLabel.Name}");
        }
        

        private void AddNameButton_Click(object sender, EventArgs e)
        {
            nameListPanel.Visible = false;
            addNamePanel.Visible = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string newName = nameTextBox.Text;
            string newAddress = addressTextBox.Text;
            string newPhonenumber = phonenumberTextBox.Text;
            string newEmail = emailTextBox.Text;
            string newWorkflow = workflowTextBox.Text;
            if (!string.IsNullOrWhiteSpace(newName) ||
                !string.IsNullOrWhiteSpace(newAddress) ||
                !string.IsNullOrWhiteSpace(newPhonenumber) ||
                !string.IsNullOrWhiteSpace(newEmail) ||
                !string.IsNullOrWhiteSpace(newWorkflow))
            {
                var addableValues = new AddableValues
                {
                    Name = newName,
                    Address = newAddress,
                    Phonenumber = newPhonenumber,
                    Email = newEmail,
                    Workflow = newWorkflow
                };
                var listjson = new listJson
                {
                    All = addableValues
                };

                list.Add(listjson);
                Label nameLabel = new Label();
                nameLabel.Text = newName;
                nameLabel.Name = JsonSerializer.Serialize(listjson.All);
                nameLabel.Location = new Point(100, nameListPanel.Controls.Count * 30 + 50);
                nameLabel.ForeColor = Color.Blue;
                nameLabel.Cursor = Cursors.Hand;
                nameLabel.Click += NameLabel_Click;
                nameListPanel.Controls.Add(nameLabel);

                nameTextBox.Text = string.Empty;
                addressTextBox.Text = string.Empty;
                phonenumberTextBox.Text = string.Empty;
                emailTextBox.Text = string.Empty;
                workflowTextBox.Text = string.Empty;
                nameListPanel.Visible = true;
                addNamePanel.Visible = false;
            }
        }
    }
}
