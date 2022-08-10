namespace SignatureRSA
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.resetRSAButton = new System.Windows.Forms.Button();
            this.setupRSAButton = new System.Windows.Forms.Button();
            this.parametersLabel = new System.Windows.Forms.Label();
            this.privateKeyLabel = new System.Windows.Forms.Label();
            this.privateKeyTextBox = new System.Windows.Forms.TextBox();
            this.publicKeyLabel = new System.Windows.Forms.Label();
            this.publicKeyTextBox = new System.Windows.Forms.TextBox();
            this.moduloLabel = new System.Windows.Forms.Label();
            this.moduloTextBox = new System.Windows.Forms.TextBox();
            this.qPrimeLabel = new System.Windows.Forms.Label();
            this.pPrimeLabel = new System.Windows.Forms.Label();
            this.qPrimeTextBox = new System.Windows.Forms.TextBox();
            this.pPrimeTextBox = new System.Windows.Forms.TextBox();
            this.signatureLabel = new System.Windows.Forms.Label();
            this.inputLabel = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.aliceLabel = new System.Windows.Forms.Label();
            this.bobLabel = new System.Windows.Forms.Label();
            this.aliceHashTextBox = new System.Windows.Forms.TextBox();
            this.aliceHashLabel = new System.Windows.Forms.Label();
            this.encodedHashLabel = new System.Windows.Forms.Label();
            this.encodedHashTextBox = new System.Windows.Forms.TextBox();
            this.bobHashLabel = new System.Windows.Forms.Label();
            this.bobHashTextBox = new System.Windows.Forms.TextBox();
            this.decodedHashLabel = new System.Windows.Forms.Label();
            this.decodedHashTextBox = new System.Windows.Forms.TextBox();
            this.checkButton = new System.Windows.Forms.Button();
            this.hashsCheckTextBox = new System.Windows.Forms.TextBox();
            this.hashsCheckLabel = new System.Windows.Forms.Label();
            this.fileRadioButton = new System.Windows.Forms.RadioButton();
            this.messageRadioButton = new System.Windows.Forms.RadioButton();
            this.clearFilePathButton = new System.Windows.Forms.Button();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.fileLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resetRSAButton
            // 
            this.resetRSAButton.Enabled = false;
            this.resetRSAButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetRSAButton.Location = new System.Drawing.Point(174, 115);
            this.resetRSAButton.Name = "resetRSAButton";
            this.resetRSAButton.Size = new System.Drawing.Size(122, 34);
            this.resetRSAButton.TabIndex = 42;
            this.resetRSAButton.Text = "Сбросить";
            this.resetRSAButton.UseVisualStyleBackColor = true;
            this.resetRSAButton.Click += new System.EventHandler(this.resetRSAButton_Click);
            // 
            // setupRSAButton
            // 
            this.setupRSAButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setupRSAButton.Location = new System.Drawing.Point(20, 115);
            this.setupRSAButton.Name = "setupRSAButton";
            this.setupRSAButton.Size = new System.Drawing.Size(122, 34);
            this.setupRSAButton.TabIndex = 41;
            this.setupRSAButton.Text = "Сгенерировать";
            this.setupRSAButton.UseVisualStyleBackColor = true;
            this.setupRSAButton.Click += new System.EventHandler(this.setupRSAButton_Click);
            // 
            // parametersLabel
            // 
            this.parametersLabel.AutoSize = true;
            this.parametersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parametersLabel.Location = new System.Drawing.Point(17, 9);
            this.parametersLabel.Name = "parametersLabel";
            this.parametersLabel.Size = new System.Drawing.Size(232, 18);
            this.parametersLabel.TabIndex = 40;
            this.parametersLabel.Text = "Параметры для шифра RSA:";
            // 
            // privateKeyLabel
            // 
            this.privateKeyLabel.AutoSize = true;
            this.privateKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.privateKeyLabel.Location = new System.Drawing.Point(453, 121);
            this.privateKeyLabel.Name = "privateKeyLabel";
            this.privateKeyLabel.Size = new System.Drawing.Size(145, 16);
            this.privateKeyLabel.TabIndex = 39;
            this.privateKeyLabel.Text = "Секретный ключ k:";
            // 
            // privateKeyTextBox
            // 
            this.privateKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.privateKeyTextBox.Location = new System.Drawing.Point(604, 115);
            this.privateKeyTextBox.Name = "privateKeyTextBox";
            this.privateKeyTextBox.ReadOnly = true;
            this.privateKeyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.privateKeyTextBox.Size = new System.Drawing.Size(258, 22);
            this.privateKeyTextBox.TabIndex = 38;
            // 
            // publicKeyLabel
            // 
            this.publicKeyLabel.AutoSize = true;
            this.publicKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publicKeyLabel.Location = new System.Drawing.Point(453, 81);
            this.publicKeyLabel.Name = "publicKeyLabel";
            this.publicKeyLabel.Size = new System.Drawing.Size(138, 16);
            this.publicKeyLabel.TabIndex = 37;
            this.publicKeyLabel.Text = "Открытый ключ K:";
            // 
            // publicKeyTextBox
            // 
            this.publicKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publicKeyTextBox.Location = new System.Drawing.Point(604, 78);
            this.publicKeyTextBox.Name = "publicKeyTextBox";
            this.publicKeyTextBox.ReadOnly = true;
            this.publicKeyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.publicKeyTextBox.Size = new System.Drawing.Size(258, 22);
            this.publicKeyTextBox.TabIndex = 36;
            // 
            // moduloLabel
            // 
            this.moduloLabel.AutoSize = true;
            this.moduloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moduloLabel.Location = new System.Drawing.Point(453, 43);
            this.moduloLabel.Name = "moduloLabel";
            this.moduloLabel.Size = new System.Drawing.Size(82, 16);
            this.moduloLabel.TabIndex = 35;
            this.moduloLabel.Text = "Модуль N:";
            // 
            // moduloTextBox
            // 
            this.moduloTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moduloTextBox.Location = new System.Drawing.Point(604, 40);
            this.moduloTextBox.Name = "moduloTextBox";
            this.moduloTextBox.ReadOnly = true;
            this.moduloTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.moduloTextBox.Size = new System.Drawing.Size(258, 22);
            this.moduloTextBox.TabIndex = 34;
            // 
            // qPrimeLabel
            // 
            this.qPrimeLabel.AutoSize = true;
            this.qPrimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qPrimeLabel.Location = new System.Drawing.Point(22, 84);
            this.qPrimeLabel.Name = "qPrimeLabel";
            this.qPrimeLabel.Size = new System.Drawing.Size(137, 16);
            this.qPrimeLabel.TabIndex = 33;
            this.qPrimeLabel.Text = "Простое число Q:";
            // 
            // pPrimeLabel
            // 
            this.pPrimeLabel.AutoSize = true;
            this.pPrimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pPrimeLabel.Location = new System.Drawing.Point(22, 46);
            this.pPrimeLabel.Name = "pPrimeLabel";
            this.pPrimeLabel.Size = new System.Drawing.Size(136, 16);
            this.pPrimeLabel.TabIndex = 32;
            this.pPrimeLabel.Text = "Простое число P:";
            // 
            // qPrimeTextBox
            // 
            this.qPrimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qPrimeTextBox.Location = new System.Drawing.Point(174, 81);
            this.qPrimeTextBox.Name = "qPrimeTextBox";
            this.qPrimeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.qPrimeTextBox.Size = new System.Drawing.Size(258, 22);
            this.qPrimeTextBox.TabIndex = 31;
            // 
            // pPrimeTextBox
            // 
            this.pPrimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pPrimeTextBox.Location = new System.Drawing.Point(174, 43);
            this.pPrimeTextBox.Name = "pPrimeTextBox";
            this.pPrimeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.pPrimeTextBox.Size = new System.Drawing.Size(258, 22);
            this.pPrimeTextBox.TabIndex = 30;
            // 
            // signatureLabel
            // 
            this.signatureLabel.AutoSize = true;
            this.signatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.signatureLabel.Location = new System.Drawing.Point(17, 172);
            this.signatureLabel.Name = "signatureLabel";
            this.signatureLabel.Size = new System.Drawing.Size(180, 18);
            this.signatureLabel.TabIndex = 43;
            this.signatureLabel.Text = "Выполнение подписи:";
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputLabel.Location = new System.Drawing.Point(31, 203);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(90, 16);
            this.inputLabel.TabIndex = 45;
            this.inputLabel.Text = "Cообщение";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Enabled = false;
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputTextBox.Location = new System.Drawing.Point(20, 222);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inputTextBox.Size = new System.Drawing.Size(571, 95);
            this.inputTextBox.TabIndex = 44;
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(686, 283);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(114, 34);
            this.startButton.TabIndex = 46;
            this.startButton.Text = "Подписать";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // aliceLabel
            // 
            this.aliceLabel.AutoSize = true;
            this.aliceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aliceLabel.Location = new System.Drawing.Point(17, 399);
            this.aliceLabel.Name = "aliceLabel";
            this.aliceLabel.Size = new System.Drawing.Size(291, 18);
            this.aliceLabel.TabIndex = 47;
            this.aliceLabel.Text = "1. Алиса (подписывает сообщение):";
            // 
            // bobLabel
            // 
            this.bobLabel.AutoSize = true;
            this.bobLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bobLabel.Location = new System.Drawing.Point(453, 399);
            this.bobLabel.Name = "bobLabel";
            this.bobLabel.Size = new System.Drawing.Size(231, 18);
            this.bobLabel.TabIndex = 48;
            this.bobLabel.Text = "2. Боб (проверяет подпись):";
            // 
            // aliceHashTextBox
            // 
            this.aliceHashTextBox.Enabled = false;
            this.aliceHashTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aliceHashTextBox.Location = new System.Drawing.Point(20, 457);
            this.aliceHashTextBox.Multiline = true;
            this.aliceHashTextBox.Name = "aliceHashTextBox";
            this.aliceHashTextBox.ReadOnly = true;
            this.aliceHashTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.aliceHashTextBox.Size = new System.Drawing.Size(388, 63);
            this.aliceHashTextBox.TabIndex = 49;
            // 
            // aliceHashLabel
            // 
            this.aliceHashLabel.AutoSize = true;
            this.aliceHashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aliceHashLabel.Location = new System.Drawing.Point(22, 434);
            this.aliceHashLabel.Name = "aliceHashLabel";
            this.aliceHashLabel.Size = new System.Drawing.Size(205, 16);
            this.aliceHashLabel.TabIndex = 50;
            this.aliceHashLabel.Text = "Хэш, вычисляемый Алисой:";
            // 
            // encodedHashLabel
            // 
            this.encodedHashLabel.AutoSize = true;
            this.encodedHashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encodedHashLabel.Location = new System.Drawing.Point(22, 538);
            this.encodedHashLabel.Name = "encodedHashLabel";
            this.encodedHashLabel.Size = new System.Drawing.Size(164, 16);
            this.encodedHashLabel.TabIndex = 52;
            this.encodedHashLabel.Text = "Зашифрованный хэш:";
            // 
            // encodedHashTextBox
            // 
            this.encodedHashTextBox.Enabled = false;
            this.encodedHashTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encodedHashTextBox.Location = new System.Drawing.Point(20, 561);
            this.encodedHashTextBox.Multiline = true;
            this.encodedHashTextBox.Name = "encodedHashTextBox";
            this.encodedHashTextBox.ReadOnly = true;
            this.encodedHashTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.encodedHashTextBox.Size = new System.Drawing.Size(388, 63);
            this.encodedHashTextBox.TabIndex = 51;
            // 
            // bobHashLabel
            // 
            this.bobHashLabel.AutoSize = true;
            this.bobHashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bobHashLabel.Location = new System.Drawing.Point(458, 434);
            this.bobHashLabel.Name = "bobHashLabel";
            this.bobHashLabel.Size = new System.Drawing.Size(198, 16);
            this.bobHashLabel.TabIndex = 54;
            this.bobHashLabel.Text = "Хэш, вычисляемый Бобом:";
            // 
            // bobHashTextBox
            // 
            this.bobHashTextBox.Enabled = false;
            this.bobHashTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bobHashTextBox.Location = new System.Drawing.Point(456, 457);
            this.bobHashTextBox.Multiline = true;
            this.bobHashTextBox.Name = "bobHashTextBox";
            this.bobHashTextBox.ReadOnly = true;
            this.bobHashTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.bobHashTextBox.Size = new System.Drawing.Size(388, 63);
            this.bobHashTextBox.TabIndex = 53;
            // 
            // decodedHashLabel
            // 
            this.decodedHashLabel.AutoSize = true;
            this.decodedHashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decodedHashLabel.Location = new System.Drawing.Point(458, 538);
            this.decodedHashLabel.Name = "decodedHashLabel";
            this.decodedHashLabel.Size = new System.Drawing.Size(242, 16);
            this.decodedHashLabel.TabIndex = 56;
            this.decodedHashLabel.Text = "Расшифрование хэша от Алисы:";
            // 
            // decodedHashTextBox
            // 
            this.decodedHashTextBox.Enabled = false;
            this.decodedHashTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decodedHashTextBox.Location = new System.Drawing.Point(456, 561);
            this.decodedHashTextBox.Multiline = true;
            this.decodedHashTextBox.Name = "decodedHashTextBox";
            this.decodedHashTextBox.ReadOnly = true;
            this.decodedHashTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.decodedHashTextBox.Size = new System.Drawing.Size(388, 63);
            this.decodedHashTextBox.TabIndex = 55;
            // 
            // checkButton
            // 
            this.checkButton.Enabled = false;
            this.checkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkButton.Location = new System.Drawing.Point(730, 661);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(114, 34);
            this.checkButton.TabIndex = 57;
            this.checkButton.Text = "Проверить";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // hashsCheckTextBox
            // 
            this.hashsCheckTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hashsCheckTextBox.Location = new System.Drawing.Point(20, 667);
            this.hashsCheckTextBox.Name = "hashsCheckTextBox";
            this.hashsCheckTextBox.ReadOnly = true;
            this.hashsCheckTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.hashsCheckTextBox.Size = new System.Drawing.Size(592, 22);
            this.hashsCheckTextBox.TabIndex = 59;
            // 
            // hashsCheckLabel
            // 
            this.hashsCheckLabel.AutoSize = true;
            this.hashsCheckLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hashsCheckLabel.Location = new System.Drawing.Point(22, 642);
            this.hashsCheckLabel.Name = "hashsCheckLabel";
            this.hashsCheckLabel.Size = new System.Drawing.Size(368, 16);
            this.hashsCheckLabel.TabIndex = 58;
            this.hashsCheckLabel.Text = "Проверка совпадения хэшей, полученных Бобом";
            // 
            // fileRadioButton
            // 
            this.fileRadioButton.AutoSize = true;
            this.fileRadioButton.Enabled = false;
            this.fileRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileRadioButton.Location = new System.Drawing.Point(392, 172);
            this.fileRadioButton.Name = "fileRadioButton";
            this.fileRadioButton.Size = new System.Drawing.Size(180, 22);
            this.fileRadioButton.TabIndex = 61;
            this.fileRadioButton.TabStop = true;
            this.fileRadioButton.Text = "Работа с документом";
            this.fileRadioButton.UseVisualStyleBackColor = true;
            this.fileRadioButton.CheckedChanged += new System.EventHandler(this.fileRadioButton_CheckedChanged);
            // 
            // messageRadioButton
            // 
            this.messageRadioButton.AutoSize = true;
            this.messageRadioButton.Enabled = false;
            this.messageRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageRadioButton.Location = new System.Drawing.Point(221, 172);
            this.messageRadioButton.Name = "messageRadioButton";
            this.messageRadioButton.Size = new System.Drawing.Size(151, 22);
            this.messageRadioButton.TabIndex = 60;
            this.messageRadioButton.TabStop = true;
            this.messageRadioButton.Text = "Работа с текстом";
            this.messageRadioButton.UseVisualStyleBackColor = true;
            this.messageRadioButton.CheckedChanged += new System.EventHandler(this.messageRadioButton_CheckedChanged);
            // 
            // clearFilePathButton
            // 
            this.clearFilePathButton.Enabled = false;
            this.clearFilePathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearFilePathButton.Location = new System.Drawing.Point(522, 356);
            this.clearFilePathButton.Name = "clearFilePathButton";
            this.clearFilePathButton.Size = new System.Drawing.Size(69, 27);
            this.clearFilePathButton.TabIndex = 64;
            this.clearFilePathButton.Text = "Отмена";
            this.clearFilePathButton.UseVisualStyleBackColor = true;
            this.clearFilePathButton.Click += new System.EventHandler(this.clearFilePathButton_Click);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Enabled = false;
            this.selectFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectFileButton.Location = new System.Drawing.Point(447, 356);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(69, 27);
            this.selectFileButton.TabIndex = 63;
            this.selectFileButton.Text = "Обзор";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Enabled = false;
            this.filePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filePathTextBox.Location = new System.Drawing.Point(20, 357);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.ReadOnly = true;
            this.filePathTextBox.Size = new System.Drawing.Size(412, 22);
            this.filePathTextBox.TabIndex = 62;
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileLabel.Location = new System.Drawing.Point(31, 338);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(175, 16);
            this.fileLabel.TabIndex = 65;
            this.fileLabel.Text = "Документ для подписи";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 712);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.clearFilePathButton);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.fileRadioButton);
            this.Controls.Add(this.messageRadioButton);
            this.Controls.Add(this.hashsCheckTextBox);
            this.Controls.Add(this.hashsCheckLabel);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.decodedHashLabel);
            this.Controls.Add(this.decodedHashTextBox);
            this.Controls.Add(this.bobHashLabel);
            this.Controls.Add(this.bobHashTextBox);
            this.Controls.Add(this.encodedHashLabel);
            this.Controls.Add(this.encodedHashTextBox);
            this.Controls.Add(this.aliceHashLabel);
            this.Controls.Add(this.aliceHashTextBox);
            this.Controls.Add(this.bobLabel);
            this.Controls.Add(this.aliceLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.signatureLabel);
            this.Controls.Add(this.resetRSAButton);
            this.Controls.Add(this.setupRSAButton);
            this.Controls.Add(this.parametersLabel);
            this.Controls.Add(this.privateKeyLabel);
            this.Controls.Add(this.privateKeyTextBox);
            this.Controls.Add(this.publicKeyLabel);
            this.Controls.Add(this.publicKeyTextBox);
            this.Controls.Add(this.moduloLabel);
            this.Controls.Add(this.moduloTextBox);
            this.Controls.Add(this.qPrimeLabel);
            this.Controls.Add(this.pPrimeLabel);
            this.Controls.Add(this.qPrimeTextBox);
            this.Controls.Add(this.pPrimeTextBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(895, 751);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(895, 751);
            this.Name = "mainForm";
            this.Text = "SignatureRSA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button resetRSAButton;
        private System.Windows.Forms.Button setupRSAButton;
        private System.Windows.Forms.Label parametersLabel;
        private System.Windows.Forms.Label privateKeyLabel;
        private System.Windows.Forms.TextBox privateKeyTextBox;
        private System.Windows.Forms.Label publicKeyLabel;
        private System.Windows.Forms.TextBox publicKeyTextBox;
        private System.Windows.Forms.Label moduloLabel;
        private System.Windows.Forms.TextBox moduloTextBox;
        private System.Windows.Forms.Label qPrimeLabel;
        private System.Windows.Forms.Label pPrimeLabel;
        private System.Windows.Forms.TextBox qPrimeTextBox;
        private System.Windows.Forms.TextBox pPrimeTextBox;
        private System.Windows.Forms.Label signatureLabel;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label aliceLabel;
        private System.Windows.Forms.Label bobLabel;
        private System.Windows.Forms.TextBox aliceHashTextBox;
        private System.Windows.Forms.Label aliceHashLabel;
        private System.Windows.Forms.Label encodedHashLabel;
        private System.Windows.Forms.TextBox encodedHashTextBox;
        private System.Windows.Forms.Label bobHashLabel;
        private System.Windows.Forms.TextBox bobHashTextBox;
        private System.Windows.Forms.Label decodedHashLabel;
        private System.Windows.Forms.TextBox decodedHashTextBox;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.TextBox hashsCheckTextBox;
        private System.Windows.Forms.Label hashsCheckLabel;
        private System.Windows.Forms.RadioButton fileRadioButton;
        private System.Windows.Forms.RadioButton messageRadioButton;
        private System.Windows.Forms.Button clearFilePathButton;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label fileLabel;
    }
}

