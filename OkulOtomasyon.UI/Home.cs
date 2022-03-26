using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.Concrete.Managers;
using OkulOtomasyon.DataAccess.Concrete.EntityFramework;
using OkulOtomasyon.Entities.Concrete;


namespace OkulOtomasyon.UI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        
        private IStudentsService _StudentsService = new StudentsManager(new EfStudentsDal()); 
        private IStudentsParentsService _studentsParentsService = new StudentsParentsManager(new EfStudentsParentsDal());
        
        private void Home_Load(object sender, EventArgs e)
        {
             
           
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
            byte[] photo = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photo, 0, photo.Length);

            _StudentsService.addStudents(new Students
            {
                IdentityNumber = IdentityNumberTextBox.Text,
                Name = NameTextBox.Text,
                LastName = LastNameTextBox.Text,
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
                StudentsIdentityNumber = IdentityNumberTextBox.Text,
                FatherName = FatherNameTextBox.Text,
                FatherLastName = FatherLastNameTextBox.Text,
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
                IdentityNumberTextBox.Text = _StudentsService.getStudents(textBox1.Text).IdentityNumber;
                byte[] photo_aray = _StudentsService.getStudents(textBox1.Text).Picture;
                System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                Image img = (Image)converter.ConvertFrom(photo_aray);

                
                NameTextBox.Text = _StudentsService.getStudents(textBox1.Text).Name;
                LastNameTextBox.Text = _StudentsService.getStudents(textBox1.Text).LastName;
                EMailTextBox.Text = _StudentsService.getStudents(textBox1.Text).Email;
                BusinessPhoneTextBox.Text = _StudentsService.getStudents(textBox1.Text).BusinessPhoneNumber;
                HomePhoneTextBox.Text = _StudentsService.getStudents(textBox1.Text).HomePhoneNumber;
                PhoneNumberTextBox.Text = _StudentsService.getStudents(textBox1.Text).PhoneNumber;
                pictureBox1.Image = img;
                DateOfBirthPicker.Value = _StudentsService.getStudents(textBox1.Text).DateOfBirth;
                StreetRichTextBox.Text = _StudentsService.getStudents(textBox1.Text).Street;
                CityComboBox.Text = _StudentsService.getStudents(textBox1.Text).City;
                RegionTextBox.Text = _StudentsService.getStudents(textBox1.Text).DistrictRegion;
                CountryComboBox.Text = _StudentsService.getStudents(textBox1.Text).Country;
                RealitonsComboBox.Text = _studentsParentsService.GetStudentsParents(textBox1.Text).FamillyRealitions;
                FatherNameTextBox.Text = _studentsParentsService.GetStudentsParents(textBox1.Text).FatherName;
                FatherLastNameTextBox.Text = _studentsParentsService.GetStudentsParents(textBox1.Text).FatherLastName;
                FatherEMailTextBox.Text = _studentsParentsService.GetStudentsParents(textBox1.Text).FatherEMail;
                FatherTelephoneTextBox.Text = _studentsParentsService.GetStudentsParents(textBox1.Text).FatherPhoneNumber;
                MotherNameTextBox.Text = _studentsParentsService.GetStudentsParents(textBox1.Text).MotherName;
                MotherLastNameTextBox.Text = _studentsParentsService.GetStudentsParents(textBox1.Text).MotherLastName;
                MotherEMailTextBox.Text = _studentsParentsService.GetStudentsParents(textBox1.Text).MotherEMail;
                MotherTelephoneTextBox.Text = _studentsParentsService.GetStudentsParents(textBox1.Text).MotherPhoneNumber;

          
        }

        private void StudentsUpdateButton_Click(object sender, EventArgs e)
        {
            _StudentsService.updateStudents()
        }
    }
}