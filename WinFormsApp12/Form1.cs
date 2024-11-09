using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.Serialization.Json;
using System.Text;

namespace WinFormsApp12
{
    public partial class Form1 : Form
    {
        private List<User> users = new List<User>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Text Files (*.txt) | *.txt | All Files (*.*) | *.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                ReadFile(filePath);
            }*/
        }
        /*private void ReadFile(string filePath)
        {
            long fileSize = new FileInfo(filePath).Length;
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fs))
            {
                char[] buffer = new char[1024];
                int bytesRead;
                long totalRead = 0;

                while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    totalRead += bytesRead;
                    int progressPercentage = (int)(totalRead * 100 / fileSize);
                    progressBar1.Value = Math.Min(progressPercentage, 100);

                    Application.DoEvents();
                }
            }
        }*/
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public override string ToString()
            {
                return $"{FirstName} {LastName}, {Email}, {Phone}";
            }
        }
        private void UpdateListBox()
        {
            lstUsers.Items.Clear();
            foreach (var user in users)
            {
                lstUsers.Items.Add(user);
            }
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            User newUser = new User { FirstName = firstName, LastName = lastName, Email = email, Phone = phone };
            users.Add(newUser);
            UpdateListBox();
        }
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItem != null)
            {
                User selectedUser = (User)lstUsers.SelectedItem;
                txtFirstName.Text = selectedUser.FirstName;
                txtLastName.Text = selectedUser.LastName;
                txtEmail.Text = selectedUser.Email;
                txtPhone.Text = selectedUser.Phone;
                users.Remove(selectedUser);
                UpdateListBox();
            }
        }
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItem != null)
            {
                User selectedUser = (User)lstUsers.SelectedItem;
                users.Remove(selectedUser);
                UpdateListBox();
            }
        }
        private void btnExport_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> lines = new List<string>();
                foreach (var user in users)
                {
                    lines.Add($"{user.FirstName}, {user.LastName}, {user.Email}, {user.Phone}");
                }
                File.WriteAllLines(saveFileDialog.FileName, lines);
            }
        }
        private void btnImport_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                users.Clear();
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        User user = new User
                        {
                            FirstName = parts[0].Trim(),
                            LastName = parts[1].Trim(),
                            Email = parts[2].Trim(),
                            Phone = parts[3].Trim()
                        };
                        users.Add(user);
                    }
                }
                UpdateListBox();
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = File.ReadAllText(openFileDialog.FileName);
                    this.Text = openFileDialog.FileName;
                }
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, textBox1.Text);
                    this.Text = saveFileDialog.FileName;
                }
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            this.Text = "Untitled";
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Font = fontDialog.Font;
                }
            }
        }
        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.ForeColor = colorDialog.Color;
                }
            }
        }
        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.BackColor = colorDialog.Color;
                }
            }
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Show();
        }
    }
}
