namespace GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelVersenylovak = new Label();
            listBoxLovakLista = new ListBox();
            buttonTorles = new Button();
            buttonBezar = new Button();
            buttonMent = new Button();
            labelIstallo = new Label();
            labelNev = new Label();
            labelFajta = new Label();
            labelSzuletett = new Label();
            labelVerseníszam = new Label();
            textBoxNev = new TextBox();
            textBoxFajta = new TextBox();
            textBoxVerseníszam = new TextBox();
            textBoxInfo = new TextBox();
            comboBoxIstallok = new ComboBox();
            dateTimePickerSzuletett = new DateTimePicker();
            SuspendLayout();
            // 
            // labelVersenylovak
            // 
            labelVersenylovak.AutoSize = true;
            labelVersenylovak.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelVersenylovak.Location = new Point(249, 19);
            labelVersenylovak.Name = "labelVersenylovak";
            labelVersenylovak.Size = new Size(142, 30);
            labelVersenylovak.TabIndex = 0;
            labelVersenylovak.Text = "Versenylovak";
            // 
            // listBoxLovakLista
            // 
            listBoxLovakLista.FormattingEnabled = true;
            listBoxLovakLista.ItemHeight = 15;
            listBoxLovakLista.Location = new Point(48, 83);
            listBoxLovakLista.Name = "listBoxLovakLista";
            listBoxLovakLista.Size = new Size(120, 199);
            listBoxLovakLista.TabIndex = 1;
            listBoxLovakLista.SelectedIndexChanged += listBoxLovakLista_SelectedIndexChanged;
            // 
            // buttonTorles
            // 
            buttonTorles.Location = new Point(290, 165);
            buttonTorles.Name = "buttonTorles";
            buttonTorles.Size = new Size(75, 23);
            buttonTorles.TabIndex = 3;
            buttonTorles.Text = "Törlés";
            buttonTorles.UseVisualStyleBackColor = true;
            buttonTorles.Click += buttonTorles_Click;
            // 
            // buttonBezar
            // 
            buttonBezar.Location = new Point(354, 241);
            buttonBezar.Name = "buttonBezar";
            buttonBezar.Size = new Size(75, 23);
            buttonBezar.TabIndex = 4;
            buttonBezar.Text = "Bezár";
            buttonBezar.UseVisualStyleBackColor = true;
            buttonBezar.Click += buttonBezar_Click;
            // 
            // buttonMent
            // 
            buttonMent.Location = new Point(553, 524);
            buttonMent.Name = "buttonMent";
            buttonMent.Size = new Size(75, 23);
            buttonMent.TabIndex = 5;
            buttonMent.Text = "Ment";
            buttonMent.UseVisualStyleBackColor = true;
            buttonMent.Click += buttonMent_Click;
            // 
            // labelIstallo
            // 
            labelIstallo.AutoSize = true;
            labelIstallo.Location = new Point(173, 376);
            labelIstallo.Name = "labelIstallo";
            labelIstallo.Size = new Size(38, 15);
            labelIstallo.TabIndex = 8;
            labelIstallo.Text = "Istálló";
            // 
            // labelNev
            // 
            labelNev.AutoSize = true;
            labelNev.Location = new Point(173, 413);
            labelNev.Name = "labelNev";
            labelNev.Size = new Size(28, 15);
            labelNev.TabIndex = 9;
            labelNev.Text = "Név";
            // 
            // labelFajta
            // 
            labelFajta.AutoSize = true;
            labelFajta.Location = new Point(173, 453);
            labelFajta.Name = "labelFajta";
            labelFajta.Size = new Size(32, 15);
            labelFajta.TabIndex = 10;
            labelFajta.Text = "Fajta";
            // 
            // labelSzuletett
            // 
            labelSzuletett.AutoSize = true;
            labelSzuletett.Location = new Point(173, 492);
            labelSzuletett.Name = "labelSzuletett";
            labelSzuletett.Size = new Size(52, 15);
            labelSzuletett.TabIndex = 11;
            labelSzuletett.Text = "Született";
            // 
            // labelVerseníszam
            // 
            labelVerseníszam.AutoSize = true;
            labelVerseníszam.Location = new Point(173, 528);
            labelVerseníszam.Name = "labelVerseníszam";
            labelVerseníszam.Size = new Size(74, 15);
            labelVerseníszam.TabIndex = 12;
            labelVerseníszam.Text = "Versenyszám";
            // 
            // textBoxNev
            // 
            textBoxNev.Location = new Point(249, 410);
            textBoxNev.Name = "textBoxNev";
            textBoxNev.Size = new Size(119, 23);
            textBoxNev.TabIndex = 14;
            // 
            // textBoxFajta
            // 
            textBoxFajta.Location = new Point(249, 450);
            textBoxFajta.Name = "textBoxFajta";
            textBoxFajta.Size = new Size(119, 23);
            textBoxFajta.TabIndex = 15;
            // 
            // textBoxVerseníszam
            // 
            textBoxVerseníszam.Location = new Point(249, 520);
            textBoxVerseníszam.Name = "textBoxVerseníszam";
            textBoxVerseníszam.Size = new Size(119, 23);
            textBoxVerseníszam.TabIndex = 17;
            // 
            // textBoxInfo
            // 
            textBoxInfo.Location = new Point(230, 89);
            textBoxInfo.Multiline = true;
            textBoxInfo.Name = "textBoxInfo";
            textBoxInfo.Size = new Size(236, 70);
            textBoxInfo.TabIndex = 18;
            // 
            // comboBoxIstallok
            // 
            comboBoxIstallok.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIstallok.FormattingEnabled = true;
            comboBoxIstallok.Location = new Point(247, 375);
            comboBoxIstallok.Name = "comboBoxIstallok";
            comboBoxIstallok.Size = new Size(121, 23);
            comboBoxIstallok.TabIndex = 19;
            // 
            // dateTimePickerSzuletett
            // 
            dateTimePickerSzuletett.Format = DateTimePickerFormat.Short;
            dateTimePickerSzuletett.Location = new Point(249, 488);
            dateTimePickerSzuletett.Name = "dateTimePickerSzuletett";
            dateTimePickerSzuletett.Size = new Size(119, 23);
            dateTimePickerSzuletett.TabIndex = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 620);
            Controls.Add(dateTimePickerSzuletett);
            Controls.Add(comboBoxIstallok);
            Controls.Add(textBoxInfo);
            Controls.Add(textBoxVerseníszam);
            Controls.Add(textBoxFajta);
            Controls.Add(textBoxNev);
            Controls.Add(labelVerseníszam);
            Controls.Add(labelSzuletett);
            Controls.Add(labelFajta);
            Controls.Add(labelNev);
            Controls.Add(labelIstallo);
            Controls.Add(buttonMent);
            Controls.Add(buttonBezar);
            Controls.Add(buttonTorles);
            Controls.Add(listBoxLovakLista);
            Controls.Add(labelVersenylovak);
            Name = "Form1";
            Text = "Versenylovak";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelVersenylovak;
        private ListBox listBoxLovakLista;
        private Button buttonTorles;
        private Button buttonBezar;
        private Button buttonMent;
        private Label labelIstallo;
        private Label labelNev;
        private Label labelFajta;
        private Label labelSzuletett;
        private Label labelVerseníszam;
        private TextBox textBoxNev;
        private TextBox textBoxFajta;
        private TextBox textBoxVerseníszam;
        private TextBox textBoxInfo;
        private ComboBox comboBoxIstallok;
        private DateTimePicker dateTimePickerSzuletett;
    }
}