using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    internal class DirectoryAction
    {
        List<Person> phoneDirectory = new List<Person>();
        public DirectoryAction()
        {
            // Default 3 değer atıyoruz rehbere
            phoneDirectory.Add(new Person("name1", "surname1", "05553331111"));
            phoneDirectory.Add(new Person("name2", "surname2", "05553332222"));
            phoneDirectory.Add(new Person("name3", "surname3", "05553333333"));
        }
        internal void Add()
        {
            Console.WriteLine("Lütfen isim giriniz             : ");
            string name = Console.ReadLine().ToLower();
            Console.WriteLine("Lütfen soyisim giriniz          : ");
            string surname = Console.ReadLine().ToLower();
            Console.WriteLine("Lütfen telefon numarası giriniz : ");
            string phoneNumber = Console.ReadLine().ToLower();
            phoneDirectory.Add(new Person(name,surname,phoneNumber));
            Console.WriteLine("Başarılı bir şekilde ekleme işlemi gerçekleştirildi.");
        }

        internal void Delete()
        {
            deleteHead:
            Console.WriteLine("Lütfen silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            var nameOrSurnameForDelete = Console.ReadLine().ToLower();
            var deletePersons = phoneDirectory.Where(p => p.Name == nameOrSurnameForDelete || p.Surname == nameOrSurnameForDelete).ToList();
            if (deletePersons.Count > 0)
            {
                var deletePerson = deletePersons.First();
                Console.WriteLine(deletePerson.Name + " " + deletePerson.Surname + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
                var confirmationToDelete = Console.ReadKey();
                Console.WriteLine();
                if (confirmationToDelete.KeyChar=='y')
                {
                    phoneDirectory.Remove(deletePerson);
                    Console.WriteLine(deletePerson.Name + " " + deletePerson.Surname + " isimli kişi rehberden silindi.");
                }
                else
                {
                    Console.WriteLine(deletePerson.Name + " " + deletePerson.Surname + " isimli kişi rehberden silinmedi.");
                    deleteBody:
                    Console.WriteLine("* Silmeyi sonlandırmak için : (1)\r\n" +
                        "* Yeniden denemek için      : (2)");
                    var chooseToValue = Console.ReadLine(); 
                    if (chooseToValue == "2")
                        goto deleteHead;
                    else if (chooseToValue != "1")
                    {
                        Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                        goto deleteBody;
                    }
                }

            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\r\n");
                deleteBody:
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)\r\n" +
                    "* Yeniden denemek için      : (2)");
                var chooseToValue = Console.ReadLine();
                if (chooseToValue == "2")
                    goto deleteHead;
                else if (chooseToValue!="1")
                {
                    Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                    goto deleteBody;
                }
            }
        }

        internal void Update()
        {
            updateHead:
            Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
            var nameOrSurnameForUpdate = Console.ReadLine().ToLower();
            var updatePersons = phoneDirectory.Where(p => p.Name == nameOrSurnameForUpdate || p.Surname == nameOrSurnameForUpdate).ToList();
            if (updatePersons.Count>0)
            {
                var updatePerson=updatePersons.First();
                Console.WriteLine(updatePerson.Name + " " + updatePerson.Surname + " isimli kişinin yeni numarasını giriniz:");
                var updateNewNumber = Console.ReadLine();
                updatePerson.Number = updateNewNumber;
                Console.WriteLine(updatePerson.Name + " " + updatePerson.Surname + " isimli kişinin numarası değiştirildi.");

            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\r\n");
                updateBody:
                Console.WriteLine("* Güncellemeyi sonlandırmak için : (1)\r\n" +
                    "* Yeniden denemek için      : (2)");
                var chooseToValue = Console.ReadLine();
                if (chooseToValue == "2")
                    goto updateHead;
                else if (chooseToValue != "1")
                {
                    Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                    goto updateBody;
                }

            }

        }

        internal void List()
        {
            Console.WriteLine("Telefon Rehberi\r\n" +
                "**********************************************");
            foreach (var person in phoneDirectory)
            {
                Console.WriteLine("Isim:{"+ person.Name + "} Soyisim:{"+ person.Surname + "} Telefon Numarası:{"+ person.Number + "} ");
            }
        }

        internal void Search()
        {
            searchHead:
            Console.WriteLine("Arama yapmak istediğiniz isim,soyisim veya telefon numarasını giriniz:");
            var searchPerson= Console.ReadLine();
            var foundPeopleBySearch = phoneDirectory.Where(p => p.Name.Contains(searchPerson) || p.Surname.Contains(searchPerson) || p.Number.Contains(searchPerson)).ToList();
            if (foundPeopleBySearch.Count()>0)
            {
                foreach (var foundPersonBySearch in foundPeopleBySearch)
                {
                    Console.WriteLine("Isim:{" + foundPersonBySearch.Name + "} Soyisim:{" + foundPersonBySearch.Surname + "} Telefon Numarası:{" + foundPersonBySearch.Number + "} ");
                }
            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                
            }
            searchBody:
            Console.WriteLine("* Aramayı sonlandırmak için : (1)\r\n" +
                    "* Yeniden denemek için      : (2)");
            var chooseToValue = Console.ReadLine();
            if (chooseToValue == "2")
            {
                goto searchHead;
            }
            else if (chooseToValue != "1")
            {
                Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                goto searchBody;
            }
        }

    }
}
