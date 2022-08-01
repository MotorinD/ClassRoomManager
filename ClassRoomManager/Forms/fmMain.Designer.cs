namespace ClassRoomManager
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvClassRoom = new System.Windows.Forms.DataGridView();
            this.dgvColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnIsOccupied = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chbxShowFreeOnly = new System.Windows.Forms.CheckBox();
            this.chbxSetRedOccupied = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClassRoom
            // 
            this.dgvClassRoom.AllowUserToAddRows = false;
            this.dgvClassRoom.AllowUserToDeleteRows = false;
            this.dgvClassRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClassRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClassRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColumnNumber,
            this.dgvColumnType,
            this.dgvColumnDescription,
            this.dgvColumnIsOccupied});
            this.dgvClassRoom.Location = new System.Drawing.Point(12, 12);
            this.dgvClassRoom.MultiSelect = false;
            this.dgvClassRoom.Name = "dgvClassRoom";
            this.dgvClassRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClassRoom.Size = new System.Drawing.Size(828, 326);
            this.dgvClassRoom.TabIndex = 0;
            this.dgvClassRoom.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassRoom_CellValueChanged);
            this.dgvClassRoom.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvClassRoom_CurrentCellDirtyStateChanged);
            // 
            // dgvColumnNumber
            // 
            this.dgvColumnNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvColumnNumber.DataPropertyName = "Number";
            this.dgvColumnNumber.FillWeight = 76.00943F;
            this.dgvColumnNumber.HeaderText = "Номер";
            this.dgvColumnNumber.Name = "dgvColumnNumber";
            this.dgvColumnNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumnNumber.Width = 66;
            // 
            // dgvColumnType
            // 
            this.dgvColumnType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvColumnType.DataPropertyName = "Type";
            this.dgvColumnType.FillWeight = 74.48924F;
            this.dgvColumnType.HeaderText = "Тип";
            this.dgvColumnType.Name = "dgvColumnType";
            this.dgvColumnType.Width = 51;
            // 
            // dgvColumnDescription
            // 
            this.dgvColumnDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvColumnDescription.DataPropertyName = "Description";
            this.dgvColumnDescription.FillWeight = 74.48924F;
            this.dgvColumnDescription.HeaderText = "Описание";
            this.dgvColumnDescription.Name = "dgvColumnDescription";
            // 
            // dgvColumnIsOccupied
            // 
            this.dgvColumnIsOccupied.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvColumnIsOccupied.DataPropertyName = "IsOccupiedBool";
            this.dgvColumnIsOccupied.FillWeight = 74.48924F;
            this.dgvColumnIsOccupied.HeaderText = "Занята";
            this.dgvColumnIsOccupied.Name = "dgvColumnIsOccupied";
            this.dgvColumnIsOccupied.Width = 49;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(537, 350);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(640, 350);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(97, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Изменить...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(743, 350);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chbxShowFreeOnly
            // 
            this.chbxShowFreeOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbxShowFreeOnly.AutoSize = true;
            this.chbxShowFreeOnly.Location = new System.Drawing.Point(13, 355);
            this.chbxShowFreeOnly.Name = "chbxShowFreeOnly";
            this.chbxShowFreeOnly.Size = new System.Drawing.Size(122, 17);
            this.chbxShowFreeOnly.TabIndex = 4;
            this.chbxShowFreeOnly.Text = "Только свободные";
            this.chbxShowFreeOnly.UseVisualStyleBackColor = true;
            this.chbxShowFreeOnly.CheckedChanged += new System.EventHandler(this.chbxShowFreeOnly_CheckedChanged);
            // 
            // chbxSetRedOccupied
            // 
            this.chbxSetRedOccupied.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbxSetRedOccupied.AutoSize = true;
            this.chbxSetRedOccupied.Location = new System.Drawing.Point(142, 355);
            this.chbxSetRedOccupied.Name = "chbxSetRedOccupied";
            this.chbxSetRedOccupied.Size = new System.Drawing.Size(171, 17);
            this.chbxSetRedOccupied.TabIndex = 5;
            this.chbxSetRedOccupied.Text = "Выделить занятые красным";
            this.chbxSetRedOccupied.UseVisualStyleBackColor = true;
            this.chbxSetRedOccupied.CheckedChanged += new System.EventHandler(this.chbxSetRedOccupied_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 385);
            this.Controls.Add(this.chbxSetRedOccupied);
            this.Controls.Add(this.chbxShowFreeOnly);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvClassRoom);
            this.Name = "Form1";
            this.Text = "Аудитории";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassRoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClassRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvColumnIsOccupied;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chbxShowFreeOnly;
        private System.Windows.Forms.CheckBox chbxSetRedOccupied;
    }
}

