

//https://academy.patika.dev/tr/courses/csharp-101/19-proje-1

using PhoneDirectory;

DirectoryAction directoryActions = new DirectoryAction();
string menuHeadString = "Telefon Rehberine Hoşgelidiniz";
string menuString = "1-Telefon numarası kaydet\n" +
        "2-Telefon numarası sil\n" +
        "3-Telefon numarası güncelle\n" +
        "4-Telefon rehberini listele\n" +
        "5-Rehberde arama\n" +
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
            directoryActions.Add();
            break;
        case "2":
            Console.WriteLine("----------------------------------------");
            directoryActions.Delete();
            break;
        case "3":
            Console.WriteLine("----------------------------------------");
            directoryActions.Update();
            break;
        case "4":
            Console.WriteLine("----------------------------------------");
            directoryActions.List();
            break;
        case "5":
            Console.WriteLine("----------------------------------------");
            directoryActions.Search();
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