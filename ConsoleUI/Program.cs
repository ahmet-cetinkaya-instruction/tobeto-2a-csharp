#region Değişkenler

// var yil = 2023; // Derlemede aşamasında veri tipini kendisi belirliyor

// Type safety, tip güvenli
// Bellekte kaplacayacağı alanı önceden ayırmış oluyoruz hem de, alabileceği değerleri ve aralığını belirlemiş oluyoruz.

// İlkel/Değer tip
//int yil = 2023; // 32-bit ~-2.1mr - ~2.1mr // default değeri: 0 (ondalik) // 00000000 (ikilik)
//short yil = 2023; // 16-bit ~-32bin - ~32bin // default: 0
using ConsoleUI;

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

if (durum3)
    Console.WriteLine("Durum 3 Geçerli");

if (durum3)
{
    Console.WriteLine("Durum 3 Geçerli");
}
else if (durum4)
{
    Console.WriteLine("Durum 4 Geçerli");
}
else
{
    Console.WriteLine("Durumlar Geçersiz");
}

string komut = "delete";

if (komut == "add" || komut == "update")
    Console.WriteLine("Ekleme işlemi tamamlandı");
else if (komut == "delete")
    Console.WriteLine("Silme işlemi tamamlandı");

switch (komut)
{
    case "add":
    case "update":
        Console.WriteLine("Ekleme işlemi tamamlandı");
        break;

    case "delete":
        Console.WriteLine("Silme işlemi tamamlandı");
        break;

    default:
        Console.WriteLine("Geçersiz işlem.");
        break;
}


string mesaj; // default: null

if (komut == "add" || komut == "update")
    mesaj = "Ekleme işlemi tamamlandı";
else if (komut == "delete")
    mesaj = "Silme işlemi tamamlandı";

mesaj = komut == "add" ? "Ekleme işlemi tamamlandı"  // ternary opreator
    : komut == "delete" ? "Silme işlemi tamamlandı" 
    : "Geçersiz işlem";

mesaj = komut switch
{
    "add" => "Ekleme işlemi tamamlandı",
    "delete" => "Silme işlemi tamamlandı",
    _ => "Geçersiz işlem"
};

Console.WriteLine(mesaj);

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

for (int index = 0; // Döngünün en başında bir kere çalışan komutumuz
    index < 10;  // Her döngünün başında kontrol ettiğimiz koşul
    ++index // index++ // index = index + 1 // index += 1 // Her döngünün sonunda çalışan atama komutuz
    )
{
    if (index == 5)
        continue; // Bu döngü adımına devam etmeden bir sonraki döngü admına geçer

    if (index == 7)
        break; // Döngü sürecini tamamen bitirir


    //for (int i = 0; i < 10; ++i)
    //{ if (i == 0) continue;}

    Console.WriteLine(index);
}

int index2 = 0;
while(index2 < 10)
{
    //if (index2 == 5) continue; // Sonsuz döngü oluşturmuş oluruz
    if(index2 == 5)
    {
        index2 += 1;
        continue;
    }

    if (index2 == 7) break;

    Console.WriteLine(index2);

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

Console.WriteLine("Program Bitti");

#endregion

#region Metot ve Fonksiyonlar

// [Döndürülen değerin veri tipi] [METOTUN İSMİ] ( [PARAMETERLER] ) { }

void yazdir(string icerik)
{
    // ...
    Console.WriteLine(icerik); // Printer'a içeriği yazdıran fonksiyon olarak da düşünebiliriz.
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
    int baslangicSayisi, params int[] sayilar) // params sadece bir tane ve en son olacak şekilde kullanabiliriz.
{
    int toplam = baslangicSayisi;
    foreach(int sayi in sayilar)
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

    Console.WriteLine($"ikiyleCarpımınıDosyaOlarakKaydet scope sayi: {sayi}");
    //.. bu parametre değişkenini kullanarak başka işlemleri yaptığını varsayalım
}

int sayi = 2;
int sayiOut;
ikiyleCarpımınıDosyaOlarakKaydet(ref sayi, out sayiOut);

Console.WriteLine("ana scope sayi " + sayi + " sayiOut: " + sayiOut);

// Metot
MathHelper mathHelper = new MathHelper(); // referans tip
mathHelper.topla(1,2);

#endregion

#region Diziler ve Koleksiyon
Console.WriteLine("--------------- Diziler ve Koleksiyon ---------------");
// Referans Tip
string[] sıra = new string[5]; // 5 dizinin içerisindeki yer sayısı

sıra[0] = "Muhammet";
sıra[2] = "Umut";

//Console.WriteLine($"sıra dizisindeki 2. indeksteki değeri: {sıra[2]}");

for (int index = 0; index < sıra.Length; index++)
{
    string sıradakıKişininAdı = sıra[index];

    Console.WriteLine($"sıra dizisindeki {index}. indeksteki değeri: {sıradakıKişininAdı ?? "null"}");
}
//foreach (string sıradakıKişininAdı in sıra)
//{
//    Console.WriteLine(sıradakıKişininAdı);
//}
#endregion
