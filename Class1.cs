using System.Text.RegularExpressions;

namespace qualitylibrary
{
    public class Class1
    {
        public struct Employee
        {
            public string name;
            public string homephone;
            public string mobilephone;
            public DateTime birth;
            public DateTime hired;

            public void SetEmployee(string Name, string Homephone, string Mobilephone, string Birth, string Hired)
            {
                name = Name;
                homephone = Homephone;
                mobilephone = Mobilephone;
                datefix(Birth, Hired, ref birth, ref hired);
            }

            public void DisplayEmployee()
            {
                Console.WriteLine("Employee:");
                Console.WriteLine("\tName: " + name);
                Console.WriteLine("\tHomephone:" + homephone);
                Console.WriteLine("\tMobilephone: " + mobilephone);
                Console.WriteLine("\tBirthday: " + birth);
                Console.WriteLine("\tHired: " + hired + "\n");
            }
        }

        public static Employee[] emp;

        public static void Main(string[] args)
        {
            
        }

        //DateFix
        public static void datefix(string strbirth, string strhired, ref DateTime fixbirth, ref DateTime fixhired)
        {
            DateTime.TryParse(strbirth, out fixbirth);
            DateTime.TryParse(strhired, out fixhired);
        }

        //AddEmployee
        public static void AddEmployee(string newname, string newhomephone, string newmobilephone, string newbirth, string newhired)
        {
            int currentLength = emp.Length;
            Array.Resize(ref emp, currentLength + 1); // Resize the array to accommodate the new employee
                                                      //emp[currentLength] = new Employee();

            DateTime tempbirth = DateTime.MinValue;
            DateTime temphired = DateTime.MinValue;

            datefix(newbirth, newhired, ref tempbirth, ref temphired);

            int age = CalculateAge(tempbirth);

            if ((tempbirth>temphired) && age>18) 
            {
                emp[currentLength].SetEmployee(newname, newhomephone, newmobilephone, newbirth, newhired); // Add the new employee details
                emp[currentLength].DisplayEmployee();
            }
            
            else
            {
                throw new ArgumentException("Mistake with employee age or experience", nameof(age));
            }
        }

        //CalculateAge
        static int CalculateAge(DateTime birthdate)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthdate.Year;

            if (currentDate.Month < birthdate.Month || (currentDate.Month == birthdate.Month && currentDate.Day < birthdate.Day))
            {
                age--;
            }

            return age;
        }

        //ValidPhone
        public static bool ValidPhone(string phone)
        {
            string pattern = @"^(69\d{8}|2[1-8]\d{8})$";
            Regex rg = new Regex(pattern);
            Match match = rg.Match(phone);

            if (match.Success)
            {
                return true;
            }

            else return false;
        }

        //ValidName
        public static bool ValidName(string name)
        {
            foreach (var employee in emp)
            {
                if (employee.name == name)
                {
                    return true;
                }
            }
            return false;
        }

        //ValidPassword
        public static bool ValidPassword(string password)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{12,}).*[0-9]$";
            Regex rg = new Regex(pattern);
            Match match = rg.Match(password);

            if (match.Success)
            {
                return true;
            }

            else return false;
        }

        //InfoEmployee
        public static void InfoEmployee(Employee employee, ref int age, ref int yearofexp)
        {
            //find age
            var today = DateTime.Today;
            var truage = today.Year - employee.birth.Year;
            if (employee.birth.Date > today.AddYears(-truage)) truage--;
            age = Convert.ToInt32(truage);

            //findexp
            var truexp = today.Year - employee.hired.Year;
            if (employee.hired.Date < today.AddYears(+truexp)) truexp++;
            yearofexp = Convert.ToInt32(truexp);
        }

        //CheckPhone
        public static void CheckPhone(string phone, ref int typephone, ref string infophone)
        {
            bool check = ValidPhone(phone);

            if (check)
            {

                string newphone = phone[..1];
                string regphone = phone[..2];
                string regcell = phone[..3];

                if (newphone == "2")
                {
                    typephone = 0;

                    if (regphone == "21")
                    {
                        infophone = "Μητροπολιτική Περιοχή Αθήνας – Πειραιά";
                    }

                    else if (regphone == "22")
                    {
                        infophone = "Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου";
                    }

                    else if (regphone == "23")
                    {
                        infophone = "Κεντρική Μακεδονία";
                    }

                    else if (regphone == "24")
                    {
                        infophone = "Θεσσαλία, Δυτική Μακεδονία";
                    }

                    else if (regphone == "25")
                    {
                        infophone = "Θράκη, Ανατολική Μακεδονία";
                    }

                    else if (regphone == "26")
                    {
                        infophone = "Ήπειρος, Δυτική Στερεά Ελλάδα, Δυτική Πελοπόννησος, Ιόνια Νησιά";
                    }

                    else if (regphone == "27")
                    {
                        infophone = "Ανατολική Πελοπόννησος, Κύθηρα";
                    }

                    else
                    {
                        infophone = "Κρήτη";
                    }

                }

                else if (newphone == "6")
                {
                    typephone = 1;

                    if (regcell == "690" || regcell == "693" || regcell == "699")
                    {
                        infophone = "Nova";
                    }

                    else if (regcell == "694" || regcell == "695")
                    {
                        infophone = "Vodafone";
                    }

                    else if (regcell == "697" || regcell == "698")
                    {
                        infophone = "Cosmote";
                    }
                }
            }

            else
            {
                typephone = -1;
                infophone = null;
            }
        }

        //CipherKey
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }

        //EncryptionPass
        public static void EncryptPassword(string pass, ref string encryptedpass)
        {
            encryptedpass = string.Empty;

            foreach (char ch in pass)
            {
                encryptedpass += cipher(ch, 5);
            }
        }

        //LiveInAthens
        public static int LiveInAthens(Employee[] allemp)
        {
            int size = allemp.Length;
            int count = 0;
            int faketype = 0;
            string fakeinfo = "";

            for (int i = 0; i < size; i++)
            {
                CheckPhone(allemp[i].homephone, ref faketype, ref fakeinfo);

                if (faketype == 0 && fakeinfo == "Μητροπολιτική Περιοχή Αθήνας – Πειραιά")
                {
                    count++;
                }
            }

            return count;
        }
    }

}