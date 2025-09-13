using Microsoft.VisualStudio.TestTools.UnitTesting;
using qualitylibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static qualitylibrary.Class1;

namespace qualitylibrary.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
         public void TestSetEmployee_ValidInput()
        {
            Class1.Employee testEmployee = new Class1.Employee();
            testEmployee.SetEmployee("John Doe", "2101234567", "6934567890", "01/01/1990", "01/01/2022");
            Assert.AreEqual("John Doe", testEmployee.name, "Αναφορά σφάλματος 1: Η μέθοδος SetEmployee δεν διέπραξε σωστή εκχώρηση ονόματος.");
        }

        [TestMethod()]
        public void TestSetEmployeeWithEmptyName()
        {
            Class1.Employee testEmployee = new Class1.Employee();
            testEmployee.SetEmployee(null, "2105766642", "6987654321", "2000-01-01", "2022-01-01");
            Assert.IsNotNull(testEmployee.name, "Αναφορά σφάλματος 1: Η μέθοδος SetEmployee δεν διέπραξε σωστή εκχώρηση ονόματος");
        }

        [TestMethod()]
        public void TestValidName_Valid()
        {
            Class1.emp = new Class1.Employee[] {
                new Class1.Employee { name = "Nikos" },
                new Class1.Employee { name = "Andreas" },
            };

            bool result = Class1.ValidName("Nikos");

            Assert.IsTrue(result, "Αναφορά σφάλματος 2: Η μέθοδος Validname απέτυχε να αναγνωρίσει έγκυρο όνομα.");
        }

        [TestMethod()]
        public void TestValidName_Invalid()
        {
            Class1.emp = new Class1.Employee[] {
                new Class1.Employee { name = "Nikos" },
                new Class1.Employee { name = "Alexis" },
                // Add more sample employees as needed
            };

            bool result = Class1.ValidName("Andreas");

            Assert.IsTrue(result, "Αναφορά σφάλματος 2: Η μέθοδος Validname απέτυχε να αναγνωρίσει έγκυρο όνομα.");
        }

        [TestMethod()]
        public void TestValidPassword_Valid()
        {
            bool temppass = Class1.ValidPassword("Abc123defG!@2");
            Assert.AreEqual(temppass, true, "Aναφορά σφάλματος 3: Δόθηκε μη έγκυρος κωδικός.");
        }

        [TestMethod()]
        public void TestValidPassword_InValid()
        {
            bool temppass = Class1.ValidPassword("dsag459");
            Assert.AreEqual(temppass, true, "Aναφορά σφάλματος 3: Δόθηκε μη έγκυρος κωδικός.");
        }

        [TestMethod()]
        public void TestEncryptPassword_Valid()
        {
            string inputPassword = "HelloWorld";
            string expectedEncryptedPassword = "MjqqtBtwqi";
            string encryptedPassword = "";
            Class1.EncryptPassword(inputPassword, ref encryptedPassword);

            Assert.AreEqual(expectedEncryptedPassword, encryptedPassword, "Αναφορά σφάλματος 4: Μη δυνατή κρυπτογράφιση κωδικού");
        }

        [TestMethod()]
        public void TestEncryptPassword_Valid_NonLetterCharacters()
        {
            string inputPassword = "123!@#";
            string expectedEncryptedPassword = "123!@#";
            string encryptedPassword = "";
            Class1.EncryptPassword(inputPassword, ref encryptedPassword);

            Assert.AreEqual(expectedEncryptedPassword, encryptedPassword, "Αναφορά σφάλματος 4: Μη δυνατή κρυπτογράφιση κωδικού");
        }

        [TestMethod()]
        public void TestEncryptPassword_Valid_Empty()
        {
            string inputPassword = "";
            string encryptedPassword = "";
            Class1.EncryptPassword(inputPassword, ref encryptedPassword);

            Assert.AreEqual("", encryptedPassword, "Αναφορά σφάλματος 4: Μη δυνατή κρυπτογράφιση κωδικού");
        }

        [TestMethod()]
        public void TestCheckPhone_ValidLandlinePhone()
        {
            int type = 0;
            string info = "";
            Class1.CheckPhone("2105234567", ref type, ref info);
            Assert.AreEqual(0, type, "Αναφορά σφάλματος 5: Η μέθοδος Checkphone δεν αναγνώρισε σωστά σταθερό τηλέφωνο.");
        }

        [TestMethod()]
        public void TestCheckPhone_MobilePhone()
        {
            int type = 0;
            string info = "";
            Class1.CheckPhone("6934567890", ref type, ref info);

            Assert.AreEqual(1, type, "Αναφορά σφάλματος 5: Η μέθοδος Checkphone δεν αναγνώρισε σωστά κινητό τηλέφωνο.");
        }

        [TestMethod()]
        public void TestCheckPhone_InvalidPhone()
        {
            int type = 0;
            string info = "";
            Class1.CheckPhone("123", ref type, ref info);

            Assert.AreNotEqual(-1, type, "Αναφορά σφάλματος 6: Η μέθοδος Checkphone δεν αναγνώρισε μη έγκυρο τηλέφωνο.");
        }

        [TestMethod()]
        public void TestInfoEmployee_ValidInfo()
        {
            Class1.Employee[] testEmployees = new Class1.Employee[1];
            testEmployees[0] = new Class1.Employee();

            testEmployees[0].birth = new DateTime(2001, 3, 9);
            testEmployees[0].hired = new DateTime(2020, 3, 7);

            int age = 0;
            int exp = 0;

            Class1.InfoEmployee(testEmployees[0], ref age, ref exp);

            Assert.AreEqual(22, age, "Αναφορά Σφάλματος 7: Πρόβλημα με την ηλικία του Υπαλλήλου");
            Assert.AreEqual(5, exp, "Αναφορά Σφάλματος 7: Πρόβλημα με τα χρόνια εμπειρίας του Υπαλλήλου");
        }

        [TestMethod()]
        public void TestLiveInAthens_ValidInfo()
        {
            Class1.Employee[] employees = new Class1.Employee[]
            {
                new Class1.Employee { name = "Nikos", homephone = "2101234567" }, 
                new Class1.Employee { name = "Alexis", homephone = "2319876543" }, 
                new Class1.Employee { name = "Andreas", homephone = "2105761532" },
            };

            int result = Class1.LiveInAthens(employees);

            Assert.AreEqual(2, result, "Αναφορά σφάλματος 8: Πρόβλημα με το τηλέφωνο των υπαλλήλων");
        }

    }
}