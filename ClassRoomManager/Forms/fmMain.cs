using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassRoomManager.DAL;
using ClassRoomManager.DataModel;
using ClassRoomManager.ViewModel;
using ClassRoomManager.Forms;
using ClassRoomManager.Managers;

namespace ClassRoomManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        public DataManager Dm { get { return DataManager.Active; } }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadInterface();
                this.RefreshData();
                this.dgvClassRoom.DataSource = this.Dm.ClassRoom.GetList().Select(o => new ClassRoomViewModelMain(new ClassRoomDataModel(o))).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshData()
        {
            try
            {
                var curIndex = 0;

                if (this.dgvClassRoom.CurrentRow != null)
                {
                    curIndex = this.dgvClassRoom.CurrentRow.Index;
                    this.dgvClassRoom.CurrentRow.Selected = false;
                }

                var dataSource = this.Dm.ClassRoom.GetList().Select(o => new ClassRoomViewModelMain(new ClassRoomDataModel(o))).ToList();

                if (this.chbxShowFreeOnly.Checked)
                    dataSource = dataSource.FindAll(o => !o.IsOccupiedBool);


                this.dgvClassRoom.DataSource = dataSource;
                this.dgvClassRoom.ClearSelection();

                foreach (DataGridViewRow row in this.dgvClassRoom.Rows)
                {
                    var item = row.DataBoundItem as ClassRoomViewModelMain;

                    if (item == null)
                        continue;

                    if (item.IsOccupiedBool)
                    {
                        row.DefaultCellStyle.BackColor = this.chbxSetRedOccupied.Checked ? Color.Red : Color.White;
                    }
                }

                if (this.dgvClassRoom.Rows.Count > 0)
                    if (this.dgvClassRoom.Rows.Count > curIndex)
                    {
                        this.dgvClassRoom.Rows[curIndex].Selected = true;
                        this.dgvClassRoom.CurrentCell = this.dgvClassRoom[0, curIndex];
                    }
                    else
                    {
                        this.dgvClassRoom.Rows[this.dgvClassRoom.Rows.Count - 1].Selected = true;
                        this.dgvClassRoom.CurrentCell = this.dgvClassRoom[0, this.dgvClassRoom.Rows.Count - 1];
                    }
            }
            catch
            {
                var dataSource = this.Dm.ClassRoom.GetList().Select(o => new ClassRoomViewModelMain(new ClassRoomDataModel(o))).ToList();
                this.dgvClassRoom.DataSource = dataSource;
            }
        }

        private void LoadInterface()
        {
            this.dgvClassRoom.AutoGenerateColumns = false;

            this.dgvColumnDescription.ReadOnly = true;
            this.dgvColumnNumber.ReadOnly = true;
            this.dgvColumnType.ReadOnly = true;
            this.dgvColumnIsOccupied.ReadOnly = false;
        }

        #region Изменение статуса при нажатии флага в таблице

        private void dgvClassRoom_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClassRoom.IsCurrentCellDirty && this.dgvClassRoom.CurrentCell.ColumnIndex == this.dgvColumnIsOccupied.Index)
                {
                    this.dgvClassRoom.EndEdit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvClassRoom_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dgvColumnIsOccupied.Index)
                {
                    if (this.dgvClassRoom.CurrentRow == null)
                        return;

                    var item = this.dgvClassRoom.CurrentRow.DataBoundItem as ClassRoomViewModelMain;

                    if (item == null)
                        return;

                    item.DataModel.IsOccupiedBool = item.IsOccupiedBool;
                    this.Dm.ClassRoom.Edit(item.DataModel);
                    this.RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (fmEditClassRoom.Execute(new ClassRoomDataModel()))
                    this.RefreshData();

                //this.Dm.Building.Add(new Entities.Building { Name = "qweqweqwe", FloorCount = 123, Id = 0 });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClassRoom.CurrentRow == null)
                    return;

                var selectedItem = this.dgvClassRoom.CurrentRow.DataBoundItem as ClassRoomViewModelMain;

                if (selectedItem == null)
                    return;

                if (fmEditClassRoom.Execute(selectedItem.DataModel))
                    this.RefreshData();

                //this.Dm.Building.Edit(new Entities.Building { Name = "111", FloorCount = 44444 });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClassRoom.CurrentRow == null)
                    return;

                var selectedItem = this.dgvClassRoom.CurrentRow.DataBoundItem as ClassRoomViewModelMain;

                if (selectedItem == null)
                    return;

                var deleteDialogResult = MessageBox.Show(string.Format("Удалить аудиторию номер {0}?", selectedItem.Number), "Внимание", MessageBoxButtons.YesNo);

                if (deleteDialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Dm.ClassRoom.Delete(selectedItem.DataModel.Id);
                    this.RefreshData();
                }

                //var list = this.Dm.Building.GetList();

                //if (list.Any())
                //    this.Dm.Building.Delete(list.First().Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chbxShowFreeOnly_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chbxSetRedOccupied_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
