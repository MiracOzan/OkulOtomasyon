using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.Concrete.Managers;
using OkulOtomasyon.Business.DependencyResolver.Ninject;
using OkulOtomasyon.DataAccess.Concrete.EntityFramework;
using OkulOtomasyon.Entities.Concrete;
using System.Data.Entity;
using DevExpress.DataAccess.Native.Data;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.ColorPick.Picker;
using DataTable = System.Data.DataTable;

namespace OkulOtomasyon.UI
{
    public partial class Home : Form
    {


        public Home()
        {

            InitializeComponent();
        }

        public byte[] photo;
        
        private readonly IStudentsService _studentsService = InstanceFactory.GetInstance<IStudentsService>();
        private IStudentsParentsService _studentsParentsService = new StudentsParentsManager(new EfStudentsParentsDal());
        private void Home_Load(object sender, EventArgs e)
        {
            //log4net.Config.XmlConfigurator.Configure();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
            photo = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photo, 0, photo.Length);

            _studentsService.Add(new Students
            {
                IdentityNumber = IdentityNumberTextBox.Text,
                Name = NameTextBox.Text.ToUpper(),
                LastName = LastNameTextBox.Text.ToUpper(),
                Email = EMailTextBox.Text,
                BusinessPhoneNumber = BusinessPhoneTextBox.Text,
                HomePhoneNumber = HomePhoneTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                DateOfBirth = DateOfBirthPicker.Value,
                Picture = photo,
                Street = StreetRichTextBox.Text,
                City = CityComboBox.Text,
                DistrictRegion = RegionTextBox.Text
            });

            _studentsParentsService.addStudentsParents(new StudentsParents
            {
                StudentsIdentityNumber =  IdentityNumberTextBox.Text,
                FatherName = FatherNameTextBox.Text.ToUpper(),
                FatherLastName = FatherLastNameTextBox.Text.ToUpper(),
                FatherEMail = FatherEMailTextBox.Text
            });

        }

        private void CountryLabel_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
         



        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "Öğrenci Fotoğraf";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;
            pictureBox1.ImageLocation = DosyaYolu;

        }

        private void öğrenciEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            

        }

        private void öğrenciBilgileriGüncellemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

          
        }

        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
          
        }

      
        private void button4_Click_2(object sender, EventArgs e)
        {
             
            if (_studentsService.getStudents(textBox1.Text).IdentityNumber == null)
            {
                MessageBox.Show("Öğrenci Bulunulamadı");
            }
                IdentityNumberTextBox.Text = _studentsService.getStudents( textBox1.Text).IdentityNumber.ToString();
                byte[] photo_aray = _studentsService.getStudents( textBox1.Text).Picture;
                System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                Image img = (Image)converter.ConvertFrom(photo_aray);

                
                GetByStudentsData(img);
        }

        #region MyRegion
        private void GetByStudentsData(Image img)
        {
             
            NameTextBox.Text = _studentsService.getStudents( textBox1.Text).Name;
            LastNameTextBox.Text = _studentsService.getStudents( textBox1.Text).LastName;
            EMailTextBox.Text = _studentsService.getStudents( textBox1.Text).Email;
            BusinessPhoneTextBox.Text = _studentsService.getStudents( textBox1.Text).BusinessPhoneNumber;
            HomePhoneTextBox.Text = _studentsService.getStudents( textBox1.Text).HomePhoneNumber;
            PhoneNumberTextBox.Text = _studentsService.getStudents( textBox1.Text).PhoneNumber;
            pictureBox1.Image = img;
            DateOfBirthPicker.Value = _studentsService.getStudents( textBox1.Text).DateOfBirth;
            StreetRichTextBox.Text = _studentsService.getStudents( textBox1.Text).Street;
            CityComboBox.Text = _studentsService.getStudents( textBox1.Text).City;
            RegionTextBox.Text = _studentsService.getStudents( textBox1.Text).DistrictRegion;
            CountryComboBox.Text = _studentsService.getStudents( textBox1.Text).Country;
            RealitonsComboBox.Text = _studentsParentsService.GetStudentsParents( textBox1.Text).FamillyRealitions;
            FatherNameTextBox.Text = _studentsParentsService.GetStudentsParents( textBox1.Text).FatherName;
            FatherLastNameTextBox.Text = _studentsParentsService.GetStudentsParents( textBox1.Text).FatherLastName;
            FatherEMailTextBox.Text = _studentsParentsService.GetStudentsParents( textBox1.Text).FatherEMail;
            FatherTelephoneTextBox.Text = _studentsParentsService.GetStudentsParents( textBox1.Text).FatherPhoneNumber;
            MotherNameTextBox.Text = _studentsParentsService.GetStudentsParents( textBox1.Text).MotherName;
            MotherLastNameTextBox.Text = _studentsParentsService.GetStudentsParents( textBox1.Text).MotherLastName;
            MotherEMailTextBox.Text = _studentsParentsService.GetStudentsParents( textBox1.Text).MotherEMail;
            MotherTelephoneTextBox.Text = _studentsParentsService.GetStudentsParents( textBox1.Text).MotherPhoneNumber;
        }

        #endregion

        private void StudentsUpdateButton_Click(object sender, EventArgs e)
        {
            if (IdentityNumberTextBox.Text != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                photo = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo, 0, photo.Length);

                var r = _studentsService.getStudents(IdentityNumberTextBox.Text).Id;
                _studentsService.updateStudents(new Students()
                {
                    Id = r,
                    IdentityNumber =  IdentityNumberTextBox.Text,
                    Name = NameTextBox.Text.ToUpper(),
                    LastName = LastNameTextBox.Text.ToUpper(),
                    Email = EMailTextBox.Text,
                    BusinessPhoneNumber = BusinessPhoneTextBox.Text,
                    HomePhoneNumber = HomePhoneTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text,
                    DateOfBirth = DateOfBirthPicker.Value,
                    Picture = photo,
                    Street = StreetRichTextBox.Text,
                    City = CityComboBox.Text,
                    DistrictRegion = RegionTextBox.Text
                });

                _studentsParentsService.updateStudentsParents(new StudentsParents
                {
                    Id = _studentsParentsService.GetStudentsParents(IdentityNumberTextBox.Text).Id,
                    StudentsIdentityNumber = IdentityNumberTextBox.Text,
                    FatherName = FatherNameTextBox.Text.ToUpper(),
                    FatherLastName = FatherLastNameTextBox.Text.ToUpper(),
                    FatherEMail = FatherEMailTextBox.Text
                });
                MessageBox.Show("Öğrenci Bilgileri Güncellenmiştir");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dt = _studentsService.GettAll().ToList();
                //dataGridView1.DataSource = dt;
            gridControl1.DataSource = dt;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
            if (e.ColumnIndex == 0)
            {
                tabPage1.Show();
                textBox1.Text = _studentsService.getStudents( textBox2.Text).IdentityNumber.ToString();
            }
        }
    }
}