namespace GSM_Masters
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Log = new System.Windows.Forms.RichTextBox();
            this.label_transferrate = new System.Windows.Forms.Label();
            this.lb_transferrate = new System.Windows.Forms.Label();
            this.label_writensize = new System.Windows.Forms.Label();
            this.lb_writensize = new System.Windows.Forms.Label();
            this.label_totalsize = new System.Windows.Forms.Label();
            this.lb_totalsize = new System.Windows.Forms.Label();
            this.ComboPort = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEMI = new DevExpress.XtraEditors.CheckEdit();
            this.CkDA = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEMI = new DevExpress.XtraEditors.TextEdit();
            this.btn_dachoose = new DevExpress.XtraEditors.SimpleButton();
            this.btn_emichoose = new DevExpress.XtraEditors.SimpleButton();
            this.BtnReadGPT = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ReadDump = new DevExpress.XtraEditors.SimpleButton();
            this.btnRead = new DevExpress.XtraEditors.SimpleButton();
            this.btnErase = new DevExpress.XtraEditors.SimpleButton();
            this.btnWrite = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnMtkExit = new DevExpress.XtraEditors.SimpleButton();
            this.GridControl5 = new DevExpress.XtraGrid.GridControl();
            this.GridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buttonStop = new DevExpress.XtraEditors.SimpleButton();
            this.ProgressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.MarqueeProgressBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.chkExit = new DevExpress.XtraEditors.CheckEdit();
            this.txtDaa = new DevExpress.XtraEditors.TextEdit();
            this.btnReadHardwareKeys = new DevExpress.XtraEditors.SimpleButton();
            this.buttonVerifyDump = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ComboPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEMI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CkDA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarqueeProgressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDaa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.Color.DimGray;
            this.Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Log.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Log.ForeColor = System.Drawing.SystemColors.Info;
            this.Log.Location = new System.Drawing.Point(626, 65);
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.Size = new System.Drawing.Size(458, 376);
            this.Log.TabIndex = 2;
            this.Log.Text = "";
            // 
            // label_transferrate
            // 
            this.label_transferrate.AutoSize = true;
            this.label_transferrate.BackColor = System.Drawing.Color.Transparent;
            this.label_transferrate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_transferrate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_transferrate.Location = new System.Drawing.Point(999, 490);
            this.label_transferrate.Name = "label_transferrate";
            this.label_transferrate.Size = new System.Drawing.Size(85, 13);
            this.label_transferrate.TabIndex = 3;
            this.label_transferrate.Text = "0.00 байт /с   ";
            // 
            // lb_transferrate
            // 
            this.lb_transferrate.AutoSize = true;
            this.lb_transferrate.BackColor = System.Drawing.Color.Transparent;
            this.lb_transferrate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_transferrate.Location = new System.Drawing.Point(909, 490);
            this.lb_transferrate.Name = "lb_transferrate";
            this.lb_transferrate.Size = new System.Drawing.Size(65, 13);
            this.lb_transferrate.TabIndex = 4;
            this.lb_transferrate.Text = "Скорость : ";
            // 
            // label_writensize
            // 
            this.label_writensize.AutoSize = true;
            this.label_writensize.BackColor = System.Drawing.Color.Transparent;
            this.label_writensize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_writensize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_writensize.Location = new System.Drawing.Point(789, 490);
            this.label_writensize.Name = "label_writensize";
            this.label_writensize.Size = new System.Drawing.Size(111, 13);
            this.label_writensize.TabIndex = 5;
            this.label_writensize.Text = "0.00 байтов            ";
            // 
            // lb_writensize
            // 
            this.lb_writensize.AutoSize = true;
            this.lb_writensize.BackColor = System.Drawing.Color.Transparent;
            this.lb_writensize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_writensize.Location = new System.Drawing.Point(686, 490);
            this.lb_writensize.Name = "lb_writensize";
            this.lb_writensize.Size = new System.Drawing.Size(97, 13);
            this.lb_writensize.TabIndex = 6;
            this.lb_writensize.Text = "Размер отправки:";
            // 
            // label_totalsize
            // 
            this.label_totalsize.AutoSize = true;
            this.label_totalsize.BackColor = System.Drawing.Color.Transparent;
            this.label_totalsize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_totalsize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_totalsize.Location = new System.Drawing.Point(594, 490);
            this.label_totalsize.Name = "label_totalsize";
            this.label_totalsize.Size = new System.Drawing.Size(102, 13);
            this.label_totalsize.TabIndex = 7;
            this.label_totalsize.Text = "0.00 байтов         ";
            // 
            // lb_totalsize
            // 
            this.lb_totalsize.AutoSize = true;
            this.lb_totalsize.BackColor = System.Drawing.Color.Transparent;
            this.lb_totalsize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_totalsize.Location = new System.Drawing.Point(504, 490);
            this.lb_totalsize.Name = "lb_totalsize";
            this.lb_totalsize.Size = new System.Drawing.Size(84, 13);
            this.lb_totalsize.TabIndex = 8;
            this.lb_totalsize.Text = "Общий размер:";
            // 
            // ComboPort
            // 
            this.ComboPort.Location = new System.Drawing.Point(684, 3);
            this.ComboPort.Name = "ComboPort";
            this.ComboPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboPort.Properties.PopupSizeable = true;
            this.ComboPort.Properties.ReadOnly = true;
            this.ComboPort.Size = new System.Drawing.Size(380, 28);
            this.ComboPort.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(625, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "ПОРТ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1070, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "R";
            // 
            // chkEMI
            // 
            this.chkEMI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEMI.Location = new System.Drawing.Point(118, 63);
            this.chkEMI.Name = "chkEMI";
            this.chkEMI.Properties.Caption = "";
            this.chkEMI.Size = new System.Drawing.Size(18, 22);
            this.chkEMI.TabIndex = 70;
            // 
            // CkDA
            // 
            this.CkDA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CkDA.Enabled = false;
            this.CkDA.Location = new System.Drawing.Point(118, 33);
            this.CkDA.Name = "CkDA";
            this.CkDA.Properties.Caption = "";
            this.CkDA.Size = new System.Drawing.Size(18, 22);
            this.CkDA.TabIndex = 71;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(29, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 68;
            this.labelControl2.Text = "EMI | Preloader";
            // 
            // labelControl1
            // 
            this.labelControl1.Enabled = false;
            this.labelControl1.Location = new System.Drawing.Point(9, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(103, 13);
            this.labelControl1.TabIndex = 69;
            this.labelControl1.Text = "DA | Download Agent";
            // 
            // txtEMI
            // 
            this.txtEMI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEMI.Location = new System.Drawing.Point(139, 59);
            this.txtEMI.Name = "txtEMI";
            this.txtEMI.Size = new System.Drawing.Size(344, 28);
            this.txtEMI.TabIndex = 66;
            // 
            // btn_dachoose
            // 
            this.btn_dachoose.Enabled = false;
            this.btn_dachoose.Location = new System.Drawing.Point(488, 33);
            this.btn_dachoose.Name = "btn_dachoose";
            this.btn_dachoose.Size = new System.Drawing.Size(29, 23);
            this.btn_dachoose.TabIndex = 72;
            this.btn_dachoose.Text = "...";
            // 
            // btn_emichoose
            // 
            this.btn_emichoose.Location = new System.Drawing.Point(489, 62);
            this.btn_emichoose.Name = "btn_emichoose";
            this.btn_emichoose.Size = new System.Drawing.Size(29, 23);
            this.btn_emichoose.TabIndex = 73;
            this.btn_emichoose.Text = "...";
            this.btn_emichoose.Click += new System.EventHandler(this.btn_emichoose_Click);
            // 
            // BtnReadGPT
            // 
            this.BtnReadGPT.Location = new System.Drawing.Point(523, 32);
            this.BtnReadGPT.Name = "BtnReadGPT";
            this.BtnReadGPT.Size = new System.Drawing.Size(92, 53);
            this.BtnReadGPT.TabIndex = 75;
            this.BtnReadGPT.Text = "Подключить";
            this.BtnReadGPT.Click += new System.EventHandler(this.BtnReadGPT_Click);
            // 
            // btn_ReadDump
            // 
            this.btn_ReadDump.Location = new System.Drawing.Point(8, 417);
            this.btn_ReadDump.Name = "btn_ReadDump";
            this.btn_ReadDump.Size = new System.Drawing.Size(287, 23);
            this.btn_ReadDump.TabIndex = 76;
            this.btn_ReadDump.Text = "Читать дамп";
            this.btn_ReadDump.Click += new System.EventHandler(this.btn_ReadDump_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(5, 42);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(86, 23);
            this.btnRead.TabIndex = 77;
            this.btnRead.Text = "Читать";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnErase
            // 
            this.btnErase.Location = new System.Drawing.Point(5, 83);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(86, 23);
            this.btnErase.TabIndex = 78;
            this.btnErase.Text = "Затереть";
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(5, 124);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(86, 23);
            this.btnWrite.TabIndex = 79;
            this.btnWrite.Text = "Записать";
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnWrite);
            this.groupControl1.Controls.Add(this.btnErase);
            this.groupControl1.Controls.Add(this.btnRead);
            this.groupControl1.Location = new System.Drawing.Point(524, 100);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(96, 152);
            this.groupControl1.TabIndex = 80;
            this.groupControl1.Text = "Раздел:";
            // 
            // btnMtkExit
            // 
            this.btnMtkExit.Location = new System.Drawing.Point(529, 360);
            this.btnMtkExit.Name = "btnMtkExit";
            this.btnMtkExit.Size = new System.Drawing.Size(86, 23);
            this.btnMtkExit.TabIndex = 81;
            this.btnMtkExit.Text = "Перезагрузить";
            // 
            // GridControl5
            // 
            this.GridControl5.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.GridControl5.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.GridControl5.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.GridControl5.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.GridControl5.Location = new System.Drawing.Point(8, 100);
            this.GridControl5.MainView = this.GridView5;
            this.GridControl5.Name = "GridControl5";
            this.GridControl5.Size = new System.Drawing.Size(515, 311);
            this.GridControl5.TabIndex = 82;
            this.GridControl5.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView5});
            // 
            // GridView5
            // 
            this.GridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumn25,
            this.GridColumn31,
            this.GridColumn32,
            this.GridColumn33,
            this.GridColumn34,
            this.GridColumn35,
            this.GridColumn36,
            this.GridColumn37});
            this.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.GridView5.GridControl = this.GridControl5;
            this.GridView5.Name = "GridView5";
            this.GridView5.OptionsBehavior.Editable = false;
            this.GridView5.OptionsCustomization.AllowFilter = false;
            this.GridView5.OptionsCustomization.AllowSort = false;
            this.GridView5.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.GridView5.OptionsFilter.AllowFilterEditor = false;
            this.GridView5.OptionsFilter.AllowMRUFilterList = false;
            this.GridView5.OptionsFilter.ShowCustomFunctions = DevExpress.Utils.DefaultBoolean.False;
            this.GridView5.OptionsMenu.EnableColumnMenu = false;
            this.GridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridView5.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.GridView5.OptionsSelection.EnableAppearanceHideSelection = false;
            this.GridView5.OptionsSelection.MultiSelect = true;
            this.GridView5.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.GridView5.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.GridView5.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.GridView5.OptionsView.ShowGroupPanel = false;
            // 
            // GridColumn25
            // 
            this.GridColumn25.Caption = "Имя";
            this.GridColumn25.FieldName = "dg0";
            this.GridColumn25.Name = "GridColumn25";
            this.GridColumn25.Visible = true;
            this.GridColumn25.VisibleIndex = 1;
            // 
            // GridColumn31
            // 
            this.GridColumn31.Caption = "Файл";
            this.GridColumn31.FieldName = "dg1";
            this.GridColumn31.Name = "GridColumn31";
            this.GridColumn31.Visible = true;
            this.GridColumn31.VisibleIndex = 2;
            // 
            // GridColumn32
            // 
            this.GridColumn32.Caption = "Размер";
            this.GridColumn32.FieldName = "dg2";
            this.GridColumn32.Name = "GridColumn32";
            this.GridColumn32.Visible = true;
            this.GridColumn32.VisibleIndex = 3;
            // 
            // GridColumn33
            // 
            this.GridColumn33.Caption = "Адрес";
            this.GridColumn33.FieldName = "dg3";
            this.GridColumn33.Name = "GridColumn33";
            this.GridColumn33.Visible = true;
            this.GridColumn33.VisibleIndex = 4;
            // 
            // GridColumn34
            // 
            this.GridColumn34.Caption = "Длина";
            this.GridColumn34.FieldName = "dg4";
            this.GridColumn34.Name = "GridColumn34";
            this.GridColumn34.Visible = true;
            this.GridColumn34.VisibleIndex = 5;
            // 
            // GridColumn35
            // 
            this.GridColumn35.Caption = "Flags";
            this.GridColumn35.FieldName = "dg5";
            this.GridColumn35.Name = "GridColumn35";
            this.GridColumn35.Visible = true;
            this.GridColumn35.VisibleIndex = 6;
            // 
            // GridColumn36
            // 
            this.GridColumn36.Caption = "UUID";
            this.GridColumn36.FieldName = "dg6";
            this.GridColumn36.Name = "GridColumn36";
            this.GridColumn36.Visible = true;
            this.GridColumn36.VisibleIndex = 7;
            // 
            // GridColumn37
            // 
            this.GridColumn37.Caption = "Место...";
            this.GridColumn37.FieldName = "dg7";
            this.GridColumn37.Name = "GridColumn37";
            this.GridColumn37.Visible = true;
            this.GridColumn37.VisibleIndex = 8;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(997, 448);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(87, 29);
            this.buttonStop.TabIndex = 83;
            this.buttonStop.Text = "СТОП";
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.EditValue = 100;
            this.ProgressBar.Location = new System.Drawing.Point(626, 448);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ProgressBar.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.ProgressBar.Properties.ShowTitle = true;
            this.ProgressBar.ShowProgressInTaskBar = true;
            this.ProgressBar.Size = new System.Drawing.Size(365, 26);
            this.ProgressBar.TabIndex = 124;
            // 
            // MarqueeProgressBar
            // 
            this.MarqueeProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MarqueeProgressBar.EditValue = 0;
            this.MarqueeProgressBar.Location = new System.Drawing.Point(689, 448);
            this.MarqueeProgressBar.Name = "MarqueeProgressBar";
            this.MarqueeProgressBar.Properties.MarqueeAnimationSpeed = 15;
            this.MarqueeProgressBar.Properties.Stopped = true;
            this.MarqueeProgressBar.Size = new System.Drawing.Size(244, 26);
            this.MarqueeProgressBar.TabIndex = 139;
            // 
            // chkExit
            // 
            this.chkExit.Location = new System.Drawing.Point(628, 38);
            this.chkExit.Name = "chkExit";
            this.chkExit.Properties.Caption = "Crash Preloader";
            this.chkExit.Size = new System.Drawing.Size(133, 22);
            this.chkExit.TabIndex = 140;
            // 
            // txtDaa
            // 
            this.txtDaa.EditValue = "АВТОМАТИЧЕСКИЙ ВЫБОР";
            this.txtDaa.Enabled = false;
            this.txtDaa.Location = new System.Drawing.Point(139, 30);
            this.txtDaa.Name = "txtDaa";
            this.txtDaa.Size = new System.Drawing.Size(344, 28);
            this.txtDaa.TabIndex = 142;
            // 
            // btnReadHardwareKeys
            // 
            this.btnReadHardwareKeys.Location = new System.Drawing.Point(301, 419);
            this.btnReadHardwareKeys.Name = "btnReadHardwareKeys";
            this.btnReadHardwareKeys.Size = new System.Drawing.Size(319, 23);
            this.btnReadHardwareKeys.TabIndex = 143;
            this.btnReadHardwareKeys.Text = "Читать Hardware Keys";
            this.btnReadHardwareKeys.Click += new System.EventHandler(this.btnReadHardwareKeys_Click);
            // 
            // buttonVerifyDump
            // 
            this.buttonVerifyDump.Location = new System.Drawing.Point(8, 445);
            this.buttonVerifyDump.Name = "buttonVerifyDump";
            this.buttonVerifyDump.Size = new System.Drawing.Size(612, 23);
            this.buttonVerifyDump.TabIndex = 144;
            this.buttonVerifyDump.Text = "Подготовить flash.bin и hardware keys для Oxygen";
            this.buttonVerifyDump.Click += new System.EventHandler(this.buttonVerifyDump_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 480);
            this.Controls.Add(this.buttonVerifyDump);
            this.Controls.Add(this.btnReadHardwareKeys);
            this.Controls.Add(this.txtDaa);
            this.Controls.Add(this.chkExit);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.GridControl5);
            this.Controls.Add(this.btnMtkExit);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btn_ReadDump);
            this.Controls.Add(this.BtnReadGPT);
            this.Controls.Add(this.btn_emichoose);
            this.Controls.Add(this.btn_dachoose);
            this.Controls.Add(this.chkEMI);
            this.Controls.Add(this.CkDA);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtEMI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboPort);
            this.Controls.Add(this.label_transferrate);
            this.Controls.Add(this.lb_transferrate);
            this.Controls.Add(this.label_writensize);
            this.Controls.Add(this.lb_writensize);
            this.Controls.Add(this.label_totalsize);
            this.Controls.Add(this.lb_totalsize);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.MarqueeProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "GSM-MASTERS - GUI MTKClient by Zerosecurity0";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ComboPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEMI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CkDA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarqueeProgressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDaa.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label_transferrate;
        private System.Windows.Forms.Label lb_transferrate;
        public System.Windows.Forms.Label label_writensize;
        private System.Windows.Forms.Label lb_writensize;
        public System.Windows.Forms.Label label_totalsize;
        private System.Windows.Forms.Label lb_totalsize;
        private DevExpress.XtraEditors.ComboBoxEdit ComboPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public DevExpress.XtraEditors.CheckEdit chkEMI;
        public DevExpress.XtraEditors.CheckEdit CkDA;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtEMI;
        private DevExpress.XtraEditors.SimpleButton btn_dachoose;
        private DevExpress.XtraEditors.SimpleButton btn_emichoose;
        private DevExpress.XtraEditors.SimpleButton BtnReadGPT;
        private DevExpress.XtraEditors.SimpleButton btn_ReadDump;
        private DevExpress.XtraEditors.SimpleButton btnRead;
        private DevExpress.XtraEditors.SimpleButton btnErase;
        private DevExpress.XtraEditors.SimpleButton btnWrite;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnMtkExit;
        public System.Windows.Forms.RichTextBox Log;
        public DevExpress.XtraGrid.Columns.GridColumn GridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumn34;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumn37;
        public DevExpress.XtraGrid.GridControl GridControl5;
        public DevExpress.XtraGrid.Views.Grid.GridView GridView5;
        private DevExpress.XtraEditors.SimpleButton buttonStop;
        private DevExpress.XtraEditors.MarqueeProgressBarControl MarqueeProgressBar;
        private DevExpress.XtraEditors.CheckEdit chkExit;
        private DevExpress.XtraEditors.TextEdit txtDaa;
        public DevExpress.XtraEditors.ProgressBarControl ProgressBar;
        private DevExpress.XtraEditors.SimpleButton btnReadHardwareKeys;
        private DevExpress.XtraEditors.SimpleButton buttonVerifyDump;
    }
}

