using System.Collections;
using System.Collections.Immutable;
using System.Text;
using System.Text.Json.Serialization;
using Business.Abstract;
using Business.Concrete;
using ConsoleUI;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

#region Değişkenler
// var yil = 2023; // Derlemede aşamasında veri tipini kendisi belirliyor

// Type safety, tip güvenli
// Bellekte kaplacayacağı alanı önceden ayırmış oluyoruz hem de, alabileceği değerleri ve aralığını belirlemiş oluyoruz.

// İlkel/Değer tip
//int yil = 2023; // 32-bit ~-2.1mr - ~2.1mr // default değeri: 0 (ondalik) // 00000000 (ikilik)
//short yil = 2023; // 16-bit ~-32bin - ~32bin // default: 0

ushort yil = 2023; // unsigned // 16-bit 0 - ~65bin // default: 0

byte yas = 25; // 0-255 // default: 0
long hesaplamaTamSayiSonucu = 9999999999999; // 64-bit // default: 0

//float dolarKuru = 29.06f; // 32-bit // default: 0.0
double dolarKuru = 29.06593; // 64-bit // default: 0.0
decimal hesaplamaSonucu = 29.06592312931290312903m; // 128-bit // default: 0.0

bool girisYaptiMi = true; // 1-bit // default: false

char karakter = 'A'; // 65 // Ek bilgi: Unicode ASCII tablolarına göre 65 // 16-bit // default: 0 // Unicode ASCII U+0000 (NULL)

// String aslında bir referans tip, İlkel/Değer tip
string isim = "Ahmet"; // 32-bit // 16mr-bit'e kadar genişleyebiliyor // default: null

string? takmaAd = null;

//if (takmaAd != null)
//    Console.WriteLine(takmaAd.ToUpper()); // takmaAd null ise ToUpper metodunu çalıştırmaya çalışmayacak ve null değerini bize verecek.

//Console.WriteLine(takmaAd?.ToUpper()); // takmaAd null ise ToUpper metodunu çalıştırmaya çalışmayacak ve null değerini bize verecek.

//Console.WriteLine(takmaAd ?? "Takma ismi bulunmuyor"); // takmaAd null ise sağdaki değeri bize verecek.

// ek bilgi: DRY - Do not Repeat Yourself
// ek bilgi: mccall software quality model

int sayi1 = 10;
int sayi2 = 20;
int sayi3 = 30;
int sayiSonuc = sayi1 + sayi2 * sayi3;

string isim2 = "Ahmet";
string soyad = "Çetinkaya";
string tamIsim = isim2 + " " + soyad;

bool durum1 = true;
bool durum2 = false;
bool sonucDurum = durum1 && durum2; // false
bool sonucDurum2 = durum1 || durum2; // true

int tamSayi = 10;
double ondalikLiSayi = tamSayi; // 10.0 // Implisit (biliçsiz) tür dönüşümü

double ondalikliSayi2 = 10.5;

//int tamSayi2 = ondalikliSayi2; // Veri kaybı olacağı için implist şekilde tür dönüşümü yapmayacaktır
int tamSayi2 = (int)ondalikliSayi2; // Casting // Explist (bilinçli) tür dönüşümü

long buyukTamSayi = long.MaxValue; // 64-bit
int normalTamSayi = (int)buyukTamSayi; // 64-bit -> 32-bit // Hata: -1

// Daha güvenli tür dönüşüm işlemleri için:
//int normalTamSayi2 = Convert.ToInt32(buyukTamSayi); // Error: değer int'e göre çok büyük
string metinselTamSayi = buyukTamSayi.ToString();

//double 2OndalıkSayı // Invalid
double ondalik_sayi = long.MaxValue; // Valid

//double double = double.MaxValue;
double @double = double.MaxValue;

//double ondalik sayi = long.MaxValue; // Invalid

//long cokBuyukTamsayi = long.MaxValue + 1; // Overflow error

long cokBuyukTamsayi = long.MaxValue;
//Console.WriteLine(cokBuyukTamsayi + 1); // Sayımız ilgili veri tipinin MinValue değerine geri döner.

#endregion

#region Koşullu ifade

bool durum3 = false;
bool durum4 = true;

//if (durum3)
//    Console.WriteLine("Durum 3 Geçerli");

//if (durum3)
//{
//    Console.WriteLine("Durum 3 Geçerli");
//}
//else if (durum4)
//{
//    Console.WriteLine("Durum 4 Geçerli");
//}
//else
//{
//    Console.WriteLine("Durumlar Geçersiz");
//}

string komut = "delete";

//if (komut == "add" || komut == "update")
//    Console.WriteLine("Ekleme işlemi tamamlandı");
//else if (komut == "delete")
//    Console.WriteLine("Silme işlemi tamamlandı");

//switch (komut)
//{
//    case "add":
//    case "update":
//        Console.WriteLine("Ekleme işlemi tamamlandı");
//        break;

//    case "delete":
//        Console.WriteLine("Silme işlemi tamamlandı");
//        break;

//    default:
//        Console.WriteLine("Geçersiz işlem.");
//        break;
//}


string mesaj; // default: null

if (komut == "add" || komut == "update")
    mesaj = "Ekleme işlemi tamamlandı";
else if (komut == "delete")
    mesaj = "Silme işlemi tamamlandı";

mesaj =
    komut == "add"
        ? "Ekleme işlemi tamamlandı" // ternary opreator
        : komut == "delete"
            ? "Silme işlemi tamamlandı"
            : "Geçersiz işlem";

mesaj = komut switch
{
    "add" => "Ekleme işlemi tamamlandı",
    "delete" => "Silme işlemi tamamlandı",
    _ => "Geçersiz işlem"
};

//Console.WriteLine(mesaj);

#endregion

#region Döngüler

int sayi4 = 10;
int sayi5 = sayi4++;
int birArttir(int sayi)
{
    int temp = sayi;
    sayi = sayi + 1;
    return temp;
}
int sayi6 = ++sayi4;
int onceBirArttir(int sayi)
{
    sayi = sayi + 1;
    return sayi;
}

//int sayi6 = ++sayi4;
//Console.WriteLine(sayi6);

for (
    int index = 0; // Döngünün en başında bir kere çalışan komutumuz
    index < 10; // Her döngünün başında kontrol ettiğimiz koşul
        ++index // index++ // index = index + 1 // index += 1 // Her döngünün sonunda çalışan atama komutuz
)
{
    if (index == 5)
        continue; // Bu döngü adımına devam etmeden bir sonraki döngü admına geçer

    if (index == 7)
        break; // Döngü sürecini tamamen bitirir

    //for (int i = 0; i < 10; ++i)
    //{ if (i == 0) continue;}

    //Console.WriteLine(index);
}

int index2 = 0;
while (index2 < 10)
{
    //if (index2 == 5) continue; // Sonsuz döngü oluşturmuş oluruz
    if (index2 == 5)
    {
        index2 += 1;
        continue;
    }

    if (index2 == 7)
        break;

    //Console.WriteLine(index2);

    index2 += 1;
}

//while (true // Her döngünün başında kontrol ettiğimiz koşul
//) // Sonsuz döngülerden her daim kaçınmamız gerekiyor, çünkü program o noktada tıkanacaktır
//{
//    // İstisna durumlarda sürekli kontrol için sonsuz döngüler oluşturulabilir fakat programı aksatmayacak ayrı bir işlem parçacığında çalışması gerekiyor
//}

do
{
    // Döngünün ilk adımında herhangi bir koşula tabi olmadan ilgili işlemler yapılır
    // Döngünün sonraki adımlarında
} while (false); // Her döngünün sonunda kontrol ettiğimiz koşul

//Console.WriteLine("Program Bitti");

#endregion

#region Metot ve Fonksiyonlar

// [Döndürülen değerin veri tipi] [METOTUN İSMİ] ( [PARAMETERLER] ) { }

void yazdir(string icerik)
{
    // ...
    //Console.WriteLine(icerik); // Printer'a içeriği yazdıran fonksiyon olarak da düşünebiliriz.
}

// Fonksiyon

int topla(
    // Parametre tanımlama özellikleri
    int sayi1, // Zorunlu parametre
    int sayi2 = 0, // Opsiyonel parametre // En son olacak şekilde kullanabiliriz.
    int sayi3 = 10
)
{
    int toplamaSonuc = sayi1 + sayi2;
    // ...
    // ...
    // ...
    // ...
    // ...

    return toplamaSonuc;
} // Modülerlik

// Fonksiyonlarda overload yok, metotlarda yapilabilir

// Parametre verme biçimleri
int sonuc = topla(40, 10); // Paramete pozisyon bazlı parametre geçtik
int sonuc2 = topla(sayi3: 100, sayi1: 40); // Tekrar kullanılabilir // Okunabilirlik // Paramete isim bazlı parametre geçtik

yazdir(sonuc.ToString()); // Pozisyon bazlı parametre

// Params
int hepsiniTopla(
    // Parametre tanımlama özellikleri
    int baslangicSayisi,
    params int[] sayilar
) // params sadece bir tane ve en son olacak şekilde kullanabiliriz.
{
    int toplam = baslangicSayisi;
    foreach (int sayi in sayilar)
    {
        toplam += sayi;
    }
    return toplam;
}

int sonuc3 = hepsiniTopla(0, 40, 60, 90, 50, 20);

// ref, out // temel/ilkel veri tipleri üzerinde kullanılır

// ref, fonksiyona kendi içinde değişken oluşturma, referans ettiğim değişkeni kullan demiş oluyoruz.
void ikiyleCarpımınıDosyaOlarakKaydet(ref int sayi, out int sayi2)
{
    sayi *= 2;
    sayi2 = 1; // out, Fonksiyon/Metot içinde ilk atama işlemini verme zorunluğuğu getirir.

    //Console.WriteLine($"ikiyleCarpımınıDosyaOlarakKaydet scope sayi: {sayi}");
    //.. bu parametre değişkenini kullanarak başka işlemleri yaptığını varsayalım
}

int sayi = 2;
int sayiOut;
ikiyleCarpımınıDosyaOlarakKaydet(ref sayi, out sayiOut);

//Console.WriteLine("ana scope sayi " + sayi + " sayiOut: " + sayiOut);

// Metot
MathHelper mathHelper = new MathHelper(); // referans tip
mathHelper.topla(1, 2);

#endregion

#region Diziler ve Koleksiyon
//Console.WriteLine("--------------- Diziler ve Koleksiyon ---------------");
// Referans Tip
string[] sira = new string[5]; // 5 dizinin içerisindeki SABIT yer sayısı
sira[0] = "Muhammet";
sira[2] = "Umut";

//Console.WriteLine($"sıra dizisindeki 2. indeksteki değeri: {sıra[2]}");

for (int index = 0; index < sira.Length; index++)
{
    string sıradakıKişininAdı = sira[index];

    //Console.WriteLine($"sıra dizisindeki {index}. indeksteki değeri: {sıradakıKişininAdı ?? "null"}");
}

//foreach (string sıradakıKişininAdı in sıra)
//{
//    Console.WriteLine(sıradakıKişininAdı);
//}

string[] sira2 = { "Muhammet", "Umut" }; // new string[2] // Verdiğimiz başlangıç değeri kadar array oluşturacatır.

string[] sira3 = new string[2] { "Muhammet", "Umut" };

//sira3[2] = "Hacer"; // Error

Array.Resize(ref sira3, 3);
sira3[2] = "Hacer";

string[,] cokluSira = new string[2, 2];
cokluSira[0, 0] = "Ahmet";
cokluSira[0, 1] = "Güven";

Array.Sort(sira);
Array.Fill(sira, "Boş");

bool ahmetVarMi = sira.Contains("Ahmet");

string siraString = string.Join(", ", sira);

//Console.WriteLine(siraString);

// Koleksiyon
//Console.WriteLine("-------- Koleksionlar --------");

// List
List<string> sira4 = new List<string>();

sira4.Add("Ahmet");
sira4.Add("Hacer");
sira4.Add("Emir");

sira4.Remove("Ahmet");

sira4[0] = "Furkan";

foreach (string siradakiIsim in sira4)
{
    //Console.WriteLine(siradakiIsim);
}

// Dictionary
// Anahter ve Değer eşleşmesiyle bir sözlük yapısı oluşturur.
//Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
Dictionary<string, string> sira5 = new();

sira5.Add(key: "Birinci Sıra", value: "Ahmet");

//Console.WriteLine(sira5["Birinci Sıra"]);

foreach (KeyValuePair<string, string> siradaki in sira5)
{
    //Console.WriteLine($"{siradaki.Key}, {siradaki.Value}");
}

// ArrayList
// Eleman veri tipleri dinamiktir.
ArrayList sira6 = new();

sira6.Add("Ahmet");
sira6.Add(null);
sira6.Add(15);
sira6.Add(true);

// LinkedList
LinkedList<string> sira7 = new();
sira7.AddFirst("Ahmet");
var sira7IlkKisi = sira7.First.Value;

// HashSet
// İçindeki elemanların tamamen birbirinden farklı olmak durumunda.
HashSet<string> katilimcilar = new();

katilimcilar.Add("ahmet@tobetto.com");
katilimcilar.Add("said@tobetto.com");

#endregion

#region Class
//Console.WriteLine("-------- Class -------");
// Referans Tip
// C# Nesneye Dayalı (OOP) Programlama Dili
// Class'lar Nesneler oluşturmak için bir şablondur diyebiliriz.
//Student ogrenci = new(); // Nesne // Referans
//ogrenci.FirstName = "Ahmet";
//ogrenci.LastName = "Çetinkaya"; //

////Console.WriteLine(ogrenci.FullName);

//Student ogrenci1 =
//    new()
//    {
//        FirstName = "Muhammet",
//        LastName = "Mutlo",
//        Yas = 25
//    };
//Student ogrenci2 = ogrenci1;
//ogrenci2.LastName = "Mutlu";

//Console.WriteLine($"{ogrenci1.FirstName} - {ogrenci1.LastName} {ogrenci1.Yas}");
//Console.WriteLine($"{ogrenci2.FirstName} - {ogrenci2.LastName} {ogrenci2.Yas}");
#endregion

#region Değer ve Referans Veri Tipleri

// Değer Veri Tipleri
int number1 = 10; // 10 // 30
int number2 = 20; // 20 // 10

number2 = number1; // number2: 20 -> 10

number1 = 30; // number1: 10 -> 30

Console.WriteLine(number2); // 10

// Referans Veri Tipleri
string[] cities1 = // 0x3271 (Hexidecimal 16'lık sayı sistemindeki sayı)
new string[2] { "Konya", "Istanbul" }; // Veri HEAP'daki ayrılan yere yerleştirilir, örneğin adresi 0x3271
string[] cities2 = // 0x5721
new string[2] { "Ankara", "Izmir" }; // Veri HEAP'daki ayrılan yere yerleştirilir, örneğin adresi 0x5721

cities2 = cities1; // 0x5721 -> 0x3271

//for (int i = 0; i < cities1.Length; i++)
//    cities2[i] // 0x5721
//        = cities1[i];

cities1[
    0
] // 0x3271
= "Antalya";

Console.WriteLine(string.Join(", ", cities2));

// String veri tipi
const int number3 = 10; // Sabit değere sahip değişken

//number3 = 11;

// Immutable
ImmutableArray<string> cities3 = cities1.ToImmutableArray();

//cities3[0] = "Konya";

string city1 = "Konya"; // 0x4242
string city2 = "Ankara"; // 0x0606

city2 = city1; // 0x0606 -> 0x4242
#region Temsili arka plan
ImmutableArray<char> setString(
    ImmutableArray<char> city1Array // 0x4242
)
{
    ImmutableArray<char> city1ArrayToAntalya = // 0x0707
    ImmutableArray.Create('A', 'n', 't', 'a', 'l', 'y', 'a'); // char[7]

    //Array.Resize(ref city1Array, 7);
    //for (int i = 0; i < city1Array.Length; i++)
    //{
    //    city1Array[i] = city1ArrayToAntalya[i];
    //}

    return city1ArrayToAntalya; // 0x0707
}
#endregion


city1 = "Antalya"; // 0x4242 -> 0x0707
city1 += " Güzeldir"; // 0x0707 -> 0x0807

Console.WriteLine(city2); // Konya

// StringBuilder
StringBuilder stringBuilder = new(); // 0x9284 // Allocation
stringBuilder.Append("Antalya"); // 0x9284
stringBuilder.Append(" Güzeldir"); // 0x9284

Console.WriteLine(
    stringBuilder.ToString() // 0x7292 // Allocation
);

#endregion


#region Nesneye Yönemli Programlama (OOP)
/*
 * Sınıflar ve Nesneler: Yazılım, gerçek dünyadaki ve iş sürecindeki nesnelerin özelliklerinin tanımı ve davranışlarının tanımını
 * içeren sınıflardır, ve sınıflarla üretilen nesnelerle oluşur.
 *
 * Kapsülleme (Encapsulation): özellikleri, davranışları bir arada tutmak ve bunlara olan dışardan erişimini kontrol edebilmemiz
 *
 * Katılım (Inheritance): Sınıflar arasında bir "parent-child" ve aynı zamanda is-a ilişkisi kurulması,
 * bir sınıfın özellikleri ve davranışlarını diğer sınıfa miras olarak geçebilmesi.
 * Böylece yazılımın bazı parçaları tekrar kullanılabilir.
 *
 * Çok Biçimlilik (Polymorphism): Aynı isimdeki davranışların farklı sınıflarda farklı şekilerde davranabilemsini sağlar,
 * bu da yazılımında esnekliğini artırır. Ek olarak Base Class'lar Child class'ların referanslarını tutabiliyorlar.
 *
 * Soyutlama (Abstraction): Karmaşık sistemleri basitleştirmek için ortak özellikleri belirleyerek gerçek hayatta da olduğu gibi
 * soyutlama yapılır.
 */

//Entity entity = new Entity();

User user = new User(
    firstName: "Hacer Sema",
    lastName: "Aktaş",
    nickName: "Hacer.Aktas",
    email: "hacer@example.com",
    password: "123456"
);
Entity user1 = new User(
    firstName: "Hacer Sema",
    lastName: "Aktaş",
    nickName: "Hacer.Aktas",
    email: "hacer@example.com",
    password: "123456"
);

Console.WriteLine(user.Id);
Console.WriteLine(user1.Id);

Console.WriteLine("-------");
int lastId = 0;

Student student =
    new Student(
        id: ++lastId,
        firstName: "Emir",
        lastName: "Karameke",
        nickName: "emir.karameke",
        email: "emir@outlook.com",
        password: "123456",
        phoneNumer: "123456",
        yas: 25
    );

Console.WriteLine("-------");

Instructor instructor =
    new(
        id: ++lastId,
        firstName: "Ahmet",
        lastName: "Çetinkaya",
        nickName: "ahmet.cetinkaya",
        email: "ahmet@outlook.com",
        password: "123456",
        field: "Software"
    );

instructor.Password = "654321";

Console.WriteLine("-------");
//EntityRepository entityRepository = new();

//entityRepository.UpdateEntity(user);
//entityRepository.UpdateEntity(student);
//entityRepository.UpdateEntity(instructor);

IUserDal userDal = new SqlDbUserDal();  //new InMemoryUserDal();
// Dependency Injection // IoC

userDal.Add( user );
#endregion

// Configuration.cs
//IBrandDal brandDal = new InMemoryBrandDal();
//IBrandService brandService = new BrandManager(brandDal);
// Configuration.cs

// > RentACar add brand BMW
//Brand brandToAdd = new Brand { Name = "BMW" };
//brandService.Add(brandToAdd);
