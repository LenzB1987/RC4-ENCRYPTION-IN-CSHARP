using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace RC4_ENCRYPTION_IN_CSHARP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string RC4(string password, string unlockkey)
        {
            StringBuilder result = new StringBuilder();
            int x, y, j = 0;
            int[] encryptor = new int[256];
            for (int i = 0; i < 256; i++)
                encryptor[i] = i;
            for (int i = 0; i < 256; i++)
            {
                j = (unlockkey[i % unlockkey.Length] + encryptor[i] + j) % 256;
                x = encryptor[i];
                encryptor[i] = encryptor[j];
                encryptor[j] = x;
            }
            for (int i = 0; i < password.Length; i++)
            {
                y = i % 256;
                j = (encryptor[y] + j) % 256;
                x = encryptor[y];
                encryptor[y] = encryptor[j];
                encryptor[j] = x;
                result.Append((char)(password[i] ^ encryptor[(encryptor[y] + encryptor[j]) % 256]));
            }
            return result.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = RC4(textBox1.Text, "1234567890abcdefghijklmnopqrstuvwxyz");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = RC4(textBox2.Text, "1234567890abcdefghijklmnopqrstuvwxyz");
        }
    }
}
