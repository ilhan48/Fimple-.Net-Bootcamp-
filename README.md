# [BANK MANAGEMENT]((https://github.com/ilhan48/Fimple.NetBootcamp))

## Proje Kazanımları

- .NET platformunu kullanarak  RESTful API tasarlama ve geliştirme konusunda pratik deneyim kazandırmak.

- Temel ve gelişmiş bankacılık işlevlerini içeren bir API oluşturarak uygulama geliştirme yeteneklerini güçlendirmek, güvenlik önlemleri konusunda bilinç kazandırmak.

- Veri tabanı yönetimi, veri doğrulama ve hizmet odaklı mimari gibi konularda öğrencilere önemli beceriler kazandırmak.

---

# Projeyi Kurma ve Çalıştırma Kılavuzu

## Kurulum

Bu bölüm, projeyi yerel geliştirme ortamınızda başarıyla kurmak ve çalıştırmak için gereken adımları detaylandırmaktadır.

### Adım 1: Repoyu Klonlama
- Projeyi yerel bilgisayarınıza klonlamak için, terminalinize şu komutu girin:
  ```
  git clone https://github.com/ilhan48/Fimple.NetBootcamp.git
  ```

### Adım 2: Geliştirme Ortamını Hazırlama
- Visual Studio veya tercih ettiğiniz IDE'yi açın.
- İndirdiğiniz projeyi IDE üzerinden açın.

### Adım 3: Bağımlılıkları Yükleme
- Projede kullanılan kütüphaneler ve bağımlılıklar için, IDE'nizdeki bağımlılık yönetimi aracını kullanarak gerekli paketleri yükleyin. (örneğin Nuget)

### Adım 4: Veritabanı Ayarlarını Yapma
- Projede Entity Framework kullanıyorsanız, veritabanını oluşturmak ve başlangıç verilerini yüklemek için migration komutlarını çalıştırın. Örnek komut:
  ```
  dotnet ef database update
  ```

## Kullanım

### Adım 1: API'yi Başlatma
- Geliştirme ortamınızda, API servisini başlatmak için gerekli komutları çalıştırın.
  ```
  docker-compose up
  ```

### Adım 2: API Dokümantasyonunu İnceleme
- API endpoint'lerini ve kullanımlarını anlamak için Swagger ya da benzeri bir API belgelendirme aracını kullanın.

### Adım 3: API İle Etkileşime Geçme
- API'nizle etkileşimde bulunmak için, belirtilen endpoint'lere uygun HTTP istekleri gönderin.

---
