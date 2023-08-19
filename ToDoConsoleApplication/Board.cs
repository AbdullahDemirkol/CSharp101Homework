using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoConsoleApplication
{
    internal class Board
    {
        public List<Card> ToDo { get; set; }
        public List<Card> InProgress { get; set; }
        public List<Card> Done { get; set; }

        public Board()
        {
            ToDo = new List<Card>();
            InProgress = new List<Card>();
            Done = new List<Card>();
        }

        public void ListBoard(Board board)
        {
            Console.WriteLine("\nTODO Line\n************************");
            foreach (var toDo in board.ToDo)
            {
                Console.WriteLine("Başlık: {0}", toDo.Title);
                Console.WriteLine("İçerik: {0}", toDo.Content);
                Console.WriteLine("Atanan Üye: {0}", toDo.AssignedPerson);
                Console.WriteLine("Boyutu: {0}\n-", toDo.CardSize);
            }
            Console.WriteLine("Finish TODO Line");
            Console.WriteLine("\nIN PROGRESS Line\n************************");
            foreach (var inProgress in board.InProgress)
            {

                Console.WriteLine("Başlık: {0}", inProgress.Title);
                Console.WriteLine("İçerik: {0}", inProgress.Content);
                Console.WriteLine("Atanan Üye: {0}", inProgress.AssignedPerson);
                Console.WriteLine("Boyutu: {0}\n-", inProgress.CardSize);
            }
            Console.WriteLine("Finish IN PROGRESS Line");

            Console.WriteLine("\nDONE Line\n************************");
            foreach (var done in board.Done)
            {
                Console.WriteLine("Başlık: {0}", done.Title);
                Console.WriteLine("İçerik: {0}", done.Content);
                Console.WriteLine("Atanan Üye: {0}", done.AssignedPerson);
                Console.WriteLine("Boyutu: {0}\n-", done.CardSize);
            }
            Console.WriteLine("Finish DONE Line");
        }

        public void ListMember(Member member)
        {
            var members = member.GetMembers();

            Console.WriteLine("\nMember List\n************************");
            foreach (var singleMember in members)
            {
                Console.WriteLine("Üye Adı: {0}\n-", singleMember.TeamMemberName);
            }
        }

        public void AddCard(Board board, Member member)
        {
            addHead:
            Console.WriteLine("Hangi alana kart eklemek isterseniz?\n" +
                "1 - ToDo\n" +
                "2 - InProgress\n" +
                "3 - Done");
            var selectMenu = Console.ReadLine();
            if (selectMenu!=((int)CardLineEnum.ToDo).ToString() && selectMenu!= ((int)CardLineEnum.InProgress).ToString() && selectMenu!= ((int)CardLineEnum.Done).ToString())
            {
                Console.WriteLine("Hatalı tuşlama yapıldır.");
                goto addHead;
            }
            Console.Write("Başlık giriniz: ");
            string title = Console.ReadLine();
            Console.Write("İçerik giriniz: ");
            string content = Console.ReadLine();
            addCardSize:
            Console.WriteLine("Boyut Giriniz:\n" +
                "1 - XS\n" +
                "2 - S\n" +
                "3 - M\n" +
                "4 - L\n" +
                "5 - XL");
            string size = Console.ReadLine();
            CardSizeEnum cardSize;
            switch (size)
            {
                case "1":
                    cardSize= CardSizeEnum.XS;
                    break;

                case "2":
                    cardSize = CardSizeEnum.S;
                    break;

                case "3":
                    cardSize = CardSizeEnum.M;
                    break;

                case "4":
                    cardSize = CardSizeEnum.L;
                    break;

                case "5":
                    cardSize = CardSizeEnum.XL;
                    break;

                default:
                    Console.WriteLine("Hatalı tuşlama yapıldı. Lütfen Tekrar Deneyiniz");
                    goto addCardSize;
            }
            getMember:
            Console.Write("Atanıcak üyenin adını giriniz: ");
            var assignedPersonName= Console.ReadLine();
            var members = member.GetMembers();
            var memberBySearch = members.FirstOrDefault(p => p.TeamMemberName == assignedPersonName);

            if (memberBySearch==null)
            {
                Console.WriteLine("Hatalı isim girildi. Lütfen Tekrar Deneyiniz");
                goto getMember;
            }
            if (selectMenu=="1")
            {
                Card card = new Card(title, content, assignedPersonName, cardSize, CardLineEnum.ToDo);
                board.ToDo.Add(card);
            }
            else if (selectMenu == "2")
            {
                Card card = new Card(title, content, assignedPersonName, cardSize, CardLineEnum.InProgress);
                board.InProgress.Add(card);
            }
            else if (selectMenu == "3")
            {
                Card card = new Card(title, content, assignedPersonName, cardSize, CardLineEnum.Done);
                board.Done.Add(card);
            }
            Console.WriteLine(" Yeni kart ekleme işlemi başarılı bir şekilde gerçekleştirildi.");
        }

        internal void DeleteCard(Board board)
        {
            deleteHead:
            Console.Write("\nSilmek istediğiniz kartın başlığını giriniz: ");
            string title = Console.ReadLine();
            int found = 0;
            var toDoCard = board.ToDo.FirstOrDefault(p => p.Title == title);
            var inProgresCard = board.InProgress.FirstOrDefault(p => p.Title == title);
            var doneCard = board.Done.FirstOrDefault(p => p.Title == title);
            if (toDoCard!=null)
            {
                found = 1;
                board.ToDo.Remove(toDoCard);
            }
            else if (inProgresCard!=null)
            {
                found = 2;

                board.InProgress.Remove(inProgresCard);
            }
            else if (doneCard!=null)
            {
                found = 3;
                board.Done.Remove(doneCard);
            }
            else if (found==0)
            {

                Console.WriteLine("Aradığınız başlığa ait kart bulunamadı. Lütfen bir seçim yapınız.\r\n");
                deleteBody:
                Console.WriteLine("* İşlemi sonlandırmak için : (1)\r\n " +
                    "* Yeniden denemek için : (2)");
                var chooseToValue = Console.ReadLine();
                if (chooseToValue == "2")
                    goto deleteHead;
                else if (chooseToValue != "1")
                {
                    Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                    goto deleteBody;
                }

            }
            Console.WriteLine("Kart başarılı bir şekilde silindi.");
        }

        internal void MoveCard(Board board)
        {
            moveHead:
            Console.WriteLine("Taşımak istediğiniz kartın başlığını giriniz:\r\n");
            string title = Console.ReadLine();
            int found = 0;
            var toDoCard = board.ToDo.FirstOrDefault(p => p.Title == title);
            var inProgresCard = board.InProgress.FirstOrDefault(p => p.Title == title);
            var doneCard = board.Done.FirstOrDefault(p => p.Title == title);
            if (toDoCard != null)
            {
                found = 1;
                Console.WriteLine(title + " başlıklı kartı hangi alana taşımak istiyorsunuz:\n" +
                "1 - InProgress\n" +
                "2 - Done\n");
                var selectMenu = Console.ReadLine();
                if (selectMenu == "1")
                {
                    board.ToDo.Remove(toDoCard);
                    toDoCard.Line = CardLineEnum.InProgress;
                    board.InProgress.Add(toDoCard);
                    Console.WriteLine("In progress alanına başarılı bir şekilde taşındı.");
                }
                else if (selectMenu == "2")
                {
                    board.ToDo.Remove(toDoCard);
                    toDoCard.Line = CardLineEnum.Done;
                    board.Done.Add(toDoCard);
                    Console.WriteLine("Done alanına başarılı bir şekilde taşındı.");
                }
                else
                {

                    Console.WriteLine("Hatalı tuşlama yapıldı. Lütfen bir seçim yapınız.\r\n");
                    moveBody:
                    Console.WriteLine("* İşlemi sonlandırmak için : (1)\r\n " +
                        "* Yeniden denemek için : (2)");
                    var chooseToValue = Console.ReadLine();
                    if (chooseToValue == "2")
                        goto moveHead;
                    else if (chooseToValue != "1")
                    {
                        Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                        goto moveBody;
                    }
                }
            }
            else if (inProgresCard != null)
            {

                found = 2;
                Console.WriteLine(title + " başlıklı kartı hangi alana taşımak istiyorsunuz:\n" +
                "1 - ToDo\n" +
                "2 - Done\n");
                var selectMenu = Console.ReadLine();
                if (selectMenu == "1")
                {
                    board.InProgress.Remove(inProgresCard);
                    inProgresCard.Line = CardLineEnum.ToDo;
                    board.ToDo.Add(inProgresCard);
                    Console.WriteLine("ToDo alanına başarılı bir şekilde taşındı.");
                }
                else if (selectMenu == "2")
                {
                    board.InProgress.Remove(inProgresCard);
                    inProgresCard.Line = CardLineEnum.Done;
                    board.Done.Add(inProgresCard);
                    Console.WriteLine("Done alanına başarılı bir şekilde taşındı.");
                }
                else
                {

                    Console.WriteLine("Hatalı tuşlama yapıldı. Lütfen bir seçim yapınız.\r\n");
                    moveBody:
                    Console.WriteLine("* İşlemi sonlandırmak için : (1)\r\n " +
                        "* Yeniden denemek için : (2)");
                    var chooseToValue = Console.ReadLine();
                    if (chooseToValue == "2")
                        goto moveHead;
                    else if (chooseToValue != "1")
                    {
                        Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                        goto moveBody;
                    }
                }
            }
            else if (doneCard != null)
            {

                found = 3;
                Console.WriteLine(title + " başlıklı kartı hangi alana taşımak istiyorsunuz:\n" +
                "1 - ToDo\n" +
                "2 - InProgress\n");
                var selectMenu = Console.ReadLine();
                if (selectMenu == "1")
                {
                    board.Done.Remove(doneCard);
                    doneCard.Line = CardLineEnum.ToDo;
                    board.ToDo.Add(doneCard);
                    Console.WriteLine("ToDo alanına başarılı bir şekilde taşındı.");
                }
                else if (selectMenu == "2")
                {
                    board.Done.Remove(doneCard);
                    doneCard.Line = CardLineEnum.InProgress;
                    board.InProgress.Add(doneCard);
                    Console.WriteLine("In progress alanına başarılı bir şekilde taşındı.");
                }
                else
                {

                    Console.WriteLine("Hatalı tuşlama yapıldı. Lütfen bir seçim yapınız.\r\n");
                    moveBody:
                    Console.WriteLine("* İşlemi sonlandırmak için : (1)\r\n " +
                        "* Yeniden denemek için : (2)");
                    var chooseToValue = Console.ReadLine();
                    if (chooseToValue == "2")
                        goto moveHead;
                    else if (chooseToValue != "1")
                    {
                        Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                        goto moveBody;
                    }
                }
            }
            else if (found == 0)
            {

                Console.WriteLine("Aradığınız başlığa ait kart bulunamadı. Lütfen bir seçim yapınız.\r\n");
                moveBody:
                Console.WriteLine("* İşlemi sonlandırmak için : (1)\r\n " +
                    "* Yeniden denemek için : (2)");
                var chooseToValue = Console.ReadLine();
                if (chooseToValue == "2")
                    goto moveHead;
                else if (chooseToValue != "1")
                {
                    Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                    goto moveBody;
                }

            }
        }
    }
}
