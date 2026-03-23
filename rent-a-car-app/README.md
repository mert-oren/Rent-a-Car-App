# McFLY Oto Kiralama Uygulaması

Bu proje, **C# Console Application** olarak geliştirilmiş basit bir **oto kiralama otomasyonudur**.  
Kullanıcı, konsol üzerinden araç ekleyebilir, araç silebilir, araç kiralayabilir, teslim alabilir, kiralama iptali yapabilir ve galerideki araçların durumunu listeleyebilir.

## Projenin Amacı

Bu uygulamanın amacı, bir oto galerisindeki araçların:

- galeride mi yoksa kirada mı olduğunu takip etmek,
- araç kiralama süreçlerini yönetmek,
- toplam araç, kiralama ve ciro bilgilerini görüntülemek,
- kullanıcıdan alınan verileri doğrulamak

gibi temel işlemleri konsol ortamında gerçekleştirmektir.

---

## Özellikler

Uygulamada aşağıdaki işlemler yapılabilir:

- **Araba Kirala**
- **Araba Teslim Al**
- **Kiradaki Arabaları Listele**
- **Galerideki Arabaları Listele**
- **Tüm Arabaları Listele**
- **Kiralama İptali**
- **Araba Ekle**
- **Araba Sil**
- **Galeri Bilgilerini Göster**

---

## Kullanılan Yapılar

Projede temel olarak şu yapılar kullanılmaktadır:

- `Program.cs`  
  Menü akışını ve kullanıcı etkileşimini yönetir.

- `Galeri` sınıfı  
  Araç listesini, kiralama işlemlerini ve galeri istatistiklerini yönetir.

- `Araba` sınıfı  
  Her bir aracın bilgilerini tutar.

- `Regex`  
  Plaka doğrulama işlemi için kullanılmıştır.

---

## Menü Yapısı

Program açıldığında aşağıdaki menü kullanıcıya gösterilir:

```text
===== McFLY OTO KIRALAMA =====

1. Araba Kirala (K)
2. Araba Teslim Al (T)
3. Kiradaki Arabalari Listele (R)
4. Galerideki Arabalari Listele (M)
5. Tüm Arabalari Listele (A)
6. Kiralama Iptali (I)
7. Araba Ekle (Y)
8. Araba Sil (S)
9. Bilgileri Göster (G)
```
