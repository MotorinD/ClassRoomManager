using ClassRoomManager.Additional;
using ClassRoomManager.DAL;
using ClassRoomManager.DataModel;
using ClassRoomManager.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassRoomManager.Forms
{
    public partial class fmEditClassRoom : Form
    {
        public fmEditClassRoom()
        {
            this.InitializeComponent();
        }

        public ClassRoomDataModel DataModel { get; set; }

        public bool IsAdd { get; set; }

        public DataManager Dm { get { return DataManager.Active; } }

        public List<ClassRoomDataModel> ClassRoomList { get; set; }

        public static bool Execute(ClassRoomDataModel dataModel)
        {
            if (dataModel == null)
                return false;

            using (var fm = new fmEditClassRoom())
            {
                fm.DataModel = dataModel;
                fm.IsAdd = dataModel.Id == 0;
                fm.ShowDialog();
                return fm.DialogResult == DialogResult.OK;
            }
        }

        private void fmEditClassRoom_Load(object sender, EventArgs e)
        {
            this.LoadInterface();
            this.LoadData();
        }

        private void LoadInterface()
        {
            this.Text = this.IsAdd ? "Добавление аудитории" : "Редактирование аудитории";
        }

        private void LoadData()
        {
            this.cbType.DataSource = Extensions.GetEnumValuesAndDescriptions<ClassRoomTypeEnum>();
            this.ClassRoomList = this.Dm.ClassRoom.GetList().Select(o => new ClassRoomDataModel(o)).ToList();

            if (!this.IsAdd)
            {
                this.tbNumber.Text = this.DataModel.Number.ToString();
                this.cbType.SelectedIndex = this.DataModel.Type ?? 0;
                this.tbDescription.Text = this.DataModel.Description;
                this.chbxIsOccupied.Checked = this.DataModel.IsOccupiedBool;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.CheckData())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            this.SaveData();
        }

        private bool CheckData()
        {
            var res = true;

            if (string.IsNullOrWhiteSpace(this.tbNumber.Text))
            {
                this.errorProvider.SetError(this.tbNumber, "Введите значение");
                res = false;
            }
            else
            {
                var num = 0;
                if (!Int32.TryParse(this.tbNumber.Text, out num))
                {
                    this.errorProvider.SetError(this.tbNumber, "Значение должно быть числом");
                    res = false;
                }

                if (this.ClassRoomList.Any(o => o.Number.HasValue && o.Number == num && o.Id != this.DataModel.Id))
                {
                    this.errorProvider.SetError(this.tbNumber, "Аудитория с таким номером уже есть");
                    res = false;
                }
            }

            return res;
        }

        private void SaveData()
        {
            this.DataModel.Number = Convert.ToInt32(this.tbNumber.Text);
            this.DataModel.Type = this.cbType.SelectedIndex;
            this.DataModel.Description = this.tbDescription.Text;
            this.DataModel.IsOccupiedBool = this.chbxIsOccupied.Checked;

            if (this.IsAdd)
                this.Dm.ClassRoom.Add(this.DataModel);
            else
                this.Dm.ClassRoom.Edit(this.DataModel);
        }
    }
}
