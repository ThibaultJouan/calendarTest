using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CalendarTest
{
    public partial class Form1 : Form
    {
        private static readonly string adresseDossier = @"C:\Users\Thibault\Desktop\CalendarTest\Data\";
        private static string pwd = String.Empty;
        private static byte[] salt = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Editer
            string date = calendrier.SelectionRange.Start.ToString("yyyy-MM-dd");
            richTextBox1.Text = String.Empty;

            if (File.Exists(adresseDossier + date))
            {
                string buffer = File.ReadAllText(adresseDossier + date);
                string[] buffToPlain = buffer.Split(' ');
                List<byte> toPlain = new List<byte>();
                foreach (string s in buffToPlain)
                {
                    if (!String.IsNullOrEmpty(s))
                    {
                        toPlain.Add(byte.Parse(s));
                    }
                }

                byte[] toUncipher = toPlain.ToArray();

                string result = String.Empty;
                if (null != CipherTools.Decrypt(toUncipher, pwd, salt))
                {
                    result = Encoding.Unicode.GetString(CipherTools.Decrypt(toUncipher, pwd, salt));
                }
                else
                {
                    result = "Il semblerait qu'il faille utiliser le bon mot de passe ;)";
                }

                richTextBox1.Text = result;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Supprimer
            string date = calendrier.SelectionRange.Start.ToString("yyyy-MM-dd");
            richTextBox1.Text = String.Empty;
            if (!String.IsNullOrEmpty(pwd))
            {
                if (File.Exists(adresseDossier + date))
                {
                    File.Delete(adresseDossier + date);
                }
            }
        }

        private void buttonNouveau_Click(object sender, EventArgs e)
        {
            //Creer
            string date = calendrier.SelectionRange.Start.ToString("yyyy-MM-dd");
            if (!String.IsNullOrEmpty(pwd))
            {
                if (!File.Exists(adresseDossier + date))
                {
                    File.Create(adresseDossier + date).Close();
                    if (richTextBox1.Text.Length > 0)
                    {
                        //File.AppendAllText(adresseDossier + date, richTextBox1.Text);
                        byte[] cipher = CipherTools.Encrypt(Encoding.Unicode.GetBytes(richTextBox1.Text), pwd, salt);
                        string result = String.Empty;
                        foreach (byte c in cipher)
                        {
                            result += c.ToString() + " ";
                        }
                        File.AppendAllText(adresseDossier + date, result);
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Enregistrer les modifs
            string date = calendrier.SelectionRange.Start.ToString("yyyy-MM-dd");

            if (File.Exists(adresseDossier + date))
            {
                //File.WriteAllText(adresseDossier + date, richTextBox1.Text);
                byte[] cipher = CipherTools.Encrypt(Encoding.Unicode.GetBytes(richTextBox1.Text), pwd, salt);
                string result = String.Empty;
                foreach (byte c in cipher)
                {
                    result += c.ToString() + " ";
                }
                File.WriteAllText(adresseDossier + date, result);
            }

        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            //Déverrouiller
            if (String.IsNullOrEmpty(textPassword.Text))
            {
                File.AppendAllText(@"test.txt", "data");
                return;
            }

            string password = textPassword.Text;
            byte[] salty = Encoding.Unicode.GetBytes(password);
            
            string buffer = File.ReadAllText(adresseDossier + @"\keycipher");
            string[] buffToPlain = buffer.Split(' ');
            List<byte> toPlain = new List<byte>();
            foreach (string s in buffToPlain)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    toPlain.Add(byte.Parse(s));
                }
            }

            byte[] toUncipher = toPlain.ToArray();

            string result = String.Empty;
            if (null != CipherTools.Decrypt(toUncipher, password, salty))
            {
                pwd = Encoding.Unicode.GetString(CipherTools.Decrypt(toUncipher, password, salty));
                salt = Encoding.Unicode.GetBytes(pwd);
            }
            else
            {
                richTextBox1.Text = "Il semblerait qu'il faille utiliser le bon mot de passe ;)";
            }
            
            //richTextBox1.Text = result;
            //CipherTools.GenerateKey(@"d:\LocalData\i021473\Desktop\Calendrier\key", password, salty);
        }

        private void calendrier_DateChanged(object sender, DateRangeEventArgs e)
        {
            string date = calendrier.SelectionRange.Start.ToString("yyyy-MM-dd");
            if (!String.IsNullOrEmpty(pwd))
            {
                richTextBox1.Text = String.Empty;

                if (File.Exists(adresseDossier + date))
                {
                    string buffer = File.ReadAllText(adresseDossier + date);
                    string[] buffToPlain = buffer.Split(' ');
                    List<byte> toPlain = new List<byte>();
                    foreach (string s in buffToPlain)
                    {
                        if (!String.IsNullOrEmpty(s))
                        {
                            toPlain.Add(byte.Parse(s));
                        }
                    }

                    byte[] toUncipher = toPlain.ToArray();

                    string result = String.Empty;
                    if (null != CipherTools.Decrypt(toUncipher, pwd, salt))
                    {
                        result = Encoding.Unicode.GetString(CipherTools.Decrypt(toUncipher, pwd, salt));
                    }
                    else
                    {
                        result = "Il semblerait qu'il faille utiliser le bon mot de passe ;)";
                    }

                    richTextBox1.Text = result;
                }
            }
        }
    }
}
