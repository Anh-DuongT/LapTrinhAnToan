using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_2
{
    public partial class Form1 : Form
    {
        public byte[] bobPublicKey;
        public byte[] bobKey;
        public string dt = DateTime.Now.ToString();
        int sec = 0;
        AES256 aes = new AES256();
        Socket client;
        EndPoint ep;
        SHA256 sha = new SHA256();
        byte[] nhanLength, nhanPublicKey, nhanSKey, secretKey02;
        

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public byte[] generatePublicKey()
        {
            //bobPublicKey = new byte[1024];
            using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
            {
                //byte[] bobPublicKey;
                bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                bob.HashAlgorithm = CngAlgorithm.Sha256;
                bobPublicKey = bob.PublicKey.ToByteArray();
                byte[] a = bobPublicKey;
                return a;
            }
            //return bobPublicKey;
        }
        public byte[] secretKey(byte[] alicePublicKey)
        {
            bobKey = new byte[1024];
            using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
            {
                CngKey k = CngKey.Import(alicePublicKey, CngKeyBlobFormat.EccPublicBlob);
                bobKey = bob.DeriveKeyMaterial(k);
                byte[] a = bobKey;
                return a;
            }
        }
        public string Encrypt(string rawString, string keyText, string iv)
        {
            string rawText = rawString;
            string key = keyText;
            string encryptedText = aes.Encrypt(rawText, key, dt);
            return encryptedText;
        }

        public string Decrypt(string textEncrypted, string Time)
        {
            string encryptedText = textEncrypted;
            string key = textBox1.Text;
            string decryptedText = aes.Decrypt(encryptedText, key, Time);
            return decryptedText;
        }
        private int paddingData()
        {
            string Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUniversalTime().ToString("yyyyMMddHHmmss");
            string HashTimeStamp = HashMd5(Timestamp);
            int byteLength = UTF8Encoding.UTF8.GetByteCount(txtNhap.Text);
            //int lengthNeed = 32 - byteLength;
            int i = 0;
            string tmpTime = string.Empty;
            if (byteLength % 16 != 0)
            {
                i = 1;
                int length = byteLength;
                while (length % 16 != 0)
                {
                    tmpTime = HashTimeStamp.Substring(0, i);
                    length = length + 1;
                    i++;
                }
            }
            txtPad.Text = txtNhap.Text + tmpTime;
            return i - 1;
        }
        public static byte[] EncryptData(string data)
        {
            MD5CryptoServiceProvider md5Hash = new MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encode = new System.Text.UTF8Encoding();
            hashedBytes = md5Hash.ComputeHash(encode.GetBytes(data));
            return hashedBytes;
        }
        public static string HashMd5(string data)
        {
            return BitConverter.ToString(EncryptData(data)).Replace("-", "").ToLower();
        }
        private string randomString32byte(int size)
        {
            //Hàm random cho key
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 122))); //Limit: chu thuong, chu hoa
                sb.Append(c);
            }
            return sb.ToString();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtNhap.Text == "") MessageBox.Show("Nhập tin nhắn!");
            else
            {
                //Encrypt nội dung
                dt = HashMd5(DateTime.Now.ToString());
                textBox1.Text = sha.SHA_256(Convert.ToBase64String(secretKey02));
                string _a = textBox1.Text;
                string valuePadding = paddingData().ToString();
                string encryptedText = Encrypt(txtPad.Text, _a, dt);
                string MD5encryptedText = HashMd5(encryptedText);
                txtEncryptedPad.Text = MD5encryptedText;
                string finalText = encryptedText + ";" + dt + ";" + MD5encryptedText + ";" + _a + ";" + valuePadding;
                txtReSult.Text = finalText;
                // gửi nội dung
                UdpClient sendData = new UdpClient();
                IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(txtIP.Text), int.Parse(txtRemotePort.Text));
                byte[] data = new byte[1024 * 24];
                data = Encoding.UTF8.GetBytes(txtReSult.Text);
                sendData.Send(data, data.Length, ipe);
                txtMessage.Invoke((MethodInvoker)delegate ()
                {
                    txtMessage.Text += "\nĐã gửi:" + txtNhap.Text;
                });
                txtNhap.Clear();
            }
        }
        void dataRecieve()
        {
            try
            {
                if (txtIP.Text == "" || txtRemotePort.Text == "" || txtLocalPort.Text == "")
                {
                    MessageBox.Show("nhap du lieu day du");
                }
                else
                {
                    UdpClient recieveData = new UdpClient(int.Parse(txtLocalPort.Text));
                    IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 0);
                    while (true)
                    {
                        //nhận dữ liệu
                        byte[] data = new byte[1024 * 24];
                        data = recieveData.Receive(ref ipe);
                        string s = Encoding.UTF8.GetString(data);
                        if (s.Trim().ToUpper().Equals("QUIT"))
                            break;
                        string[] arrString = s.Split(';');
                        string encryptedText = arrString[0];
                        string dt = arrString[1];
                        string md5Text = arrString[2];
                        string _a = arrString[3];
                        string paddingValue = arrString[4];
                        //so sánh 2 đoạn hash md5 và decrypt message
                        string hashmd5Text = HashMd5(encryptedText);
                        if (md5Text == hashmd5Text)
                        {
                            txtEncryptText.Invoke((MethodInvoker)delegate ()
                            {
                                txtEncryptText.Text += "\nĐã nhận: " + s;
                            });
                            txtReSult.Text = s;
                            textBox1.Text = _a;
                            string rawText = Decrypt(encryptedText, dt);
                            txtMessage.Invoke((MethodInvoker)delegate ()
                            {
                                txtMessage.Text += "\nĐã nhận: " + rawText.Substring(0, rawText.Length - int.Parse(paddingValue));

                            });
                            
                        }
                        else
                        {
                            txtMessage.Invoke((MethodInvoker)delegate ()
                            {
                                txtMessage.Text += "\nĐã nhận: Nội dung đã bị thay đổi.";

                            });
                        }
                        txtPad.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnKetnoi_Click(object sender, EventArgs e)
        {
            txtIP.Text = "127.0.0.1";
            txtLocalPort.Text = "30";
            txtRemotePort.Text = "70";
            Thread thr = new Thread(new ThreadStart(dataRecieve));
            thr.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            ep = ipep;

            byte[] publicKey = generatePublicKey();
            int x = publicKey.Length;
            byte[] length = BitConverter.GetBytes(x);
            client.SendTo(length, ep);
            client.SendTo(publicKey, ep);

            txtAlicePubKey.Text = Convert.ToBase64String(publicKey);
            nhanLength = new byte[100];
            int recLength = client.ReceiveFrom(nhanLength, ref ep);

            int y = BitConverter.ToInt32(nhanLength, 0);
            nhanPublicKey = new byte[y];
            int recPublicKey = client.ReceiveFrom(nhanPublicKey, ref ep);

            byte[] a = nhanPublicKey;
            nhanSKey = new byte[1024];
            int recKey = client.ReceiveFrom(nhanSKey, ref ep);
            string nhanKey = Encoding.ASCII.GetString(nhanSKey, 0, recKey);
            int count = (Encoding.ASCII.GetByteCount(nhanKey));
            string publicKey01 = Encoding.ASCII.GetString(nhanPublicKey, 0, recPublicKey);
            int count1 = (Encoding.ASCII.GetByteCount(publicKey01));
            txtBobPubKey.Text = Convert.ToBase64String(nhanPublicKey, 0, count1);

            secretKey02 = secretKey(nhanPublicKey);
            txtKey.Text = Convert.ToBase64String(nhanSKey, 0, count);

            client.Close();
            btnSend.Enabled = true;
            btnSendNoise.Enabled = true;
            
        }

        
        private void btnSendNoise_Click(object sender, EventArgs e)
        {
            //Noise và encrypt message
            dt = HashMd5(DateTime.Now.ToString());
            textBox1.Text = sha.SHA_256(Convert.ToBase64String(secretKey02));
            string _a = textBox1.Text;
            string valuePadding = paddingData().ToString();
            string encryptedText = Encrypt(txtPad.Text, _a, dt);
            string a = encryptedText;
            int length = encryptedText.Length;
            Random r = new Random();
            int randomPos = r.Next(0, length + 1);
            string stringPos1 = a.Substring(0, randomPos);
            string stringPos2 = a.Substring(randomPos);
            string textChanged = stringPos1 + PhatSinhKyTuNgauNhien() + stringPos2;
            string MD5encryptedText = HashMd5(textChanged);
            txtEncryptedPad.Text = encryptedText;
            string finalText = encryptedText + ";" + dt + ";" + MD5encryptedText + ";" + _a + ";" + valuePadding;
            txtReSult.Text = finalText;
            // Gửi Message
            UdpClient sendData = new UdpClient();
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(txtIP.Text), int.Parse(txtRemotePort.Text));
            byte[] data = new byte[1024 * 24];
            data = Encoding.UTF8.GetBytes(txtReSult.Text);
            sendData.Send(data, data.Length, ipep);
            txtMessage.Invoke((MethodInvoker)delegate ()
            {
                txtMessage.Text += "\nĐã gửi:" + txtNhap.Text;
            });
            txtNhap.Clear();
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            sec = 0;
            KhoiTaoTimer();
            
        }

        private void txtNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSend_Click(sender, e);
        }

        public static string PhatSinhKyTuNgauNhien()
        {
            char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            Random r = new Random();
            int i = r.Next(chars.Length);
            return chars[i].ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            sec = sec + 1;
            if (sec == 10)
            {
                MessageBox.Show("Time Out. Please change another key !!!", "CLIENT-02");
                timer1.Stop();
                sec = 0;
                //button1_Click(sender,e);
                txtKey.Clear();
                txtReSult.Clear();
                txtNhap.Clear();
                txtPad.Clear();
                btnSend.Enabled = false;
                btnSendNoise.Enabled = false;

            }
        }
        public void KhoiTaoTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
        }

    }
}
