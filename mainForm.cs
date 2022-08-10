using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using Math.Gmp.Native;

namespace SignatureRSA
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void setupRSAButton_Click(object sender, EventArgs e)
        {
            #region Генерация ключей

            if (pPrimeTextBox.Text.Length != 0 || qPrimeTextBox.Text.Length != 0)
            {
                var regex = new Regex(@"^[1-9]+\d{0,}$"); // Задаем регулярное выражение для проверки введенного текста
                if (regex.IsMatch(pPrimeTextBox.Text) && regex.IsMatch(qPrimeTextBox.Text))
                {
                    string strA = pPrimeTextBox.Text;
                    string strB = qPrimeTextBox.Text;

                    if (!string.Equals(strA, strB))
                    {
                        var result = RSA.GenerateKeys(pPrimeTextBox.Text, qPrimeTextBox.Text); // Генерируем открытый и секретный ключ с параметрами
                        if (result.Item1)
                            MessageBox.Show(result.Item2, "Успешная генерация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            MessageBox.Show(result.Item2, "Параметры шифра не установлены", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    } // Если числа введенные пользователем не совпадают => выполняем шифрование
                    else
                    {
                        MessageBox.Show("Введите различные простые числа!", "Параметры шифра не установлены", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } // Пользователь ввел одинаковые числа
                }
                else
                {
                    MessageBox.Show("P и Q введены некорреткно! Повторите ввод!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                var result = RSA.GenerateKeys(); // Генерируем открытый и секретный ключ без параметров
                MessageBox.Show(result, "Успешная генерация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            #endregion

            // Вывод информации о шифре на экран
            var cipherParameters = RSA.GetCipherParameters(); // Получаем параметры шифра
            pPrimeTextBox.Text = cipherParameters.Item1;
            qPrimeTextBox.Text = cipherParameters.Item2;
            moduloTextBox.Text = cipherParameters.Item3;
            publicKeyTextBox.Text = cipherParameters.Item4;
            privateKeyTextBox.Text = cipherParameters.Item5;

            // Включаем элементы управления, которые должны применяться далее
            resetRSAButton.Enabled = true;
            messageRadioButton.Enabled = true;
            fileRadioButton.Enabled = true;

            // Отключаем элементы управления, которые не должны применяться далее
            setupRSAButton.Enabled = false;
            pPrimeTextBox.ReadOnly = true;
            qPrimeTextBox.ReadOnly = true;

        } // Настройка параметров шифра RSA

        private void resetRSAButton_Click(object sender, EventArgs e)
        {
            //Сбрасываем параметры шифрования
            RSA.RSAReset();

            // Чистим MessageBox'ы
            pPrimeTextBox.Clear();
            qPrimeTextBox.Clear();
            moduloTextBox.Clear();
            publicKeyTextBox.Clear();
            privateKeyTextBox.Clear();
            inputTextBox.Clear();
            aliceHashTextBox.Clear();
            encodedHashTextBox.Clear();
            bobHashTextBox.Clear();
            decodedHashTextBox.Clear();
            hashsCheckTextBox.Clear();
            filePathTextBox.Clear();

            // Включаем элементы управления, которые применяются в этом режиме
            setupRSAButton.Enabled = true;
            pPrimeTextBox.ReadOnly = false;
            qPrimeTextBox.ReadOnly = false;
            inputTextBox.ReadOnly = false;

            // Отключаем элементы управления, которые не применяются в этом режиме
            inputTextBox.Enabled = false;
            aliceHashTextBox.Enabled = false;
            encodedHashTextBox.Enabled = false;
            bobHashTextBox.Enabled = false;
            decodedHashTextBox.Enabled = false;
            startButton.Enabled = false;
            checkButton.Enabled = false;
            resetRSAButton.Enabled = false;
            messageRadioButton.Enabled = false;
            fileRadioButton.Enabled = false;
            selectFileButton.Enabled = false;
            clearFilePathButton.Enabled = false;

            MessageBox.Show("Параметры шифра были успешно сброшены!", "Сброс параметров шифра", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } // Сброс параметров шифра RSA

        private void startButton_Click(object sender, EventArgs e)
        {
            // Вычисляем хэш для исходного сообщения

            if (messageRadioButton.Checked)
            {
                byte[] data = Encoding.UTF8.GetBytes(inputTextBox.Text);
                MessageWorker.CalculateHash(data, true, data.Length);
            } // Работа с текстом

            if (fileRadioButton.Checked)
            {
                if (filePathTextBox.Text.Length != 0)
                {
                    bool lastBlock = false; // Фиксируем является ли блок последним

                    var fileParameters = FileWorker.GetFileParameters(); // Получаем параметры файла, с которым работаем

                    FileInfo fileInfo = new FileInfo(fileParameters.Item1);
                    long fileLength = fileInfo.Length;

                    var infile = File.OpenRead(fileParameters.Item1); // Открываем файл для чтения

                    while (true)
                    {
                        var data = FileWorker.ReadFile(infile); // Считываем блок данных из файла (100 КБ)

                        // Фиксируем, что это последние 100 КБ или меньше
                        if (!data.Item1)
                            lastBlock = true; // Фиксируем, что блок является последним => нужен падинг

                        MessageWorker.CalculateHash(data.Item2, lastBlock, fileLength);

                        if (!data.Item1)
                        {
                            infile.Close(); // Закрываем файл, т.к. он прочитан
                            break; // В случае, когда весь файл прочитан
                        }
                    }

                } // Если пользователь выбрал файл, то выполняем хэширование
                else
                {
                    MessageBox.Show("Выберите файл для вычисления хэша!", "Файл не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } // Если пользователь не выбрал файл
            } // Работа с документом

            string hash = SHA.GetResultHash();
            aliceHashTextBox.Text = hash; // Выводим хэш на экран

            // Выполняем шифрование хэша
            string resultMessage = "";
            List<byte> byteArrayHexs = new List<byte>(); // Создаем список для хранения данных хэша в виде байтов
            string[] hexs = hash.Split(' '); // Получаем отдельные части хэша в 16-разрядном видем
            foreach (string hex in hexs)
            {
                byte[] bytes = new byte[4];
                long value = Convert.ToInt64(hex, 16); // Переводим hex значение в десятичный
                string str = Convert.ToString(value, 2).PadLeft(32, '0'); // Переводим в строку в двоичном виде (32 бит)

                for (int i = 0; i < str.Length / 8; i++)
                {
                    string buffer = "";
                    for (int j = i * 8; j < i * 8 + 8; j++)
                        buffer += str[j];

                    bytes[i] = Convert.ToByte(buffer, 2);
                } // Получаем hex значение в виде массива байт

                foreach (byte b in bytes)
                    byteArrayHexs.Add(b); // Добавляем каждый байт хэша в список
            } // Получаем части хэша в виде массивов байт

            byte[] content = byteArrayHexs.ToArray(); // Получаем хэш в виде массива байт
            byteArrayHexs.Clear();

            List<mpz_t> encryptedMessage = MessageWorker.EncryptMessage(content); // Шифруем части сообщения
            foreach (mpz_t part in encryptedMessage)
                resultMessage += part.ToString() + " "; // Формируем шифр
            resultMessage = resultMessage.Substring(0, resultMessage.Length - 1); // Убираем последний символ

            encodedHashTextBox.Text = resultMessage; // Выводим шифр на экран

            // Включаем элементы управления, которые должны применяться далее
            checkButton.Enabled = true;
            aliceHashTextBox.Enabled = true;
            encodedHashTextBox.Enabled = true;

            // Отключаем элементы управления, которые не должны применяться далее
            startButton.Enabled = false;
            inputTextBox.ReadOnly = true;
            filePathTextBox.Enabled = false;
            selectFileButton.Enabled = false;
            clearFilePathButton.Enabled = false;
            messageRadioButton.Enabled = false;
            fileRadioButton.Enabled = false;

        } // Постановка ЭП

        private void checkButton_Click(object sender, EventArgs e)
        {
            // Вычисляем хэш для исходного сообщения

            if (messageRadioButton.Checked)
            {
                byte[] data = Encoding.UTF8.GetBytes(inputTextBox.Text);
                MessageWorker.CalculateHash(data, true, data.Length);
            } // Работа с текстом

            if (fileRadioButton.Checked)
            {
                if (filePathTextBox.Text.Length != 0)
                {
                    bool lastBlock = false; // Фиксируем является ли блок последним

                    var fileParameters = FileWorker.GetFileParameters(); // Получаем параметры файла, с которым работаем

                    FileInfo fileInfo = new FileInfo(fileParameters.Item1);
                    long fileLength = fileInfo.Length;

                    var infile = File.OpenRead(fileParameters.Item1); // Открываем файл для чтения

                    while (true)
                    {
                        var data = FileWorker.ReadFile(infile); // Считываем блок данных из файла (100 КБ)

                        // Фиксируем, что это последние 100 КБ или меньше
                        if (!data.Item1)
                            lastBlock = true; // Фиксируем, что блок является последним => нужен падинг

                        MessageWorker.CalculateHash(data.Item2, lastBlock, fileLength);

                        if (!data.Item1)
                        {
                            infile.Close(); // Закрываем файл, т.к. он прочитан
                            break; // В случае, когда весь файл прочитан
                        }
                    }

                } // Если пользователь выбрал файл, то выполняем хэширование
                else
                {
                    MessageBox.Show("Выберите файл для вычисления хэша!", "Файл не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } // Если пользователь не выбрал файл
            } // Работа с документом

            bobHashTextBox.Text = SHA.GetResultHash();// Выводим хэш на экран

            // Выполняем расшифровку хэша, полученного от Алисы
            string[] symbols = encodedHashTextBox.Text.Split(' '); // Считываем шифр из текстбокса
            List<mpz_t> symbolsForDecoding = new List<mpz_t>();
            foreach (string symb in symbols)
                if (symb.Length != 0)
                    symbolsForDecoding.Add(symb); // Формируем список символов для расшифрования

            var content = MessageWorker.DecryptMessage(symbolsForDecoding); // Получаем байты расшифрованного хэша
            string resultStr = ""; // Строка для получения расшифрованного хэша

            for (int i = 0; i < content.Length / 4; i++)
            {
                byte[] buffer = new byte[4];

                for (int j = 0; j < buffer.Length; j++)
                    buffer[j] = content[i * 4 + j];

                string bitString = "";
                foreach (byte b in buffer)
                    bitString += Convert.ToString(b, 2).PadLeft(8, '0'); // Конвертируем массив байт в битовую строку

                long value = Convert.ToInt64(bitString, 2); // Переводим битовую строку в десятичное число
                resultStr += Convert.ToString(value, 16) + " "; // Переводим десятичное число в HEX запись
            }

            resultStr = resultStr.Substring(0, resultStr.Length - 1); // Убираем последний символ
            decodedHashTextBox.Text = resultStr; // Выводим расшифрованный хэш на экран

            // Проверяем совпадение хэшей
            hashsCheckTextBox.Text = string.Equals(bobHashTextBox.Text, decodedHashTextBox.Text).ToString();

            // Включаем элементы управления, которые должны применяться далее
            bobHashTextBox.Enabled = true;
            decodedHashTextBox.Enabled = true;

            // Отключаем элементы управления, которые не должны применяться далее
            checkButton.Enabled = false;

        } // Проверка ЭП

        private void messageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (messageRadioButton.Checked)
            {
                // Включаем элементы управления, которые применяются в этом режиме
                inputTextBox.Enabled = true;
                startButton.Enabled = true;

                // Отключаем элементы управления, которые не применяются в этом режиме
                filePathTextBox.Enabled = false;
                selectFileButton.Enabled = false;
                clearFilePathButton.Enabled = false;
            }
        } // Программа переходит в режим работы с сообщениями

        private void fileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fileRadioButton.Checked)
            {
                // Включаем элементы управления, которые применяются в этом режиме
                filePathTextBox.Enabled = true;
                selectFileButton.Enabled = true;
                clearFilePathButton.Enabled = true;
                startButton.Enabled = true;

                // Отключаем элементы управления, которые не применяются в этом режиме
                inputTextBox.Enabled = false;
            }
        } // Программа переходит в режим работы с документами

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "All files(*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return; // Если была нажата отмена, то ничего не происходит

            // Получаем путь до выбранного файла и его короткое имя
            FileWorker.SetFileParameters(openFileDialog.FileName, openFileDialog.SafeFileName);
            filePathTextBox.Text = FileWorker.GetFileParameters().Item1;

        } // Выбор файла для вычисления хэша

        private void clearFilePathButton_Click(object sender, EventArgs e)
        {
            filePathTextBox.Clear();
            FileWorker.SetFileParameters("", "");
        } // Отмена выбора файла
    }
}
