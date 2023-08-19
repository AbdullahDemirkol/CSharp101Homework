

//https://academy.patika.dev/tr/courses/csharp-101/20-proje-2


using ToDoConsoleApplication;

Member members = new Member();
members.AddMember(new Member(1, "member1"));
members.AddMember(new Member(2, "member2"));
members.AddMember(new Member(3, "member3"));
Board board= new Board();


string menuHeadString = "ToDo Listesine Hoşgelidiniz";
string menuString = "1-Board Listelemek\n" +
        "2-Board'a Kart Eklemek\n" +
        "3-Board'dan Kart Silmek\n" +
        "4-Kart Taşımak\n" +
        "5-Üyeleri Listelemek\n"+
        "0-Çıkış";
var status = true;
while (status)
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine(menuHeadString);
    Console.WriteLine(menuString);

    var choose = Console.ReadLine();
    switch (choose)
    {
        case "1":
            Console.WriteLine("----------------------------------------");
            board.ListBoard(board);
            break;
        case "2":
            Console.WriteLine("----------------------------------------");
            board.AddCard(board,members);
            break;
        case "3":
            Console.WriteLine("----------------------------------------");
            board.DeleteCard(board);
            break;
        case "4":
            Console.WriteLine("----------------------------------------");
            board.MoveCard(board);
            break;
        case "5":
            Console.WriteLine("----------------------------------------");
            board.ListMember(members);
            break;
        case "0":
            status = false;
            break;
        default:
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Hatalı tuşlama yaptınız. Tekrar deneyiniz.");
            break;
    }
}